using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft.Configuration
{
    static class AutoStartup
    {
        /// <summary>
        /// Sets the auto startup location for borderless minecraft
        /// </summary>
        /// <param name="enabled"></param>
        internal static void SetStartup(bool enabled)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (enabled)
                key.SetValue(nameof(BorderlessMinecraft), System.Reflection.Assembly.GetEntryAssembly().Location + " -autoStart"); //set the key value and append the flag
            else
                key.DeleteValue(nameof(BorderlessMinecraft), false); //remove the startup entry

        }
    }
}
