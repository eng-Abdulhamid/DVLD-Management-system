using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Login
{
    partial class frmForgetPassword
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblUsername;
        private NControls.NTextBox txtUserName;
        private ModernUI.Controls.NButton btnVerifyUser;
        private ModernUI.Controls.NButton btnVerifiedCheck;
        private ModernUI.Controls.NButton btnEditUsername;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlCreateNewPassword;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblOldPassword;
        private NControls.NTextBox txtOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private NControls.NTextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private NControls.NTextBox txtConfirmPassword;
        private System.Windows.Forms.LinkLabel lnkForgotCurrentPassword;
        private ModernUI.Controls.NButton btnChangePassword;
        private ModernUI.Controls.NButton btnCancel;

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
            lblStatus = new Label();
            btnEditUsername = new ModernUI.Controls.NButton();
            btnVerifiedCheck = new ModernUI.Controls.NButton();
            btnVerifyUser = new ModernUI.Controls.NButton();
            txtUserName = new NControls.NTextBox();
            lblUsername = new Label();
            lblStep1 = new Label();
            lblSubHeader = new Label();
            lblHeader = new Label();
            pnlCreateNewPassword = new Panel();
            lblStep2 = new Label();
            lblOldPassword = new Label();
            txtOldPassword = new NControls.NTextBox();
            lblNewPassword = new Label();
            txtNewPassword = new NControls.NTextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new NControls.NTextBox();
            lnkForgotCurrentPassword = new LinkLabel();
            btnChangePassword = new ModernUI.Controls.NButton();
            btnCancel = new ModernUI.Controls.NButton();
            pnlMain = new Panel();
            pnlCreateNewPassword.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(520, 38);
            headerControl.TitleText = "DVLD - Reset Password";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlCreateNewPassword);
            pnlMain.Controls.Add(lblHeader);
            pnlMain.Controls.Add(lblSubHeader);
            pnlMain.Controls.Add(lblStep1);
            pnlMain.Controls.Add(lblUsername);
            pnlMain.Controls.Add(txtUserName);
            pnlMain.Controls.Add(btnVerifyUser);
            pnlMain.Controls.Add(btnVerifiedCheck);
            pnlMain.Controls.Add(btnEditUsername);
            pnlMain.Controls.Add(lblStatus);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(2, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(516, 638);
            pnlMain.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblHeader.Location = new Point(36, 25);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(265, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Reset your password";
            // 
            // lblSubHeader
            // 
            lblSubHeader.AutoSize = true;
            lblSubHeader.Font = new Font("Segoe UI", 9.5F);
            lblSubHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubHeader.Location = new Point(38, 66);
            lblSubHeader.Name = "lblSubHeader";
            lblSubHeader.Size = new Size(311, 17);
            lblSubHeader.TabIndex = 1;
            lblSubHeader.Text = "Verify your account first, then choose a new password.";
            // 
            // lblStep1
            // 
            lblStep1.AutoSize = true;
            lblStep1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblStep1.ForeColor = Color.FromArgb(124, 58, 237);
            lblStep1.Location = new Point(38, 115);
            lblStep1.Name = "lblStep1";
            lblStep1.Size = new Size(137, 19);
            lblStep1.TabIndex = 2;
            lblStep1.Text = "1. Verify your account";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(71, 85, 105);
            lblUsername.Location = new Point(38, 145);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 17);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // txtUserName
            // 
            txtUserName.AllowArabicCharacters = false;
            txtUserName.AllowEnglishCharacters = true;
            txtUserName.AllowNumbers = true;
            txtUserName.AllowSpaces = false;
            txtUserName.AllowSymbols = true;
            txtUserName.BackColor = Color.Transparent;
            txtUserName.BorderColor = Color.FromArgb(226, 232, 240);
            txtUserName.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtUserName.BorderRadius = 8;
            txtUserName.BorderSize = 1;
            txtUserName.CustomAllowedCharacters = "";
            txtUserName.EnableIconTinting = true;
            txtUserName.EnableSuggest = false;
            txtUserName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtUserName.FillColor = Color.White;
            txtUserName.Font = new Font("Segoe UI", 10F);
            txtUserName.ForeColor = Color.FromArgb(15, 23, 42);
            txtUserName.HasError = false;
            txtUserName.IconColor = Color.FromArgb(148, 163, 184);
            txtUserName.IconOffsetLeft = 12;
            txtUserName.IconOffsetRight = 10;
            txtUserName.IconSize = new Size(18, 18);
            txtUserName.IconSpacing = 8;
            txtUserName.LeftIcon = Properties.Resources.User;
            txtUserName.LeftIconClickable = false;
            txtUserName.Location = new Point(38, 168);
            txtUserName.MaxLength = 50;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(8, 12, 8, 12);
            txtUserName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.RightIcon = null;
            txtUserName.RightIconClickable = false;
            txtUserName.ShowClearButton = false;
            txtUserName.Size = new Size(300, 44);
            txtUserName.SuggestIcon = null;
            txtUserName.TabIndex = 0;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            // 
            // btnVerifyUser
            // 
            btnVerifyUser.BackColor = Color.Transparent;
            btnVerifyUser.BorderRadius = 8;
            btnVerifyUser.BorderSize = 0;
            btnVerifyUser.CenterIconWithText = true;
            btnVerifyUser.Cursor = Cursors.Hand;
            btnVerifyUser.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVerifyUser.IsLoading = false;
            btnVerifyUser.LeftIcon = null;
            btnVerifyUser.Location = new Point(348, 168);
            btnVerifyUser.Name = "btnVerifyUser";
            btnVerifyUser.RightIcon = null;
            btnVerifyUser.Size = new Size(125, 44);
            btnVerifyUser.TabIndex = 1;
            btnVerifyUser.Text = "Verify";
            btnVerifyUser.TextOffset = new Point(0, 0);
            // 
            // btnVerifiedCheck
            // 
            btnVerifiedCheck.BackColor = Color.Transparent;
            btnVerifiedCheck.BorderRadius = 8;
            btnVerifiedCheck.BorderSize = 0;
            btnVerifiedCheck.CenterIconWithText = true;
            btnVerifiedCheck.Cursor = Cursors.Default;
            btnVerifiedCheck.EnableHoverAnimation = false;
            btnVerifiedCheck.EnableRippleEffect = false;
            btnVerifiedCheck.IconSize = new Size(22, 22);
            btnVerifiedCheck.IsLoading = false;
            btnVerifiedCheck.LeftIcon = null;
            btnVerifiedCheck.Location = new Point(352, 168);
            btnVerifiedCheck.MiddleIcon = Properties.Resources.hasFounded;
            btnVerifiedCheck.Name = "btnVerifiedCheck";
            btnVerifiedCheck.RightIcon = null;
            btnVerifiedCheck.Size = new Size(44, 44);
            btnVerifiedCheck.TabIndex = 2;
            btnVerifiedCheck.TabStop = false;
            btnVerifiedCheck.Text = "";
            btnVerifiedCheck.TextOffset = new Point(0, 0);
            btnVerifiedCheck.Visible = false;
            // 
            // btnEditUsername
            // 
            btnEditUsername.BackColor = Color.Transparent;
            btnEditUsername.BorderRadius = 8;
            btnEditUsername.BorderSize = 1;
            btnEditUsername.CenterIconWithText = true;
            btnEditUsername.Cursor = Cursors.Hand;
            btnEditUsername.IconSize = new Size(18, 18);
            btnEditUsername.IsLoading = false;
            btnEditUsername.LeftIcon = null;
            btnEditUsername.Location = new Point(404, 168);
            btnEditUsername.MiddleIcon = Properties.Resources.editSquare;
            btnEditUsername.Name = "btnEditUsername";
            btnEditUsername.RightIcon = null;
            btnEditUsername.Size = new Size(44, 44);
            btnEditUsername.TabIndex = 3;
            btnEditUsername.Text = "";
            btnEditUsername.TextOffset = new Point(0, 0);
            btnEditUsername.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblStatus.Location = new Point(38, 222);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 11;
            lblStatus.Visible = false;
            // 
            // pnlCreateNewPassword
            // 
            pnlCreateNewPassword.Controls.Add(lblStep2);
            pnlCreateNewPassword.Controls.Add(lblOldPassword);
            pnlCreateNewPassword.Controls.Add(txtOldPassword);
            pnlCreateNewPassword.Controls.Add(lblNewPassword);
            pnlCreateNewPassword.Controls.Add(txtNewPassword);
            pnlCreateNewPassword.Controls.Add(lblConfirmPassword);
            pnlCreateNewPassword.Controls.Add(txtConfirmPassword);
            pnlCreateNewPassword.Controls.Add(lnkForgotCurrentPassword);
            pnlCreateNewPassword.Controls.Add(btnChangePassword);
            pnlCreateNewPassword.Controls.Add(btnCancel);
            pnlCreateNewPassword.Location = new Point(28, 245);
            pnlCreateNewPassword.Name = "pnlCreateNewPassword";
            pnlCreateNewPassword.Size = new Size(460, 380);
            pnlCreateNewPassword.TabIndex = 14;
            pnlCreateNewPassword.Visible = false;
            // 
            // lblStep2
            // 
            lblStep2.AutoSize = true;
            lblStep2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblStep2.ForeColor = Color.FromArgb(124, 58, 237);
            lblStep2.Location = new Point(10, 6);
            lblStep2.Name = "lblStep2";
            lblStep2.Size = new Size(162, 19);
            lblStep2.TabIndex = 5;
            lblStep2.Text = "2. Create a new password";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblOldPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblOldPassword.Location = new Point(10, 42);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(115, 17);
            lblOldPassword.TabIndex = 6;
            lblOldPassword.Text = "Current password";
            // 
            // txtOldPassword
            // 
            txtOldPassword.AllowArabicCharacters = true;
            txtOldPassword.AllowEnglishCharacters = true;
            txtOldPassword.AllowNumbers = true;
            txtOldPassword.AllowSpaces = true;
            txtOldPassword.AllowSymbols = true;
            txtOldPassword.BackColor = Color.Transparent;
            txtOldPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtOldPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtOldPassword.BorderRadius = 8;
            txtOldPassword.BorderSize = 1;
            txtOldPassword.CustomAllowedCharacters = "";
            txtOldPassword.EnableIconTinting = true;
            txtOldPassword.EnableSuggest = false;
            txtOldPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtOldPassword.FillColor = Color.White;
            txtOldPassword.Font = new Font("Segoe UI", 10F);
            txtOldPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtOldPassword.HasError = false;
            txtOldPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtOldPassword.IconOffsetLeft = 10;
            txtOldPassword.IconOffsetRight = 12;
            txtOldPassword.IconSize = new Size(18, 18);
            txtOldPassword.IconSpacing = 8;
            txtOldPassword.LeftIcon = null;
            txtOldPassword.LeftIconClickable = false;
            txtOldPassword.Location = new Point(10, 64);
            txtOldPassword.MaxLength = 50;
            txtOldPassword.MaxSuggestItems = 8;
            txtOldPassword.MoveToNextControlOnEnter = true;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Padding = new Padding(8, 12, 8, 12);
            txtOldPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtOldPassword.PlaceholderText = "Enter your current password";
            txtOldPassword.RightIcon = Properties.Resources.visibilityOff;
            txtOldPassword.RightIconClickable = true;
            txtOldPassword.ShowClearButton = false;
            txtOldPassword.Size = new Size(330, 44);
            txtOldPassword.SuggestIcon = null;
            txtOldPassword.TabIndex = 4;
            txtOldPassword.UseSystemPasswordChar = true;
            txtOldPassword.ValidateEmail = false;
            // 
            // lnkForgotCurrentPassword
            // 
            lnkForgotCurrentPassword.ActiveLinkColor = Color.FromArgb(126, 87, 194);
            lnkForgotCurrentPassword.AutoSize = true;
            lnkForgotCurrentPassword.Cursor = Cursors.Hand;
            lnkForgotCurrentPassword.Font = new Font("Segoe UI", 8.5F);
            lnkForgotCurrentPassword.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkForgotCurrentPassword.LinkColor = Color.FromArgb(124, 58, 237);
            lnkForgotCurrentPassword.Location = new Point(140, 44);
            lnkForgotCurrentPassword.Name = "lnkForgotCurrentPassword";
            lnkForgotCurrentPassword.Size = new Size(147, 15);
            lnkForgotCurrentPassword.TabIndex = 10;
            lnkForgotCurrentPassword.TabStop = true;
            lnkForgotCurrentPassword.Text = "Forgot current password?";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblNewPassword.Location = new Point(10, 120);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(98, 17);
            lblNewPassword.TabIndex = 7;
            lblNewPassword.Text = "New password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.AllowArabicCharacters = true;
            txtNewPassword.AllowEnglishCharacters = true;
            txtNewPassword.AllowNumbers = true;
            txtNewPassword.AllowSpaces = true;
            txtNewPassword.AllowSymbols = true;
            txtNewPassword.BackColor = Color.Transparent;
            txtNewPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtNewPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtNewPassword.BorderRadius = 8;
            txtNewPassword.BorderSize = 1;
            txtNewPassword.CustomAllowedCharacters = "";
            txtNewPassword.EnableIconTinting = true;
            txtNewPassword.EnableSuggest = false;
            txtNewPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtNewPassword.FillColor = Color.White;
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtNewPassword.HasError = false;
            txtNewPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtNewPassword.IconOffsetLeft = 10;
            txtNewPassword.IconOffsetRight = 12;
            txtNewPassword.IconSize = new Size(18, 18);
            txtNewPassword.IconSpacing = 8;
            txtNewPassword.LeftIcon = null;
            txtNewPassword.LeftIconClickable = false;
            txtNewPassword.Location = new Point(10, 142);
            txtNewPassword.MaxLength = 50;
            txtNewPassword.MaxSuggestItems = 8;
            txtNewPassword.MoveToNextControlOnEnter = true;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Padding = new Padding(8, 12, 8, 12);
            txtNewPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtNewPassword.PlaceholderText = "Enter a new password";
            txtNewPassword.RightIcon = Properties.Resources.visibilityOff;
            txtNewPassword.RightIconClickable = true;
            txtNewPassword.ShowClearButton = false;
            txtNewPassword.Size = new Size(330, 44);
            txtNewPassword.SuggestIcon = null;
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.ValidateEmail = false;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblConfirmPassword.Location = new Point(10, 198);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(149, 17);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm new password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AllowArabicCharacters = true;
            txtConfirmPassword.AllowEnglishCharacters = true;
            txtConfirmPassword.AllowNumbers = true;
            txtConfirmPassword.AllowSpaces = true;
            txtConfirmPassword.AllowSymbols = true;
            txtConfirmPassword.BackColor = Color.Transparent;
            txtConfirmPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtConfirmPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtConfirmPassword.BorderRadius = 8;
            txtConfirmPassword.BorderSize = 1;
            txtConfirmPassword.CustomAllowedCharacters = "";
            txtConfirmPassword.EnableIconTinting = true;
            txtConfirmPassword.EnableSuggest = false;
            txtConfirmPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtConfirmPassword.FillColor = Color.White;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtConfirmPassword.HasError = false;
            txtConfirmPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.IconOffsetLeft = 10;
            txtConfirmPassword.IconOffsetRight = 12;
            txtConfirmPassword.IconSize = new Size(18, 18);
            txtConfirmPassword.IconSpacing = 8;
            txtConfirmPassword.LeftIcon = null;
            txtConfirmPassword.LeftIconClickable = false;
            txtConfirmPassword.Location = new Point(10, 220);
            txtConfirmPassword.MaxLength = 50;
            txtConfirmPassword.MaxSuggestItems = 8;
            txtConfirmPassword.MoveToNextControlOnEnter = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(8, 12, 8, 12);
            txtConfirmPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.PlaceholderText = "Re-enter the new password";
            txtConfirmPassword.RightIcon = Properties.Resources.visibilityOff;
            txtConfirmPassword.RightIconClickable = true;
            txtConfirmPassword.ShowClearButton = false;
            txtConfirmPassword.Size = new Size(330, 44);
            txtConfirmPassword.SuggestIcon = null;
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.ValidateEmail = false;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.BorderRadius = 8;
            btnChangePassword.BorderSize = 0;
            btnChangePassword.CenterIconWithText = true;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnChangePassword.IsLoading = false;
            btnChangePassword.LeftIcon = null;
            btnChangePassword.Location = new Point(125, 290);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.RightIcon = null;
            btnChangePassword.Size = new Size(160, 44);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "Update password";
            btnChangePassword.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = true;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(10, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.RightIcon = null;
            btnCancel.Size = new Size(100, 44);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmForgetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(520, 680);
            Controls.Add(pnlMain);
            Name = "frmForgetPassword";
            Text = "DVLD - Reset Password";
            Controls.SetChildIndex(pnlMain, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlCreateNewPassword.ResumeLayout(false);
            pnlCreateNewPassword.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }
    }
}