using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft.Configuration
{
    /// <summary>
    /// Exposes configuration properties that will be automatically saved to and retrieved from the registry
    /// </summary>
    class Config
    {
        private RegistryEditor Registry { get; }
        public Config()
        {
            Registry = new RegistryEditor(@"SOFTWARE\BorderlessMinecraft"); //open the registry in this location

            if (bool.TryParse((string)Registry.GetKeyValue(nameof(StartOnBoot)), out bool value1))
                _startOnBoot = value1;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(StartMinimized)), out bool value2))
                _startMinimized = value2;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(MinimizeToTray)), out bool value3))
                _minimizeToTray = value3;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(AutomaticBorderless)), out bool value4))
                _automaticBorderless = value4;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(PreserveTaskBar)), out bool value5))
                _preserveTaskBar = value5;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(ShowAllClients)), out bool value6))
                _showAllClients = value6;
        }

        public bool StartOnBoot
        {
            get => _startOnBoot;
            set
            {
                _startOnBoot = value;
                Registry.SetKeyValue(nameof(StartOnBoot), value);
                AutoStartup.SetStartup(value);
            }
        }
        private bool _startOnBoot;

        public bool StartMinimized
        {
            get => _startMinimized;
            set
            {
                _startMinimized = value;
                Registry.SetKeyValue(nameof(StartMinimized), value);
            }
        }
        private bool _startMinimized;
        public bool MinimizeToTray
        {
            get => _minimizeToTray; set
            {
                _minimizeToTray = value;
                Registry.SetKeyValue(nameof(MinimizeToTray), value);
            }
        }
        private bool _minimizeToTray;
        public bool AutomaticBorderless
        {
            get => _automaticBorderless; set
            {
                _automaticBorderless = value;
                Registry.SetKeyValue(nameof(AutomaticBorderless), value);
            }
        }
        private bool _automaticBorderless;
        public bool PreserveTaskBar
        {
            get => _preserveTaskBar; set
            {
                _preserveTaskBar = value;
                Registry.SetKeyValue(nameof(PreserveTaskBar), value);
            }
        }
        private bool _preserveTaskBar;
        public bool ShowAllClients
        {
            get => _showAllClients; set
            {
                _showAllClients = value;
                Registry.SetKeyValue(nameof(ShowAllClients), value);
            }
        }
        private bool _showAllClients;
    }
}
