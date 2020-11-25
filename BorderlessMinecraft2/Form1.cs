using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessMinecraft2
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Stores a reference to the main object.
        /// </summary>
        private BorderlessMinecraft borderlessMinecraft;
        /// <summary>
        /// The currently selected handle. Gets a reference from the currently selected process.
        /// </summary>
        private IntPtr SelectedHandle { get => process == null ? IntPtr.Zero : process.MainWindowHandle; }
        /// <summary>
        /// The currently selected process.
        /// </summary>
        private Process process;
        /// <summary>
        /// If true, the working height will be used instead of the screen height
        /// </summary>
        private bool PreserveTaskbar;

        public Form1()
        {
            KeyPreview = true; //required for key listening
            InitializeComponent();
            AdvancedModePanel.Visible = false; //hide controls by default

            ToolTip toolTip = new ToolTip //create tooltip
            {
                AutoPopDelay = 5000,
                InitialDelay = 1,
                ReshowDelay = 500,
                ShowAlways = true
            };

            toolTip.SetToolTip(AdvancedModeCheckBox, "Enables the use of custom positioning and sizing.");
            toolTip.SetToolTip(PreserveTaskbarCheckBox, "Shows the taskbar when in borderless mode. Ignored if custom height is set.");

            borderlessMinecraft = new BorderlessMinecraft(); //initialize object
            RefreshList(); //refresh list on form creation
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //test copied from https://stackoverflow.com/a/400325/14024210
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                //MessageBox.Show("What the Ctrl+F?");
                ApplyTransforms();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.Up))
            {
                ProcessInterop.SetPosition(SelectedHandle, 0, 0, ProcessInterop.GetScreenResX(), ProcessInterop.GetWorkingAreaHeight() / 2, false);
            }
            else if (keyData == (Keys.Control | Keys.Left))
            {
                ProcessInterop.SetPosition(SelectedHandle, 0, 0, ProcessInterop.GetScreenResX() / 2, ProcessInterop.GetWorkingAreaHeight(), false);
            }
            else if (keyData == (Keys.Control | Keys.Right))
            {
                ProcessInterop.SetPosition(SelectedHandle, ProcessInterop.GetScreenResX() / 2, 0, ProcessInterop.GetScreenResX() / 2, ProcessInterop.GetWorkingAreaHeight(), false);
            }
            else if (keyData == (Keys.Control | Keys.Down))
            {
                ProcessInterop.SetPosition(SelectedHandle, 0, ProcessInterop.GetWorkingAreaHeight() / 2, ProcessInterop.GetScreenResX(), ProcessInterop.GetWorkingAreaHeight() / 2, false);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Transforms the selected window
        /// </summary>
        private void ApplyTransforms()
        {
            ProcessInterop.SetPosition(SelectedHandle, 0, 0, ProcessInterop.GetScreenResX() / 2, ProcessInterop.GetWorkingAreaHeight(), false);
        }

        /// <summary>
        /// Refreshes the contents of the Process listbox
        /// </summary>
        private void RefreshList()
        {
            var processes = borderlessMinecraft.GetProcesses(); //get the processes
            process = null; //reset the selected process on refresh
            ProcessList.Items.Clear(); //clear all items
            foreach (var process in processes) //add each process to the list box
            {
                ProcessList.Items.Add(new ProcessUI(process)); //switch to something other than ID. Maybe define new object with toString for rendering that stores the handle
            }
        }

        private void ProcessList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListBox listbox = sender as ListBox;
                ProcessUI processUI = listbox.SelectedItem as ProcessUI;
                process = processUI.GetProcess(); //save the selected process on click
            }
            catch (NullReferenceException)
            {
                //null if no item selected
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void BorderlessButton_Click(object sender, EventArgs e)
        {
            int xPosition = 0;
            int yPosition = 0;
            int width = ProcessInterop.GetScreenResX();
            int height = PreserveTaskbar ? ProcessInterop.GetWorkingAreaHeight() : ProcessInterop.GetScreenResY(); //use the working area height instead

            //try to get values from the textboxes, catching exceptions as needed
            try
            {
                xPosition = Convert.ToInt32(CustomXPosition.Text);
            }
            catch (FormatException) { }
            catch (OverflowException) { }
            try
            {
                yPosition = Convert.ToInt32(CustomYPosition.Text);
            }
            catch (FormatException) { }
            catch (OverflowException) { }
            try
            {
                width = Convert.ToInt32(CustomXSize.Text);
            }
            catch (FormatException) { }
            catch (OverflowException) { }
            try
            {
                height = Convert.ToInt32(CustomYSize.Text);
            }
            catch (FormatException) { }
            catch (OverflowException) { }
            width = width < 0 ? -width : width; //if the width is less than 0, invert it
            height = height < 0 ? -height : height; //if the width is less than 0, invert it

            ProcessInterop.RestoreWindow(SelectedHandle);
            ProcessInterop.SetBorderless(SelectedHandle);
            ProcessInterop.SetPosition(SelectedHandle, xPosition, yPosition, width, height);
            ProcessInterop.SetForeground(SelectedHandle);
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            ProcessInterop.RestoreWindow(SelectedHandle);
            ProcessInterop.UndoBorderless(SelectedHandle);
            ProcessInterop.SetPosition(SelectedHandle, ProcessInterop.GetCenterX(), ProcessInterop.GetCenterY(), ProcessInterop.xDefaultRes, ProcessInterop.yDefaultRes);
        }

        private void TitleButton_Click(object sender, EventArgs e)
        {
            if (process == null) return; //null check
            string newTitle = process.MainWindowTitle + TitleTextBox.Text; //keep the old title and add the textbox contents
            ProcessInterop.SetTitle(SelectedHandle, newTitle);
            RefreshList(); //refresh after setting new title
        }

        private void PreserveTaskbarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreserveTaskbar = (sender as CheckBox).Checked;
        }

        private void AdvancedModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AdvancedModePanel.Visible = (sender as CheckBox).Checked; //toggle visibiity of advanced mode buttons
        }

        private void ApplyTransform_Click(object sender, EventArgs e)
        {
            ApplyTransforms();
        }
    }
}
