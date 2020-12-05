using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessMinecraft2
{
    /// <summary>
    /// Handles interop between user32.dll and the rest of the program
    /// </summary>
    public static class ProcessInterop
    {
        /// <summary>
        /// Represents the height and width of a window
        /// </summary>
        public struct Dimensions
        {
            private Rect Rect { get; set; }
            public int X { get => Rect.Left; }
            public int Y { get => Rect.Top; }
            public int Height { get => Rect.Bottom - Rect.Top; }
            public int Width { get => Rect.Right - Rect.Left; }
            public int AdjustedHeight { get => Height - Modifier; }
            public int AdjustedWidth { get => Width - (Modifier * 2); }

            public Dimensions(Rect rect)
            {
                Rect = rect;
            }
        }

        /// <summary>
        /// Represents the corners of a window
        /// </summary>
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg); //restores the window
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLongPtr(IntPtr hWnd, int nIndex); //gets window style
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLongPtr64(IntPtr hWnd, int nIndex, uint dwNewLong); //sets window style
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags); //sets window position
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd); //sets the window to the foreground
        [DllImport("user32.dll")]
        private static extern bool SetWindowText(IntPtr hWnd, string title); //changes the window title
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle); //gets the current window position

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
        /// All position and sizing values will be adjusted by this value
        /// </summary>
        private static readonly int Modifier = 7;

        /// <summary>
        /// The default style of the Minecraft window
        /// </summary>
        private static readonly uint styleCache = 382664704;
        /// <summary>
        /// The default width of a restored window
        /// </summary>
        public static readonly int xDefaultRes = 854 + (Modifier * 2);
        /// <summary>
        /// The default height of a restored window
        /// </summary>
        public static readonly int yDefaultRes = 480 + Modifier;

        /// <summary>
        /// Restores the provided window handle to default
        /// </summary>
        /// <returns></returns>
        public static int RestoreWindow(IntPtr handle)
        {
            return ShowWindow(handle, SW_RESTORE);
        }
        /// <summary>
        /// Minimizes the provided window handle 
        /// </summary>
        /// <returns></returns>
        public static int MinimizeWindow(IntPtr handle)
        {
            return ShowWindow(handle, SW_MINIMIZE); //minimizes the window
        }
        /// <summary>
        /// Makes the provided window handle borderless
        /// </summary>
        /// <returns></returns>
        public static int SetBorderless(IntPtr handle)
        {
            long currentStyle = GetWindowLongPtr(handle, GWL_STYLE); //gets the current style
            currentStyle &= ~(WS_BORDER | WS_DLGFRAME | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SYSMENU); //sets the style elements to be removed
            return SetWindowLongPtr64(handle, GWL_STYLE, (uint)currentStyle); //removes the style elements
        }
        /// <summary>
        /// Removes the borderless window styling from the provided handle
        /// </summary>
        /// <returns></returns>
        public static int UndoBorderless(IntPtr handle)
        {
            return SetWindowLongPtr64(handle, GWL_STYLE, styleCache); //adds the style elements
        }
        /// <summary>
        /// Sets the provided handle position
        /// </summary>
        /// <returns></returns>
        public static bool SetPosition(IntPtr handle, int xPos, int yPos, int xRes, int yRes, bool WindowIsBorderless = true)
        {
            if (WindowIsBorderless) //a borderless window has no invisible padding
            {
                return SetWindowPos(handle, handle, xPos, yPos, xRes, yRes, SWP_NOZORDER); //sets the minecraft window to the provided position
            }
            else
            {
                return SetWindowPos(handle, handle, xPos - Modifier, yPos, xRes + (Modifier * 2), yRes + Modifier, SWP_NOZORDER); //sets the minecraft window to the provided position
            }
        }
        /// <summary>
        /// Sets the provided handle to the foreground
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static bool SetForeground(IntPtr handle)
        {
            return SetForegroundWindow(handle); //places the Minecraft window at the foreground            
        }
        /// <summary>
        /// Sets the title of the provided handle to the provided string
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static bool SetTitle(IntPtr handle, string title)
        {
            return SetWindowText(handle, title); //sets the window title
        }

        /// <summary>
        /// Returns the position of the current window
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static Dimensions GetWindowDimensions(IntPtr handle)
        {
            Rect rect = new Rect();
            GetWindowRect(handle, ref rect);
            return new Dimensions(rect);
        }

        /// <summary>
        /// Returns true if the current window is snapped according to the current gride sizw
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public static bool WindowIsSnapped(IntPtr handle, int gridSize)
        {
            Dimensions dimensions = GetWindowDimensions(handle);
            int modX = dimensions.AdjustedWidth % (GetScreenResX() / gridSize);
            int modY = dimensions.AdjustedHeight % (GetWorkingAreaHeight() / gridSize);
            return modX == 0 && modY == 0; //return true if the screen width mod snap quadrant size is 0 on both dimensions. If false, the window is not snapped
        }

        /// <summary>
        /// Gets the screen width
        /// </summary>
        /// <returns></returns>
        public static int GetScreenResX()
        {
            return Screen.PrimaryScreen.Bounds.Width; //returns screen width
        }
        /// <summary>
        /// Gets the screen height
        /// </summary>
        /// <returns></returns>
        public static int GetScreenResY()
        {
            return Screen.PrimaryScreen.Bounds.Height; //returns screen height
        }
        /// <summary>
        /// Gets the screen center width
        /// </summary>
        /// <returns></returns>
        public static int GetCenterX()
        {
            return (Screen.PrimaryScreen.Bounds.Width / 2) - (xDefaultRes / 2); //gets the x coordinate to center the window
        }
        /// <summary>
        /// Gets the screen center height
        /// </summary>
        /// <returns></returns>
        public static int GetCenterY()
        {
            return (Screen.PrimaryScreen.Bounds.Height / 2) - (yDefaultRes / 2); //gets the x coordinate to center the window
        }
        /// <summary>
        /// Gets the working area of the desktop (height minus taskbar)
        /// </summary>
        /// <returns></returns>
        public static int GetWorkingAreaHeight()
        {
            return Screen.PrimaryScreen.WorkingArea.Height; //gets the size of the taskbar
        }
    }
}
