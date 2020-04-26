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

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace BorderlessMinecraft
{
    public partial class Form1 : Form
    {
        Process[] minecraftProcesses; //initializes an array of processess
        List<int> renamedProcesses = new List<int>(); //PIDs that are renamed

        public Form1()
        {
            InitializeComponent();
            addProcesses();

            //create the ToolTip for advanced mode hover
            ToolTip toolTip1 = new ToolTip();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(this.checkBox1, "Enables the use of custom positioning and sizing.");

            //
            ToolTip toolTip2 = new ToolTip();

            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;

            toolTip2.SetToolTip(this.checkBox2, "Shows the taskbar when in borderless mode. Ignored if custom height is set.");

            ToolTip toolTip3 = new ToolTip();

            toolTip3.AutoPopDelay = 5000;
            toolTip3.InitialDelay = 1;
            toolTip3.ReshowDelay = 500;
            toolTip3.ShowAlways = true;

            toolTip3.SetToolTip(this.checkBox3, "Shows all Minecraft Java clients. This option will also show other Java apps that are currently running.");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void addProcesses() //method to add processes to list
        {
            listBox1.Items.Clear(); //clear the listbox on refresh
            button1.Enabled = false; //disable the button by default
            button3.Enabled = false; //disable the button by default
            button4.Enabled = false; //disable the button by default

            if (checkBox3.Checked) //if the checkbox is checked, no title filtering will occur
            {
                minecraftProcesses = Program.getProcesses(renamedProcesses);
            }
            else //if not, filter titles by the word "minecraft"
            {
                minecraftProcesses = Program.getProcesses(renamedProcesses, "Minecraft");
            }

            foreach (Process proc in minecraftProcesses)
            {
                listBox1.Items.Add(proc.MainWindowTitle); //adds process title to list
            }
        }

        private void debugInstructionsLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e) //go borderless button
        {
            //default values, changed by advanced mode
            int xPos = 0;
            int yPos = 0;
            int xRes = Program.getScreenRezx();
            int yRes = Program.getScreenRezy();

            if (checkBox2.Checked)
            {
                yRes = Program.getWorkingAreaHeight(); //ignored if advanced mode is enabled
            }
            
            //advanced mode checks
            if (textBox1.Text != "")
            {
                try
                {
                    xPos = Convert.ToInt32(textBox1.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    xPos = 0;
                }
            }
            if (textBox2.Text != "")
            {
                try
                {
                    yPos = Convert.ToInt32(textBox2.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    yPos = 0;
                }
            }
            if (textBox3.Text != "")
            {
                try
                {
                    xRes = Convert.ToInt32(textBox3.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    xRes = Program.getScreenRezx();
                }
            }
            if (textBox4.Text != "")
            {
                try
                {
                    yRes = Convert.ToInt32(textBox4.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    yRes = Program.getScreenRezy();
                }
            }
            IntPtr handle = minecraftProcesses[listBox1.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            Program.restoreWindow(handle);
            Program.setBorderless(handle);
            Program.setPos(handle, xPos, yPos, xRes, yRes);
            Program.setForeground(handle);
            //debugInstructionsLabel.Text = Program.getCurrentStyle(handle).ToString();
        }

        private void button2_Click(object sender, EventArgs e) //refresh button
        {
            addProcesses();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1) //checks if something is selected
            {
                button1.Enabled = true; //enable the button when a session is seleced
                button3.Enabled = true; //enable the button when a session is seleced
                button4.Enabled = true; //enable the button when a session is seleced
            }
        }

        private void button3_Click(object sender, EventArgs e) //edit title button
        {
            IntPtr handle = minecraftProcesses[listBox1.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            int PID = minecraftProcesses[listBox1.SelectedIndex].Id;
            string currentTitle = minecraftProcesses[listBox1.SelectedIndex].MainWindowTitle; //gets the minecraft process by index, and then its title
            string title;
            if (textBox5.Text != "") //if the textbox has content, use for title
            {
                title = textBox5.Text;

            }
            else //if the textbox is empty, use default
            {
                title = currentTitle + " (Second Account)";
            }
            Program.setTitle(handle, title);
            if (!renamedProcesses.Contains(PID)) //if the renamed handle is not currently stored, add it. This allows borderless minecraft to detect windows that have been renamed
            {
                renamedProcesses.Add(PID);
            }

            addProcesses(); //after rename, refresh the list
            textBox5.Text = ""; //reset text
        }

        private void button4_Click(object sender, EventArgs e) //restore window button
        {
            //default values, changed by advanced mode
            int xPos = Program.getCenterx();
            int yPos = Program.getCentery();
            int xRes = Program.xDefaultRes;
            int yRes = Program.yDefaultRes;

            if (textBox1.Text != "")
            {
                try
                {
                    xPos = Convert.ToInt32(textBox1.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    xPos = Program.getCenterx();
                }
            }
            if (textBox2.Text != "")
            {
                try
                {
                    yPos = Convert.ToInt32(textBox2.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    yPos = Program.getCentery();
                }
            }
            if (textBox3.Text != "")
            {
                try
                {
                    xRes = Convert.ToInt32(textBox3.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    xRes = Program.xDefaultRes;
                }
            }
            if (textBox4.Text != "")
            {
                try
                {
                    yRes = Convert.ToInt32(textBox4.Text); //if there is content in the textbox, an attempt is made to assign it to variable
                }
                catch {
                    yRes = Program.yDefaultRes;
                }
            }

            IntPtr handle = minecraftProcesses[listBox1.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            Program.restoreWindow(handle);
            Program.undoBorderless(handle);
            Program.setPos(handle, xPos, yPos, xRes, yRes);
            Program.setForeground(handle);
            //debugInstructionsLabel.Text = Program.getCurrentStyle(handle).ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) //if advanced mode is on, make visible
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            addProcesses(); //refresh the process list when changing the filter option
        }
    }
}
