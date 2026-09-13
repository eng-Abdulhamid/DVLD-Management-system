using DVLD.PL.Global;
using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL
{
    partial class frmMainScreen
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContainer;
        private Panel pnlContentArea;
        private MenuStrip menuStrip1;

        // Management Menu
        private ToolStripMenuItem peopleManagementToolStripMenuItem;
        private ToolStripMenuItem btnPeopleManagement;
        private ToolStripMenuItem btnUsersManagement;
        private ToolStripMenuItem btnDriversManagement;

        // Account & Settings Menu
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem btnCurrentUserInfo;
        private ToolStripMenuItem btnChangePassword;
        private ToolStripSeparator sepAccount;
        private ToolStripMenuItem btnSignOut;

        // Current User Profile Button
        private ToolStripMenuItem btnCurrentUser;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                AppSession.OnUserSessionChanged -= UpdateCurrentUserInfo;
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pnlContentArea = new Panel();
            menuStrip1 = new MenuStrip();

            // عناصر الإدارة
            peopleManagementToolStripMenuItem = new ToolStripMenuItem();
            btnPeopleManagement = new ToolStripMenuItem();
            btnUsersManagement = new ToolStripMenuItem();
            btnDriversManagement = new ToolStripMenuItem();

            // عناصر الحساب والإعدادات
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            btnCurrentUserInfo = new ToolStripMenuItem();
            btnChangePassword = new ToolStripMenuItem();
            sepAccount = new ToolStripSeparator();
            btnSignOut = new ToolStripMenuItem();

            // زر المستخدم الحالي (أقصى اليمين)
            btnCurrentUser = new ToolStripMenuItem();

            pnlContainer.SuspendLayout();
            pnlContentArea.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(1100, 38);
            headerControl.TitleText = "DVLD - Management System";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.FromArgb(248, 250, 252);
            pnlContainer.Controls.Add(pnlContentArea);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 38);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(2);
            pnlContainer.Size = new Size(1100, 612);
            pnlContainer.TabIndex = 1;
            // 
            // pnlContentArea
            // 
            pnlContentArea.BackColor = Color.White;
            pnlContentArea.Controls.Add(menuStrip1);
            pnlContentArea.Dock = DockStyle.Fill;
            pnlContentArea.Location = new Point(2, 2);
            pnlContentArea.Name = "pnlContentArea";
            pnlContentArea.Padding = new Padding(24, 16, 24, 24);
            pnlContentArea.Size = new Size(1096, 608);
            pnlContentArea.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] {
                peopleManagementToolStripMenuItem,
                accountSettingsToolStripMenuItem,
                btnCurrentUser
            });
            menuStrip1.Location = new Point(24, 16);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.ShowItemToolTips = true;
            menuStrip1.Size = new Size(1048, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // peopleManagementToolStripMenuItem
            // 
            peopleManagementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                btnPeopleManagement,
                btnUsersManagement,
                btnDriversManagement
            });
            peopleManagementToolStripMenuItem.ForeColor = Color.FromArgb(30, 41, 59);
            peopleManagementToolStripMenuItem.Name = "peopleManagementToolStripMenuItem";
            peopleManagementToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            peopleManagementToolStripMenuItem.Size = new Size(130, 32);
            peopleManagementToolStripMenuItem.Text = "📁 Management";
            // 
            // btnPeopleManagement
            // 
            btnPeopleManagement.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPeopleManagement.ForeColor = Color.FromArgb(30, 41, 59);
            btnPeopleManagement.Name = "btnPeopleManagement";
            btnPeopleManagement.Padding = new Padding(8, 6, 16, 6);
            btnPeopleManagement.Size = new Size(230, 32);
            btnPeopleManagement.Text = "People Management";
            btnPeopleManagement.Click += btnPeopleManagement_Click;
            // 
            // btnUsersManagement
            // 
            btnUsersManagement.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUsersManagement.ForeColor = Color.FromArgb(30, 41, 59);
            btnUsersManagement.Name = "btnUsersManagement";
            btnUsersManagement.Padding = new Padding(8, 6, 16, 6);
            btnUsersManagement.Size = new Size(230, 32);
            btnUsersManagement.Text = "Users Management";
            btnUsersManagement.Click += btnUsersManagement_Click;
            // 
            // btnDriversManagement
            // 
            btnDriversManagement.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDriversManagement.ForeColor = Color.FromArgb(30, 41, 59);
            btnDriversManagement.Name = "btnDriversManagement";
            btnDriversManagement.Padding = new Padding(8, 6, 16, 6);
            btnDriversManagement.Size = new Size(230, 32);
            btnDriversManagement.Text = "Drivers Management";
            btnDriversManagement.Click += btnDriversManagement_Click;
            // 
            // accountSettingsToolStripMenuItem
            // 
            accountSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                btnCurrentUserInfo,
                btnChangePassword,
                sepAccount,
                btnSignOut
            });
            accountSettingsToolStripMenuItem.ForeColor = Color.FromArgb(30, 41, 59);
            accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            accountSettingsToolStripMenuItem.Padding = new Padding(12, 6, 12, 6);
            accountSettingsToolStripMenuItem.Size = new Size(150, 32);
            accountSettingsToolStripMenuItem.Text = "⚙️ Account Settings";
            // 
            // btnCurrentUserInfo
            // 
            btnCurrentUserInfo.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCurrentUserInfo.ForeColor = Color.FromArgb(30, 41, 59);
            btnCurrentUserInfo.Name = "btnCurrentUserInfo";
            btnCurrentUserInfo.Padding = new Padding(8, 6, 16, 6);
            btnCurrentUserInfo.Size = new Size(220, 32);
            btnCurrentUserInfo.Text = "Current User Info";
            btnCurrentUserInfo.Click += btnCurrentUserInfo_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.FromArgb(30, 41, 59);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Padding = new Padding(8, 6, 16, 6);
            btnChangePassword.Size = new Size(220, 32);
            btnChangePassword.Text = "Change Password";
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // sepAccount
            // 
            sepAccount.Name = "sepAccount";
            sepAccount.Size = new Size(217, 6);
            // 
            // btnSignOut
            // 
            btnSignOut.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignOut.ForeColor = Color.FromArgb(239, 68, 68);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Padding = new Padding(8, 6, 16, 6);
            btnSignOut.Size = new Size(220, 32);
            btnSignOut.Tag = "Danger";
            btnSignOut.Text = "Sign Out";
            btnSignOut.Click += btnSignOut_Click;
            // 
            // btnCurrentUser
            // 
            btnCurrentUser.Alignment = ToolStripItemAlignment.Right;
            btnCurrentUser.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCurrentUser.ForeColor = Color.FromArgb(124, 58, 237);
            btnCurrentUser.Name = "btnCurrentUser";
            btnCurrentUser.Padding = new Padding(12, 6, 12, 6);
            btnCurrentUser.Size = new Size(110, 32);
            btnCurrentUser.Text = "👤 Current User";
            btnCurrentUser.Click += btnCurrentUserInfo_Click;
            // 
            // frmMainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(1100, 650);
            Controls.Add(pnlContainer);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(950, 580);
            Name = "frmMainScreen";
            Text = "DVLD - Management System";
            Controls.SetChildIndex(pnlContainer, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlContainer.ResumeLayout(false);
            pnlContentArea.ResumeLayout(false);
            pnlContentArea.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}