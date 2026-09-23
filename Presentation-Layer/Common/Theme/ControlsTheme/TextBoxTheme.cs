namespace DVLD.PL.ControlsTheme;

public sealed class TextBoxTheme
{
    public Color Background { get; init; }
    public Color DisabledBackground { get; init; }
    public Color BorderColor { get; init; }
    public Color FocusBorderColor { get; init; }
    public Color DisabledBorderColor { get; init; }
    public Color ErrorBorderColor { get; init; }
    public Color TextColor { get; init; }
    public Color PlaceholderColor { get; init; }

    public int BorderRadius { get; init; }
    public int BorderSize { get; init; }

    public bool EnableIconTinting { get; init; }
    public Color IconColor { get; init; }
    public Color HoverIconColor { get; init; }

    public Color ClearButtonColor { get; init; }
    public Color ClearButtonHoverColor { get; init; }

    public Color SuggestBackground { get; init; }
    public Color SuggestTextColor { get; init; }
    public Color SuggestHoverColor { get; init; }
    public Color SuggestBorderColor { get; init; }
}