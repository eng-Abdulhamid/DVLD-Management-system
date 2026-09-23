using System;
using System.IO;

namespace DVLD.PL.Theme;

public sealed class ThemeSettingsStore : JsonSettingsStore<ThemeAppSettings>
{
    private static readonly string DefaultThemePath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings", "theme.json");

    public ThemeSettingsStore() : base(DefaultThemePath)
    {
    }

    public ThemeSettingsStore(string customPath) : base(customPath)
    {
    }
}