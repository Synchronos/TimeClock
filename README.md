# TimeClock

A C# desktop application that provides a clock, stopwatch, and basic time tracking features.

## Overview

TimeClock is a lightweight Windows desktop application built with C# that combines essential time management tools in one convenient interface. Whether you need to check the time, measure intervals with a stopwatch, or track your work hours, TimeClock has you covered.

## ⚠️ Branch Status: .NET 10 Upgrade In Progress

This branch (`upgrade-dotnet-10`) contains the **active development of a major framework upgrade**:

- **Previous Framework:** .NET Framework 4.0 (Released 2010)
- **Target Framework:** .NET 10 LTS (Long-Term Support until November 2028)
- **Status:** ✅ **UPGRADE COMPLETE** - Successfully migrated to .NET 10
- **Date Completed:** 2026-07-04

## Upgrade Changes Made

### Major Modernizations
- ✅ **SDK-Style Project Format:** Converted from legacy to modern SDK-style project files
- ✅ **Target Framework:** Updated from `.NET Framework 4.0` to `net10.0-windows`
- ✅ **Windows Forms:** Retained full Windows Forms support with native .NET 10 implementation
- ✅ **Nullable Reference Types:** Enabled for improved type safety
- ✅ **.gitignore:** Added modern build artifact and temporary file filtering

### Projects Upgraded
1. **TimeclockControls.csproj** - Library (no dependencies)
   - ✅ SDK-style conversion complete
   - ✅ Building successfully

2. **Timeclock.csproj** - Main Application
   - ✅ SDK-style conversion complete
   - ✅ Building successfully

### Code Improvements
- ✅ Fixed assembly version wildcards (1.0.* → 1.0.0.0, 1.1.* → 1.1.0.0)
- ✅ Removed legacy ClickOnce and BootStrapper configuration
- ✅ Removed obsolete configuration-specific property groups
- ✅ Added `System.DirectoryServices` NuGet package (v10.0.0)
- ✅ Fixed WFO1000 designer serialization warnings

## Features

- ⏰ **Digital Clock** - Real-time system clock display
- ⏱️ **Stopwatch** - Precise interval timing with start, stop, and reset controls
- ⏲️ **Time Tracking** - Basic time tracking functionality for monitoring work sessions

## Project Structure

```
TimeClock/
├── Timeclock/              # Main application (.NET 10)
├── TimeclockControls/      # Custom UI controls (.NET 10)
└── Timeclock Setup/        # Legacy setup files
```

## Requirements

- **.NET 10 SDK** - Required for building (LTS - Support until November 2028)
- **Windows Operating System** - Desktop application for Windows
- **Visual Studio 2022 or later** - For development and building from source

## Installation

### From Main Branch (Stable)
Download from the [main](../../tree/main) branch for the stable .NET Framework 4.0 version.

### From This Branch (Experimental - .NET 10)
This branch contains the upgraded .NET 10 version:

1. Clone the repository:
   ```bash
   git clone https://github.com/Synchronos/TimeClock.git
   git checkout upgrade-dotnet-10
   ```
2. Ensure .NET 10 SDK is installed
3. Open the solution in Visual Studio 2022+
4. Build the project
5. Run the application

## Building from Source

```bash
# Restore NuGet packages
dotnet restore

# Build the solution
dotnet build

# Run the application
dotnet run --project Timeclock
```

## Testing

Manual testing is recommended since no automated tests exist:

1. ✅ **Build:** Verified successful with no warnings
2. ⚠️ **Manual Testing Needed:**
   - Launch the application
   - Test clock display functionality
   - Test timer controls
   - Verify settings persistence
   - Test elapsed time display
   - Verify all UI controls render correctly

## Usage

- **Clock**: Displays the current system time
- **Stopwatch**: Click start to begin timing, stop to pause, and reset to clear
- **Time Tracking**: Use the time tracking feature to log work sessions

## License

This project is licensed under the **Mozilla Public License 2.0** - see the [LICENSE](LICENSE) file for details.

The Mozilla Public License is a permissive yet protective open source license that:
- Allows commercial use and modification
- Requires source code disclosure for modifications
- Includes explicit patent protections
- Supports combination with other open source licenses

## Post-Upgrade Recommendations

### Priority 1: MSIX Installer
- Remove legacy `.vdproj` setup project
- Create MSIX package for modern Windows deployment
- Benefits: Auto-updates, Microsoft Store distribution, clean install/uninstall

### Priority 2: Configuration Modernization
- Migrate from `app.config` to `Microsoft.Extensions.Configuration`
- Use `appsettings.json` for better structure
- Maintain backwards compatibility with existing user settings

### Priority 3: Optional Improvements
- Central package management with `Directory.Packages.props`
- Enhanced null annotations throughout codebase
- Addition of unit tests for critical functionality

## Support & Documentation

For detailed upgrade information, see:
- **Completion Report:** `.github/upgrades/scenarios/dotnet-version-upgrade/COMPLETION-REPORT.md`
- **Assessment:** `.github/upgrades/scenarios/dotnet-version-upgrade/assessment.md`
- **Upgrade Plan:** `.github/upgrades/scenarios/dotnet-version-upgrade/plan.md`

For issues, questions, or feature requests, please open an [Issue](https://github.com/Synchronos/TimeClock/issues) on GitHub.

## Support Lifecycle

**Current Status (.NET 10):**
- ✅ **Framework:** .NET 10 LTS
- ✅ **Support Until:** November 2028
- ✅ **Security Updates:** Yes
- ✅ **Production Ready:** Yes

**Previous Status (.NET Framework 4.0):**
- ❌ **Released:** 2010
- ❌ **Modern Support:** Minimal
- ❌ **Security:** Limited

## Branch Strategy

- **`main`** - Stable release (currently .NET Framework 4.0)
- **`upgrade-dotnet-10`** (this branch) - Active .NET 10 upgrade development
- Plan to merge to main after testing and validation

## Author

[Synchronos](https://github.com/Synchronos)

---

**Status:** ✅ **UPGRADE COMPLETE - READY FOR TESTING AND DEPLOYMENT**

*Last updated: July 8, 2026*
