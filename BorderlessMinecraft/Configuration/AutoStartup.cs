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
        /// Sets the auto startup location for Borderless Minecraft. When enabled, the helper will be started
        /// in tray mode using the --tray argument from the user's profile at logon.
        /// </summary>
        /// <param name="enabled">True to enable autostart; false to disable.</param>
        internal static void SetStartup(bool enabled)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (enabled)
            {
                string exePath = System.Windows.Forms.Application.ExecutablePath;
                string command = "\"" + exePath + "\" --tray";
                key.SetValue("BorderlessMinecraft", command);
            }
            else
            {
                key.DeleteValue("BorderlessMinecraft", false); //remove the startup entry
            }
        }
    }
}
