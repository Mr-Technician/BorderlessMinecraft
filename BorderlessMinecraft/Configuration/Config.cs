using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderlessMinecraft.Configuration
{
    /// <summary>
    /// Exposes configuration properties that will be automatically saved to and retrieved from the registry.
    /// All property setters signal the ConfigReloadSignal IPC event so tray/background helpers can reload configuration immediately.
    /// </summary>
    class Config
    {
        private RegistryEditor Registry { get; }
        public Config()
        {
            Registry = new RegistryEditor(@"SOFTWARE\BorderlessMinecraft"); //open the registry in this location

            if (bool.TryParse((string)Registry.GetKeyValue(nameof(StartOnBoot)), out bool startOnBoot))
                _startOnBoot = startOnBoot;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(MinimizeToTray)), out bool minimizeToTray))
                _minimizeToTray = minimizeToTray;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(AutomaticBorderless)), out bool automaticBorderless))
                _automaticBorderless = automaticBorderless;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(PreserveTaskBar)), out bool preserveTaskBar))
                _preserveTaskBar = preserveTaskBar;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(ShowAllClients)), out bool showAllClients))
                _showAllClients = showAllClients;
            if (bool.TryParse((string)Registry.GetKeyValue(nameof(Advanced)), out bool advanced))
                _advanced = advanced;
            _advancedParams = "" + (string)Registry.GetKeyValue(nameof(AdvancedParams));
        }

        public bool StartOnBoot
        {
            get => _startOnBoot;
            set
            {
                _startOnBoot = value;
                Registry.SetKeyValue(nameof(StartOnBoot), value);
                AutoStartup.SetStartup(value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private bool _startOnBoot;

        public bool MinimizeToTray
        {
            get => _minimizeToTray; set
            {
                _minimizeToTray = value;
                Registry.SetKeyValue(nameof(MinimizeToTray), value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private bool _minimizeToTray;
        public bool AutomaticBorderless
        {
            get => _automaticBorderless; set
            {
                _automaticBorderless = value;
                Registry.SetKeyValue(nameof(AutomaticBorderless), value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private bool _automaticBorderless;
        public bool PreserveTaskBar
        {
            get => _preserveTaskBar; set
            {
                _preserveTaskBar = value;
                Registry.SetKeyValue(nameof(PreserveTaskBar), value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private bool _preserveTaskBar;
        public bool ShowAllClients
        {
            get => _showAllClients; set
            {
                _showAllClients = value;
                Registry.SetKeyValue(nameof(ShowAllClients), value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private bool _showAllClients;
        public bool Advanced
        {
            get => _advanced; set
            {
                _advanced = value;
                Registry.SetKeyValue(nameof(Advanced), value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private bool _advanced;
        public string AdvancedParams
        {
            get => _advancedParams; set
            {
                _advancedParams = value;
                Registry.SetKeyValue(nameof(AdvancedParams), value);
                BorderlessMinecraft.ConfigReloadSignal.SignalReload();
            }
        }
        private string _advancedParams;
    }
}
