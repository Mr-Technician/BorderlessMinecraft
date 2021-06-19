using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft2
{
    /// <summary>
    /// The main class of the borderless Minecraft project.
    /// </summary>
    public class BorderlessMinecraft
    {        
        /// <summary>
        /// The Minecraft processes
        /// </summary>
        private List<Process> Processes;

        public BorderlessMinecraft()
        {
            Processes = new List<Process>(); //initialize object
            LoadProcesses(); //when the object is created, load processes
        }

        /// <summary>
        /// Returns the search processes after refreshing their contents
        /// </summary>
        /// <returns></returns>
        public List<Process> GetProcesses()
        {
            LoadProcesses();
            return Processes;
        }        

        /// <summary>
        /// Gets all currently running processes and saves java processes to the list
        /// </summary>
        private void LoadProcesses(string startsWith = "")
        {
            Process[] allProcesses = Process.GetProcesses(); //gets an array of all system processes
            Processes.Clear(); //reset the processes
            foreach (Process proc in allProcesses)
            {
                if (proc.MainWindowTitle.StartsWith(startsWith) && proc.ProcessName == "javaw") //checks for java processes that start with the start text
                    Processes.Add(proc);
            }
        }
    }
}
