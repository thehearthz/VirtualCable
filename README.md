# VirtualCable for Jellyfin

Create custom or auto-generated live TV channels using your Jellyfin media library.
Supports commercials, pre-rolls, and time-based scheduling.

## Installation

1. Clone this repo
2. Build:
   ```bash
   dotnet restore
   dotnet build -c Release
   ```
3. Copy DLL to Jellyfin plugin folder:
   ```
   /var/lib/jellyfin/plugins/VirtualCable/
   ```
4. Restart Jellyfin and enable plugin in Dashboard.

---
Version 1.0.0 | Compatible with Jellyfin 10.10.7
