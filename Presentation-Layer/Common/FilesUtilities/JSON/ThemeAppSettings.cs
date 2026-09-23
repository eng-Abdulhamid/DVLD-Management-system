using System.Drawing;

namespace DVLD.PL.Theme;

public sealed record ThemeAppSettings
{
    public enMode Mode { get; init; } = enMode.DefaultDark;
    public ThemePreferences Preferences { get; init; } = ThemePreferences.CreateDefaultDark();
}