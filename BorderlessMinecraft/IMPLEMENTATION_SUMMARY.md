# BorderlessMinecraft - Tray, IPC, and MSI Implementation Summary

## Completed Implementation (Phase 1)

### 1. **IPC (Inter-Process Communication) - ConfigReloadSignal**
✅ **Status:** Fully integrated

- All configuration property setters in `Config.cs` now call `ConfigReloadSignal.SignalReload()` after persisting changes
- Properties that signal IPC:
  - `StartOnBoot`
  - `StartMinimized`
  - `MinimizeToTray`
  - `AutomaticBorderless`
  - `PreserveTaskBar`
  - `ShowAllClients`
  - `Advanced`
  - `AdvancedParams`
- Tray helper (`TrayApplicationContext`) already has background listener that waits for reload signals
- When signaled, tray helper reloads configuration from registry

### 2. **Auto-Start Behavior - Windows Run Key**
✅ **Status:** Updated for tray mode

- `AutoStartup.SetStartup()` now writes the Run key with `--tray` argument
- Command line format: `"<path>\BorderlessMinecraft.exe" --tray`
- When enabled, the app will start in tray/background mode at Windows logon
- Registry location: `HKCU\Software\Microsoft\Windows\CurrentVersion\Run\BorderlessMinecraft`

### 3. **Program Entry Point - Mode Selection**
✅ **Status:** Already implemented

- `Program.cs` checks for `--tray` argument
- If present: launches `TrayApplicationContext` (background/tray mode)
- If absent: launches `MainForm` (normal GUI mode)

### 4. **Tray Application Context**
✅ **Status:** Already implemented with IPC support

- Runs as an `ApplicationContext` with system tray icon
- Context menu: "Open Borderless Minecraft", "Exit"
- Background thread listens for `ConfigReloadSignal` events
- On reload: creates new `Config()` instance to read fresh settings from registry
- Left-click on tray icon launches the main GUI

### 5. **Minimize-to-Tray in Main GUI**
✅ **Status:** Already implemented

- `MainForm` has `NotifyIcon` (TrayIcon) component
- When `Config.MinimizeToTray` is enabled and window is minimized:
  - Form hides
  - Taskbar button removed (`ShowInTaskbar = false`)
  - Tray icon becomes visible
- Tray context menu: "Show BorderlessMinecraft", "Exit"
- Left-click on tray icon restores the window
- On restore: form shows, window state normal, taskbar button restored

---

## Testing Checklist

### Basic Functionality Tests
- [ ] **Normal Mode Launch:** Run `BorderlessMinecraft.exe` (no args) - should show main GUI
- [ ] **Tray Mode Launch:** Run `BorderlessMinecraft.exe --tray` - should show tray icon only
- [ ] **Minimize to Tray (GUI):**
  1. Enable "Settings > Minimize to Tray"
  2. Minimize the window
  3. Verify: window hidden, tray icon visible
  4. Click tray icon → verify window restored
- [ ] **Start on Boot Toggle:**
  1. Enable "Settings > Start on Boot"
  2. Check registry: `HKCU\...\Run\BorderlessMinecraft` should exist with `--tray` argument
  3. Disable setting → verify Run key removed
- [ ] **Start Minimized:**
  1. Enable "Settings > Start Minimized"
  2. Close and relaunch app (normal mode)
  3. Verify: app starts minimized to tray

### IPC Tests
- [ ] **Config Reload (Tray Helper):**
  1. Start tray helper: `BorderlessMinecraft.exe --tray`
  2. Start main GUI: `BorderlessMinecraft.exe`
  3. Change a setting in GUI (e.g., "Automatic Borderless")
  4. Verify: tray helper receives reload signal (no easy visual confirmation, but should not crash)
- [ ] **Multiple Changes:**
  1. With tray helper running, toggle several settings in GUI
  2. Verify: no errors, tray helper remains responsive
- [ ] **No Tray Helper Running:**
  1. Close any tray helpers
  2. Open GUI and change settings
  3. Verify: no errors when signaling (IPC call gracefully fails)

### Edge Cases
- [ ] **Both Modes Running:**
  1. Start tray helper
  2. Start main GUI
  3. Verify: both can coexist, two tray icons may appear (acceptable)
- [ ] **Auto-Start After Boot:**
  1. Enable "Start on Boot"
  2. Log out and log back in
  3. Verify: tray icon appears automatically
  4. Open main GUI from tray
  5. Verify: both work correctly
- [ ] **Upgrade Path:**
  1. If you have an old Run key value (with `-autoStart` instead of `--tray`), toggle "Start on Boot" off/on
  2. Verify: Run key updates to new `--tray` format

---

## Future Work / Not Yet Implemented

### 1. **MSI Installer Integration**
**Status:** Design documented, not yet implemented in installer

- MSI should provide a checkbox during install: "Run Borderless Minecraft helper at Windows startup"
- If checked: MSI should set `HKCU\SOFTWARE\BorderlessMinecraft\StartOnBoot = "True"`
- App will read this on first run and create the Run key accordingly
- MSI should **not** directly manage the Run key after install (app owns it)
- On uninstall: optionally clean up the Run key value

**Action Required:**
- Update Visual Studio Setup Project (`.vdproj` or WiX installer)
- Add custom action or registry entries to set initial `StartOnBoot` value
- Add dialog with checkbox for "Run on startup" option

