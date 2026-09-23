using DVLD.PL.ControlsTheme;

namespace DVLD.PL.Theme;

public class CustomDarkThemeProvider : IThemeProvider
{
    private readonly Theme _theme;

    public CustomDarkThemeProvider(ThemePreferences? prefs = null)
    {
        prefs ??= ThemePreferences.CreateDefaultDark();
        _theme = BuildCustomizedTheme(prefs);
    }

    private static Theme BuildCustomizedTheme(ThemePreferences prefs)
    {
        Color bg = prefs.DarkTone switch
        {
            enDarkTone.OledBlack => Color.FromArgb(0, 0, 0),
            enDarkTone.MidnightNavy => Color.FromArgb(10, 15, 30),
            enDarkTone.Charcoal => Color.FromArgb(24, 24, 27),
            _ => Color.FromArgb(15, 23, 42)
        };

        Color surface = prefs.DarkTone switch
        {
            enDarkTone.OledBlack => Color.FromArgb(18, 18, 18),
            enDarkTone.MidnightNavy => Color.FromArgb(20, 28, 48),
            enDarkTone.Charcoal => Color.FromArgb(39, 39, 42),
            _ => Color.FromArgb(30, 41, 59)
        };

        Color border = prefs.DarkTone switch
        {
            enDarkTone.OledBlack => Color.FromArgb(38, 38, 38),
            enDarkTone.MidnightNavy => Color.FromArgb(35, 45, 75),
            enDarkTone.Charcoal => Color.FromArgb(63, 63, 70),
            _ => Color.FromArgb(51, 65, 85)
        };

        Color accent = prefs.AccentColor;
        Color accentHover = ColorMathHelper.Lighten(accent, 0.18f);
        Color accentPressed = ColorMathHelper.Darken(accent, 0.18f);

        int rowHeight = prefs.Density switch
        {
            enUIDensity.Compact => 30,
            enUIDensity.Relaxed => 44,
            _ => 36
        };

        int headerHeight = prefs.Density switch
        {
            enUIDensity.Compact => 36,
            enUIDensity.Relaxed => 48,
            _ => 42
        };

        int radius = prefs.BorderRadius;
        bool shadows = !prefs.PerformanceMode;
        bool animations = !prefs.PerformanceMode;

        Color btnStart = accent;
        Color btnEnd = prefs.ButtonStyle == enButtonStyleMode.Gradient
            ? ColorMathHelper.Darken(accent, 0.15f)
            : accent;

        return new Theme
        {
            Colors = new ThemeColors
            {
                Primary = accent,
                PrimaryHover = accentHover,
                PrimaryPressed = accentPressed,
                Background = bg,
                Surface = surface,
                Border = border,
                BorderHover = accent,
                TextPrimary = Color.FromArgb(241, 245, 249),
                TextSecondary = Color.FromArgb(148, 163, 184),
                TextMuted = Color.FromArgb(100, 116, 139),
                Success = Color.FromArgb(16, 185, 129),
                Danger = Color.FromArgb(239, 68, 68),
                DangerHover = Color.FromArgb(248, 113, 113),
                DangerPressed = Color.FromArgb(220, 38, 38),
                Warning = Color.FromArgb(245, 158, 11),
                Info = Color.FromArgb(14, 165, 233),
                DisabledBackground = surface,
                DisabledText = Color.FromArgb(100, 116, 139),
                SelectionBackground = ColorMathHelper.WithAlpha(accent, 60),
                SelectionText = Color.White
            },
            Common = new CommonTheme
            {
                FontFamily = prefs.FontFamily,
                DefaultFontSize = prefs.FontSize,
                DefaultBorderRadius = radius,
                DefaultBorderSize = 1,
                EnableAnimations = animations,
                EnableRippleEffects = animations,
                EnableShadows = shadows
            },
            Form = new FormTheme
            {
                Background = bg,
                Foreground = Color.FromArgb(241, 245, 249),
                BorderColor = border,
                BorderSize = 1,
                HeaderBackground = surface,
                HeaderForeground = Color.FromArgb(241, 245, 249),
                HeaderBorderColor = border,
                CloseButtonHoverColor = Color.FromArgb(239, 68, 68),
                CloseButtonPressedColor = Color.FromArgb(185, 28, 28),
                WindowControlHoverColor = border,
                WindowControlPressedColor = surface
            },
            Buttons = new ButtonThemes
            {
                Primary = new ButtonTheme
                {
                    BackgroundStartColor = btnStart,
                    BackgroundEndColor = btnEnd,
                    HoverStartColor = accentHover,
                    HoverEndColor = accent,
                    PressedStartColor = accentPressed,
                    PressedEndColor = ColorMathHelper.Darken(accentPressed, 0.1f),
                    DisabledStartColor = surface,
                    DisabledEndColor = surface,
                    GradientAngle = 90f,
                    TextColor = Color.White,
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = accentHover,
                    HoverBorderColor = ColorMathHelper.Lighten(accentHover, 0.15f),
                    DisabledBorderColor = border,
                    EnableShadow = shadows,
                    ShadowSize = 4,
                    ShadowOffset = new Point(0, 2),
                    ShadowColor = Color.FromArgb(60, 0, 0, 0),
                    EnableHoverAnimation = animations,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = animations,
                    RippleColor = Color.FromArgb(60, 255, 255, 255),
                    RippleSpeed = 10
                },
                Secondary = new ButtonTheme
                {
                    BackgroundStartColor = border,
                    BackgroundEndColor = prefs.ButtonStyle == enButtonStyleMode.Gradient ? surface : border,
                    HoverStartColor = ColorMathHelper.Lighten(border, 0.15f),
                    HoverEndColor = border,
                    PressedStartColor = surface,
                    PressedEndColor = bg,
                    DisabledStartColor = surface,
                    DisabledEndColor = surface,
                    GradientAngle = 90f,
                    TextColor = Color.FromArgb(241, 245, 249),
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = border,
                    HoverBorderColor = ColorMathHelper.Lighten(border, 0.2f),
                    DisabledBorderColor = border,
                    EnableShadow = false,
                    EnableHoverAnimation = animations,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = animations,
                    RippleColor = Color.FromArgb(40, 255, 255, 255),
                    RippleSpeed = 10
                },
                Danger = new ButtonTheme
                {
                    BackgroundStartColor = Color.FromArgb(220, 38, 38),
                    BackgroundEndColor = prefs.ButtonStyle == enButtonStyleMode.Gradient ? Color.FromArgb(185, 28, 28) : Color.FromArgb(220, 38, 38),
                    HoverStartColor = Color.FromArgb(239, 68, 68),
                    HoverEndColor = Color.FromArgb(220, 38, 38),
                    PressedStartColor = Color.FromArgb(153, 27, 27),
                    PressedEndColor = Color.FromArgb(127, 29, 29),
                    DisabledStartColor = surface,
                    DisabledEndColor = surface,
                    GradientAngle = 90f,
                    TextColor = Color.White,
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = Color.FromArgb(248, 113, 113),
                    HoverBorderColor = Color.FromArgb(252, 165, 165),
                    DisabledBorderColor = border,
                    EnableShadow = shadows,
                    ShadowSize = 4,
                    ShadowOffset = new Point(0, 2),
                    ShadowColor = Color.FromArgb(60, 0, 0, 0),
                    EnableHoverAnimation = animations,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = animations,
                    RippleColor = Color.FromArgb(60, 255, 255, 255),
                    RippleSpeed = 10
                },
                Disabled = new ButtonTheme
                {
                    BackgroundStartColor = surface,
                    BackgroundEndColor = surface,
                    TextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = border,
                    DisabledBorderColor = border,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    DisabledStartColor = surface,
                    DisabledEndColor = surface
                }
            },
            TextBox = new TextBoxTheme
            {
                Background = surface,
                DisabledBackground = bg,
                BorderColor = border,
                FocusBorderColor = accent,
                DisabledBorderColor = surface,
                ErrorBorderColor = Color.FromArgb(239, 68, 68),
                TextColor = Color.FromArgb(241, 245, 249),
                PlaceholderColor = Color.FromArgb(100, 116, 139),
                BorderRadius = radius,
                BorderSize = 1,
                EnableIconTinting = true,
                IconColor = Color.FromArgb(148, 163, 184),
                HoverIconColor = accent,
                ClearButtonColor = Color.FromArgb(148, 163, 184),
                ClearButtonHoverColor = Color.FromArgb(239, 68, 68),
                SuggestBackground = surface,
                SuggestTextColor = Color.FromArgb(241, 245, 249),
                SuggestHoverColor = border,
                SuggestBorderColor = ColorMathHelper.Lighten(border, 0.15f),
            },
            CheckBox = new CheckBoxTheme
            {
                BoxBackground = surface,
                BoxBorder = border,
                CheckedColor = accent,
                HoverBorderColor = accentHover,
                DisabledColor = border,
                CheckMarkColor = Color.White,
                DisabledTextColor = Color.FromArgb(100, 116, 139),
                SwitchOffTrackColor = border,
                SwitchThumbColor = Color.FromArgb(241, 245, 249),
                TextColor = Color.FromArgb(241, 245, 249),
                CheckThickness = 2.0f,
                BorderRadius = Math.Min(4, radius),
                BorderSize = 1,
                EnableAnimation = animations,
                AnimationSpeed = 15,
                EnableRipple = animations,
                RippleColor = ColorMathHelper.WithAlpha(accent, 40)
            },
            ComboBox = new ComboBoxTheme
            {
                Background = surface,
                Foreground = Color.FromArgb(241, 245, 249),
                BorderColor = border,
                HoverColor = ColorMathHelper.Lighten(border, 0.15f),
                FocusColor = accent,
                DropDownBackground = surface,
                DropDownForeground = Color.FromArgb(241, 245, 249),
                DropDownHoverBackground = border,
                DropDownHoverForeground = Color.White,
                DisabledBackground = bg,
                DisabledForeground = Color.FromArgb(100, 116, 139),
                BorderSize = 1,
                BorderRadius = radius
            },
            DataGrid = new DataGridTheme
            {
                Background = bg,
                BorderColor = border,
                GridColor = surface,
                HeaderBackground = surface,
                HeaderForeground = Color.FromArgb(241, 245, 249),
                HeaderSelectionBackground = border,
                HeaderSelectionForeground = Color.White,
                CellBackground = bg,
                CellForeground = Color.FromArgb(226, 232, 240),
                AlternatingRowBackground = prefs.EnableAlternatingRows ? ColorMathHelper.Lighten(bg, 0.05f) : bg,
                AlternatingRowForeground = Color.FromArgb(226, 232, 240),
                SelectionBackground = ColorMathHelper.WithAlpha(accent, 60),
                SelectionForeground = Color.White,
                BorderSize = 1
            },
            Label = new LabelTheme
            {
                PrimaryColor = Color.FromArgb(241, 245, 249),
                SecondaryColor = Color.FromArgb(148, 163, 184),
                MutedColor = Color.FromArgb(100, 116, 139),
                SuccessColor = Color.FromArgb(16, 185, 129),
                DangerColor = Color.FromArgb(239, 68, 68),
                WarningColor = Color.FromArgb(245, 158, 11),
                InfoColor = Color.FromArgb(14, 165, 233),
                DisabledColor = Color.FromArgb(100, 116, 139),
                LinkColor = accentHover,
                LinkHoverColor = ColorMathHelper.Lighten(accentHover, 0.15f)
            },
            Panel = new PanelTheme
            {
                Background = surface,
                Foreground = Color.FromArgb(241, 245, 249),
            },
            ToolStrip = new ToolStripTheme
            {
                Background = surface,
                Foreground = Color.FromArgb(241, 245, 249),
                BorderColor = border,
                ItemBackground = surface,
                ItemForeground = Color.FromArgb(241, 245, 249),
                ItemHoverBackground = border,
                ItemHoverForeground = Color.White,
                ItemPressedBackground = ColorMathHelper.Lighten(border, 0.15f),
                ItemPressedForeground = Color.White,
                DisabledForeground = Color.FromArgb(100, 116, 139),
                SeparatorColor = border,
                AccentColor = accent,
                Borderless = true
            },
            Menu = new MenuTheme
            {
                Background = surface,
                Border = border,
                ItemBackground = surface,
                ItemText = Color.FromArgb(241, 245, 249),
                ItemHoverBackground = border,
                ItemHoverText = Color.White,
                ItemPressedBackground = ColorMathHelper.Lighten(border, 0.15f),
                ItemPressedText = Color.White,
                DisabledText = Color.FromArgb(100, 116, 139),
                Separator = border,
                Accent = accent,
                Arrow = Color.FromArgb(148, 163, 184),
                DangerText = Color.FromArgb(248, 113, 113),
                DangerHoverBackground = Color.FromArgb(153, 27, 27),
                BorderSize = 1,
                ItemHorizontalPadding = 12,
                ItemVerticalPadding = 8,
                SeparatorHeight = 1,
                AccentSize = 3
            },
            Notification = new NotificationTheme
            {
                Background = surface,
                TextColor = Color.FromArgb(241, 245, 249),
                BorderColor = border,
                SuccessColor = Color.FromArgb(16, 185, 129),
                DangerColor = Color.FromArgb(239, 68, 68),
                WarningColor = Color.FromArgb(245, 158, 11),
                InfoColor = Color.FromArgb(14, 165, 233),
                ProgressBarColor = accent,
                TitleFontSize = prefs.FontSize + 1.5f,
                MessageFontSize = prefs.FontSize,
                BorderSize = 1,
                BorderRadius = radius + 2,
                Padding = new Padding(12)
            }
        };
    }

    public Theme BuildTheme() => _theme;
    public ThemeColors GetThemeColors() => _theme.Colors;
    public CommonTheme GetCommonTheme() => _theme.Common;
    public FormTheme GetFormTheme() => _theme.Form;
    public ButtonThemes GetButtonThemes() => _theme.Buttons;
    public TextBoxTheme GetTextBoxTheme() => _theme.TextBox;
    public CheckBoxTheme GetCheckBoxTheme() => _theme.CheckBox;
    public ComboBoxTheme GetComboBoxTheme() => _theme.ComboBox;
    public DataGridTheme GetDataGridTheme() => _theme.DataGrid;
    public LabelTheme GetLabelTheme() => _theme.Label;
    public PanelTheme GetPanelTheme() => _theme.Panel;
    public ToolStripTheme GetToolStripTheme() => _theme.ToolStrip;
    public MenuTheme GetMenuTheme() => _theme.Menu;
    public NotificationTheme GetNotificationTheme() => _theme.Notification;
}