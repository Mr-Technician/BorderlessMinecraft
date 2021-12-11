using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessMinecraft
{
    static class DLLInterop
    {
        private const uint styleCache = 382664704; //caches the default window style

        internal const int xDefaultRes = 900; //default xRes for restored window
        internal const int yDefaultRes = 520; //default yRes for restored window

        [DllImport("shell32.dll")]
        internal static extern bool IsUserAnAdmin(); //checks if the current user is an admin
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
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle); //get the window's size

        private static readonly uint SW_RESTORE = 0x09; //const for restoreWindow
        private static readonly uint SW_MINIMIZE = 0x06;

        //sets the necessary constants for setBorderless
        private static readonly int GWL_STYLE = -16;
        private static readonly int WS_BORDER = 0x00800000;
        private static readonly int WS_THICKFRAME = 0x00040000;
        private static readonly int WS_MINIMIZEBOX = 0x00020000;
        private static readonly int WS_MAXIMIZEBOX = 0x00010000;
        private static readonly int WS_SYSMENU = 0x00800000;
        private static readonly int WS_DLGFRAME = 0x00400000;

        private static readonly uint SWP_NOZORDER = 0x0004; //const for setPos

        /// <summary>
        /// A helper method that calls other methods internally
        /// </summary>ram>
        /// <returns></returns>
        internal static void GoBorderless(IntPtr handle, int xPos, int yPos, int xRes, int yRes)
        {
            if (WindowIsFullScreen(handle))
                return; // if the current window is fullsreen, return
            RestoreWindow(handle);
            SetBorderless(handle);
            SetPos(handle, xPos, yPos, xRes, yRes);

            SetForeground(handle);
        }

        internal static int RestoreWindow(IntPtr handle)
        {
            return ShowWindow(handle, SW_RESTORE); //restores the window to a normal state
        }

        internal static int MinimizeWindow(IntPtr handle)
        {
            return ShowWindow(handle, SW_MINIMIZE); //minimizes the window
        }

        internal static int SetBorderless(IntPtr handle)
        {
            long currentStyle = GetWindowLongPtr(handle, GWL_STYLE); //gets the current style
            currentStyle &= ~(WS_BORDER | WS_DLGFRAME | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU); //sets the style elements to be removed
            return SetWindowLongPtr(handle, GWL_STYLE, (uint)currentStyle); //removes the style elements
        }

        internal static int UndoBorderless(IntPtr handle)
        {
            //return SetWindowLongPtr(handle, GWL_STYLE, (uint)styleCache); //adds the style elements
            return SetWindowLongPtr(handle, GWL_STYLE, styleCache); //adds the style elements
        }

        internal static bool SetPos(IntPtr handle, int xPos, int yPos, int xRes, int yRes)
        {
            return SetWindowPos(handle, handle, xPos, yPos, xRes, yRes, SWP_NOZORDER); //sets the minecraft window to the 
        }

        internal static bool SetForeground(IntPtr handle)
        {
            return SetForegroundWindow(handle); //places the Minecraft window at the foreground
        }

        internal static bool SetTitle(IntPtr handle, string title)
        {
            return SetWindowText(handle, title); //sets the window title
        }

        //helper methods

        internal static int GetScreenRezx()
        {
            return Screen.PrimaryScreen.Bounds.Width; //returns screen width
        }

        internal static int GetScreenRezy()
        {
            return Screen.PrimaryScreen.Bounds.Height; //returns screen height
        }

        internal static int GetCenterx()
        {
            return (Screen.PrimaryScreen.Bounds.Width / 2) - (xDefaultRes / 2); //gets the x coordinate to center the window
        }

        internal static int GetCentery()
        {
            return (Screen.PrimaryScreen.Bounds.Height / 2) - (yDefaultRes / 2); //gets the x coordinate to center the window
        }

        internal static int GetWorkingAreaHeight()
        {
            return Screen.PrimaryScreen.WorkingArea.Height; //gets the size of the taskbar
        }

        private static bool WindowIsFullScreen(IntPtr handle) //returns true if a window is full screen
        {
            Rect rect = default;
            GetWindowRect(handle, ref rect);
            return rect.Left == -32000 && rect.Top == -32000; //by default, full screen windows have left and top values of -32000
        }

        //debug methods

        internal static int getCurrentStyle(IntPtr handle)
        {
            return GetWindowLongPtr(handle, GWL_STYLE); //gets the current style
        }
    }
    /// <summary>
    /// A window rectangle
    /// </summary>
    internal struct Rect
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
}