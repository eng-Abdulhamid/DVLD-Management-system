using System;
using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Global
{
    public enum enMode
    {
        Light = 0,
        Dark = 1
    }

    public enum enBadgeState
    {
        Success,
        Danger,
        Warning,
        Info,
        Neutral
    }

    public static class UITheme
    {
        public static enMode Mode { get; private set; } = enMode.Light;

        // Fired across all active windows when Mode toggles
        public static event Action? OnThemeChanged;

        public static void SetMode(enMode mode)
        {
            if (Mode == mode) return;
            Mode = mode;
            OnThemeChanged?.Invoke();
        }

        #region Theme Colors (Dynamic based on enMode)

        public static Color Primary => Mode == enMode.Dark
            ? Color.FromArgb(139, 92, 246)
            : Color.FromArgb(124, 58, 237);

        public static Color PrimaryHover => Mode == enMode.Dark
            ? Color.FromArgb(167, 139, 250)
            : Color.FromArgb(135, 72, 240);

        public static Color PrimaryPressed => Mode == enMode.Dark
            ? Color.FromArgb(124, 58, 237)
            : Color.FromArgb(112, 48, 222);

        public static Color Background => Mode == enMode.Dark
            ? Color.FromArgb(15, 23, 42)
            : Color.FromArgb(248, 250, 252);

        public static Color Surface => Mode == enMode.Dark
            ? Color.FromArgb(30, 41, 59)
            : Color.White;

        public static Color Border => Mode == enMode.Dark
            ? Color.FromArgb(51, 65, 85)
            : Color.FromArgb(226, 232, 240);

        public static Color BorderHover => Mode == enMode.Dark
            ? Color.FromArgb(71, 85, 105)
            : Color.FromArgb(203, 213, 225);

        public static Color TextPrimary => Mode == enMode.Dark
            ? Color.FromArgb(248, 250, 252)
            : Color.FromArgb(15, 23, 42);

        public static Color TextSecondary => Mode == enMode.Dark
            ? Color.FromArgb(203, 213, 225)
            : Color.FromArgb(71, 85, 105);

        public static Color TextMuted => Mode == enMode.Dark
            ? Color.FromArgb(100, 116, 139)
            : Color.FromArgb(148, 163, 184);

        public static Color Success => Mode == enMode.Dark
            ? Color.FromArgb(52, 211, 153)
            : Color.FromArgb(16, 185, 129);

        public static Color Danger => Mode == enMode.Dark
            ? Color.FromArgb(248, 113, 113)
            : Color.FromArgb(239, 68, 68);

        public static Color Warning => Mode == enMode.Dark
            ? Color.FromArgb(251, 191, 36)
            : Color.FromArgb(245, 158, 11);

        public static Color Info => Mode == enMode.Dark
            ? Color.FromArgb(56, 189, 248)
            : Color.FromArgb(14, 165, 233);

        public static Color DisabledBackground => Mode == enMode.Dark
            ? Color.FromArgb(30, 41, 59)
            : Color.FromArgb(241, 245, 249);

        public static Color DisabledText => Mode == enMode.Dark
            ? Color.FromArgb(71, 85, 105)
            : Color.FromArgb(148, 163, 184);

        public static Color SelectionBg => Mode == enMode.Dark
            ? Color.FromArgb(88, 28, 135)
            : Color.FromArgb(243, 232, 255);

        public static Color SelectionText => Mode == enMode.Dark
            ? Color.FromArgb(248, 250, 252)
            : Color.FromArgb(112, 48, 222);

        #endregion

        #region Backward Compatibility Aliases

        public static Color NeutralBackground => Background;
        public static Color NeutralBorder => Border;
        public static Color NeutralText => TextSecondary;
        public static Color SurfaceWhite => Surface;
        public static Color FormBackgroundColor => Background;

        public static int DefaultBorderRadius { get; set; } = 8;
        public static bool EnableSystemAnimations { get; set; } = true;
        public static string SystemFontFamily { get; set; } = "Segoe UI";

        public static bool NotificationsEnabled { get; set; } = true;
        public static bool NotificationPlaySound { get; set; } = false;
        public static bool NotificationShowProgressBar { get; set; } = true;
        public static int NotificationDefaultDuration { get; set; } = 4;
        public static NotificationPosition NotificationDefaultPosition { get; set; } = NotificationPosition.BottomRight;

        #endregion

        #region Toast Notification Methods

        public static void ShowSuccessToast(string message, string title = "Success") =>
            ShowToast(title, message, IconType.Success);

        public static void ShowErrorToast(string message, string title = "Error") =>
            ShowToast(title, message, IconType.Error);

        public static void ShowWarningToast(string message, string title = "Warning") =>
            ShowToast(title, message, IconType.Warning);

        public static void ShowInfoToast(string message, string title = "Information") =>
            ShowToast(title, message, IconType.Info);

        private static void ShowToast(string title, string message, IconType type)
        {
            if (!NotificationsEnabled) return;

            new NotificationBuilder()
                .WithTitle(title)
                .WithMessage(message)
                .WithType(type)
                .WithDuration(NotificationDefaultDuration)
                .WithPosition(NotificationDefaultPosition)
                .WithProgressBar(NotificationShowProgressBar)
                .WithSound(NotificationPlaySound)
                .WithCustomColors(
                    accent: type switch
                    {
                        IconType.Success => Success,
                        IconType.Error => Danger,
                        IconType.Warning => Warning,
                        IconType.Info => Info,
                        _ => Primary
                    },
                    back: Surface,
                    text: TextPrimary,
                    border: Border)
                .Show();
        }

        #endregion

        #region Button Styling Engine

        private static void SetButtonColors(NButton btn, Color bg, Color hoverBg, Color pressedBg, Color border, Color text, bool drawBorder)
        {
            if (btn == null) return;

            btn.BackgroundStartColor = bg;
            btn.BackgroundEndColor = bg;
            btn.HoverStartColor = hoverBg;
            btn.HoverEndColor = hoverBg;
            btn.PressedStartColor = pressedBg;
            btn.PressedEndColor = pressedBg;
            btn.BorderColor = border;
            btn.HoverBorderColor = border;
            btn.BorderSize = drawBorder ? 1 : 0;
            btn.TextColor = text;
            btn.HoverTextColor = text;
            btn.BorderRadius = DefaultBorderRadius;
            btn.Cursor = Cursors.Hand;
            btn.EnableHoverAnimation = EnableSystemAnimations;
            btn.EnableRippleEffect = EnableSystemAnimations;
            btn.EnableIconTinting = true;
            btn.IconColor = text;
            btn.HoverIconColor = text;
            btn.Invalidate();
        }

        public static void ApplyPrimaryStyle(this NButton btn) =>
            SetButtonColors(btn, Primary, PrimaryHover, PrimaryPressed, Primary, Color.White, false);

        public static void ApplySecondaryStyle(this NButton btn) =>
            SetButtonColors(btn, Surface, DisabledBackground, Border, Border, TextSecondary, true);

        public static void ApplyDangerStyle(this NButton btn) =>
            SetButtonColors(btn, Danger, Color.FromArgb(243, 85, 85), Color.FromArgb(225, 52, 52), Danger, Color.White, false);

        public static void ApplyDisabledStyle(this NButton btn)
        {
            if (btn == null) return;
            SetButtonColors(btn, DisabledBackground, DisabledBackground, DisabledBackground, Color.Transparent, DisabledText, false);
            btn.EnableHoverAnimation = false;
            btn.EnableRippleEffect = false;
            btn.Cursor = Cursors.Default;
        }

        #endregion

        #region Form & Common Controls Styling

        public static void ApplyStandardFormTheme(this Form frm)
        {
            frm.BackColor = Background;
            frm.ForeColor = TextPrimary;
        }

        public static void ApplyCardStyle(this Panel pnl)
        {
            pnl.BackColor = Surface;
            pnl.Padding = new Padding(16);
        }

        public static void ApplyStandardStyle(this NTextBox txt)
        {
            txt.BorderRadius = DefaultBorderRadius;
            txt.BorderSize = 1;
            txt.BorderColor = Border;
            txt.BorderFocusColor = Primary;
            txt.FillColor = Surface;
            txt.Font = new Font(SystemFontFamily, 10F);
            txt.ForeColor = TextPrimary;
            txt.PlaceholderColor = TextMuted;
            txt.ErrorBorderColor = Danger;
            txt.ShowClearButton = true;
            txt.EnableIconTinting = true;
            txt.IconColor = TextMuted;
            txt.HoverIconColor = TextPrimary;
        }

        public static void ApplyStandardStyle(this ComboBox cb)
        {
            cb.FlatStyle = FlatStyle.Flat;
            cb.Font = new Font(SystemFontFamily, 9.5F);
            cb.ForeColor = TextPrimary;
            cb.BackColor = Surface;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ApplyStandardStyle(this NCheckBox chk)
        {
            chk.CheckedColor = Primary;
            chk.HoverBorderColor = Primary;
            chk.BoxBorderColor = Border;
            chk.BoxBackColor = Surface;
            chk.CheckMarkColor = Color.White;
            chk.ForeColor = TextPrimary;
            chk.Cursor = Cursors.Hand;
            chk.EnableAnimation = EnableSystemAnimations;
        }

        public static void ApplyModernStyle(this DataGridView dgv)
        {
            dgv.BackgroundColor = Surface;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Border;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 42;
            dgv.ColumnHeadersHeight = 44;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Background,
                Font = new Font(SystemFontFamily, 10F, FontStyle.Bold),
                ForeColor = TextSecondary,
                SelectionBackColor = Background,
                SelectionForeColor = TextSecondary,
                Padding = new Padding(12, 0, 0, 0)
            };

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Surface,
                Font = new Font(SystemFontFamily, 9.5F),
                ForeColor = TextPrimary,
                SelectionBackColor = SelectionBg,
                SelectionForeColor = SelectionText,
                Padding = new Padding(12, 0, 0, 0)
            };

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Background,
                Font = new Font(SystemFontFamily, 9.5F),
                ForeColor = TextPrimary,
                SelectionBackColor = SelectionBg,
                SelectionForeColor = SelectionText,
                Padding = new Padding(12, 0, 0, 0)
            };
        }

        public static void ApplyStatusBadge(this Label lbl, enBadgeState state, string text)
        {
            var (accent, alpha) = state switch
            {
                enBadgeState.Success => (Success, 25),
                enBadgeState.Danger => (Danger, 25),
                enBadgeState.Warning => (Warning, 25),
                enBadgeState.Info => (Info, 25),
                _ => (TextMuted, 25)
            };

            lbl.Text = text;
            lbl.BackColor = Color.FromArgb(alpha, accent);
            lbl.ForeColor = accent;
            lbl.Font = new Font(SystemFontFamily, 8.5F, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Padding = new Padding(8, 3, 8, 3);
        }

        public static void ApplyModernMenuRenderer(this ToolStrip ts, bool borderless = false)
        {
            var colorTable = new NMenuColorTable
            {
                CustomBackground = Surface,
                CustomItemSelected = SelectionBg,
                CustomSeparator = Border
            };

            ts.Renderer = new NMenuRenderer(colorTable)
            {
                ItemTextColor = TextPrimary,
                ItemHoverTextColor = PrimaryPressed,
                DangerTextColor = Danger
            };
        }

        public static void ApplyModernMenuRenderer(this ContextMenuStrip cms) =>
            ApplyModernMenuRenderer((ToolStrip)cms, borderless: false);

        #endregion
    }
}