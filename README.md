# Easy WSL Manager

Easy WSL Manager is a utility to manage WSL and its distributions on GUI.

## Features

- Configures WSL settings in GUI
- Configures WSL distribution settings
  - Some settings, unable to change from CLI such as base path and default user, can also be changed.
- Supports for installation of WSL

## Requirements

- Windows 10 or later (which supports WSL)
  - 'wsl.exe' must be available (at least KB5004296 needs to be installed)
- .NET 5.0 (Desktop runtime) or later (you can get from https://dotnet.microsoft.com/ja-jp/download/dotnet)

## Intall

No installation is required; only to extract zip and put extracted files in any (same) place.

## Usage

### Install WSL

If WSL is not installed, 'Install WSL' dialog will be displayed. You can install WSL by clicking 'Install' button. (Prompt for elevation may appear for some times.)

> To complete the installation, system reboot is necessary.

If WSL is installed, 'Install WSL' dialog will not be displayed, and the main window will be displayed.

### Install distributions

To use WSL, distributions need to be installed. To install a distribution, click 'Distribution' menu in the main window, and click 'Install new distribution...' menu (a dialog will appear). In the dialog, select a distribution from distribution list (provided by WSL system) and click 'Install'.

If you have a .tar file of file system or .vhdx file containing Linux, you can 'Import' instead of installation.

> Importing .vhdx is available only in the latest WSL.

### Configuring

The main window displays configurable settings. For almost all settings, changing the value will be saved immediately.

> Some settings need to restart WSL. To restart, use 'Shutdown WSL' in File menu.

#### Configuring WSL

In 'Settings' tab in the main window, you can configure WSL settings over all distributions.  
Settings in 'General' are set as 'Default' by default (for checkboxes, indeterminate state means 'using default'). By changing these settings, `.wslconfig` will be created in %USERPROFILE% directory.

#### Configuring distributions

Available distributions are displayed as main window tabs. You can change per-distribution settings in the tabs.

Note that 'Open configuration' button will start WSL distribution instance. This may affect changing other settings.

## Development

Using Visual Studio 2022 is suitable for development. Other methods are not tested.

## License

[MIT License](./LICENSE)
