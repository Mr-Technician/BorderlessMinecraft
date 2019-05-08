using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace BorderlessMinecraft
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static ArrayList getProcesses()
        {
            Process[] allProcesses = Process.GetProcesses(); //gets an array of all system processes
            ArrayList processes = new ArrayList();
            foreach (Process proc in allProcesses)
            {
                if (proc.MainWindowTitle.Contains("Minecraft") && proc.ProcessName == "javaw") //checks for Minecraft in the title and the java process
                    processes.Add(proc);
            }
            return processes;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void setBorderless(IntPtr handle)
        {

        }

        public static void setPos(IntPtr handle)
        {

        }

        public static bool setForeground(IntPtr handle)
        {
            return SetForegroundWindow(handle); //Places the Minecraft window at the foreground
        }

    }
}
