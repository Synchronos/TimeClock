# Upgrade Options — TimeClock

Assessment: 2 projects (both .NET Framework 4.0), 1,782+ LOC to modify, Windows Forms desktop applications, non-SDK-style projects

## Strategy

### Upgrade Strategy
Assessment shows 2 .NET Framework 4.0 projects. Bottom-Up strategy ensures proper validation at each tier when crossing the Framework→modern .NET boundary.

| Value | Description |
|-------|-------------|
| **Bottom-Up** (selected) | Upgrade leaf libraries first, then work upward through dependency graph tier by tier with validation at each level |

## Project Structure

### Project Approach
Both projects are Windows Forms desktop applications (not web projects). In-place migration is appropriate for this scenario.

| Value | Description |
|-------|-------------|
| **In-place** (selected) | Replace .NET Framework 4.0 target with net10.0-windows directly. Clean upgrade path for desktop applications |
| Multi-targeting | Add net10.0-windows alongside net40 temporarily. Adds complexity without benefit for desktop apps not serving as shared libraries |

### Package Management
Assessment shows non-SDK-style projects crossing Framework→modern .NET boundary. Deferring CPM avoids VersionOverride friction during the active migration.

| Value | Description |
|-------|-------------|
| **Per-Project (defer CPM to post-migration)** (selected) | Each project manages its own package versions during migration. CPM setup will be recommended as a post-migration cleanup step when all projects are SDK-style and on net10.0 |
| Central Package Management (CPM) | Create Directory.Packages.props now. May require VersionOverride usage during multi-step migration from old-style Framework projects |

## Compatibility

### Unsupported API Handling
Assessment shows 1,620 binary incompatible APIs and 162 source incompatible APIs, primarily Windows Forms and System.Drawing.

| Value | Description |
|-------|-------------|
| **Ship-Stopper Mode** (selected) | Treat all incompatible APIs as blocking issues. Fix each occurrence before continuing. Ensures code quality and eliminates technical debt |
| Progressive Mode | Document incompatible APIs for later. Complete TFM upgrade first, address API issues incrementally. Faster but leaves technical debt |

### Windows Native APIs
Assessment shows heavy Windows Forms (90.9% of issues) and System.Drawing usage (8.2% of issues). Target platform restriction required.

| Value | Description |
|-------|-------------|
| **net10.0-windows** (selected) | Add -windows suffix to TFM. Enables Windows Desktop SDK with Windows Forms, WPF support. Required for this application |
| Use Windows Compatibility Pack | Add Microsoft.Windows.Compatibility package. Not applicable - already using net10.0-windows which includes required APIs |

## Modernization

### Configuration Migration
Assessment shows legacy app.config usage (0.7% of codebase issues).

| Value | Description |
|-------|-------------|
| **Migrate to Microsoft.Extensions.Configuration** (selected) | Replace System.Configuration with modern configuration system. Better flexibility and testability |
| Keep System.Configuration | Use System.Configuration.ConfigurationManager NuGet package as bridge. Minimal changes but stays on legacy system |

### Assembly Binding Redirects
Assessment shows 2 binding redirect issues detected.

| Value | Description |
|-------|-------------|
| **Remove (automatic assembly unification)** (selected) | Delete assemblyBinding entries. .NET handles version unification automatically. Simplifies configuration |
| Preserve binding redirects | Keep existing assemblyBinding configuration. May be unnecessary on modern .NET |

### Nullable Reference Types
Target is net10.0 and projects use C#. Nullable reference types improve code safety.

| Value | Description |
|-------|-------------|
| **Enable** (selected) | Add &lt;Nullable&gt;enable&lt;/Nullable&gt; to projects. Improves code quality with compiler-enforced null safety. Address warnings incrementally |
| Defer | Skip nullable migration during TFM upgrade. Can enable later as a separate modernization step |
