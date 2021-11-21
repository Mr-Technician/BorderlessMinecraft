using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft.Configuration
{
    class RegistryEditor
    {
        private string SubKeyName { get; }
        public RegistryEditor(string subkeyName = @"SOFTWARE\TestSettings")
        {
            SubKeyName = subkeyName;
        }

        public object GetKeyValue(string key)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(SubKeyName);

            //if it does exist, retrieve the stored values  
            if (regKey != null)
            {
                var value = regKey.GetValue(key);
                regKey.Close();
                return value;
            }
            return null;
        }

        public void SetKeyValue(string key, object value)
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(SubKeyName);
            regKey.SetValue(key, value);
            regKey.Close();
        }
    }
}
