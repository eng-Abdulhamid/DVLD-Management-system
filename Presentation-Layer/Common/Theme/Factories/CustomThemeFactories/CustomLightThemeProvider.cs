using System.Drawing;
using System.Windows.Forms;
using DVLD.PL.ControlsTheme;

namespace DVLD.PL.Theme;

public class CustomLightThemeProvider : IThemeProvider
{
    private readonly Theme _theme;

    public CustomLightThemeProvider(ThemePreferences? prefs = null)
    {
        prefs ??= ThemePreferences.CreateDefaultLight();
        _theme = BuildCustomizedTheme(prefs);
    }

    private static Theme BuildCustomizedTheme(ThemePreferences prefs)
    {
        Color bg = prefs.LightTone switch
        {
            enLightTone.PureWhite => Color.FromArgb(255, 255, 255),
            enLightTone.WarmPaper => Color.FromArgb(250, 248, 245),
            _ => Color.FromArgb(248, 250, 252)
        };

        Color surface = prefs.LightTone switch
        {
            enLightTone.PureWhite => Color.FromArgb(248, 250, 252),
            enLightTone.WarmPaper => Color.FromArgb(255, 255, 255),
            _ => Color.FromArgb(255, 255, 255)
        };

        Color border = prefs.LightTone switch
        {
            enLightTone.WarmPaper => Color.FromArgb(229, 224, 216),
            _ => Color.FromArgb(226, 232, 240)
        };

        Color accent = prefs.AccentColor;
        Color accentHover = ColorMathHelper.Darken(accent, 0.12f);
        Color accentPressed = ColorMathHelper.Darken(accent, 0.22f);

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
                TextPrimary = Color.FromArgb(15, 23, 42),
                TextSecondary = Color.FromArgb(71, 85, 105),
                TextMuted = Color.FromArgb(148, 163, 184),
                Success = Color.FromArgb(16, 185, 129),
                Danger = Color.FromArgb(239, 68, 68),
                DangerHover = Color.FromArgb(220, 38, 38),
                DangerPressed = Color.FromArgb(185, 28, 28),
                Warning = Color.FromArgb(245, 158, 11),
                Info = Color.FromArgb(14, 165, 233),
                DisabledBackground = Color.FromArgb(241, 245, 249),
                DisabledText = Color.FromArgb(148, 163, 184),
                SelectionBackground = ColorMathHelper.WithAlpha(accent, 40),
                SelectionText = ColorMathHelper.Darken(accent, 0.25f)
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
                Foreground = Color.FromArgb(15, 23, 42),
                BorderColor = border,
                BorderSize = 1,
                HeaderBackground = surface,
                HeaderForeground = Color.FromArgb(15, 23, 42),
                HeaderBorderColor = border,
                CloseButtonHoverColor = Color.FromArgb(239, 68, 68),
                CloseButtonPressedColor = Color.FromArgb(220, 38, 38),
                WindowControlHoverColor = Color.FromArgb(241, 245, 249),
                WindowControlPressedColor = Color.FromArgb(226, 232, 240)
            },
            Buttons = new ButtonThemes
            {
                Primary = new ButtonTheme
                {
                    BackgroundStartColor = btnStart,
                    BackgroundEndColor = btnEnd,
                    HoverStartColor = ColorMathHelper.Lighten(accent, 0.15f),
                    HoverEndColor = accent,
                    PressedStartColor = accentPressed,
                    PressedEndColor = ColorMathHelper.Darken(accentPressed, 0.1f),
                    DisabledStartColor = Color.FromArgb(241, 245, 249),
                    DisabledEndColor = Color.FromArgb(241, 245, 249),
                    GradientAngle = 90f,
                    TextColor = Color.White,
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(148, 163, 184),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = ColorMathHelper.Darken(accent, 0.1f),
                    HoverBorderColor = accent,
                    DisabledBorderColor = border,
                    EnableShadow = shadows,
                    ShadowSize = 3,
                    ShadowOffset = new Point(0, 2),
                    ShadowColor = ColorMathHelper.WithAlpha(accent, 45),
                    EnableHoverAnimation = animations,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = animations,
                    RippleColor = Color.FromArgb(60, 255, 255, 255),
                    RippleSpeed = 10
                },
                Secondary = new ButtonTheme
                {
                    BackgroundStartColor = Color.White,
                    BackgroundEndColor = prefs.ButtonStyle == enButtonStyleMode.Gradient ? Color.FromArgb(248, 250, 252) : Color.White,
                    HoverStartColor = Color.FromArgb(241, 245, 249),
                    HoverEndColor = Color.FromArgb(241, 245, 249),
                    PressedStartColor = Color.FromArgb(226, 232, 240),
                    PressedEndColor = Color.FromArgb(226, 232, 240),
                    DisabledStartColor = Color.FromArgb(241, 245, 249),
                    DisabledEndColor = Color.FromArgb(241, 245, 249),
                    GradientAngle = 90f,
                    TextColor = Color.FromArgb(51, 65, 85),
                    HoverTextColor = Color.FromArgb(15, 23, 42),
                    DisabledTextColor = Color.FromArgb(148, 163, 184),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = border,
                    HoverBorderColor = ColorMathHelper.Darken(border, 0.15f),
                    DisabledBorderColor = border,
                    EnableShadow = false,
                    EnableHoverAnimation = animations,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = animations,
                    RippleColor = Color.FromArgb(30, 0, 0, 0),
                    RippleSpeed = 10
                },
                Danger = new ButtonTheme
                {
                    BackgroundStartColor = Color.FromArgb(239, 68, 68),
                    BackgroundEndColor = prefs.ButtonStyle == enButtonStyleMode.Gradient ? Color.FromArgb(220, 38, 38) : Color.FromArgb(239, 68, 68),
                    HoverStartColor = Color.FromArgb(248, 113, 113),
                    HoverEndColor = Color.FromArgb(239, 68, 68),
                    PressedStartColor = Color.FromArgb(185, 28, 28),
                    PressedEndColor = Color.FromArgb(153, 27, 27),
                    DisabledStartColor = Color.FromArgb(241, 245, 249),
                    DisabledEndColor = Color.FromArgb(241, 245, 249),
                    GradientAngle = 90f,
                    TextColor = Color.White,
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(148, 163, 184),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = Color.FromArgb(220, 38, 38),
                    HoverBorderColor = Color.FromArgb(239, 68, 68),
                    DisabledBorderColor = border,
                    EnableShadow = shadows,
                    ShadowSize = 3,
                    ShadowOffset = new Point(0, 2),
                    ShadowColor = Color.FromArgb(35, 220, 38, 38),
                    EnableHoverAnimation = animations,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = animations,
                    RippleColor = Color.FromArgb(60, 255, 255, 255),
                    RippleSpeed = 10
                },
                Disabled = new ButtonTheme
                {
                    BackgroundStartColor = Color.FromArgb(241, 245, 249),
                    BackgroundEndColor = Color.FromArgb(241, 245, 249),
                    TextColor = Color.FromArgb(148, 163, 184),
                    BorderRadius = radius,
                    BorderSize = 1,
                    BorderColor = border,
                    DisabledBorderColor = border,
                    DisabledTextColor = Color.FromArgb(148, 163, 184),
                    DisabledStartColor = Color.FromArgb(241, 245, 249),
                    DisabledEndColor = Color.FromArgb(241, 245, 249)
                }
            },
            TextBox = new TextBoxTheme
            {
                Background = surface,
                DisabledBackground = Color.FromArgb(248, 250, 252),
                BorderColor = border,
                FocusBorderColor = accent,
                DisabledBorderColor = border,
                ErrorBorderColor = Color.FromArgb(239, 68, 68),
                TextColor = Color.FromArgb(15, 23, 42),
                PlaceholderColor = Color.FromArgb(148, 163, 184),
                BorderRadius = radius,
                BorderSize = 1,
                EnableIconTinting = true,
                IconColor = Color.FromArgb(100, 116, 139),
                HoverIconColor = Color.FromArgb(15, 23, 42),
                ClearButtonColor = Color.FromArgb(148, 163, 184),
                ClearButtonHoverColor = Color.FromArgb(239, 68, 68),
                SuggestBackground = surface,
                SuggestTextColor = Color.FromArgb(15, 23, 42),
                SuggestHoverColor = ColorMathHelper.WithAlpha(accent, 25),
                SuggestBorderColor = border
            },
            CheckBox = new CheckBoxTheme
            {
                BoxBackground = surface,
                BoxBorder = border,
                CheckedColor = accent,
                HoverBorderColor = accent,
                DisabledColor = border,
                CheckMarkColor = Color.White,
                DisabledTextColor = Color.FromArgb(148, 163, 184),
                SwitchOffTrackColor = border,
                SwitchThumbColor = Color.White,
                TextColor = Color.FromArgb(15, 23, 42),
                BorderRadius = Math.Min(4, radius),
                BorderSize = 1,
                EnableAnimation = animations,
                AnimationSpeed = 15,
                EnableRipple = animations,
                RippleColor = ColorMathHelper.WithAlpha(accent, 30)
            },
            ComboBox = new ComboBoxTheme
            {
                Background = surface,
                Foreground = Color.FromArgb(15, 23, 42),
                BorderColor = border,
                HoverColor = ColorMathHelper.Darken(border, 0.15f),
                FocusColor = accent,
                DropDownBackground = surface,
                DropDownForeground = Color.FromArgb(15, 23, 42),
                DropDownHoverBackground = ColorMathHelper.WithAlpha(accent, 25),
                DropDownHoverForeground = ColorMathHelper.Darken(accent, 0.25f),
                DisabledBackground = Color.FromArgb(248, 250, 252),
                DisabledForeground = Color.FromArgb(148, 163, 184)
            },
            DataGrid = new DataGridTheme
            {
                Background = surface,
                BorderColor = border,
                GridColor = Color.FromArgb(241, 245, 249),
                HeaderBackground = bg,
                HeaderForeground = Color.FromArgb(71, 85, 105),
                HeaderSelectionBackground = Color.FromArgb(241, 245, 249),
                HeaderSelectionForeground = Color.FromArgb(15, 23, 42),
                CellBackground = surface,
                CellForeground = Color.FromArgb(15, 23, 42),
                AlternatingRowBackground = prefs.EnableAlternatingRows ? bg : surface,
                AlternatingRowForeground = Color.FromArgb(15, 23, 42),
                SelectionBackground = ColorMathHelper.WithAlpha(accent, 40),
                SelectionForeground = ColorMathHelper.Darken(accent, 0.25f),
                BorderSize = 1
            },
            Label = new LabelTheme
            {
                PrimaryColor = Color.FromArgb(15, 23, 42),
                SecondaryColor = Color.FromArgb(71, 85, 105),
                MutedColor = Color.FromArgb(148, 163, 184),
                SuccessColor = Color.FromArgb(16, 185, 129),
                DangerColor = Color.FromArgb(239, 68, 68),
                WarningColor = Color.FromArgb(245, 158, 11),
                InfoColor = Color.FromArgb(14, 165, 233),
                DisabledColor = Color.FromArgb(148, 163, 184),
                LinkColor = accent,
                LinkHoverColor = accentHover
            },
            Panel = new PanelTheme
            {
                Background = surface,
                Foreground = Color.FromArgb(15, 23, 42),
            },
            ToolStrip = new ToolStripTheme
            {
                Background = surface,
                Foreground = Color.FromArgb(15, 23, 42),
                BorderColor = border,
                ItemBackground = surface,
                ItemForeground = Color.FromArgb(71, 85, 105),
                ItemHoverBackground = Color.FromArgb(241, 245, 249),
                ItemHoverForeground = Color.FromArgb(15, 23, 42),
                ItemPressedBackground = Color.FromArgb(226, 232, 240),
                ItemPressedForeground = Color.FromArgb(15, 23, 42),
                DisabledForeground = Color.FromArgb(148, 163, 184),
                SeparatorColor = border,
                AccentColor = accent,
                Borderless = true
            },
            Menu = new MenuTheme
            {
                Background = surface,
                Border = border,
                ItemBackground = surface,
                ItemText = Color.FromArgb(51, 65, 85),
                ItemHoverBackground = Color.FromArgb(241, 245, 249),
                ItemHoverText = Color.FromArgb(15, 23, 42),
                ItemPressedBackground = Color.FromArgb(226, 232, 240),
                ItemPressedText = Color.FromArgb(15, 23, 42),
                DisabledText = Color.FromArgb(148, 163, 184),
                Separator = border,
                Accent = accent,
                Arrow = Color.FromArgb(100, 116, 139),
                DangerText = Color.FromArgb(220, 38, 38),
                DangerHoverBackground = Color.FromArgb(254, 242, 242),
                BorderSize = 1,
                SeparatorHeight = 1,
                AccentSize = 3
            },
            Notification = new NotificationTheme
            {
                Background = surface,
                TextColor = Color.FromArgb(15, 23, 42),
                BorderColor = border,
                SuccessColor = Color.FromArgb(16, 185, 129),
                DangerColor = Color.FromArgb(239, 68, 68),
                WarningColor = Color.FromArgb(245, 158, 11),
                InfoColor = Color.FromArgb(14, 165, 233),
                ProgressBarColor = accent,
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