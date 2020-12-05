using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft2
{
    /// <summary>
    /// Uses ProcessInterop to snap windows based on their current position
    /// </summary>
    public static class WindowSnap
    {
        /// <summary>
        /// 
        /// </summary>
        public enum SnapOptions
        {
            Default,
            ShiftRight,
            ShiftLeft,
            ShiftUp,
            ShiftDown,
            ExpandRight,
            ExpandLeft,
            ExpandUp,
            ExpandDown
        }

        public static bool HandleKeyboardInput(IntPtr SelectedHandle, SnapOptions snapOptions, int GridSize)
        {
            if (snapOptions == SnapOptions.Default) return false; //return false if option is default
            if (!ProcessInterop.WindowIsSnapped(SelectedHandle, GridSize)) //if window is not snapped, snap it to upper left corner
            {
                ProcessInterop.SetPosition(SelectedHandle, 0, 0, (ProcessInterop.GetScreenResX() / GridSize), ProcessInterop.GetWorkingAreaHeight() / GridSize, false);
            }

            ProcessInterop.Dimensions dimensions = ProcessInterop.GetWindowDimensions(SelectedHandle); //get the current screen corners

            switch (snapOptions)
            {
                case SnapOptions.ShiftUp:
                    {
                        ProcessInterop.SetPosition(SelectedHandle, dimensions.X, dimensions.Y - (ProcessInterop.GetScreenResX() / 2), ProcessInterop.GetScreenResX(), ProcessInterop.GetWorkingAreaHeight() / 2, false);
                        break;
                    }
                case SnapOptions.ShiftDown:
                    {
                        ProcessInterop.SetPosition(SelectedHandle, dimensions.X, dimensions.Y + (ProcessInterop.GetWorkingAreaHeight() / 2), ProcessInterop.GetScreenResX(), ProcessInterop.GetWorkingAreaHeight() / 2, false);
                        break;
                    }
                case SnapOptions.ShiftRight:
                    {
                        ProcessInterop.SetPosition(SelectedHandle, dimensions.X - (ProcessInterop.GetScreenResX() / 2), dimensions.Y, ProcessInterop.GetScreenResX() / 2, ProcessInterop.GetWorkingAreaHeight(), false);
                        break;
                    }
                case SnapOptions.ShiftLeft:
                    {
                        ProcessInterop.SetPosition(SelectedHandle, ProcessInterop.GetScreenResX() / 2, dimensions.Y, ProcessInterop.GetScreenResX() / 2, ProcessInterop.GetWorkingAreaHeight(), false);
                        break;
                    }
                case SnapOptions.ExpandUp:
                    {
                        break;
                    }
                case SnapOptions.ExpandDown:
                    {
                        break;
                    }
                case SnapOptions.ExpandRight:
                    {
                        break;
                    }
                case SnapOptions.ExpandLeft:
                    {
                        break;
                    }
            }
            return true;
        }
    }
}
