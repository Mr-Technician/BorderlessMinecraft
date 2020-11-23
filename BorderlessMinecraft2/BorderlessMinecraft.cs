using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorderlessMinecraft2
{
    /// <summary>
    /// The main class of the borderless Minecraft project.
    /// </summary>
    public class BorderlessMinecraft
    {
        /// <summary>
        /// The default style of the Minecraft window
        /// </summary>
        private const uint styleCache = 382664704;

        /// <summary>
        /// The default width of a restored window
        /// </summary>
        private const int xDefaultRes = 900;
        /// <summary>
        /// The default height of a restored window
        /// </summary>
        private const int yDefaultRes = 520;

        /// <summary>
        /// The Minecraft processes
        /// </summary>
        private List<Process> Processes;

        public BorderlessMinecraft()
        {
            this.LoadProcesses(); //when the object is created, load processes
        }

        /// <summary>
        /// Returns the searches processes
        /// </summary>
        /// <returns></returns>
        public List<Process> GetProcesses()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Restores the provided window handle to default
        /// </summary>
        /// <returns></returns>
        public int RestoreWindow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Minimizes the provided window handle 
        /// </summary>
        /// <returns></returns>
        public int MinimizeWindow()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Makes the provided window handle borderless
        /// </summary>
        /// <returns></returns>
        public int SetBorderless()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Removes the borderless window styling from the provided handle
        /// </summary>
        /// <returns></returns>
        public int UndoBorderless()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the provided handle position
        /// </summary>
        /// <returns></returns>
        public bool SetPosition()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the provided handle to the foreground
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public bool SetForeground(IntPtr handle)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sets the title of the provided handle to the provided string
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool SetTitle(IntPtr handle, string title)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all currently running processes and saves MC processes to the list
        /// </summary>
        private void LoadProcesses()
        {

        }

        //static helpers
        /// <summary>
        /// Gets the screen width
        /// </summary>
        /// <returns></returns>
        private static int GetScreenResX()
        {
            return Screen.PrimaryScreen.Bounds.Width; //returns screen width
        }
        /// <summary>
        /// Gets the screen height
        /// </summary>
        /// <returns></returns>
        private static int GetScreenResY()
        {
            return Screen.PrimaryScreen.Bounds.Height; //returns screen height
        }
        /// <summary>
        /// Gets the screen center width
        /// </summary>
        /// <returns></returns>
        private static int GetCenterX()
        {
            return (Screen.PrimaryScreen.Bounds.Width / 2) - (xDefaultRes / 2); //gets the x coordinate to center the window
        }
        /// <summary>
        /// Gets the screen center height
        /// </summary>
        /// <returns></returns>
        private static int GetCenterY()
        {
            return (Screen.PrimaryScreen.Bounds.Height / 2) - (yDefaultRes / 2); //gets the x coordinate to center the window
        }
        /// <summary>
        /// Gets the working area of the desktop (height minus taskbar)
        /// </summary>
        /// <returns></returns>
        private static int GetWorkingAreaHeight()
        {
            return Screen.PrimaryScreen.WorkingArea.Height; //gets the size of the taskbar
        }
    }
}
