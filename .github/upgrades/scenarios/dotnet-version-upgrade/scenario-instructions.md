# .NET Version Upgrade: .NET Framework 4.0 → .NET 10 LTS

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net10.0 (LTS — Support ends Nov 2028)

## Source Control
- **Source Branch**: main
- **Working Branch**: upgrade-dotnet-10
- **Commit Strategy**: After Each Task
- **Branch Sync**: Auto (Merge)

## Upgrade Options
**Source**: .github/upgrades/scenarios/dotnet-version-upgrade/upgrade-options.md

### Strategy
- Upgrade Strategy: Bottom-Up

### Project Structure
- Project Approach: In-place
- Package Management: Per-Project (defer CPM to post-migration)

### Compatibility
- Unsupported API Handling: Ship-Stopper Mode
- Windows Native APIs: net10.0-windows

### Modernization
- Configuration Migration: Migrate to Microsoft.Extensions.Configuration
- Assembly Binding Redirects: Remove (automatic assembly unification)
- Nullable Reference Types: Enable

## Post-Upgrade Considerations
- **MSIX Packaging**: Will be addressed after the core .NET upgrade is complete. MSIX requires .NET 6+ and will be added as a follow-on modernization step.
