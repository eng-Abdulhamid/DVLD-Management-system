
namespace DVLD.PL.Theme;

public enum enDarkTone
{
    DeepSlate,
    OledBlack,
    MidnightNavy,
    Charcoal
}

public enum enLightTone
{
    SnowGray,
    PureWhite,
    WarmPaper
}

public enum enUIDensity
{
    Compact,
    Normal,
    Relaxed
}

public enum enButtonStyleMode
{
    Flat,
    Gradient
}

public sealed class ThemePreferences
{
    public Color AccentColor { get; set; } = Color.FromArgb(99, 102, 241);
    public int BorderRadius { get; set; } = 8;
    public string FontFamily { get; set; } = "Segoe UI";
    public float FontSize { get; set; } = 9.5f;

    public enDarkTone DarkTone { get; set; } = enDarkTone.DeepSlate;
    public enLightTone LightTone { get; set; } = enLightTone.SnowGray;
    public enButtonStyleMode ButtonStyle { get; set; } = enButtonStyleMode.Gradient;
    public enUIDensity Density { get; set; } = enUIDensity.Normal;

    public bool PerformanceMode { get; set; } = false;
    public bool EnableAlternatingRows { get; set; } = true;

    public static ThemePreferences CreateDefaultDark() => new()
    {
        AccentColor = Color.FromArgb(99, 102, 241),
        DarkTone = enDarkTone.DeepSlate,
        BorderRadius = 8,
        ButtonStyle = enButtonStyleMode.Gradient
    };

    public static ThemePreferences CreateDefaultLight() => new()
    {
        AccentColor = Color.FromArgb(99, 102, 241),
        LightTone = enLightTone.SnowGray,
        BorderRadius = 8,
        ButtonStyle = enButtonStyleMode.Gradient
    };
}