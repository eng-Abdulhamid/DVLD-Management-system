using System.Drawing;

namespace DVLD.PL.ControlsTheme;

public sealed class ButtonTheme
{
    public Color BackgroundStartColor { get; init; }
    public Color BackgroundEndColor { get; init; }
    public Color HoverStartColor { get; init; }
    public Color HoverEndColor { get; init; }
    public Color PressedStartColor { get; init; }
    public Color PressedEndColor { get; init; }
    public Color DisabledStartColor { get; init; }
    public Color DisabledEndColor { get; init; }
    public float GradientAngle { get; init; }

    public Color TextColor { get; init; }
    public Color HoverTextColor { get; init; }
    public Color DisabledTextColor { get; init; }

    public int BorderRadius { get; init; }
    public int BorderSize { get; init; }
    public Color BorderColor { get; init; }
    public Color HoverBorderColor { get; init; }
    public Color DisabledBorderColor { get; init; }

    public bool EnableIconTinting { get; init; }
    public Color IconColor { get; init; }
    public Color HoverIconColor { get; init; }

    public bool EnableShadow { get; init; }
    public int ShadowSize { get; init; }
    public Point ShadowOffset { get; init; }
    public Color ShadowColor { get; init; }

    public bool EnableHoverAnimation { get; init; }
    public int HoverAnimationSpeed { get; init; }
    public bool ShiftOnPress { get; init; }

    public bool EnableRippleEffect { get; init; }
    public Color RippleColor { get; init; }
    public int RippleSpeed { get; init; }
}