using CustomControls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Global
{
    public static class UITheme
    {
        public static readonly Color Primary = Color.FromArgb(124, 58, 237);
        public static readonly Color PrimaryHover = Color.FromArgb(135, 72, 240);
        public static readonly Color PrimaryPressed = Color.FromArgb(112, 48, 222);

        public static readonly Color NeutralBackground = Color.FromArgb(248, 250, 252);
        public static readonly Color NeutralHover = Color.FromArgb(241, 245, 249);
        public static readonly Color NeutralPressed = Color.FromArgb(235, 239, 245);
        public static readonly Color NeutralBorder = Color.FromArgb(226, 232, 240);
        public static readonly Color NeutralHoverBorder = Color.FromArgb(215, 222, 232);
        public static readonly Color NeutralText = Color.FromArgb(71, 85, 105);

        public static readonly Color Danger = Color.FromArgb(239, 68, 68);
        public static readonly Color DangerHover = Color.FromArgb(243, 85, 85);
        public static readonly Color DangerPressed = Color.FromArgb(225, 52, 52);

        public static readonly Color Success = Color.FromArgb(16, 185, 129);
        public static readonly Color SuccessHover = Color.FromArgb(34, 197, 94);
        public static readonly Color SuccessPressed = Color.FromArgb(21, 128, 61);

        public static readonly Color Warning = Color.FromArgb(245, 158, 11);
        public static readonly Color WarningHover = Color.FromArgb(251, 191, 36);

        public static readonly Color Info = Color.FromArgb(14, 165, 233);
        public static readonly Color InfoHover = Color.FromArgb(56, 189, 248);

        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);
        public static readonly Color SurfaceWhite = Color.White;

        public static readonly Color FormBackgroundColor = Color.FromArgb(248, 250, 252);
        public static int DefaultBorderRadius { get; set; } = 8;
        public static bool EnableSystemAnimations { get; set; } = true;
        public static string SystemFontFamily { get; set; } = "Segoe UI";

        public static Color IconDefaultColor { get; set; } = Color.FromArgb(100, 116, 139);
        public static Color IconHoverColor { get; set; } = Color.FromArgb(15, 23, 42);
        public static Color IconLightColor { get; set; } = Color.White;
        public static Color IconPrimaryColor { get; set; } = Color.FromArgb(124, 58, 237);
        public static Color IconDangerColor { get; set; } = Color.FromArgb(239, 68, 68);
        public static Color IconSuccessColor { get; set; } = Color.FromArgb(16, 185, 129);
        public static Size IconStandardSize { get; set; } = new Size(18, 18);
        public static Size IconActionSize { get; set; } = new Size(20, 20);

        public static bool NotificationsEnabled { get; set; } = true;
        public static bool NotificationPlaySound { get; set; } = false;
        public static bool NotificationShowProgressBar { get; set; } = true;
        public static int NotificationDefaultDuration { get; set; } = 4;
        public static NotificationPosition NotificationDefaultPosition { get; set; } = NotificationPosition.BottomRight;

        public static void ApplyStandardFormTheme(this Form frm)
        {
            frm.BackColor = FormBackgroundColor;
        }

        public static void ShowSuccessToast(string message, string title = "Success")
        {
            if (!NotificationsEnabled) return;

            new NotificationBuilder()
                .WithTitle(title)
                .WithMessage(message)
                .WithType(IconType.Success)
                .WithDuration(NotificationDefaultDuration)
                .WithPosition(NotificationDefaultPosition)
                .WithProgressBar(NotificationShowProgressBar)
                .WithSound(NotificationPlaySound)
                .Show();
        }

        public static void ShowErrorToast(string message, string title = "Error")
        {
            if (!NotificationsEnabled) return;

            new NotificationBuilder()
                .WithTitle(title)
                .WithMessage(message)
                .WithType(IconType.Error)
                .WithDuration(NotificationDefaultDuration)
                .WithPosition(NotificationDefaultPosition)
                .WithProgressBar(NotificationShowProgressBar)
                .WithSound(NotificationPlaySound)
                .Show();
        }

        public static void ShowWarningToast(string message, string title = "Warning")
        {
            if (!NotificationsEnabled) return;

            new NotificationBuilder()
                .WithTitle(title)
                .WithMessage(message)
                .WithType(IconType.Warning)
                .WithDuration(NotificationDefaultDuration)
                .WithPosition(NotificationDefaultPosition)
                .WithProgressBar(NotificationShowProgressBar)
                .WithSound(NotificationPlaySound)
                .Show();
        }

        public static void ShowInfoToast(string message, string title = "Information")
        {
            if (!NotificationsEnabled) return;

            new NotificationBuilder()
                .WithTitle(title)
                .WithMessage(message)
                .WithType(IconType.Info)
                .WithDuration(NotificationDefaultDuration)
                .WithPosition(NotificationDefaultPosition)
                .WithProgressBar(NotificationShowProgressBar)
                .WithSound(NotificationPlaySound)
                .Show();
        }

        public static void ApplyPrimaryStyle(this ModernUI.Controls.NButton btn)
        {
            btn.BackgroundStartColor = Primary;
            btn.BackgroundEndColor = Primary;
            btn.HoverStartColor = PrimaryHover;
            btn.HoverEndColor = PrimaryHover;
            btn.PressedStartColor = PrimaryPressed;
            btn.PressedEndColor = PrimaryPressed;
            btn.BorderColor = Primary;
            btn.HoverBorderColor = PrimaryHover;
            btn.TextColor = SurfaceWhite;
            btn.HoverTextColor = SurfaceWhite;
            btn.BorderRadius = DefaultBorderRadius;
            btn.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.EnableHoverAnimation = EnableSystemAnimations;
            btn.EnableRippleEffect = EnableSystemAnimations;
            btn.RippleColor = Color.FromArgb(40, 255, 255, 255);
            btn.EnableIconTinting = true;
            btn.IconColor = IconLightColor;
            btn.HoverIconColor = IconLightColor;
        }

        public static void ApplySecondaryStyle(this ModernUI.Controls.NButton btn)
        {
            btn.BackgroundStartColor = NeutralBackground;
            btn.BackgroundEndColor = NeutralBackground;
            btn.HoverStartColor = NeutralHover;
            btn.HoverEndColor = NeutralHover;
            btn.PressedStartColor = NeutralPressed;
            btn.PressedEndColor = NeutralPressed;
            btn.BorderColor = NeutralBorder;
            btn.HoverBorderColor = NeutralHoverBorder;
            btn.BorderSize = 1;
            btn.TextColor = NeutralText;
            btn.HoverTextColor = TextPrimary;
            btn.BorderRadius = DefaultBorderRadius;
            btn.Cursor = Cursors.Hand;
            btn.EnableHoverAnimation = EnableSystemAnimations;
            btn.EnableRippleEffect = EnableSystemAnimations;
            btn.RippleColor = Color.FromArgb(25, 0, 0, 0);
            btn.EnableIconTinting = true;
            btn.IconColor = IconDefaultColor;
            btn.HoverIconColor = IconHoverColor;
        }

        public static void ApplyDangerStyle(this ModernUI.Controls.NButton btn)
        {
            btn.BackgroundStartColor = Danger;
            btn.BackgroundEndColor = Danger;
            btn.HoverStartColor = DangerHover;
            btn.HoverEndColor = DangerHover;
            btn.PressedStartColor = DangerPressed;
            btn.PressedEndColor = DangerPressed;
            btn.BorderColor = Danger;
            btn.HoverBorderColor = DangerHover;
            btn.TextColor = SurfaceWhite;
            btn.HoverTextColor = SurfaceWhite;
            btn.BorderRadius = DefaultBorderRadius;
            btn.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.EnableHoverAnimation = EnableSystemAnimations;
            btn.EnableRippleEffect = EnableSystemAnimations;
            btn.RippleColor = Color.FromArgb(40, 255, 255, 255);
            btn.EnableIconTinting = true;
            btn.IconColor = IconLightColor;
            btn.HoverIconColor = IconLightColor;
        }

        public static void ApplyStandardStyle(this NControls.NTextBox txt)
        {
            txt.BorderRadius = DefaultBorderRadius;
            txt.BorderSize = 1;
            txt.BorderColor = NeutralBorder;
            txt.BorderFocusColor = Primary;
            txt.FillColor = SurfaceWhite;
            txt.Font = new Font(SystemFontFamily, 10F, FontStyle.Regular);
            txt.ForeColor = TextPrimary;
            txt.PlaceholderColor = TextMuted;
            txt.ErrorBorderColor = Danger;
            txt.ShowClearButton = true;
            txt.EnableIconTinting = true;
            txt.IconColor = IconDefaultColor;
            txt.HoverIconColor = IconHoverColor;
        }

        public static void ApplyStandardStyle(this ComboBox cb)
        {
            cb.FlatStyle = FlatStyle.Flat;
            cb.Font = new Font(SystemFontFamily, 9.5F, FontStyle.Regular);
            cb.ForeColor = TextPrimary;
            cb.BackColor = SurfaceWhite;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ApplyStandardStyle(this NControls.NCheckBox chk)
        {
            chk.CheckedColor = Primary;
            chk.HoverBorderColor = Primary;
            chk.BoxBorderColor = NeutralBorder;
            chk.BoxBackColor = SurfaceWhite;
            chk.CheckMarkColor = SurfaceWhite;
            chk.ForeColor = TextPrimary;
            chk.Cursor = Cursors.Hand;
            chk.EnableAnimation = EnableSystemAnimations;
        }

        public static void ApplyModernStyle(this DataGridView dgv)
        {
            dgv.BackgroundColor = SurfaceWhite;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = NeutralBorder;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 42;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = NeutralBackground,
                Font = new Font(SystemFontFamily, 10F, FontStyle.Bold),
                ForeColor = NeutralText,
                SelectionBackColor = NeutralBackground,
                SelectionForeColor = NeutralText,
                Padding = new Padding(12, 0, 0, 0),
                WrapMode = DataGridViewTriState.False
            };

            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SurfaceWhite,
                Font = new Font(SystemFontFamily, 9.75F, FontStyle.Regular),
                ForeColor = TextPrimary,
                SelectionBackColor = Color.FromArgb(237, 233, 254),
                SelectionForeColor = PrimaryPressed,
                Padding = new Padding(12, 0, 0, 0),
                WrapMode = DataGridViewTriState.False
            };

            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(248, 250, 252),
                Font = new Font(SystemFontFamily, 9.75F, FontStyle.Regular),
                ForeColor = TextPrimary,
                SelectionBackColor = Color.FromArgb(237, 233, 254),
                SelectionForeColor = PrimaryPressed,
                Padding = new Padding(12, 0, 0, 0),
                WrapMode = DataGridViewTriState.False
            };
        }
    }
}