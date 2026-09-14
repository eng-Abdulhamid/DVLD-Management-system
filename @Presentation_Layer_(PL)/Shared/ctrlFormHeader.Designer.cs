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
                UITheme.OnThemeChanged -= HandleThemeChanged;
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            pnlWindowControls = new Panel();
            btnMinimize = new Button();
            btnMaximize = new Button();
            btnClose = new Button();
            btnUserProfile = new Button();
            contextMenuUser = new ContextMenuStrip(components);
            itemCurrentUserInfo = new ToolStripMenuItem();
            itemChangePassword = new ToolStripMenuItem();
            itemSettings = new ToolStripMenuItem();
            sepUser = new ToolStripSeparator();
            itemSignOut = new ToolStripMenuItem();
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
            lblTitle.Size = new Size(1051, 38);
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
            pnlWindowControls.Location = new Point(1166, 0);
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
            // btnUserProfile
            // 
            btnUserProfile.AutoSize = true;
            btnUserProfile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnUserProfile.BackColor = Color.Transparent;
            btnUserProfile.Dock = DockStyle.Right;
            btnUserProfile.FlatAppearance.BorderSize = 0;
            btnUserProfile.FlatStyle = FlatStyle.Flat;
            btnUserProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUserProfile.ForeColor = Color.FromArgb(71, 85, 105);
            btnUserProfile.Location = new Point(1051, 0);
            btnUserProfile.Name = "btnUserProfile";
            btnUserProfile.Padding = new Padding(14, 0, 14, 0);
            btnUserProfile.Size = new Size(115, 38);
            btnUserProfile.TabIndex = 1;
            btnUserProfile.Text = "👤  User  ▾";
            btnUserProfile.UseVisualStyleBackColor = true;
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
            // ctrlFormHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
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

        #endregion

        private Label lblTitle;
        private Button btnUserProfile;
        private Panel pnlWindowControls;
        private Button btnMinimize;
        private Button btnMaximize;
        private Button btnClose;

        private ContextMenuStrip contextMenuUser;
        private ToolStripMenuItem itemCurrentUserInfo;
        private ToolStripMenuItem itemChangePassword;
        private ToolStripMenuItem itemSettings;
        private ToolStripSeparator sepUser;
        private ToolStripMenuItem itemSignOut;
    }
}