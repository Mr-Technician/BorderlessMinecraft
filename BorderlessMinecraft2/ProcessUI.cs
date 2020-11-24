using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft2
{
    /// <summary>
    /// Provides a friendly toString method for a process class
    /// </summary>
    public class ProcessUI
    {
        /// <summary>
        /// The process this UI represents
        /// </summary>
        private Process process;

        public ProcessUI(Process process)
        {
            this.process = process;
        }

        /// <summary>
        /// Returns the prcoess this UI represents
        /// </summary>
        /// <returns></returns>
        public Process GetProcess()
        {
            return process;
        }

        /// <summary>
        /// Returns the main window of the process
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return process.MainWindowTitle;
        }
    }
}
