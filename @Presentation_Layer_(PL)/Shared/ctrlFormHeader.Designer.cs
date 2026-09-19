using CustomizeControls;
using DVLD.PL.Theme;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Global
{
    partial class ctrlFormHeader
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ThemeManager.ThemeChanged -= HandleThemeChanged;
                UnhookParentFormEvents();

                if (_parentControlRef != null)
                {
                    _parentControlRef.BackColorChanged -= Parent_BackColorChanged;
                    _parentControlRef = null;
                }

                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            pnlWindowControls = new Panel();
            btnMinimize = new NButton();
            btnMaximize = new NButton();
            btnClose = new NButton();
            btnUserProfile = new NButton();
            contextMenuUser = new ContextMenuStrip(components);
            itemCurrentUserInfo = new ToolStripMenuItem();
            itemChangePassword = new ToolStripMenuItem();
            itemSettings = new ToolStripMenuItem();
            sepUser = new ToolStripSeparator();
            itemSignOut = new ToolStripMenuItem();
            btnSwitchMode = new NButton();
            pnlWindowControls.SuspendLayout();
            contextMenuUser.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(12, 0, 0, 0);
            lblTitle.Size = new Size(1054, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlWindowControls
            // 
            pnlWindowControls.AutoSize = true;
            pnlWindowControls.BackColor = Color.Transparent;
            pnlWindowControls.Controls.Add(btnMinimize);
            pnlWindowControls.Controls.Add(btnMaximize);
            pnlWindowControls.Controls.Add(btnClose);
            pnlWindowControls.Dock = DockStyle.Right;
            pnlWindowControls.Location = new Point(1169, 0);
            pnlWindowControls.Name = "pnlWindowControls";
            pnlWindowControls.Size = new Size(135, 38);
            pnlWindowControls.TabIndex = 2;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.BackgroundEndColor = Color.Transparent;
            btnMinimize.BackgroundStartColor = Color.Transparent;
            btnMinimize.BorderColor = Color.DarkGray;
            btnMinimize.BorderRadius = 0;
            btnMinimize.BorderSize = 1;
            btnMinimize.ButtonType = enButtonType.Primary;
            btnMinimize.CenterIconWithText = false;
            btnMinimize.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnMinimize.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnMinimize.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnMinimize.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.EnableHoverAnimation = false;
            btnMinimize.EnableIconTinting = false;
            btnMinimize.EnableRippleEffect = false;
            btnMinimize.EnableShadow = false;
            btnMinimize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMinimize.GradientAngle = 90F;
            btnMinimize.HoverAnimationSpeed = 25;
            btnMinimize.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnMinimize.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnMinimize.HoverIconColor = Color.White;
            btnMinimize.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnMinimize.HoverTextColor = SystemColors.ControlText;
            btnMinimize.IconColor = Color.White;
            btnMinimize.IconMargin = 10;
            btnMinimize.IconOffset = new Point(0, 0);
            btnMinimize.IconSize = new Size(16, 16);
            btnMinimize.IconSpacing = 5;
            btnMinimize.IsLoading = false;
            btnMinimize.LeftIcon = null;
            btnMinimize.Location = new Point(0, 0);
            btnMinimize.Margin = new Padding(0);
            btnMinimize.MiddleIcon = null;
            btnMinimize.Name = "btnMinimize";
            btnMinimize.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnMinimize.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnMinimize.RightIcon = null;
            btnMinimize.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnMinimize.RippleSpeed = 15;
            btnMinimize.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnMinimize.ShadowOffset = new Point(1, 1);
            btnMinimize.ShadowSize = 3;
            btnMinimize.ShiftOnPress = false;
            btnMinimize.Size = new Size(45, 38);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "—";
            btnMinimize.TextColor = SystemColors.ControlText;
            btnMinimize.TextOffset = new Point(0, 0);
            // 
            // btnMaximize
            // 
            btnMaximize.BackColor = Color.Transparent;
            btnMaximize.BackgroundEndColor = Color.Transparent;
            btnMaximize.BackgroundStartColor = Color.Transparent;
            btnMaximize.BorderColor = Color.DarkGray;
            btnMaximize.BorderRadius = 0;
            btnMaximize.BorderSize = 1;
            btnMaximize.ButtonType = enButtonType.Primary;
            btnMaximize.CenterIconWithText = false;
            btnMaximize.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnMaximize.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnMaximize.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnMaximize.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.EnableHoverAnimation = false;
            btnMaximize.EnableIconTinting = false;
            btnMaximize.EnableRippleEffect = false;
            btnMaximize.EnableShadow = false;
            btnMaximize.Font = new Font("Segoe UI", 11F);
            btnMaximize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMaximize.GradientAngle = 90F;
            btnMaximize.HoverAnimationSpeed = 25;
            btnMaximize.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnMaximize.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnMaximize.HoverIconColor = Color.White;
            btnMaximize.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnMaximize.HoverTextColor = SystemColors.ControlText;
            btnMaximize.IconColor = Color.White;
            btnMaximize.IconMargin = 10;
            btnMaximize.IconOffset = new Point(0, 0);
            btnMaximize.IconSize = new Size(16, 16);
            btnMaximize.IconSpacing = 5;
            btnMaximize.IsLoading = false;
            btnMaximize.LeftIcon = null;
            btnMaximize.Location = new Point(45, 0);
            btnMaximize.Margin = new Padding(0);
            btnMaximize.MiddleIcon = Properties.Resources.maximize;
            btnMaximize.Name = "btnMaximize";
            btnMaximize.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnMaximize.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnMaximize.RightIcon = null;
            btnMaximize.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnMaximize.RippleSpeed = 15;
            btnMaximize.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnMaximize.ShadowOffset = new Point(1, 1);
            btnMaximize.ShadowSize = 3;
            btnMaximize.ShiftOnPress = false;
            btnMaximize.Size = new Size(45, 38);
            btnMaximize.TabIndex = 1;
            btnMaximize.TextColor = SystemColors.ControlText;
            btnMaximize.TextOffset = new Point(0, 0);
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BackgroundEndColor = Color.Transparent;
            btnClose.BackgroundStartColor = Color.Transparent;
            btnClose.BorderColor = Color.DarkGray;
            btnClose.BorderRadius = 0;
            btnClose.BorderSize = 1;
            btnClose.ButtonType = enButtonType.Primary;
            btnClose.CenterIconWithText = false;
            btnClose.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnClose.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnClose.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnClose.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnClose.Dock = DockStyle.Right;
            btnClose.EnableHoverAnimation = false;
            btnClose.EnableIconTinting = false;
            btnClose.EnableRippleEffect = false;
            btnClose.EnableShadow = false;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(148, 163, 184);
            btnClose.GradientAngle = 90F;
            btnClose.HoverAnimationSpeed = 25;
            btnClose.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnClose.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnClose.HoverIconColor = Color.White;
            btnClose.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnClose.HoverTextColor = SystemColors.ControlText;
            btnClose.IconColor = Color.White;
            btnClose.IconMargin = 10;
            btnClose.IconOffset = new Point(0, 0);
            btnClose.IconSize = new Size(16, 16);
            btnClose.IconSpacing = 5;
            btnClose.IsLoading = false;
            btnClose.LeftIcon = null;
            btnClose.Location = new Point(90, 0);
            btnClose.Margin = new Padding(0);
            btnClose.MiddleIcon = Properties.Resources.Close;
            btnClose.Name = "btnClose";
            btnClose.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnClose.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnClose.RightIcon = null;
            btnClose.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnClose.RippleSpeed = 15;
            btnClose.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnClose.ShadowOffset = new Point(1, 1);
            btnClose.ShadowSize = 3;
            btnClose.ShiftOnPress = false;
            btnClose.Size = new Size(45, 38);
            btnClose.TabIndex = 2;
            btnClose.TextColor = SystemColors.ControlText;
            btnClose.TextOffset = new Point(0, 0);
            // 
            // btnUserProfile
            // 
            btnUserProfile.BackColor = Color.Transparent;
            btnUserProfile.BackgroundEndColor = Color.Transparent;
            btnUserProfile.BackgroundStartColor = Color.Transparent;
            btnUserProfile.BorderColor = Color.DarkGray;
            btnUserProfile.BorderRadius = 0;
            btnUserProfile.BorderSize = 1;
            btnUserProfile.ButtonType = enButtonType.Primary;
            btnUserProfile.CenterIconWithText = false;
            btnUserProfile.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnUserProfile.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnUserProfile.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnUserProfile.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnUserProfile.Dock = DockStyle.Right;
            btnUserProfile.EnableHoverAnimation = false;
            btnUserProfile.EnableIconTinting = false;
            btnUserProfile.EnableRippleEffect = false;
            btnUserProfile.EnableShadow = false;
            btnUserProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUserProfile.ForeColor = Color.FromArgb(71, 85, 105);
            btnUserProfile.GradientAngle = 90F;
            btnUserProfile.HoverAnimationSpeed = 25;
            btnUserProfile.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnUserProfile.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnUserProfile.HoverIconColor = Color.White;
            btnUserProfile.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnUserProfile.HoverTextColor = SystemColors.ControlText;
            btnUserProfile.IconColor = Color.White;
            btnUserProfile.IconMargin = 10;
            btnUserProfile.IconOffset = new Point(0, 0);
            btnUserProfile.IconSize = new Size(16, 16);
            btnUserProfile.IconSpacing = 5;
            btnUserProfile.IsLoading = false;
            btnUserProfile.LeftIcon = null;
            btnUserProfile.Location = new Point(1054, 0);
            btnUserProfile.MiddleIcon = null;
            btnUserProfile.Name = "btnUserProfile";
            btnUserProfile.Padding = new Padding(14, 0, 14, 0);
            btnUserProfile.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnUserProfile.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnUserProfile.RightIcon = Properties.Resources.down;
            btnUserProfile.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnUserProfile.RippleSpeed = 15;
            btnUserProfile.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnUserProfile.ShadowOffset = new Point(1, 1);
            btnUserProfile.ShadowSize = 3;
            btnUserProfile.ShiftOnPress = false;
            btnUserProfile.Size = new Size(115, 38);
            btnUserProfile.TabIndex = 1;
            btnUserProfile.Text = " User ";
            btnUserProfile.TextColor = SystemColors.ControlText;
            btnUserProfile.TextOffset = new Point(0, 0);
            btnUserProfile.Visible = false;
            // 
            // contextMenuUser
            // 
            contextMenuUser.Font = new Font("Segoe UI", 10F);
            contextMenuUser.Items.AddRange(new ToolStripItem[] { itemCurrentUserInfo, itemChangePassword, itemSettings, sepUser, itemSignOut });
            contextMenuUser.Name = "contextMenuUser";
            contextMenuUser.Size = new Size(188, 106);
            // 
            // itemCurrentUserInfo
            // 
            itemCurrentUserInfo.Name = "itemCurrentUserInfo";
            itemCurrentUserInfo.Size = new Size(187, 24);
            itemCurrentUserInfo.Text = "Current User Info";
            // 
            // itemChangePassword
            // 
            itemChangePassword.Name = "itemChangePassword";
            itemChangePassword.Size = new Size(187, 24);
            itemChangePassword.Text = "Change Password";
            // 
            // itemSettings
            // 
            itemSettings.Name = "itemSettings";
            itemSettings.Size = new Size(187, 24);
            itemSettings.Text = "Settings";
            // 
            // sepUser
            // 
            sepUser.Name = "sepUser";
            sepUser.Size = new Size(184, 6);
            // 
            // itemSignOut
            // 
            itemSignOut.ForeColor = Color.FromArgb(220, 38, 38);
            itemSignOut.Name = "itemSignOut";
            itemSignOut.Size = new Size(187, 24);
            itemSignOut.Tag = "Danger";
            itemSignOut.Text = "Sign Out";
            // 
            // btnSwitchMode
            // 
            btnSwitchMode.BackColor = Color.Transparent;
            btnSwitchMode.BackgroundEndColor = Color.Transparent;
            btnSwitchMode.BackgroundStartColor = Color.Transparent;
            btnSwitchMode.BorderColor = Color.DarkGray;
            btnSwitchMode.BorderRadius = 0;
            btnSwitchMode.BorderSize = 1;
            btnSwitchMode.ButtonType = enButtonType.Primary;
            btnSwitchMode.CenterIconWithText = false;
            btnSwitchMode.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnSwitchMode.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnSwitchMode.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnSwitchMode.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnSwitchMode.Dock = DockStyle.Right;
            btnSwitchMode.EnableHoverAnimation = false;
            btnSwitchMode.EnableIconTinting = false;
            btnSwitchMode.EnableRippleEffect = false;
            btnSwitchMode.EnableShadow = false;
            btnSwitchMode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSwitchMode.ForeColor = Color.FromArgb(148, 163, 184);
            btnSwitchMode.GradientAngle = 90F;
            btnSwitchMode.HoverAnimationSpeed = 25;
            btnSwitchMode.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSwitchMode.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSwitchMode.HoverIconColor = Color.White;
            btnSwitchMode.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSwitchMode.HoverTextColor = SystemColors.ControlText;
            btnSwitchMode.IconColor = Color.White;
            btnSwitchMode.IconMargin = 10;
            btnSwitchMode.IconOffset = new Point(0, 0);
            btnSwitchMode.IconSize = new Size(16, 16);
            btnSwitchMode.IconSpacing = 5;
            btnSwitchMode.IsLoading = false;
            btnSwitchMode.LeftIcon = null;
            btnSwitchMode.Location = new Point(1009, 0);
            btnSwitchMode.Margin = new Padding(0);
            btnSwitchMode.MiddleIcon = null;
            btnSwitchMode.Name = "btnSwitchMode";
            btnSwitchMode.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSwitchMode.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSwitchMode.RightIcon = null;
            btnSwitchMode.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnSwitchMode.RippleSpeed = 15;
            btnSwitchMode.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnSwitchMode.ShadowOffset = new Point(1, 1);
            btnSwitchMode.ShadowSize = 3;
            btnSwitchMode.ShiftOnPress = false;
            btnSwitchMode.Size = new Size(45, 38);
            btnSwitchMode.TabIndex = 3;
            btnSwitchMode.Text = "—";
            btnSwitchMode.TextColor = SystemColors.ControlText;
            btnSwitchMode.TextOffset = new Point(0, 0);
            // 
            // ctrlFormHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnSwitchMode);
            Controls.Add(lblTitle);
            Controls.Add(btnUserProfile);
            Controls.Add(pnlWindowControls);
            Name = "ctrlFormHeader";
            Size = new Size(1304, 38);
            pnlWindowControls.ResumeLayout(false);
            contextMenuUser.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private NButton btnUserProfile;
        private Panel pnlWindowControls;
        private NButton btnMinimize;
        private NButton btnMaximize;
        private NButton btnClose;
        private ContextMenuStrip contextMenuUser;
        private ToolStripMenuItem itemCurrentUserInfo;
        private ToolStripMenuItem itemChangePassword;
        private ToolStripMenuItem itemSettings;
        private ToolStripSeparator sepUser;
        private ToolStripMenuItem itemSignOut;
        private NButton btnSwitchMode;
    }
}