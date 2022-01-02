//Copyright (C) 2019 Riley Nielsen

//This file is part of Borderless Minecraft.

//   Borderless Minecraft is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    Borderless Minecraft is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with Borderless Minecraft.  If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using BorderlessMinecraft.Configuration;
using System.Management;
using BorderlessMinecraft.Processes;
using static BorderlessMinecraft.DLLInterop; //includ the static DLL Interop class

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace BorderlessMinecraft
{
    internal partial class MainForm : Form
    {
        int? AutoBorderlessPID; //the process id of an automatically set borderless window
        Process[] minecraftProcesses; //initializes an array of processess
        List<int> renamedProcesses = new List<int>(); //PIDs that are renamed
        Config Config { get; } = new Config();
        ProcessMonitor ProcessMonitor { get; }

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var parameters = base.CreateParams;
        //        parameters.ExStyle |= 0x80; //we need to hide the 
        //        return parameters;
        //    }
        //}

        internal MainForm()
        {
            InitializeComponent();
            AddProcesses();

            //create the ToolTip for advanced mode hover
            ToolTip advancedToolTip = new ToolTip();

            advancedToolTip.AutoPopDelay = 5000;
            advancedToolTip.InitialDelay = 1;
            advancedToolTip.ReshowDelay = 500;
            advancedToolTip.ShowAlways = true;

            advancedToolTip.SetToolTip(this.advancedCheckBox, "Enables the use of custom positioning and sizing.");

            startOnBootMenuItem.Checked = Config.StartOnBoot;
            startMinimizedMenuItem.Checked = Config.StartMinimized;
            minimizeToTrayMenuItem.Checked = Config.MinimizeToTray;
            automaticBorderlessMenuItem.Checked = Config.AutomaticBorderless;
            preserveTaskbarMenuItem.Checked = Config.PreserveTaskBar;
            showAllClientsMenuItem.Checked = Config.ShowAllClients;

            ProcessMonitor = new ProcessMonitor(); //create the process monitor
            ProcessMonitor.OnJavaAppStarted += ProcessMonitor_OnJavaAppStarted; //attach events
            ProcessMonitor.OnJavaAppStopped += ProcessMonitor_OnJavaAppStopped;
            ProcessMonitor.OnProcessShouldExit += ProcessMonitor_OnProcessShouldExit;
            if (Config.AutomaticBorderless) //start listening if auto borderless is enabled
                ProcessMonitor.Start(); //this call must occur after attaching the OnProcessShouldExit event

            //set up event handlers
            Resize += MainForm_Resize1;

            TrayIcon.MouseClick += TrayIcon_Click;
            Exit.Click += Exit_Click;

            startOnBootMenuItem.CheckedChanged += StartOnBootItem_CheckedChanged;
            startMinimizedMenuItem.CheckedChanged += StartMinimizedItem_CheckedChanged;
            minimizeToTrayMenuItem.CheckedChanged += MinimizeToTrayItem_CheckedChanged;
            automaticBorderlessMenuItem.CheckedChanged += AutoBorderlessItem_CheckedChanged;
            preserveTaskbarMenuItem.CheckedChanged += PreserveTaskBarItem_CheckedChanged;
            showAllClientsMenuItem.CheckedChanged += ShowAllClientsItem_CheckedChanged;

            if (Config.StartMinimized && IsAutoStarted()) //ensure the app has autostarted and minimize to tray is enabled. This ensures normal starts will not be minimized
            {
                WindowState = FormWindowState.Minimized;
                Hide(); //hide the app in the tray
                ShowInTaskbar = false; //When hiding on startup, we need to explicitly set ShowInTaskbar to false
                TrayIcon.Visible = true;
            }
        }

        private void ProcessMonitor_OnProcessShouldExit() => Environment.Exit(0);

        private async void ProcessMonitor_OnJavaAppStarted(int pid)
        {
            if (!AutoBorderlessPID.HasValue) //if no window has been made borderless, make the java app that just opened borderless
            {
                AutoBorderlessPID = pid; //store the pid
                IntPtr handle = default;
                bool HandleFound = false;
                Process process = null;
                while (!HandleFound)
                {
                    process = Process.GetProcessById(AutoBorderlessPID.Value); //get the process by ID
                    if (process.MainWindowHandle != default) //check if the handle exists
                    {
                        HandleFound = true;
                        handle = process.MainWindowHandle; //if yes, save the handle
                    }
                    await Task.Delay(250); //if no, delay 250 ms
                }

                if (process.MainWindowTitle.Contains("Minecraft")) //for now just check the title with a magic string. In the future this will allow better control. Also note that we have already filtered out any non-java process
                    GoBorderless(handle, 0, 0, GetScreenRezx(), GetScreenRezy()); //go borderless
            }
            AddProcessesThreadSafe();
        }

        private void ProcessMonitor_OnJavaAppStopped(int pid)
        {
            if (AutoBorderlessPID.HasValue) //if the app that was made borderless automatically has
            {
                AutoBorderlessPID = null; //reset the pid to null
            }
            AddProcessesThreadSafe();
        }

        private void TrayIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //show the window when the tray icon is left clicked
            {
                Show();
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
            }
        }

        private void StartOnBootItem_CheckedChanged(object sender, EventArgs e) => Config.StartOnBoot = ((ToolStripMenuItem)sender).Checked;
        private void StartMinimizedItem_CheckedChanged(object sender, EventArgs e) => Config.StartMinimized = ((ToolStripMenuItem)sender).Checked;
        private void MinimizeToTrayItem_CheckedChanged(object sender, EventArgs e) => Config.MinimizeToTray = ((ToolStripMenuItem)sender).Checked;
        private void AutoBorderlessItem_CheckedChanged(object sender, EventArgs e)
        {
            var state = ((ToolStripMenuItem)sender).Checked;
            Config.AutomaticBorderless = state;
            if (state)
                ProcessMonitor.Start();
            if (!state) //if the mode is disabled, stop the process monitor
                ProcessMonitor.Stop();
        }
        private void PreserveTaskBarItem_CheckedChanged(object sender, EventArgs e) => Config.PreserveTaskBar = ((ToolStripMenuItem)sender).Checked;
        private void ShowAllClientsItem_CheckedChanged(object sender, EventArgs e) => Config.ShowAllClients = ((ToolStripMenuItem)sender).Checked;

        private void Exit_Click(object sender, EventArgs e) => Close();

        private void AddProcesses() //method to add processes to list
        {
            processesListBox.Items.Clear(); //clear the listbox on refresh
            goBorderlessButton.Enabled = false; //disable the button by default
            setTitleButton.Enabled = false; //disable the button by default
            restoreWindowButton.Enabled = false; //disable the button by default

            if (Config.ShowAllClients) //if the checkbox is checked, no title filtering will occur
            {
                minecraftProcesses = GetProcesses(renamedProcesses);
            }
            else //if not, filter titles by the word "minecraft"
            {
                minecraftProcesses = GetProcesses(renamedProcesses, "Minecraft");
            }

            foreach (Process proc in minecraftProcesses)
            {
                processesListBox.Items.Add(proc.MainWindowTitle); //adds process title to list
            }
        }

        /// <summary>
        /// Calls AddProcesses internally after syncing back to the UI thread
        /// </summary>
        private void AddProcessesThreadSafe()
        {
            Invoke(new MethodInvoker(delegate () //sync back to UI thread https://stackoverflow.com/a/6691629/14024210
            {
                AddProcesses();
            }));
        }

        private void debugInstructionsLabel_Click(object sender, EventArgs e)
        {

        }

        private void goBorderlessButton_Click(object sender, EventArgs e) //go borderless button
        {
            //default values, changed by advanced mode
            int xPos = 0;
            int yPos = 0;
            int xRes = GetScreenRezx();
            int yRes = GetScreenRezy();

            if (Config.PreserveTaskBar)
            {
                yRes = GetWorkingAreaHeight(); //ignored if advanced mode is enabled
            }

            //advanced mode checks
            if (xPosTextBox.Text != "" && int.TryParse(xPosTextBox.Text, out int parsed))
                xPos = parsed;
            if (yPosTextBox.Text != "" && int.TryParse(yPosTextBox.Text, out int parsed2))
                yPos = parsed2;
            if (widthTextBox.Text != "" && int.TryParse(widthTextBox.Text, out int parsed3))
                xRes = parsed3;
            if (heightTextBox.Text != "" && int.TryParse(heightTextBox.Text, out int parsed4))
                yRes = parsed4;
            IntPtr handle = minecraftProcesses[processesListBox.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            int pid = minecraftProcesses[processesListBox.SelectedIndex].Id; //get the minecraft process by id
            GoBorderless(handle, xPos, yPos, xRes, yRes);
            if (!AutoBorderlessPID.HasValue) //save this pid to effectively disable auto borderless. Otherwise a second instance of MC would also go borderless
                AutoBorderlessPID = pid;
        }

        private void refreshButton_Click(object sender, EventArgs e) //refresh button
        {
            AddProcesses();
        }

        private void processesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (processesListBox.SelectedIndex > -1) //checks if something is selected
            {
                goBorderlessButton.Enabled = true; //enable the button when a session is seleced
                setTitleButton.Enabled = true; //enable the button when a session is seleced
                restoreWindowButton.Enabled = true; //enable the button when a session is seleced
            }
        }

        private void setTitleButton_Click(object sender, EventArgs e) //edit title button
        {
            IntPtr handle = minecraftProcesses[processesListBox.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            int PID = minecraftProcesses[processesListBox.SelectedIndex].Id;
            string currentTitle = minecraftProcesses[processesListBox.SelectedIndex].MainWindowTitle; //gets the minecraft process by index, and then its title
            string title;
            if (newTitleTextBox.Text != "") //if the textbox has content, use for title
            {
                title = newTitleTextBox.Text;

            }
            else //if the textbox is empty, use default
            {
                title = currentTitle + " (Second Account)";
            }
            SetTitle(handle, title);
            if (!renamedProcesses.Contains(PID)) //if the renamed handle is not currently stored, add it. This allows borderless minecraft to detect windows that have been renamed
            {
                renamedProcesses.Add(PID);
            }

            AddProcesses(); //after rename, refresh the list
            newTitleTextBox.Text = ""; //reset text
        }

        private void restoreWindowButton_Click(object sender, EventArgs e) //restore window button
        {
            //default values, changed by advanced mode
            int xPos = GetCenterx();
            int yPos = GetCentery();
            int xRes = xDefaultRes;
            int yRes = yDefaultRes;

            if (xPosTextBox.Text != "")
            {
                try
                {
                    xPos = Convert.ToInt32(xPosTextBox.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch
                {
                    xPos = GetCenterx();
                }
            }
            if (yPosTextBox.Text != "")
            {
                try
                {
                    yPos = Convert.ToInt32(yPosTextBox.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch
                {
                    yPos = GetCentery();
                }
            }
            if (widthTextBox.Text != "")
            {
                try
                {
                    xRes = Convert.ToInt32(widthTextBox.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch
                {
                    xRes = xDefaultRes;
                }
            }
            if (heightTextBox.Text != "")
            {
                try
                {
                    yRes = Convert.ToInt32(heightTextBox.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch
                {
                    yRes = yDefaultRes;
                }
            }

            IntPtr handle = minecraftProcesses[processesListBox.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            int pid = minecraftProcesses[processesListBox.SelectedIndex].Id; //get the pid
            RestoreWindow(handle);
            UndoBorderless(handle);
            SetPos(handle, xPos, yPos, xRes, yRes);
            SetForeground(handle);
            if (AutoBorderlessPID == pid) //if the pid of the restored window matches our saved pid, set the saved pid to null
                AutoBorderlessPID = null;
        }

        private void advancedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (advancedCheckBox.Checked) //if advanced mode is on, make visible
            {
                xPosTextBox.Visible = true;
                yPosTextBox.Visible = true;
                widthTextBox.Visible = true;
                heightTextBox.Visible = true;
                xPosLabel.Visible = true;
                yPosLabel.Visible = true;
                widthLabel.Visible = true;
                heightLabel.Visible = true;
            }
            else
            {
                xPosTextBox.Text = "";
                yPosTextBox.Text = "";
                widthTextBox.Text = "";
                heightTextBox.Text = "";
                xPosTextBox.Visible = false;
                yPosTextBox.Visible = false;
                widthTextBox.Visible = false;
                heightTextBox.Visible = false;
                xPosLabel.Visible = false;
                yPosLabel.Visible = false;
                widthLabel.Visible = false;
                heightLabel.Visible = false;
            }
        }

        private void xPosLabel_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            AddProcesses(); //refresh the process list when changing the filter option
        }

        private void MainForm_Resize1(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (Config.MinimizeToTray && WindowState == FormWindowState.Minimized)
            {
                Hide();
                TrayIcon.Visible = true;
            }
            else
            {
                TrayIcon.Visible = false; //we don't want the tray icon to show when window is normal
            }
        }

        /// <summary>
        /// Returns true if the -autoStart argument is included
        /// </summary>
        /// <returns></returns>
        private static bool IsAutoStarted()
        {
            string[] args = Environment.GetCommandLineArgs();
            return args.Contains("-autoStart");
        }

        private static Process[] GetProcesses(List<int> processIDs, string startsWith = "")
        {
            Process[] allProcesses = Process.GetProcesses(); //gets an array of all system processes
            List<Process> processes = new List<Process>();
            foreach (Process proc in allProcesses)
            {
                if (proc.MainWindowTitle.StartsWith(startsWith) && proc.ProcessName.Contains("java") && !string.IsNullOrWhiteSpace(proc.MainWindowTitle) && !processIDs.Contains(proc.Id)) //checks the java process and non empty titles OR its handle matches
                    processes.Add(proc);
            }

            foreach (int PID in processIDs)
            {
                try
                {
                    processes.Add(Process.GetProcessById(PID)); //adds each process by ID
                }
                catch (ArgumentException) { }
            }
            return processes.Distinct().ToArray(); //converts dynamic arraylist to static array
        }
    }
}
