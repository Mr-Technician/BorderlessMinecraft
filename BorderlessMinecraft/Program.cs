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

        public static Process[] getProcesses()
        {
            Process[] allProcesses = Process.GetProcesses(); //gets an array of all system processes
            ArrayList processes = new ArrayList();
            foreach (Process proc in allProcesses)
            {
                if (proc.MainWindowTitle.Contains("Minecraft") && proc.ProcessName == "javaw") //checks for Minecraft in the title and the java process
                    processes.Add(proc);
            }
            return processes.ToArray(typeof(Process)) as Process[]; //converts dynamic arraylist to static array
        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg); //restores the window
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex); //gets window style
        [DllImport("user32.dll", EntryPoint ="SetWindowLong")]
        private static extern int SetWindowLongPtr(IntPtr hWnd, int nIndex, uint dwNewLong); //sets window style
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); //sets window position
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd); //sets the window to the foreground
        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hWnd, string title); //changes the window title

        private static uint SW_RESTORE = 0x09; //const for restoreWindow

        //sets the necessary constants for setBorderless
        private static int GWL_STYLE = -16;
        private static int WS_BORDER = 0x00800000;
        private static int WS_THICKFRAME = 0x00040000;
        private static int WS_MINIMIZEBOX = 0x00020000;
        private static int WS_MAXIMIZEBOX = 0x00010000;
        private static int WS_SYSMENU = 0x00800000;
        private static int WS_DLGFRAME = 0x00400000;

        private static uint SWP_NOZORDER = 0x0004; //const for setPos

        public static int restoreWindow(IntPtr handle)
        {
            return ShowWindow(handle, SW_RESTORE); //restores the window to a normal state
        }

        public static int setBorderless(IntPtr handle)
        {
            long currentStyle = GetWindowLongPtr(handle, GWL_STYLE); //gets the current style
            currentStyle &= ~(WS_BORDER | WS_DLGFRAME | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU); //sets the style elements to be removed
            return SetWindowLongPtr(handle, GWL_STYLE, (uint)currentStyle); //removes the style elements
        }

        public static bool setPos(IntPtr handle)
        {
            return SetWindowPos(handle, handle, 0, 0, getScreenRezx(), getScreenRezy(), SWP_NOZORDER); //sets the minecraft window to the 
        }

        public static bool setForeground(IntPtr handle)
        {
            return SetForegroundWindow(handle); //Places the Minecraft window at the foreground
        }   

        public static bool setTitle(IntPtr handle, string title)
        {
            return SetWindowText(handle, title + " (Second Account)");
        }

        //helper methods

        private static int getScreenRezx()
        {
            return Screen.PrimaryScreen.Bounds.Width; //returns screen width
        }
        private static int getScreenRezy()
        {
            return Screen.PrimaryScreen.Bounds.Height; //returns screen height
        }
    }
}
