using System.Drawing;
using System.Windows.Forms;
using NControls;

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
        private NButton btnVerifyUser;
        private NButton btnVerifiedCheck;
        private NButton btnEditUsername;
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
        private NButton btnChangePassword;
        private NButton btnCancel;

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
            btnEditUsername = new NButton();
            btnVerifiedCheck = new NButton();
            btnVerifyUser = new NButton();
            txtUserName = new NTextBox();
            lblUsername = new Label();
            lblStep1 = new Label();
            lblSubHeader = new Label();
            lblHeader = new Label();
            pnlCreateNewPassword = new Panel();
            lblStep2 = new Label();
            lblOldPassword = new Label();
            txtOldPassword = new NTextBox();
            lblNewPassword = new Label();
            txtNewPassword = new NTextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new NTextBox();
            lnkForgotCurrentPassword = new LinkLabel();
            btnChangePassword = new NButton();
            btnCancel = new NButton();
            pnlMain = new Panel();
            pnlCreateNewPassword.SuspendLayout();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(516, 38);
            headerControl.TitleText = "DVLD - Reset Password";
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
            // btnEditUsername
            // 
            btnEditUsername.BackColor = Color.Transparent;
            btnEditUsername.BackgroundEndColor = SystemColors.Control;
            btnEditUsername.BackgroundStartColor = SystemColors.Control;
            btnEditUsername.BorderColor = Color.DarkGray;
            btnEditUsername.BorderRadius = 8;
            btnEditUsername.BorderSize = 1;
            btnEditUsername.CenterIconWithText = true;
            btnEditUsername.Cursor = Cursors.Hand;
            btnEditUsername.EnableHoverAnimation = false;
            btnEditUsername.EnableIconTinting = false;
            btnEditUsername.EnableRippleEffect = false;
            btnEditUsername.EnableShadow = false;
            btnEditUsername.Font = new Font("Segoe UI", 9F);
            btnEditUsername.ForeColor = SystemColors.ControlText;
            btnEditUsername.GradientAngle = 90F;
            btnEditUsername.HoverAnimationSpeed = 20;
            btnEditUsername.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnEditUsername.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnEditUsername.HoverIconColor = Color.White;
            btnEditUsername.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnEditUsername.HoverTextColor = SystemColors.ControlText;
            btnEditUsername.IconColor = Color.White;
            btnEditUsername.IconMargin = 10;
            btnEditUsername.IconOffset = new Point(0, 0);
            btnEditUsername.IconSize = new Size(18, 18);
            btnEditUsername.IconSpacing = 5;
            btnEditUsername.IsLoading = false;
            btnEditUsername.LeftIcon = null;
            btnEditUsername.Location = new Point(404, 168);
            btnEditUsername.MiddleIcon = Properties.Resources.editSquare;
            btnEditUsername.Name = "btnEditUsername";
            btnEditUsername.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnEditUsername.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnEditUsername.RightIcon = null;
            btnEditUsername.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnEditUsername.RippleSpeed = 15;
            btnEditUsername.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnEditUsername.ShadowOffset = new Point(1, 1);
            btnEditUsername.ShadowSize = 3;
            btnEditUsername.ShiftOnPress = false;
            btnEditUsername.Size = new Size(44, 44);
            btnEditUsername.TabIndex = 3;
            btnEditUsername.TextColor = SystemColors.ControlText;
            btnEditUsername.TextOffset = new Point(0, 0);
            btnEditUsername.Visible = false;
            // 
            // btnVerifiedCheck
            // 
            btnVerifiedCheck.BackColor = Color.Transparent;
            btnVerifiedCheck.BackgroundEndColor = SystemColors.Control;
            btnVerifiedCheck.BackgroundStartColor = SystemColors.Control;
            btnVerifiedCheck.BorderColor = Color.DarkGray;
            btnVerifiedCheck.BorderRadius = 8;
            btnVerifiedCheck.BorderSize = 0;
            btnVerifiedCheck.CenterIconWithText = true;
            btnVerifiedCheck.EnableHoverAnimation = false;
            btnVerifiedCheck.EnableIconTinting = false;
            btnVerifiedCheck.EnableRippleEffect = false;
            btnVerifiedCheck.EnableShadow = false;
            btnVerifiedCheck.Font = new Font("Segoe UI", 9F);
            btnVerifiedCheck.ForeColor = SystemColors.ControlText;
            btnVerifiedCheck.GradientAngle = 90F;
            btnVerifiedCheck.HoverAnimationSpeed = 20;
            btnVerifiedCheck.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnVerifiedCheck.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnVerifiedCheck.HoverIconColor = Color.White;
            btnVerifiedCheck.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnVerifiedCheck.HoverTextColor = SystemColors.ControlText;
            btnVerifiedCheck.IconColor = Color.White;
            btnVerifiedCheck.IconMargin = 10;
            btnVerifiedCheck.IconOffset = new Point(0, 0);
            btnVerifiedCheck.IconSize = new Size(22, 22);
            btnVerifiedCheck.IconSpacing = 5;
            btnVerifiedCheck.IsLoading = false;
            btnVerifiedCheck.LeftIcon = null;
            btnVerifiedCheck.Location = new Point(352, 168);
            btnVerifiedCheck.MiddleIcon = Properties.Resources.hasFounded;
            btnVerifiedCheck.Name = "btnVerifiedCheck";
            btnVerifiedCheck.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnVerifiedCheck.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnVerifiedCheck.RightIcon = null;
            btnVerifiedCheck.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnVerifiedCheck.RippleSpeed = 15;
            btnVerifiedCheck.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnVerifiedCheck.ShadowOffset = new Point(1, 1);
            btnVerifiedCheck.ShadowSize = 3;
            btnVerifiedCheck.ShiftOnPress = false;
            btnVerifiedCheck.Size = new Size(44, 44);
            btnVerifiedCheck.TabIndex = 2;
            btnVerifiedCheck.TabStop = false;
            btnVerifiedCheck.TextColor = SystemColors.ControlText;
            btnVerifiedCheck.TextOffset = new Point(0, 0);
            btnVerifiedCheck.Visible = false;
            // 
            // btnVerifyUser
            // 
            btnVerifyUser.BackColor = Color.Transparent;
            btnVerifyUser.BackgroundEndColor = SystemColors.Control;
            btnVerifyUser.BackgroundStartColor = SystemColors.Control;
            btnVerifyUser.BorderColor = Color.DarkGray;
            btnVerifyUser.BorderRadius = 8;
            btnVerifyUser.BorderSize = 0;
            btnVerifyUser.CenterIconWithText = true;
            btnVerifyUser.Cursor = Cursors.Hand;
            btnVerifyUser.EnableHoverAnimation = false;
            btnVerifyUser.EnableIconTinting = false;
            btnVerifyUser.EnableRippleEffect = false;
            btnVerifyUser.EnableShadow = false;
            btnVerifyUser.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVerifyUser.ForeColor = SystemColors.ControlText;
            btnVerifyUser.GradientAngle = 90F;
            btnVerifyUser.HoverAnimationSpeed = 20;
            btnVerifyUser.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnVerifyUser.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnVerifyUser.HoverIconColor = Color.White;
            btnVerifyUser.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnVerifyUser.HoverTextColor = SystemColors.ControlText;
            btnVerifyUser.IconColor = Color.White;
            btnVerifyUser.IconMargin = 10;
            btnVerifyUser.IconOffset = new Point(0, 0);
            btnVerifyUser.IconSize = new Size(16, 16);
            btnVerifyUser.IconSpacing = 5;
            btnVerifyUser.IsLoading = false;
            btnVerifyUser.LeftIcon = null;
            btnVerifyUser.Location = new Point(348, 168);
            btnVerifyUser.MiddleIcon = null;
            btnVerifyUser.Name = "btnVerifyUser";
            btnVerifyUser.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnVerifyUser.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnVerifyUser.RightIcon = null;
            btnVerifyUser.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnVerifyUser.RippleSpeed = 15;
            btnVerifyUser.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnVerifyUser.ShadowOffset = new Point(1, 1);
            btnVerifyUser.ShadowSize = 3;
            btnVerifyUser.ShiftOnPress = false;
            btnVerifyUser.Size = new Size(125, 44);
            btnVerifyUser.TabIndex = 1;
            btnVerifyUser.Text = "Verify";
            btnVerifyUser.TextColor = SystemColors.ControlText;
            btnVerifyUser.TextOffset = new Point(0, 0);
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
            txtUserName.HoverIconColor = Color.FromArgb(15, 23, 42);
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
            // lblStep1
            // 
            lblStep1.AutoSize = true;
            lblStep1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblStep1.ForeColor = Color.FromArgb(124, 58, 237);
            lblStep1.Location = new Point(38, 115);
            lblStep1.Name = "lblStep1";
            lblStep1.Size = new Size(144, 19);
            lblStep1.TabIndex = 2;
            lblStep1.Text = "1. Verify your account";
            // 
            // lblSubHeader
            // 
            lblSubHeader.AutoSize = true;
            lblSubHeader.Font = new Font("Segoe UI", 9.5F);
            lblSubHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubHeader.Location = new Point(38, 66);
            lblSubHeader.Name = "lblSubHeader";
            lblSubHeader.Size = new Size(325, 17);
            lblSubHeader.TabIndex = 1;
            lblSubHeader.Text = "Verify your account first, then choose a new password.";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblHeader.Location = new Point(36, 25);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(269, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Reset your password";
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
            lblStep2.Size = new Size(168, 19);
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
            lblOldPassword.Size = new Size(116, 17);
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
            txtOldPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
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
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblNewPassword.Location = new Point(10, 120);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(97, 17);
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
            txtNewPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
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
            lblConfirmPassword.Size = new Size(147, 17);
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
            txtConfirmPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
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
            lnkForgotCurrentPassword.Size = new Size(141, 15);
            lnkForgotCurrentPassword.TabIndex = 10;
            lnkForgotCurrentPassword.TabStop = true;
            lnkForgotCurrentPassword.Text = "Forgot current password?";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.BackgroundEndColor = SystemColors.Control;
            btnChangePassword.BackgroundStartColor = SystemColors.Control;
            btnChangePassword.BorderColor = Color.DarkGray;
            btnChangePassword.BorderRadius = 8;
            btnChangePassword.BorderSize = 0;
            btnChangePassword.CenterIconWithText = true;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.EnableHoverAnimation = false;
            btnChangePassword.EnableIconTinting = false;
            btnChangePassword.EnableRippleEffect = false;
            btnChangePassword.EnableShadow = false;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnChangePassword.ForeColor = SystemColors.ControlText;
            btnChangePassword.GradientAngle = 90F;
            btnChangePassword.HoverAnimationSpeed = 20;
            btnChangePassword.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnChangePassword.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnChangePassword.HoverIconColor = Color.White;
            btnChangePassword.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnChangePassword.HoverTextColor = SystemColors.ControlText;
            btnChangePassword.IconColor = Color.White;
            btnChangePassword.IconMargin = 10;
            btnChangePassword.IconOffset = new Point(0, 0);
            btnChangePassword.IconSize = new Size(16, 16);
            btnChangePassword.IconSpacing = 5;
            btnChangePassword.IsLoading = false;
            btnChangePassword.LeftIcon = null;
            btnChangePassword.Location = new Point(125, 290);
            btnChangePassword.MiddleIcon = null;
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnChangePassword.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnChangePassword.RightIcon = null;
            btnChangePassword.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnChangePassword.RippleSpeed = 15;
            btnChangePassword.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnChangePassword.ShadowOffset = new Point(1, 1);
            btnChangePassword.ShadowSize = 3;
            btnChangePassword.ShiftOnPress = false;
            btnChangePassword.Size = new Size(160, 44);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "Update password";
            btnChangePassword.TextColor = SystemColors.ControlText;
            btnChangePassword.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = true;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.EnableHoverAnimation = false;
            btnCancel.EnableIconTinting = false;
            btnCancel.EnableRippleEffect = false;
            btnCancel.EnableShadow = false;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.ControlText;
            btnCancel.GradientAngle = 90F;
            btnCancel.HoverAnimationSpeed = 20;
            btnCancel.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnCancel.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverIconColor = Color.White;
            btnCancel.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverTextColor = SystemColors.ControlText;
            btnCancel.IconColor = Color.White;
            btnCancel.IconMargin = 10;
            btnCancel.IconOffset = new Point(0, 0);
            btnCancel.IconSize = new Size(16, 16);
            btnCancel.IconSpacing = 5;
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(10, 290);
            btnCancel.MiddleIcon = null;
            btnCancel.Name = "btnCancel";
            btnCancel.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnCancel.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnCancel.RightIcon = null;
            btnCancel.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnCancel.RippleSpeed = 15;
            btnCancel.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnCancel.ShadowOffset = new Point(1, 1);
            btnCancel.ShadowSize = 3;
            btnCancel.ShiftOnPress = false;
            btnCancel.Size = new Size(100, 44);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlText;
            btnCancel.TextOffset = new Point(0, 0);
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
            pnlMain.Location = new Point(2, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(516, 676);
            pnlMain.TabIndex = 0;
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