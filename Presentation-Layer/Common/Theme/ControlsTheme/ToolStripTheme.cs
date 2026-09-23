namespace DVLD.PL.ControlsTheme;

public sealed class ToolStripTheme
{
    public Color Background { get; init; }
    public Color Foreground { get; init; }
    public Color BorderColor { get; init; }

    public Color ItemBackground { get; init; }
    public Color ItemForeground { get; init; }
    public Color ItemHoverBackground { get; init; }
    public Color ItemHoverForeground { get; init; }
    public Color ItemPressedBackground { get; init; }
    public Color ItemPressedForeground { get; init; }
    public Color DisabledForeground { get; init; }

    public Color SeparatorColor { get; init; }
    public Color AccentColor { get; init; }
    public bool Borderless { get; init; }
}