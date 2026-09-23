using System.Drawing;
using System.Windows.Forms;
using DVLD.PL.ControlsTheme;

namespace DVLD.PL.Theme;

public class DefaultLightThemeProvider : IThemeProvider
{
    public Theme BuildTheme()
    {
        return new Theme
        {
            Colors = GetThemeColors(),
            Common = GetCommonTheme(),
            Form = GetFormTheme(),
            Buttons = GetButtonThemes(),
            TextBox = GetTextBoxTheme(),
            CheckBox = GetCheckBoxTheme(),
            ComboBox = GetComboBoxTheme(),
            DataGrid = GetDataGridTheme(),
            Label = GetLabelTheme(),
            Panel = GetPanelTheme(),
            ToolStrip = GetToolStripTheme(),
            Menu = GetMenuTheme(),
            Notification = GetNotificationTheme()
        };
    }

    public ThemeColors GetThemeColors()
    {
        return new ThemeColors
        {
            Primary = Color.FromArgb(99, 102, 241),
            PrimaryHover = Color.FromArgb(79, 70, 229),
            PrimaryPressed = Color.FromArgb(67, 56, 202),
            Background = Color.FromArgb(248, 250, 252),
            Surface = Color.FromArgb(255, 255, 255),
            Border = Color.FromArgb(226, 232, 240),
            BorderHover = Color.FromArgb(99, 102, 241),
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
            SelectionBackground = Color.FromArgb(238, 242, 255),
            SelectionText = Color.FromArgb(67, 56, 202)
        };
    }

