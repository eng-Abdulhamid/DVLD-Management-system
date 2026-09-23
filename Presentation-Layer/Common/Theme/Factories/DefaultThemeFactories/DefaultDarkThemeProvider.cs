using DVLD.PL.ControlsTheme;
namespace DVLD.PL.Theme
{
    public class DefaultDarkThemeProvider : IThemeProvider
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
                PrimaryHover = Color.FromArgb(129, 140, 248),
                PrimaryPressed = Color.FromArgb(67, 56, 202),
                Background = Color.FromArgb(15, 23, 42),
                Surface = Color.FromArgb(30, 41, 59),
                Border = Color.FromArgb(51, 65, 85),
                BorderHover = Color.FromArgb(99, 102, 241),
                TextPrimary = Color.FromArgb(241, 245, 249),
                TextSecondary = Color.FromArgb(148, 163, 184),
                TextMuted = Color.FromArgb(100, 116, 139),
                Success = Color.FromArgb(16, 185, 129),
                Danger = Color.FromArgb(239, 68, 68),
                DangerHover = Color.FromArgb(248, 113, 113),
                DangerPressed = Color.FromArgb(220, 38, 38),
                Warning = Color.FromArgb(245, 158, 11),
                Info = Color.FromArgb(14, 165, 233),
                DisabledBackground = Color.FromArgb(30, 41, 59),
                DisabledText = Color.FromArgb(100, 116, 139),
                SelectionBackground = Color.FromArgb(49, 46, 129),
                SelectionText = Color.FromArgb(255, 255, 255)
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
                    DisabledStartColor = Color.FromArgb(30, 41, 59),
                    DisabledEndColor = Color.FromArgb(30, 41, 59),
                    GradientAngle = 90f,
                    TextColor = Color.White,
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = 8,
                    BorderSize = 1,
                    BorderColor = Color.FromArgb(129, 140, 248),
                    HoverBorderColor = Color.FromArgb(165, 180, 252),
                    DisabledBorderColor = Color.FromArgb(51, 65, 85),
                    EnableIconTinting = false,
                    IconColor = Color.White,
                    HoverIconColor = Color.White,
                    EnableShadow = true,
                    ShadowSize = 4,
                    ShadowOffset = new Point(0, 2),
                    ShadowColor = Color.FromArgb(60, 0, 0, 0),
                    EnableHoverAnimation = true,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = true,
                    RippleColor = Color.FromArgb(60, 255, 255, 255),
                    RippleSpeed = 10
                },
                Secondary = new ButtonTheme
                {
                    BackgroundStartColor = Color.FromArgb(51, 65, 85),
                    BackgroundEndColor = Color.FromArgb(30, 41, 59),
                    HoverStartColor = Color.FromArgb(71, 85, 105),
                    HoverEndColor = Color.FromArgb(51, 65, 85),
                    PressedStartColor = Color.FromArgb(30, 41, 59),
                    PressedEndColor = Color.FromArgb(15, 23, 42),
                    DisabledStartColor = Color.FromArgb(30, 41, 59),
                    DisabledEndColor = Color.FromArgb(30, 41, 59),
                    GradientAngle = 90f,
                    TextColor = Color.FromArgb(241, 245, 249),
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = 8,
                    BorderSize = 1,
                    BorderColor = Color.FromArgb(71, 85, 105),
                    HoverBorderColor = Color.FromArgb(100, 116, 139),
                    DisabledBorderColor = Color.FromArgb(51, 65, 85),
                    EnableIconTinting = false,
                    IconColor = Color.FromArgb(241, 245, 249),
                    HoverIconColor = Color.White,
                    EnableShadow = false,
                    ShadowSize = 0,
                    ShadowOffset = Point.Empty,
                    ShadowColor = Color.Transparent,
                    EnableHoverAnimation = true,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = true,
                    RippleColor = Color.FromArgb(40, 255, 255, 255),
                    RippleSpeed = 10
                },
                Danger = new ButtonTheme
                {
                    BackgroundStartColor = Color.FromArgb(220, 38, 38),
                    BackgroundEndColor = Color.FromArgb(185, 28, 28),
                    HoverStartColor = Color.FromArgb(239, 68, 68),
                    HoverEndColor = Color.FromArgb(220, 38, 38),
                    PressedStartColor = Color.FromArgb(153, 27, 27),
                    PressedEndColor = Color.FromArgb(127, 29, 29),
                    DisabledStartColor = Color.FromArgb(30, 41, 59),
                    DisabledEndColor = Color.FromArgb(30, 41, 59),
                    GradientAngle = 90f,
                    TextColor = Color.White,
                    HoverTextColor = Color.White,
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = 8,
                    BorderSize = 1,
                    BorderColor = Color.FromArgb(248, 113, 113),
                    HoverBorderColor = Color.FromArgb(252, 165, 165),
                    DisabledBorderColor = Color.FromArgb(51, 65, 85),
                    EnableIconTinting = false,
                    IconColor = Color.White,
                    HoverIconColor = Color.White,
                    EnableShadow = true,
                    ShadowSize = 4,
                    ShadowOffset = new Point(0, 2),
                    ShadowColor = Color.FromArgb(60, 0, 0, 0),
                    EnableHoverAnimation = true,
                    HoverAnimationSpeed = 15,
                    ShiftOnPress = true,
                    EnableRippleEffect = true,
                    RippleColor = Color.FromArgb(60, 255, 255, 255),
                    RippleSpeed = 10
                },
                Disabled = new ButtonTheme
                {
                    BackgroundStartColor = Color.FromArgb(30, 41, 59),
                    BackgroundEndColor = Color.FromArgb(30, 41, 59),
                    HoverStartColor = Color.FromArgb(30, 41, 59),
                    HoverEndColor = Color.FromArgb(30, 41, 59),
                    PressedStartColor = Color.FromArgb(30, 41, 59),
                    PressedEndColor = Color.FromArgb(30, 41, 59),
                    DisabledStartColor = Color.FromArgb(30, 41, 59),
                    DisabledEndColor = Color.FromArgb(30, 41, 59),
                    GradientAngle = 0f,
                    TextColor = Color.FromArgb(100, 116, 139),
                    HoverTextColor = Color.FromArgb(100, 116, 139),
                    DisabledTextColor = Color.FromArgb(100, 116, 139),
                    BorderRadius = 8,
                    BorderSize = 1,
                    BorderColor = Color.FromArgb(51, 65, 85),
                    HoverBorderColor = Color.FromArgb(51, 65, 85),
                    DisabledBorderColor = Color.FromArgb(51, 65, 85),
                    EnableIconTinting = true,
                    IconColor = Color.FromArgb(100, 116, 139),
                    HoverIconColor = Color.FromArgb(100, 116, 139),
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
                BoxBackground = Color.FromArgb(30, 41, 59),
                BoxBorder = Color.FromArgb(71, 85, 105),
                CheckedColor = Color.FromArgb(99, 102, 241),
                HoverBorderColor = Color.FromArgb(129, 140, 248),
                DisabledColor = Color.FromArgb(51, 65, 85),
                CheckMarkColor = Color.White,
                DisabledTextColor = Color.FromArgb(100, 116, 139),
                SwitchOffTrackColor = Color.FromArgb(51, 65, 85),
                SwitchThumbColor = Color.FromArgb(241, 245, 249),
                TextColor = Color.FromArgb(241, 245, 249),
                CheckThickness = 2.0f,
                BorderRadius = 4,
                BorderSize = 1,
                EnableAnimation = true,
                AnimationSpeed = 15,
                EnableRipple = true,
                RippleColor = Color.FromArgb(40, 99, 102, 241)
            };
        }

        public ComboBoxTheme GetComboBoxTheme()
        {
            return new ComboBoxTheme
            {
                Background = Color.FromArgb(30, 41, 59),
                Foreground = Color.FromArgb(241, 245, 249),
                BorderColor = Color.FromArgb(51, 65, 85),
                HoverColor = Color.FromArgb(71, 85, 105),
                FocusColor = Color.FromArgb(99, 102, 241),
                DropDownBackground = Color.FromArgb(30, 41, 59),
                DropDownForeground = Color.FromArgb(241, 245, 249),
                DropDownHoverBackground = Color.FromArgb(51, 65, 85),
                DropDownHoverForeground = Color.White,
                DisabledBackground = Color.FromArgb(15, 23, 42),
                DisabledForeground = Color.FromArgb(100, 116, 139),
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
                Background = Color.FromArgb(15, 23, 42),
                BorderColor = Color.FromArgb(51, 65, 85),
                GridColor = Color.FromArgb(30, 41, 59),
                HeaderBackground = Color.FromArgb(30, 41, 59),
                HeaderForeground = Color.FromArgb(241, 245, 249),
                HeaderSelectionBackground = Color.FromArgb(51, 65, 85),
                HeaderSelectionForeground = Color.White,
                CellBackground = Color.FromArgb(15, 23, 42),
                CellForeground = Color.FromArgb(226, 232, 240),
                AlternatingRowBackground = Color.FromArgb(20, 29, 47),
                AlternatingRowForeground = Color.FromArgb(226, 232, 240),
                SelectionBackground = Color.FromArgb(49, 46, 129),
                SelectionForeground = Color.White,
                BorderSize = 1,
            };
        }

        public FormTheme GetFormTheme()
        {
            return new FormTheme
            {
                Background = Color.FromArgb(15, 23, 42),
                Foreground = Color.FromArgb(241, 245, 249),
                BorderColor = Color.FromArgb(51, 65, 85),
                BorderSize = 1,
                HeaderBackground = Color.FromArgb(24, 32, 47),
                HeaderForeground = Color.FromArgb(241, 245, 249),
                HeaderBorderColor = Color.FromArgb(51, 65, 85),
                CloseButtonHoverColor = Color.FromArgb(239, 68, 68),
                CloseButtonPressedColor = Color.FromArgb(185, 28, 28),
                WindowControlHoverColor = Color.FromArgb(51, 65, 85),
                WindowControlPressedColor = Color.FromArgb(30, 41, 59)
            };
        }

        public LabelTheme GetLabelTheme()
        {
            return new LabelTheme
            {
                PrimaryColor = Color.FromArgb(241, 245, 249),
                SecondaryColor = Color.FromArgb(148, 163, 184),
                MutedColor = Color.FromArgb(100, 116, 139),
                SuccessColor = Color.FromArgb(16, 185, 129),
                DangerColor = Color.FromArgb(239, 68, 68),
                WarningColor = Color.FromArgb(245, 158, 11),
                InfoColor = Color.FromArgb(14, 165, 233),
                DisabledColor = Color.FromArgb(100, 116, 139),
                LinkColor = Color.FromArgb(129, 140, 248),
                LinkHoverColor = Color.FromArgb(165, 180, 252),
            };
        }

        public MenuTheme GetMenuTheme()
        {
            return new MenuTheme
            {
                Background = Color.FromArgb(30, 41, 59),
                Border = Color.FromArgb(51, 65, 85),
                ItemBackground = Color.FromArgb(30, 41, 59),
                ItemText = Color.FromArgb(241, 245, 249),
                ItemHoverBackground = Color.FromArgb(51, 65, 85),
                ItemHoverText = Color.White,
                ItemPressedBackground = Color.FromArgb(71, 85, 105),
                ItemPressedText = Color.White,
                DisabledText = Color.FromArgb(100, 116, 139),
                Separator = Color.FromArgb(51, 65, 85),
                Accent = Color.FromArgb(99, 102, 241),
                Arrow = Color.FromArgb(148, 163, 184),
                DangerText = Color.FromArgb(248, 113, 113),
                DangerHoverBackground = Color.FromArgb(153, 27, 27),
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
                Background = Color.FromArgb(30, 41, 59),
                TextColor = Color.FromArgb(241, 245, 249),
                BorderColor = Color.FromArgb(51, 65, 85),
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
                Background = Color.FromArgb(24, 32, 47),
                Foreground = Color.FromArgb(241, 245, 249),
            };
        }

        public TextBoxTheme GetTextBoxTheme()
        {
            return new TextBoxTheme
            {
                Background = Color.FromArgb(30, 41, 59),
                DisabledBackground = Color.FromArgb(15, 23, 42),
                BorderColor = Color.FromArgb(51, 65, 85),
                FocusBorderColor = Color.FromArgb(99, 102, 241),
                DisabledBorderColor = Color.FromArgb(30, 41, 59),
                ErrorBorderColor = Color.FromArgb(239, 68, 68),
                TextColor = Color.FromArgb(241, 245, 249),
                PlaceholderColor = Color.FromArgb(100, 116, 139),
                BorderRadius = 8,
                BorderSize = 1,
                EnableIconTinting = true,
                IconColor = Color.FromArgb(148, 163, 184),
                HoverIconColor = Color.FromArgb(99, 102, 241),
                ClearButtonColor = Color.FromArgb(148, 163, 184),
                ClearButtonHoverColor = Color.FromArgb(239, 68, 68),
                SuggestBackground = Color.FromArgb(30, 41, 59),
                SuggestTextColor = Color.FromArgb(241, 245, 249),
                SuggestHoverColor = Color.FromArgb(51, 65, 85),
                SuggestBorderColor = Color.FromArgb(71, 85, 105),
            };
        }
        public ToolStripTheme GetToolStripTheme()
        {
            return new ToolStripTheme
            {
                Background = Color.FromArgb(24, 32, 47),
                Foreground = Color.FromArgb(241, 245, 249),
                BorderColor = Color.FromArgb(51, 65, 85),
                ItemBackground = Color.FromArgb(24, 32, 47),
                ItemForeground = Color.FromArgb(241, 245, 249),
                ItemHoverBackground = Color.FromArgb(51, 65, 85),
                ItemHoverForeground = Color.White,
                ItemPressedBackground = Color.FromArgb(71, 85, 105),
                ItemPressedForeground = Color.White,
                DisabledForeground = Color.FromArgb(100, 116, 139),
                SeparatorColor = Color.FromArgb(51, 65, 85),
                AccentColor = Color.FromArgb(99, 102, 241),
                Borderless = true
            };
        }
    }
}
