# 02 - Convert Projects to SDK-Style Format: Convert Projects to SDK-Style Format

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
