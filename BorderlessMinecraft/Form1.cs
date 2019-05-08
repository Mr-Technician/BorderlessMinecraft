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
        //ArrayList minecraftProcesses = new ArrayList();
        Process[] minecraftProcesses = new Process[10]; //initializes an array of processess
        public Form1()
        {
            InitializeComponent();
            addProcesses();
            //button1.Enabled = false; //disable the button by default
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void addProcesses() //method to add processes to list
        {
            listBox1.Items.Clear();
            int i = 0;
            foreach (Process proc in Program.getProcesses())
            {
                listBox1.Items.Add(proc.MainWindowTitle); //adds process title to list
                minecraftProcesses[i] = proc; //adds the processes to the arry
                i++;
            }
        }

        private void debugInstructionsLabel_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Process[] processess = minecraftProcesses.ToArray();
            Process process = minecraftProcesses[listBox1.SelectedIndex];
            Program.setBorderless(process.MainWindowHandle);
            Program.setPos(process.MainWindowHandle);
            Program.setForeground(process.MainWindowHandle);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            addProcesses();
        }
    }
}