    public ButtonThemes GetButtonThemes()
    {
        return new ButtonThemes
        {
            Primary = new ButtonTheme
            {
                BackgroundStartColor = Color.FromArgb(99, 102, 241),
                BackgroundEndColor = Color.FromArgb(79, 70, 229),
                HoverStartColor = Color.FromArgb(129, 140, 248),
                HoverEndColor = Color.FromArgb(99, 102, 241),
                PressedStartColor = Color.FromArgb(67, 56, 202),
                PressedEndColor = Color.FromArgb(55, 48, 163),
                DisabledStartColor = Color.FromArgb(241, 245, 249),
                DisabledEndColor = Color.FromArgb(241, 245, 249),
                GradientAngle = 90f,
                TextColor = Color.White,
                HoverTextColor = Color.White,
                DisabledTextColor = Color.FromArgb(148, 163, 184),
                BorderRadius = 0,
                BorderSize = 1,
                BorderColor = Color.FromArgb(79, 70, 229),
                HoverBorderColor = Color.FromArgb(99, 102, 241),
                DisabledBorderColor = Color.FromArgb(226, 232, 240),
                EnableIconTinting = false,
                IconColor = Color.White,
                HoverIconColor = Color.White,
                EnableShadow = true,
                ShadowSize = 3,
                ShadowOffset = new Point(0, 2),
                ShadowColor = Color.FromArgb(35, 79, 70, 229),
                EnableHoverAnimation = true,
                HoverAnimationSpeed = 15,
                ShiftOnPress = true,
                EnableRippleEffect = true,
                RippleColor = Color.FromArgb(60, 255, 255, 255),
                RippleSpeed = 10
            },
            Secondary = new ButtonTheme
            {
                BackgroundStartColor = Color.FromArgb(255, 255, 255),
                BackgroundEndColor = Color.FromArgb(248, 250, 252),
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
                BorderRadius = 0,
                BorderSize = 1,
                BorderColor = Color.FromArgb(203, 213, 225),
                HoverBorderColor = Color.FromArgb(148, 163, 184),
                DisabledBorderColor = Color.FromArgb(226, 232, 240),
                EnableIconTinting = false,
                IconColor = Color.FromArgb(71, 85, 105),
                HoverIconColor = Color.FromArgb(15, 23, 42),
                EnableShadow = false,
                ShadowSize = 0,
                ShadowOffset = Point.Empty,
                ShadowColor = Color.Transparent,
                EnableHoverAnimation = true,
                HoverAnimationSpeed = 15,
                ShiftOnPress = true,
                EnableRippleEffect = true,
                RippleColor = Color.FromArgb(30, 0, 0, 0),
                RippleSpeed = 10
            },
            Danger = new ButtonTheme
            {
                BackgroundStartColor = Color.FromArgb(239, 68, 68),
                BackgroundEndColor = Color.FromArgb(220, 38, 38),
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
                BorderRadius = 0,
                BorderSize = 1,
                BorderColor = Color.FromArgb(220, 38, 38),
                HoverBorderColor = Color.FromArgb(239, 68, 68),
                DisabledBorderColor = Color.FromArgb(226, 232, 240),
                EnableIconTinting = false,
                IconColor = Color.White,
                HoverIconColor = Color.White,
                EnableShadow = true,
                ShadowSize = 3,
                ShadowOffset = new Point(0, 2),
                ShadowColor = Color.FromArgb(35, 220, 38, 38),
                EnableHoverAnimation = true,
                HoverAnimationSpeed = 15,
                ShiftOnPress = true,
                EnableRippleEffect = true,
                RippleColor = Color.FromArgb(60, 255, 255, 255),
                RippleSpeed = 10
            },
            Disabled = new ButtonTheme
            {
                BackgroundStartColor = Color.FromArgb(241, 245, 249),
                BackgroundEndColor = Color.FromArgb(241, 245, 249),
                HoverStartColor = Color.FromArgb(241, 245, 249),
                HoverEndColor = Color.FromArgb(241, 245, 249),
                PressedStartColor = Color.FromArgb(241, 245, 249),
                PressedEndColor = Color.FromArgb(241, 245, 249),
                DisabledStartColor = Color.FromArgb(241, 245, 249),
                DisabledEndColor = Color.FromArgb(241, 245, 249),
                GradientAngle = 0f,
                TextColor = Color.FromArgb(148, 163, 184),
                HoverTextColor = Color.FromArgb(148, 163, 184),
                DisabledTextColor = Color.FromArgb(148, 163, 184),
                BorderRadius = 0,
                BorderSize = 1,
                BorderColor = Color.FromArgb(226, 232, 240),
                HoverBorderColor = Color.FromArgb(226, 232, 240),
                DisabledBorderColor = Color.FromArgb(226, 232, 240),
                EnableIconTinting = true,
                IconColor = Color.FromArgb(148, 163, 184),
                HoverIconColor = Color.FromArgb(148, 163, 184),
                EnableShadow = false,
                ShadowSize = 0,
                ShadowOffset = Point.Empty,
                ShadowColor = Color.Transparent,
                EnableHoverAnimation = false,
                HoverAnimationSpeed = 0,
                ShiftOnPress = false,
                EnableRippleEffect = false,
                RippleColor = Color.Transparent,
                RippleSpeed = 0
            }
        };
    }

    public CheckBoxTheme GetCheckBoxTheme()
    {
        return new CheckBoxTheme
        {
            BoxBackground = Color.FromArgb(255, 255, 255),
            BoxBorder = Color.FromArgb(203, 213, 225),
            CheckedColor = Color.FromArgb(99, 102, 241),
            HoverBorderColor = Color.FromArgb(99, 102, 241),
            DisabledColor = Color.FromArgb(226, 232, 240),
            CheckMarkColor = Color.White,
            DisabledTextColor = Color.FromArgb(148, 163, 184),
            SwitchOffTrackColor = Color.FromArgb(226, 232, 240),
            SwitchThumbColor = Color.White,
            TextColor = Color.FromArgb(15, 23, 42),
            CheckThickness = 2.0f,
            BorderRadius = 4,
            BorderSize = 1,
            EnableAnimation = true,
            AnimationSpeed = 15,
            EnableRipple = true,
            RippleColor = Color.FromArgb(30, 99, 102, 241)
        };
    }

