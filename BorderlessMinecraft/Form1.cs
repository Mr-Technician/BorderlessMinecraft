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
        public Form1()
        {
            InitializeComponent();
            addProcesses();
            checkBox1.Enabled = false;
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

            minecraftProcesses = Program.getProcesses(); //gets the array list
            foreach (Process proc in minecraftProcesses)
            {
                listBox1.Items.Add(proc.MainWindowTitle); //adds process title to list
            }
        }

        private void debugInstructionsLabel_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr handle = minecraftProcesses[listBox1.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            Program.restoreWindow(handle);
            Program.setBorderless(handle);
            Program.setPos(handle);
            Program.setForeground(handle);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            addProcesses();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1) //checks if something is selected
            {
                button1.Enabled = true; //enable the button when a session is seleced
                button3.Enabled = true; //enable the button when a session is seleced
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IntPtr handle = minecraftProcesses[listBox1.SelectedIndex].MainWindowHandle; //gets the minecraft process by index, and then its handle
            string title = minecraftProcesses[listBox1.SelectedIndex].MainWindowTitle; //gets the minecraft process by index, and then its title
            Program.setTitle(handle, title);
            addProcesses(); //after rename, refresh the list
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) //if advanced mode is on, make visible
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
    }
}
