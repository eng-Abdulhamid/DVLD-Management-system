using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Global
{
    partial class ctrlFormHeader
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            pnlWindowControls = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            pnlUserActions = new Panel();
            btnPreferences = new NButton();
            btnCurrentUser = new NButton();
            cmsUserMenu = new ContextMenuStrip(components);
            tsmiViewProfile = new ToolStripMenuItem();
            tsmiEditInfo = new ToolStripMenuItem();
            tsmiChangePassword = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiLogout = new ToolStripMenuItem();
            pnlWindowControls.SuspendLayout();
            pnlUserActions.SuspendLayout();
            cmsUserMenu.SuspendLayout();
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
            lblTitle.Size = new Size(870, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlWindowControls
            // 
            pnlWindowControls.AutoSize = true;
            pnlWindowControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlWindowControls.BackColor = Color.Transparent;
            pnlWindowControls.Controls.Add(btnMinimize);
            pnlWindowControls.Controls.Add(btnMaximize);
            pnlWindowControls.Controls.Add(btnClose);
            pnlWindowControls.Dock = DockStyle.Right;
            pnlWindowControls.Location = new Point(1040, 0);
            pnlWindowControls.Name = "pnlWindowControls";
            pnlWindowControls.Size = new Size(138, 38);
            pnlWindowControls.TabIndex = 2;
            // 
            // btnMinimize
            // 
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMinimize.Location = new Point(0, 0);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(46, 38);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "—";
            btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnMaximize
            // 
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.Font = new Font("Segoe UI", 11F);
            btnMaximize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMaximize.Location = new Point(46, 0);
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new Size(46, 38);
            btnMaximize.TabIndex = 1;
            btnMaximize.Text = "🗖";
            btnMaximize.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(148, 163, 184);
            btnClose.Location = new Point(92, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(46, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlUserActions
            // 
            pnlUserActions.AutoSize = true;
            pnlUserActions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlUserActions.BackColor = Color.Transparent;
            pnlUserActions.Controls.Add(btnPreferences);
            pnlUserActions.Controls.Add(btnCurrentUser);
            pnlUserActions.Dock = DockStyle.Right;
            pnlUserActions.Location = new Point(870, 0);
            pnlUserActions.Name = "pnlUserActions";
            pnlUserActions.Padding = new Padding(0, 3, 6, 3);
            pnlUserActions.Size = new Size(170, 38);
            pnlUserActions.TabIndex = 1;
            // 
            // btnPreferences
            // 
            btnPreferences.BackColor = Color.Transparent;
            btnPreferences.BackgroundEndColor = Color.Transparent;
            btnPreferences.BackgroundStartColor = Color.Transparent;
            btnPreferences.BorderColor = Color.Transparent;
            btnPreferences.BorderRadius = 6;
            btnPreferences.BorderSize = 0;
            btnPreferences.CenterIconWithText = false;
            btnPreferences.Cursor = Cursors.Hand;
            btnPreferences.Dock = DockStyle.Right;
            btnPreferences.EnableHoverAnimation = false;
            btnPreferences.EnableIconTinting = false;
            btnPreferences.EnableRippleEffect = false;
            btnPreferences.EnableShadow = false;
            btnPreferences.Font = new Font("Segoe UI", 11F);
            btnPreferences.ForeColor = Color.FromArgb(100, 116, 139);
            btnPreferences.GradientAngle = 90F;
            btnPreferences.HoverAnimationSpeed = 20;
            btnPreferences.HoverBorderColor = Color.Transparent;
            btnPreferences.HoverEndColor = Color.FromArgb(241, 245, 249);
            btnPreferences.HoverIconColor = Color.White;
            btnPreferences.HoverStartColor = Color.FromArgb(241, 245, 249);
            btnPreferences.HoverTextColor = Color.FromArgb(15, 23, 42);
            btnPreferences.IconColor = Color.White;
            btnPreferences.IconMargin = 10;
            btnPreferences.IconOffset = new Point(0, 0);
            btnPreferences.IconSize = new Size(16, 16);
            btnPreferences.IconSpacing = 5;
            btnPreferences.IsLoading = false;
            btnPreferences.LeftIcon = null;
            btnPreferences.Location = new Point(0, 3);
            btnPreferences.MiddleIcon = null;
            btnPreferences.Name = "btnPreferences";
            btnPreferences.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnPreferences.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnPreferences.RightIcon = null;
            btnPreferences.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnPreferences.RippleSpeed = 15;
            btnPreferences.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnPreferences.ShadowOffset = new Point(1, 1);
            btnPreferences.ShadowSize = 3;
            btnPreferences.ShiftOnPress = false;
            btnPreferences.Size = new Size(34, 32);
            btnPreferences.TabIndex = 0;
            btnPreferences.Text = "⚙";
            btnPreferences.TextColor = Color.FromArgb(100, 116, 139);
            btnPreferences.TextOffset = new Point(0, 0);
            // 
            // btnCurrentUser
            // 
            btnCurrentUser.BackColor = Color.Transparent;
            btnCurrentUser.BackgroundEndColor = Color.Transparent;
            btnCurrentUser.BackgroundStartColor = Color.Transparent;
            btnCurrentUser.BorderColor = Color.Transparent;
            btnCurrentUser.BorderRadius = 6;
            btnCurrentUser.BorderSize = 0;
            btnCurrentUser.CenterIconWithText = false;
            btnCurrentUser.Cursor = Cursors.Hand;
            btnCurrentUser.Dock = DockStyle.Right;
            btnCurrentUser.EnableHoverAnimation = false;
            btnCurrentUser.EnableIconTinting = false;
            btnCurrentUser.EnableRippleEffect = false;
            btnCurrentUser.EnableShadow = false;
            btnCurrentUser.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCurrentUser.ForeColor = Color.FromArgb(71, 85, 105);
            btnCurrentUser.GradientAngle = 90F;
            btnCurrentUser.HoverAnimationSpeed = 20;
            btnCurrentUser.HoverBorderColor = Color.Transparent;
            btnCurrentUser.HoverEndColor = Color.FromArgb(241, 245, 249);
            btnCurrentUser.HoverIconColor = Color.White;
            btnCurrentUser.HoverStartColor = Color.FromArgb(241, 245, 249);
            btnCurrentUser.HoverTextColor = Color.FromArgb(15, 23, 42);
            btnCurrentUser.IconColor = Color.White;
            btnCurrentUser.IconMargin = 10;
            btnCurrentUser.IconOffset = new Point(0, 0);
            btnCurrentUser.IconSize = new Size(16, 16);
            btnCurrentUser.IconSpacing = 5;
            btnCurrentUser.IsLoading = false;
            btnCurrentUser.LeftIcon = null;
            btnCurrentUser.Location = new Point(34, 3);
            btnCurrentUser.MiddleIcon = null;
            btnCurrentUser.Name = "btnCurrentUser";
            btnCurrentUser.Padding = new Padding(8, 0, 8, 0);
            btnCurrentUser.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnCurrentUser.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnCurrentUser.RightIcon = null;
            btnCurrentUser.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnCurrentUser.RippleSpeed = 15;
            btnCurrentUser.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnCurrentUser.ShadowOffset = new Point(1, 1);
            btnCurrentUser.ShadowSize = 3;
            btnCurrentUser.ShiftOnPress = false;
            btnCurrentUser.Size = new Size(130, 32);
            btnCurrentUser.TabIndex = 1;
            btnCurrentUser.Text = "User Name ▾";
            btnCurrentUser.TextColor = Color.FromArgb(71, 85, 105);
            btnCurrentUser.TextOffset = new Point(0, 0);
            // 
            // cmsUserMenu
            // 
            cmsUserMenu.Font = new Font("Segoe UI", 9.5F);
            cmsUserMenu.Items.AddRange(new ToolStripItem[] { tsmiViewProfile, tsmiEditInfo, tsmiChangePassword, toolStripSeparator1, tsmiLogout });
            cmsUserMenu.Name = "cmsUserMenu";
            cmsUserMenu.Size = new Size(181, 98);
            // 
            // tsmiViewProfile
            // 
            tsmiViewProfile.Name = "tsmiViewProfile";
            tsmiViewProfile.Size = new Size(180, 22);
            tsmiViewProfile.Text = "View Profile";
            // 
            // tsmiEditInfo
            // 
            tsmiEditInfo.Name = "tsmiEditInfo";
            tsmiEditInfo.Size = new Size(180, 22);
            tsmiEditInfo.Text = "Edit Personal Info";
            // 
            // tsmiChangePassword
            // 
            tsmiChangePassword.Name = "tsmiChangePassword";
            tsmiChangePassword.Size = new Size(180, 22);
            tsmiChangePassword.Text = "Change Password";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // tsmiLogout
            // 
            tsmiLogout.ForeColor = Color.FromArgb(239, 68, 68);
            tsmiLogout.Name = "tsmiLogout";
            tsmiLogout.Size = new Size(180, 22);
            tsmiLogout.Text = "Sign Out";
            // 
            // ctrlFormHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblTitle);
            Controls.Add(pnlUserActions);
            Controls.Add(pnlWindowControls);
            Name = "ctrlFormHeader";
            Size = new Size(1178, 38);
            pnlWindowControls.ResumeLayout(false);
            pnlUserActions.ResumeLayout(false);
            pnlUserActions.PerformLayout();
            cmsUserMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Panel pnlWindowControls;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnClose;
        private Panel pnlUserActions;
        private NButton btnPreferences;
        private NButton btnCurrentUser;
        private ContextMenuStrip cmsUserMenu;
        private ToolStripMenuItem tsmiViewProfile;
        private ToolStripMenuItem tsmiEditInfo;
        private ToolStripMenuItem tsmiChangePassword;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiLogout;
    }
}