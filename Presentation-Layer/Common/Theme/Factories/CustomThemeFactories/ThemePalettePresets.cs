using System.Collections.Generic;
using System.Drawing;

namespace DVLD.PL.Theme;

public readonly record struct AccentColorPreset(string Name, Color Color);

public static class ThemePalettePresets
{
    public static readonly IReadOnlyList<AccentColorPreset> AccentPresets =
    [
        new("Indigo Modern", Color.FromArgb(99, 102, 241)),
        new("Royal Blue", Color.FromArgb(37, 99, 235)),
        new("Emerald Green", Color.FromArgb(16, 185, 129)),
        new("Crimson Rose", Color.FromArgb(244, 63, 94)),
        new("Violet Velvet", Color.FromArgb(139, 92, 246)),
        new("Amber Gold", Color.FromArgb(245, 158, 11)),
        new("Teal Cyan", Color.FromArgb(20, 184, 166)),
        new("Sunset Orange", Color.FromArgb(249, 115, 22))
    ];
}