### 2. **Automatic Borderless Monitoring in Tray Mode**
**Status:** Hooks exist, behavior not yet implemented

- `TrayApplicationContext` currently only manages the tray icon and config reloading
- Plan: when `Config.AutomaticBorderless` is true, tray helper should:
  - Start `ProcessMonitor` (already exists in codebase)
  - Listen for Java/Minecraft processes
  - Automatically apply borderless to new Minecraft windows
- This would allow the tray helper to actually **do something** beyond just being an icon

**Action Required:**
- In `TrayApplicationContext`, after loading config:
  ```csharp
  if (_config.AutomaticBorderless)
  {
      // Start ProcessMonitor similar to MainForm
      // Subscribe to OnJavaAppStarted event
      // Trigger borderless when new Minecraft detected
  }
  ```
- On config reload (IPC signal), check if `AutomaticBorderless` changed and start/stop monitor accordingly

### 3. **Single-Instance Mutex (Optional Enhancement)**
**Status:** Not implemented

- Currently, multiple tray helpers or GUI instances can run simultaneously
- Could add a named `Mutex` to ensure only one tray helper runs per user
- Pattern:
  ```csharp
  bool createdNew;
  using (var mutex = new Mutex(true, "BorderlessMinecraft.Tray.Instance", out createdNew))
  {
      if (!createdNew)
      {
          // Another tray instance is running, exit
          return;
      }
      // Continue with tray mode
  }
  ```

**Decision:** This is optional and may not be necessary if running multiple instances is acceptable.

### 4. **Enhanced Tray UX**
**Status:** Not implemented

Possible improvements:
- Show notification balloon when automatically making a window borderless
- Add menu item to tray context to toggle "Automatic Borderless" on/off without opening GUI
- Display current config state in tray tooltip (e.g., "Borderless Minecraft (Auto: ON)")

---

## Technical Notes

### Architecture Summary
```
BorderlessMinecraft.exe (single EXE, two modes)
│
├─ Normal Mode (no args)
│  └─ MainForm
│     ├─ User settings UI
│     ├─ Manual borderless controls
│     ├─ Minimize-to-tray behavior
│     └─ Writes config → signals IPC
│
└─ Tray Mode (--tray arg)
   └─ TrayApplicationContext
      ├─ System tray icon + menu
      ├─ Config reload listener (IPC)
      └─ (Future) Automatic borderless monitoring
```

### IPC Flow
1. User changes setting in GUI (`MainForm`)
2. `Config` property setter:
   - Writes to registry (`HKCU\SOFTWARE\BorderlessMinecraft`)
   - Calls `AutoStartup.SetStartup()` if `StartOnBoot` changed
   - Calls `ConfigReloadSignal.SignalReload()` → sets `EventWaitHandle`
3. Tray helper (`TrayApplicationContext`) background thread:
   - Blocks on `ConfigReloadSignal.WaitForReload(token)`
   - When signaled → creates new `Config()` instance
   - Reads fresh values from registry
   - (Future) Adjusts monitoring behavior based on new config

### Registry Keys
- **Settings:** `HKCU\SOFTWARE\BorderlessMinecraft`
  - `StartOnBoot` (DWORD or string "True"/"False")
  - `StartMinimized`
  - `MinimizeToTray`
  - `AutomaticBorderless`
  - `PreserveTaskBar`
  - `ShowAllClients`
  - `Advanced`
  - `AdvancedParams` (string, comma-separated)
- **Auto-Start:** `HKCU\Software\Microsoft\Windows\CurrentVersion\Run`
  - Value: `BorderlessMinecraft`
  - Data: `"<path>\BorderlessMinecraft.exe" --tray`

---

## Build Information
- **Build Date:** November 23, 2025
- **Configuration:** Debug
- **Output:** `BorderlessMinecraft\bin\Debug\BorderlessMinecraft.exe`
- **Build Status:** ✅ Successful (no errors, only warnings about unused usings)

---

## Next Steps

1. **Test the implementation:**
   - Walk through the testing checklist above
   - Verify all modes, IPC, and settings work as expected

2. **Implement automatic borderless in tray mode:**
   - Add `ProcessMonitor` integration to `TrayApplicationContext`
   - Wire up event handlers for Java process detection
   - Apply borderless logic based on `Config.AutomaticBorderless`

3. **MSI installer updates:**
   - Add installer dialog with "Run on startup" checkbox
   - Set initial `StartOnBoot` registry value based on user choice
   - Document installer behavior for upgrades and uninstalls

4. **Optional enhancements:**
   - Single-instance mutex for tray mode
   - Notification balloons when auto-borderless triggers
   - In-tray settings toggles

5. **Documentation:**
   - Update README.md with new tray mode and auto-start features
   - Create user guide explaining tray behavior
   - Document MSI installer options

---

**Questions or Issues?**
If you encounter any problems during testing or have questions about the implementation, check the following files:
- `Program.cs` - Entry point and mode selection
- `TrayApplicationContext.cs` - Tray helper implementation
- `Form1.cs` - Main GUI and minimize-to-tray
- `Configuration/Config.cs` - Settings and IPC signaling
- `Configuration/AutoStartup.cs` - Run key management
- `ConfigReloadSignal.cs` - IPC event wrapper

