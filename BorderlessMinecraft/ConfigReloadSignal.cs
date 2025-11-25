using System;
using System.Threading;

namespace BorderlessMinecraft
{
    /// <summary>
    /// Simple IPC helper using a named EventWaitHandle to signal that configuration
    /// has changed and should be reloaded by background helpers (tray mode).
    /// </summary>
    internal static class ConfigReloadSignal
    {
        // Per-user event name; change to Global\\ if you need cross-session.
        private const string EventName = "BorderlessMinecraft.ConfigReload";

        /// <summary>
        /// Signal that configuration has changed.
        /// Safe to call even if no listener exists.
        /// </summary>
        internal static void SignalReload()
        {
            try
            {
                using (var ewh = new EventWaitHandle(false, EventResetMode.AutoReset, EventName))
                {
                    ewh.Set();
                }
            }
            catch
            {
                // Ignore IPC failures; they shouldn't break the main app.
            }
        }

        /// <summary>
        /// Blocks until a reload is signaled or the token is cancelled.
        /// Returns false if cancelled, true if signaled.
        /// Caller is responsible for looping.
        /// </summary>
        internal static bool WaitForReload(CancellationToken token)
        {
            try
            {
                using (var ewh = new EventWaitHandle(false, EventResetMode.AutoReset, EventName))
                {
                    int index = WaitHandle.WaitAny(new WaitHandle[] { ewh, token.WaitHandle });
                    return index == 0; // 0 = event, 1 = cancellation
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

