# SavePreviewFix

Single-player module for Mount & Blade II: Bannerlord. It brings back the 3D character preview on the save/load screen, which in recent game versions (seen on v1.4.7 and v1.4.8) only shows a dark silhouette.

## What it does

- **Fixes the save/load preview**: Your character and horse are shown again instead of the placeholder silhouette, for every save.
- **Root cause**: In vanilla, the hero preview's texture provider is only created after the preview widget has been rendered once, but `SaveLoadMainHeroVisualWidget` keeps the preview hidden until that provider reports a compatible character code. Neither ever happens, so the silhouette is always shown. The mod shows the preview widget while its provider is missing, so the provider gets created and the vanilla logic takes over.
- **Respects vanilla**: The preview stays disabled where the game turns it off on purpose ("Save As" on the campaign map).

## Release contents

The build scripts produce a self-contained module in the `dist/SavePreviewFix` directory.

## Compatibility and dependencies

- Single-player only.
- Requires the **Harmony** module (`Bannerlord.Harmony`), loaded before this module.
- Changes only the save/load screen UI; does not touch saves or gameplay. Safe to add to or remove from existing saves.

## Build from WSL/Linux

You must provide the path to your Bannerlord installation using the `BANNERLORD_DIR` environment variable. With Mono installed, run:

```bash
chmod +x build-linux.sh
BANNERLORD_DIR="/path/to/Mount & Blade II Bannerlord" ./build-linux.sh
```

**Important note for WSL users:** Windows restricts executing `.dll` files generated or copied from WSL environments (Mark of the Web issue). After copying the module to your game directory on Windows, you must unblock the files. Open PowerShell and run:

```powershell
Get-ChildItem -Path "C:\Your\Path\To\Mount & Blade II Bannerlord\Modules\SavePreviewFix" -Recurse | Unblock-File
```

## Build from Windows

Run the PowerShell script. If your game is not in the default Steam directory, specify the `-BannerlordDir` parameter:

```powershell
.\build-windows.ps1 -BannerlordDir "\path\to\Mount & Blade II Bannerlord"
```

## Install

Copy the contents of `dist/SavePreviewFix` to:

```text
Mount & Blade II Bannerlord/Modules/SavePreviewFix
```

Then enable **SavePreviewFix** in the Bannerlord launcher, after **Harmony** and the official single-player modules.
