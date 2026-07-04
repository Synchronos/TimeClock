# Upgrade Plan: .NET Framework 4.0 → .NET 10 LTS

## Overview

**Target**: Upgrade TimeClock solution from .NET Framework 4.0 to .NET 10 (LTS)

**Projects**: 2 Windows Forms desktop applications
- TimeclockControls.csproj (Tier 1 - leaf library)
- Timeclock.csproj (Tier 2 - main application)

**Estimated Impact**: 1,782+ lines of code requiring modification (49.1% of codebase)

## Selected Strategy

**Bottom-Up (Dependency-First)** — Upgrade from leaf nodes to root applications, tier by tier.

**Rationale**: 2 projects with 2-tier dependency graph. Framework→modern .NET boundary requires different upgrade mechanics per layer; tier-by-tier validation ensures stability.

## Dependency Graph

```
Tier 2: [Timeclock] (Windows Forms Application)
		 ↓
Tier 1: [TimeclockControls] (Windows Forms Control Library)
```

## Tasks

### 01 - Prerequisites and Environment Setup

Verify that the development environment is ready for .NET 10 upgrade.

**Scope**:
- Verify .NET 10 SDK is installed and available
- Check global.json compatibility (validate if one exists)
- Ensure Visual Studio supports .NET 10 development
- Verify build tools and MSBuild version compatibility

**Done when**:
- [ ] .NET 10 SDK verified (dotnet --list-sdks shows 10.x)
- [ ] No global.json conflicts preventing .NET 10 targeting
- [ ] Build environment validated

---

### 02 - Convert Projects to SDK-Style Format

Convert both projects from legacy csproj format to modern SDK-style on current TFM (net40).

**Scope**:
- Convert TimeclockControls.csproj to SDK-style while staying on net40
- Convert Timeclock.csproj to SDK-style while staying on net40
- Migrate any packages.config to PackageReference
- Preserve all project capabilities (Windows Forms, resources, etc.)

**Rationale**: SDK-style conversion is a structural change that must be separated from TFM upgrade. Keeping projects on net40 during conversion isolates any SDK-style conversion issues from API compatibility issues.

**Done when**:
- [ ] Both projects use SDK-style format
- [ ] No packages.config files remain (all use PackageReference)
- [ ] Projects build successfully on net40
- [ ] All existing functionality preserved

---

### 03 - Upgrade Tier 1: TimeclockControls Library

Upgrade the leaf library (TimeclockControls) to net10.0-windows.

**Scope**:
- Update TimeclockControls.csproj TFM from net40 to net10.0-windows
- Update/add required NuGet packages (System.Drawing.Common if needed)
- Fix all API compatibility issues specific to this library:
  - 875 binary incompatible APIs
  - Windows Forms control implementations
  - System.Drawing usage
- Verify tier builds and tests pass
- **Between-tier validation**: Confirm Tier 2 (Timeclock) still builds on net40

**Technology migration notes**:
- Windows Forms desktop support enabled via net10.0-windows TFM
- System.Drawing available via System.Drawing.Common package
- Legacy controls (if any) require replacement with modern equivalents

**Done when**:
- [ ] TFM updated to net10.0-windows
- [ ] All 875+ API issues resolved
- [ ] Project builds warning-free
- [ ] Tier 2 (Timeclock on net40) still builds successfully

---

### 04 - Upgrade Tier 2: Timeclock Application

Upgrade the root application (Timeclock) to net10.0-windows.

**Scope**:
- Update Timeclock.csproj TFM from net40 to net10.0-windows
- Update/add required NuGet packages
- Fix all API compatibility issues specific to this application:
  - 907 binary incompatible APIs
  - Windows Forms UI code
  - System.Drawing usage
  - Legacy configuration system (app.config) migration
- Implement configuration migration:
  - Replace System.Configuration with Microsoft.Extensions.Configuration
  - Migrate app.config settings to modern configuration system
- Remove assembly binding redirects (automatic unification on .NET 10)
- Verify application builds and runs

**Technology migration notes**:
- Windows Forms desktop support enabled via net10.0-windows TFM
- Configuration: migrate from app.config to Microsoft.Extensions.Configuration
- Binding redirects: .NET handles assembly unification automatically

**Done when**:
- [ ] TFM updated to net10.0-windows
- [ ] All 907+ API issues resolved
- [ ] Configuration migrated to Microsoft.Extensions.Configuration
- [ ] Assembly binding redirects removed
- [ ] Application builds warning-free
- [ ] Application starts and basic functionality verified

---

### 05 - Enable Nullable Reference Types

Enable nullable reference types across both projects to improve code safety.

**Scope**:
- Add `<Nullable>enable</Nullable>` to both project files
- Address nullable warnings incrementally in critical code paths
- Document remaining warnings for future cleanup

**Rationale**: Nullable reference types provide compile-time null safety. Enabled after TFM upgrade to avoid mixing modernization concerns.

**Done when**:
- [ ] Nullable enabled in both projects
- [ ] Critical path nullable warnings resolved
- [ ] Projects build (warnings documented, not required to be zero)

---

### 06 - Final Validation and Documentation

Validate the complete solution and document post-upgrade recommendations.

**Scope**:
- Full solution build validation
- Run all tests (if test projects exist)
- Functional smoke testing of the application
- Performance comparison (startup time, memory usage)
- Document deferred modernizations:
  - Central Package Management (CPM) - appropriate now that both projects are SDK-style on net10.0
  - MSIX packaging setup (user requested)
  - Any remaining nullable warnings cleanup
  - Legacy Windows Forms controls modernization (if applicable)

**Done when**:
- [ ] Full solution builds without errors
- [ ] All tests pass
- [ ] Application runs and core features work correctly
- [ ] Performance is acceptable or improved
- [ ] Deferred recommendations documented

---

## Post-Upgrade Recommendations

After completing the core upgrade:

1. **Central Package Management** - Now that all projects are SDK-style on a single TFM, CPM can be added cleanly without VersionOverride friction
2. **MSIX Packaging** - Create MSIX installer for modern Windows deployment
3. **Nullable warnings** - Address remaining nullable reference type warnings
4. **Legacy controls audit** - Review for any legacy Windows Forms controls that could be modernized

## Risk Mitigation

- SDK-style conversion separated from TFM upgrade to isolate failure modes
- Bottom-Up strategy ensures each tier is stable before proceeding
- Between-tier validation catches breaking changes early
- All warnings treated as errors to prevent technical debt
