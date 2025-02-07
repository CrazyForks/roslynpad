# RoslynPad

![RoslynPad](src/RoslynPad/Resources/RoslynPad.png)

A cross-platform C# editor based on Roslyn and AvalonEdit

## Installing

**You must also install a supported .NET SDK to allow RoslynPad to compile programs.**

| Source | |
|-|-|
| GitHub | [![Downloads](https://img.shields.io/github/downloads/aelij/RoslynPad/total.svg?style=flat-square)](https://github.com/aelij/RoslynPad/releases/latest) |
| Microsoft Store | <a href="https://www.microsoft.com/store/apps/9nctj2cqwxv0?ocid=badge"><img src="https://get.microsoft.com/images/en-us%20light.svg" height="50" alt="Microsoft Store badge logo" /></a> |
| winget | `winget install --id RoslynPad.RoslynPad` |

### Running on macOS

1. Open the .dmg file and drag RoslynPad to the Applications directory.
1. On the first run:
   * **macOS Sonoma** or earlier - Right click the app on Finder and select **Open**. You will be prompted that the app is not signed by a known developer - click **Open**.
   * **macOS Sequoia** you must go to **Settings > Privacy & Security** to approve non-notarized apps after the first run attempt.
   * For more information see [Open a Mac app from an unknown developer](https://support.apple.com/guide/mac-help/mh40616).

## Packages

See [Packages](docs/packages/README.md) for more information.

## Building

To build the source code, use one of the following:
* `dotnet build`
* Visual Studio 2022
* Visual Studio Code with the C# Dev Kit extension

Solutions:
* `RoslynPad.sln` - contains all projects (recommended only on Windows)
* `src/RoslynPad.Avalonia.sln` - contains only cross-platform projects

## Features

### Completion

![Completion](docs/Completion.png)

### Signature Help

![Signature Help](docs/SignatureHelp.png)

### Diagnostics

![Diagnostics](docs/Diagnostics.png)

### Code Fixes

![Code Fixes](docs/CodeFixes.png)