    public ComboBoxTheme GetComboBoxTheme()
    {
        return new ComboBoxTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            Foreground = Color.FromArgb(15, 23, 42),
            BorderColor = Color.FromArgb(203, 213, 225),
            HoverColor = Color.FromArgb(148, 163, 184),
            FocusColor = Color.FromArgb(99, 102, 241),
            DropDownBackground = Color.FromArgb(255, 255, 255),
            DropDownForeground = Color.FromArgb(15, 23, 42),
            DropDownHoverBackground = Color.FromArgb(238, 242, 255),
            DropDownHoverForeground = Color.FromArgb(67, 56, 202),
            DisabledBackground = Color.FromArgb(248, 250, 252),
            DisabledForeground = Color.FromArgb(148, 163, 184),
            BorderSize = 1,
            BorderRadius = 8
        };
    }

    public CommonTheme GetCommonTheme()
    {
        return new CommonTheme
        {
            FontFamily = "Segoe UI",
            DefaultFontSize = 9.5f,
            DefaultBorderRadius = 8,
            DefaultBorderSize = 1,
            EnableAnimations = true,
            EnableRippleEffects = true,
            EnableShadows = true
        };
    }

    public DataGridTheme GetDataGridTheme()
    {
        return new DataGridTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            BorderColor = Color.FromArgb(226, 232, 240),
            GridColor = Color.FromArgb(241, 245, 249),
            HeaderBackground = Color.FromArgb(248, 250, 252),
            HeaderForeground = Color.FromArgb(71, 85, 105),
            HeaderSelectionBackground = Color.FromArgb(241, 245, 249),
            HeaderSelectionForeground = Color.FromArgb(15, 23, 42),
            CellBackground = Color.FromArgb(255, 255, 255),
            CellForeground = Color.FromArgb(15, 23, 42),
            AlternatingRowBackground = Color.FromArgb(248, 250, 252),
            AlternatingRowForeground = Color.FromArgb(15, 23, 42),
            SelectionBackground = Color.FromArgb(238, 242, 255),
            SelectionForeground = Color.FromArgb(67, 56, 202),
            BorderSize = 1,
        };
    }

    public FormTheme GetFormTheme()
    {
        return new FormTheme
        {
            Background = Color.FromArgb(248, 250, 252),
            Foreground = Color.FromArgb(15, 23, 42),
            BorderColor = Color.FromArgb(226, 232, 240),
            BorderSize = 1,
            HeaderBackground = Color.FromArgb(255, 255, 255),
            HeaderForeground = Color.FromArgb(15, 23, 42),
            HeaderBorderColor = Color.FromArgb(226, 232, 240),
            CloseButtonHoverColor = Color.FromArgb(239, 68, 68),
            CloseButtonPressedColor = Color.FromArgb(220, 38, 38),
            WindowControlHoverColor = Color.FromArgb(241, 245, 249),
            WindowControlPressedColor = Color.FromArgb(226, 232, 240)
        };
    }

    public LabelTheme GetLabelTheme()
    {
        return new LabelTheme
        {
            PrimaryColor = Color.FromArgb(15, 23, 42),
            SecondaryColor = Color.FromArgb(71, 85, 105),
            MutedColor = Color.FromArgb(148, 163, 184),
            SuccessColor = Color.FromArgb(16, 185, 129),
            DangerColor = Color.FromArgb(239, 68, 68),
            WarningColor = Color.FromArgb(245, 158, 11),
            InfoColor = Color.FromArgb(14, 165, 233),
            DisabledColor = Color.FromArgb(148, 163, 184),
            LinkColor = Color.FromArgb(79, 70, 229),
            LinkHoverColor = Color.FromArgb(67, 56, 202),
        };
    }

    public MenuTheme GetMenuTheme()
    {
        return new MenuTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            Border = Color.FromArgb(226, 232, 240),
            ItemBackground = Color.FromArgb(255, 255, 255),
            ItemText = Color.FromArgb(51, 65, 85),
            ItemHoverBackground = Color.FromArgb(241, 245, 249),
            ItemHoverText = Color.FromArgb(15, 23, 42),
            ItemPressedBackground = Color.FromArgb(226, 232, 240),
            ItemPressedText = Color.FromArgb(15, 23, 42),
            DisabledText = Color.FromArgb(148, 163, 184),
            Separator = Color.FromArgb(226, 232, 240),
            Accent = Color.FromArgb(99, 102, 241),
            Arrow = Color.FromArgb(100, 116, 139),
            DangerText = Color.FromArgb(220, 38, 38),
            DangerHoverBackground = Color.FromArgb(254, 242, 242),
            BorderSize = 1,
            ItemHorizontalPadding = 12,
            ItemVerticalPadding = 8,
            SeparatorHeight = 1,
            AccentSize = 3
        };
    }

    public NotificationTheme GetNotificationTheme()
    {
        return new NotificationTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            TextColor = Color.FromArgb(15, 23, 42),
            BorderColor = Color.FromArgb(226, 232, 240),
            SuccessColor = Color.FromArgb(16, 185, 129),
            DangerColor = Color.FromArgb(239, 68, 68),
            WarningColor = Color.FromArgb(245, 158, 11),
            InfoColor = Color.FromArgb(14, 165, 233),
            ProgressBarColor = Color.FromArgb(99, 102, 241),
            TitleFontSize = 11.0f,
            MessageFontSize = 9.5f,
            BorderSize = 1,
            BorderRadius = 10,
            Padding = new Padding(12)
        };
    }

    public PanelTheme GetPanelTheme()
    {
        return new PanelTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            Foreground = Color.FromArgb(15, 23, 42),
        };
    }

    public TextBoxTheme GetTextBoxTheme()
    {
        return new TextBoxTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            DisabledBackground = Color.FromArgb(248, 250, 252),
            BorderColor = Color.FromArgb(203, 213, 225),
            FocusBorderColor = Color.FromArgb(99, 102, 241),
            DisabledBorderColor = Color.FromArgb(226, 232, 240),
            ErrorBorderColor = Color.FromArgb(239, 68, 68),
            TextColor = Color.FromArgb(15, 23, 42),
            PlaceholderColor = Color.FromArgb(148, 163, 184),
            BorderRadius = 8,
            BorderSize = 1,
            EnableIconTinting = true,
            IconColor = Color.FromArgb(100, 116, 139),
            HoverIconColor = Color.FromArgb(15, 23, 42),
            ClearButtonColor = Color.FromArgb(148, 163, 184),
            ClearButtonHoverColor = Color.FromArgb(239, 68, 68),
            SuggestBackground = Color.FromArgb(255, 255, 255),
            SuggestTextColor = Color.FromArgb(15, 23, 42),
            SuggestHoverColor = Color.FromArgb(238, 242, 255),
            SuggestBorderColor = Color.FromArgb(226, 232, 240),
        };
    }

    public ToolStripTheme GetToolStripTheme()
    {
        return new ToolStripTheme
        {
            Background = Color.FromArgb(255, 255, 255),
            Foreground = Color.FromArgb(15, 23, 42),
            BorderColor = Color.FromArgb(226, 232, 240),
            ItemBackground = Color.FromArgb(255, 255, 255),
            ItemForeground = Color.FromArgb(71, 85, 105),
            ItemHoverBackground = Color.FromArgb(241, 245, 249),
            ItemHoverForeground = Color.FromArgb(15, 23, 42),
            ItemPressedBackground = Color.FromArgb(226, 232, 240),
            ItemPressedForeground = Color.FromArgb(15, 23, 42),
            DisabledForeground = Color.FromArgb(148, 163, 184),
            SeparatorColor = Color.FromArgb(226, 232, 240),
            AccentColor = Color.FromArgb(99, 102, 241),
            Borderless = true
        };
    }
}