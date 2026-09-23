using System;
using CustomizeControls;

namespace DVLD.PL.Theme;

public static class ThemeManager
{
    public static enMode Mode { get; private set; }
    private static IControlApplicator _currentApplicator =
        new ControlApplicator(new DefaultLightThemeProvider().BuildTheme());

    public static IControlApplicator Current => _currentApplicator;
    public static event EventHandler? ThemeChanged;

    public static void SetMode(enMode mode, ThemePreferences? customPreferences = null)
    {
        Mode = mode;
        IThemeProvider provider = mode switch
        {
            enMode.DefaultLight => new DefaultLightThemeProvider(),
            enMode.DefaultDark => new DefaultDarkThemeProvider(),
            enMode.CustomDark => new CustomDarkThemeProvider(customPreferences),
            enMode.CustomLight => new CustomLightThemeProvider(customPreferences),
            _ => new DefaultLightThemeProvider()
        };

        _currentApplicator = new ControlApplicator(provider.BuildTheme());
        ThemeChanged?.Invoke(null, EventArgs.Empty);
    }
}