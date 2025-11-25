using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using BorderlessMinecraft.Configuration;

namespace BorderlessMinecraft
{
    /// <summary>
    /// ApplicationContext used when running BorderlessMinecraft in tray/background mode (via --tray).
    /// For now this only shows a tray icon and allows opening the main UI or exiting.
    /// Borderless/monitoring logic can be added here later.
    /// </summary>
    internal sealed class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;
        private Config _config;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        public TrayApplicationContext()
        {
            _config = new Config();

            var contextMenu = new ContextMenuStrip();
            var openItem = new ToolStripMenuItem("Open Borderless Minecraft", null, OnOpenClicked);
            var exitItem = new ToolStripMenuItem("Exit", null, OnExitClicked);
            contextMenu.Items.Add(openItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(exitItem);

            _notifyIcon = new NotifyIcon
            {
                Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath),
                Visible = true,
                ContextMenuStrip = contextMenu,
                Text = "Borderless Minecraft Helper"
            };

            _notifyIcon.MouseClick += NotifyIcon_MouseClick;

            // Start a background listener for config reload signals.
            var _ = System.Threading.Tasks.Task.Run(() => ListenForConfigReloadsAsync(_cts.Token));
        }

        private async System.Threading.Tasks.Task ListenForConfigReloadsAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // Block until signaled or cancelled.
                bool signaled = ConfigReloadSignal.WaitForReload(token);
                if (!signaled || token.IsCancellationRequested)
                    break;

                // Reload configuration; future logic can react to changed values here.
                _config = new Config();
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LaunchMainForm();
            }
        }

        private void OnOpenClicked(object sender, EventArgs e)
        {
            LaunchMainForm();
        }

        private void LaunchMainForm()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    UseShellExecute = true
                });
            }
            catch
            {
                // Swallow for now; failures to launch the main UI shouldn't crash the helper.
            }
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            ExitThread();
        }

        protected override void ExitThreadCore()
        {
            _cts.Cancel();
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            base.ExitThreadCore();
        }
    }
}
