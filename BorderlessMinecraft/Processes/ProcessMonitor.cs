using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft.Processes
{
    class ProcessMonitor
    {
        ManagementEventWatcher StartEventWatcher { get; }
        ManagementEventWatcher StopEventWatcher { get; }
        public ProcessMonitor()
        {
            StartEventWatcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
            StartEventWatcher.EventArrived += StartEventWatcher_EventArrived;
            StopEventWatcher = new ManagementEventWatcher(new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
            StopEventWatcher.EventArrived += StopEventWatcher_EventArrived;
        }

        public void Start()
        {
            try
            {
                if (Program.IsUserAnAdmin()) //check if the current user is an admin
                {
                    StartEventWatcher.Start();
                    StopEventWatcher.Start();
                }
                else
                {
                    ElevateProcess();
                }
            }
            catch (ManagementException) { }
        }

        public void Stop()
        {
            StartEventWatcher.Stop();
            StopEventWatcher.Stop();
        }

        /// <summary>
        /// Returns the process ID of the started process
        /// </summary>
        public event Action<int> OnJavaAppStarted;
        /// <summary>
        /// Returns the process ID of the started process
        /// </summary>
        public event Action<int> OnJavaAppStopped;
        /// <summary>
        /// Tells the Form object to kill the current process
        /// </summary>
        public event Action OnProcessShouldExit;

        private void StartEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            if (processName.Contains("javaw.exe")) //true if the process name is java
            {
                OnJavaAppStarted.Invoke(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)); //return the process id
            }
        }

        private void StopEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            if (processName.Contains("javaw.exe")) //true if the process name is java
            {
                OnJavaAppStopped.Invoke(Convert.ToInt32(e.NewEvent.Properties["ProcessID"].Value)); //return the process id
            }
        }

        private void ElevateProcess()
        {
            var path = System.Reflection.Assembly.GetEntryAssembly().Location;
            var processInfo = new ProcessStartInfo(path);
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas";
            Process.Start(processInfo);
            OnProcessShouldExit.Invoke(); //exit the current process
        }
    }
}
