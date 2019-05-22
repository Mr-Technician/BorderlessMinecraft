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
        private const uint styleCache = 382664704; //caches the default window style

        public const int xDefaultRes = 900; //default xRes for restored window
        public const int yDefaultRes = 520; //default yRes for restored window

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
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLongPtr(IntPtr hWnd, int nIndex, uint dwNewLong); //sets window style
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); //sets window position
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd); //sets the window to the foreground
        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hWnd, string title); //changes the window title

        private static uint SW_RESTORE = 0x09; //const for restoreWindow
        private static uint SW_MINIMIZE = 0x06;

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
        public static int minimizeWindow(IntPtr handle)
        {
            return ShowWindow(handle, SW_MINIMIZE); //minimizes the window
        }

        public static int setBorderless(IntPtr handle)
        {
            long currentStyle = GetWindowLongPtr(handle, GWL_STYLE); //gets the current style
            currentStyle &= ~(WS_BORDER | WS_DLGFRAME | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU); //sets the style elements to be removed
            return SetWindowLongPtr(handle, GWL_STYLE, (uint)currentStyle); //removes the style elements
        }

        public static int undoBorderless(IntPtr handle)
        {
            //return SetWindowLongPtr(handle, GWL_STYLE, (uint)styleCache); //adds the style elements
            return SetWindowLongPtr(handle, GWL_STYLE, styleCache); //adds the style elements
        }

        public static bool setPos(IntPtr handle, int xPos, int yPos, int xRes, int yRes)
        {
            return SetWindowPos(handle, handle, xPos, yPos, xRes, yRes, SWP_NOZORDER); //sets the minecraft window to the 
        }

        public static bool setForeground(IntPtr handle)
        {
            return SetForegroundWindow(handle); //places the Minecraft window at the foreground
        }

        public static bool setTitle(IntPtr handle, string title)
        {
            return SetWindowText(handle, title); //sets the window title
        }

        //helper methods

        public static int getScreenRezx()
        {
            return Screen.PrimaryScreen.Bounds.Width; //returns screen width
        }

        public static int getScreenRezy()
        {
            return Screen.PrimaryScreen.Bounds.Height; //returns screen height
        }

        public static int getCenterx()
        {
            return (Screen.PrimaryScreen.Bounds.Width / 2) - (xDefaultRes / 2); //gets the x coordinate to center the window
        }

        public static int getCentery()
        {
            return (Screen.PrimaryScreen.Bounds.Height / 2) - (yDefaultRes / 2); //gets the x coordinate to center the window
        }

        //debug methods

        public static int getCurrentStyle(IntPtr handle)
        {
            return GetWindowLongPtr(handle, GWL_STYLE); //gets the current style
        }
    }
}
