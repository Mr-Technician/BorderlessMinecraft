# WiX Installer Implementation - Complete

## Summary

Successfully converted the WiX v3 installer template to WiX v6 format for Borderless Minecraft.

## Files Created/Modified

### 1. **Package.wxs** (Updated)
- **Product Information**: Name, Version (1.3.4.0), Manufacturer (Mr-Technician)
- **UpgradeCode**: A8B9C1D2-E3F4-5678-9ABC-DEF012345678 (permanent across versions)
- **Scope**: perUser (installs to %LOCALAPPDATA%, no admin required)
- **Icons**: barrier.ico from BorderlessMinecraft project
- **Add/Remove Programs**: GitHub links, disabled repair/modify buttons
- **UI**: WixUI_FeatureTree with license agreement (License.rtf)
- **Features**:
  - **MainApplication** (always installed): App files, Start Menu & Desktop shortcuts
  - **StartOnBootFeature** (optional, Level=1000): Auto-start with Windows

### 2. **Folders.wxs** (Updated)
- **Installation Path**: `%LOCALAPPDATA%\BorderlessMinecraft\BorderlessMinecraft`
- **Start Menu**: `%APPDATA%\Microsoft\Windows\Start Menu\Programs\Borderless Minecraft`
- **Desktop**: Desktop shortcuts supported

### 3. **Components.wxs** (New - replaces ExampleComponents.wxs)
**ProductComponents Group:**
- BorderlessMinecraft.exe (main executable)
- BorderlessMinecraft.exe.config (app configuration)
- System.CodeDom.dll (dependency)
- COPYING.txt (license file)
- Registry settings (InstallPath)

**Shortcuts:**
- Start Menu shortcut with barrier.ico
- Desktop shortcut with barrier.ico
- Both create registry entries for tracking

**Startup Component:**
- Registry entry in `HKCU\Software\Microsoft\Windows\CurrentVersion\Run`
- Sets `BorderlessMinecraft="[INSTALLFOLDER]BorderlessMinecraft.exe" --tray`
- Also creates `StartOnBoot=True` registry value

### 4. **License.rtf** (New)
- RTF format license file
- Contains GPLv3 summary
- Required for WixUI_FeatureTree dialog

### 5. **BorderlessMinecraft.Installer.wixproj** (Updated)
- Added `WixToolset.UI.wixext` package reference (v6.0.2)
- Includes License.rtf as content

### 6. **Package.en-us.wxl** (Updated)
- Localized downgrade error message

## Key Features Implemented

### ? Per-User Installation
- No administrator rights required
- Installs to user's LocalAppData folder
- Uses registry keys as KeyPath for ICE validation compliance

### ? Upgrade Strategy
- MajorUpgrade configured to remove old versions automatically
- Prevents downgrades with user-friendly error message

### ? Start on Boot (Optional Feature)
- User can choose during installation
- Creates Windows startup registry entry
- Launches with `--tray` argument for background mode

### ? Shortcuts
- Start Menu shortcut (always installed)
- Desktop shortcut (always installed)
- Both use barrier.ico icon
- Properly cleaned up on uninstall

### ? Registry Management
- Tracks installation path
- Stores component installation state
- Supports StartOnBoot configuration
- Properly removes entries on uninstall

## WiX v3 ? v6 Conversion Notes

1. **Namespace**: Changed from `http://schemas.microsoft.com/wix/2006/wi` to `http://wixtoolset.org/schemas/v4/wxs`
2. **Package Element**: Merged `<Product>` and `<Package>` into single `<Package>` element
3. **StandardDirectory**: Used for common folders like LocalAppData, ProgramMenuFolder
4. **UI Extension**: Added `xmlns:ui` namespace and `WixToolset.UI.wixext` package
5. **KeyPath Requirements**: All per-user components now use registry KeyPath for ICE compliance
6. **RemoveFolder**: Added to handle user profile directory cleanup

## Build Configuration

The installer supports configuration-based builds:
- Uses `$(var.Configuration)` variable for Debug/Release paths
- Automatically includes all required files from build output

## Installation Behavior

1. **First Install**: Installs all features, user can deselect StartOnBoot
2. **Upgrade**: Automatically removes previous version before installing
3. **Uninstall**: 
   - Removes all files
   - Cleans up shortcuts
   - Removes registry entries
   - Removes startup entry (if installed)

## Build Status

? **Build Successful** - All ICE validation checks passed
