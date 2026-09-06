using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Login
{
    partial class frmForgetPassword
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
            lblStatus = new Label();
            btnEditUsername = new ModernUI.Controls.NButton();
            btnVerifiedCheck = new ModernUI.Controls.NButton();
            btnVerifyUser = new ModernUI.Controls.NButton();
            txtUserName = new NControls.NTextBox();
            lblUsername = new Label();
            lblStep1 = new Label();
            lblSubHeader = new Label();
            lblHeader = new Label();
            btnMinimize = new Button();
            btnClose = new Button();
            label1 = new Label();
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
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatus.Location = new Point(38, 255);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 11;
            lblStatus.Visible = false;
            // 
            // btnEditUsername
            // 
            btnEditUsername.BackColor = Color.Transparent;
            btnEditUsername.BackgroundEndColor = Color.FromArgb(241, 245, 249);
            btnEditUsername.BackgroundStartColor = Color.FromArgb(241, 245, 249);
            btnEditUsername.BorderColor = Color.DarkGray;
            btnEditUsername.BorderRadius = 10;
            btnEditUsername.BorderSize = 0;
            btnEditUsername.CenterIconWithText = false;
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
            btnEditUsername.IconMargin = 12;
            btnEditUsername.IconOffset = new Point(0, 0);
            btnEditUsername.IconSize = new Size(24, 24);
            btnEditUsername.IconSpacing = 5;
            btnEditUsername.IsLoading = false;
            btnEditUsername.LeftIcon = Properties.Resources.editSquare;
            btnEditUsername.Location = new Point(382, 198);
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
            btnEditUsername.Size = new Size(48, 48);
            btnEditUsername.TabIndex = 3;
            btnEditUsername.TextColor = SystemColors.ControlText;
            btnEditUsername.TextOffset = new Point(0, 0);
            btnEditUsername.Visible = false;
            // 
            // btnVerifiedCheck
            // 
            btnVerifiedCheck.BackColor = Color.Transparent;
            btnVerifiedCheck.BackgroundEndColor = Color.FromArgb(167, 243, 208);
            btnVerifiedCheck.BackgroundStartColor = Color.FromArgb(167, 243, 208);
            btnVerifiedCheck.BorderColor = Color.DarkGray;
            btnVerifiedCheck.BorderRadius = 10;
            btnVerifiedCheck.BorderSize = 0;
            btnVerifiedCheck.CenterIconWithText = false;
            btnVerifiedCheck.Enabled = false;
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
            btnVerifiedCheck.IconMargin = 12;
            btnVerifiedCheck.IconOffset = new Point(0, 0);
            btnVerifiedCheck.IconSize = new Size(24, 24);
            btnVerifiedCheck.IconSpacing = 5;
            btnVerifiedCheck.IsLoading = false;
            btnVerifiedCheck.LeftIcon = Properties.Resources.hasFounded;
            btnVerifiedCheck.Location = new Point(326, 198);
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
            btnVerifiedCheck.Size = new Size(48, 48);
            btnVerifiedCheck.TabIndex = 2;
            btnVerifiedCheck.TabStop = false;
            btnVerifiedCheck.TextColor = SystemColors.ControlText;
            btnVerifiedCheck.TextOffset = new Point(0, 0);
            btnVerifiedCheck.Visible = false;
            // 
            // btnVerifyUser
            // 
            btnVerifyUser.BackColor = Color.Transparent;
            btnVerifyUser.BackgroundEndColor = Color.FromArgb(103, 78, 167);
            btnVerifyUser.BackgroundStartColor = Color.FromArgb(126, 87, 194);
            btnVerifyUser.BorderColor = Color.DarkGray;
            btnVerifyUser.BorderRadius = 10;
            btnVerifyUser.BorderSize = 0;
            btnVerifyUser.CenterIconWithText = false;
            btnVerifyUser.Cursor = Cursors.Hand;
            btnVerifyUser.EnableHoverAnimation = false;
            btnVerifyUser.EnableIconTinting = false;
            btnVerifyUser.EnableRippleEffect = false;
            btnVerifyUser.EnableShadow = false;
            btnVerifyUser.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnVerifyUser.ForeColor = Color.White;
            btnVerifyUser.GradientAngle = 90F;
            btnVerifyUser.HoverAnimationSpeed = 20;
            btnVerifyUser.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnVerifyUser.HoverEndColor = Color.FromArgb(126, 87, 194);
            btnVerifyUser.HoverIconColor = Color.White;
            btnVerifyUser.HoverStartColor = Color.FromArgb(119, 92, 185);
            btnVerifyUser.HoverTextColor = Color.White;
            btnVerifyUser.IconColor = Color.White;
            btnVerifyUser.IconMargin = 10;
            btnVerifyUser.IconOffset = new Point(0, 0);
            btnVerifyUser.IconSize = new Size(16, 16);
            btnVerifyUser.IconSpacing = 5;
            btnVerifyUser.IsLoading = false;
            btnVerifyUser.LeftIcon = null;
            btnVerifyUser.Location = new Point(326, 198);
            btnVerifyUser.Name = "btnVerifyUser";
            btnVerifyUser.PressedEndColor = Color.FromArgb(145, 108, 211);
            btnVerifyUser.PressedStartColor = Color.FromArgb(91, 69, 149);
            btnVerifyUser.RightIcon = null;
            btnVerifyUser.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnVerifyUser.RippleSpeed = 15;
            btnVerifyUser.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnVerifyUser.ShadowOffset = new Point(1, 1);
            btnVerifyUser.ShadowSize = 3;
            btnVerifyUser.ShiftOnPress = false;
            btnVerifyUser.Size = new Size(120, 48);
            btnVerifyUser.TabIndex = 1;
            btnVerifyUser.Text = "Verify account";
            btnVerifyUser.TextColor = Color.White;
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
            txtUserName.BorderRadius = 10;
            txtUserName.BorderSize = 2;
            txtUserName.CustomAllowedCharacters = "";
            txtUserName.EnableSuggest = false;
            txtUserName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtUserName.FillColor = Color.FromArgb(250, 250, 252);
            txtUserName.Font = new Font("Segoe UI", 10.5F);
            txtUserName.ForeColor = Color.FromArgb(15, 23, 42);
            txtUserName.HasError = false;
            txtUserName.IconOffsetLeft = 10;
            txtUserName.IconOffsetRight = 10;
            txtUserName.IconSpacing = 8;
            txtUserName.Location = new Point(38, 198);
            txtUserName.MaxLength = 50;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(8, 12, 8, 12);
            txtUserName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.ShowClearButton = false;
            txtUserName.Size = new Size(280, 48);
            txtUserName.SuggestIcon = null;
            txtUserName.TabIndex = 0;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(55, 65, 81);
            lblUsername.Location = new Point(38, 175);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 17);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // lblStep1
            // 
            lblStep1.AutoSize = true;
            lblStep1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblStep1.ForeColor = Color.FromArgb(103, 78, 167);
            lblStep1.Location = new Point(38, 145);
            lblStep1.Name = "lblStep1";
            lblStep1.Size = new Size(145, 19);
            lblStep1.TabIndex = 2;
            lblStep1.Text = "1  Verify your account";
            // 
            // lblSubHeader
            // 
            lblSubHeader.AutoSize = true;
            lblSubHeader.Font = new Font("Segoe UI", 10F);
            lblSubHeader.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubHeader.Location = new Point(41, 100);
            lblSubHeader.Name = "lblSubHeader";
            lblSubHeader.Size = new Size(341, 19);
            lblSubHeader.TabIndex = 1;
            lblSubHeader.Text = "Verify your account first, then choose a new password.";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI Semibold", 21F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(31, 41, 55);
            lblHeader.Location = new Point(38, 60);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(279, 38);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Reset your password";
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMinimize.Location = new Point(433, 10);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 30);
            btnMinimize.TabIndex = 11;
            btnMinimize.Text = "—";
            btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(148, 163, 184);
            btnClose.Location = new Point(469, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 30);
            btnClose.TabIndex = 12;
            btnClose.Text = "✕";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(148, 163, 184);
            label1.Location = new Point(15, 15);
            label1.Name = "label1";
            label1.Size = new Size(126, 17);
            label1.TabIndex = 13;
            label1.Text = "Password Recovery";
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
            pnlCreateNewPassword.Location = new Point(28, 280);
            pnlCreateNewPassword.Name = "pnlCreateNewPassword";
            pnlCreateNewPassword.Size = new Size(450, 380);
            pnlCreateNewPassword.TabIndex = 14;
            pnlCreateNewPassword.Visible = false;
            // 
            // lblStep2
            // 
            lblStep2.AutoSize = true;
            lblStep2.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblStep2.ForeColor = Color.FromArgb(103, 78, 167);
            lblStep2.Location = new Point(10, 5);
            lblStep2.Name = "lblStep2";
            lblStep2.Size = new Size(169, 19);
            lblStep2.TabIndex = 5;
            lblStep2.Text = "2  Create a new password";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblOldPassword.ForeColor = Color.FromArgb(55, 65, 81);
            lblOldPassword.Location = new Point(10, 45);
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
            txtOldPassword.BorderRadius = 10;
            txtOldPassword.BorderSize = 2;
            txtOldPassword.CustomAllowedCharacters = "";
            txtOldPassword.EnableSuggest = false;
            txtOldPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtOldPassword.FillColor = Color.FromArgb(250, 250, 252);
            txtOldPassword.Font = new Font("Segoe UI", 10.5F);
            txtOldPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtOldPassword.HasError = false;
            txtOldPassword.IconOffsetLeft = 10;
            txtOldPassword.IconOffsetRight = 10;
            txtOldPassword.IconSpacing = 8;
            txtOldPassword.Location = new Point(10, 68);
            txtOldPassword.MaxLength = 32767;
            txtOldPassword.MaxSuggestItems = 8;
            txtOldPassword.MoveToNextControlOnEnter = true;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Padding = new Padding(8, 12, 8, 12);
            txtOldPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtOldPassword.PlaceholderText = "Enter your current password";
            txtOldPassword.ShowClearButton = false;
            txtOldPassword.Size = new Size(280, 48);
            txtOldPassword.SuggestIcon = null;
            txtOldPassword.TabIndex = 4;
            txtOldPassword.UseSystemPasswordChar = false;
            txtOldPassword.ValidateEmail = false;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(55, 65, 81);
            lblNewPassword.Location = new Point(10, 130);
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
            txtNewPassword.BorderRadius = 10;
            txtNewPassword.BorderSize = 2;
            txtNewPassword.CustomAllowedCharacters = "";
            txtNewPassword.EnableSuggest = false;
            txtNewPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtNewPassword.FillColor = Color.FromArgb(250, 250, 252);
            txtNewPassword.Font = new Font("Segoe UI", 10.5F);
            txtNewPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtNewPassword.HasError = false;
            txtNewPassword.IconOffsetLeft = 10;
            txtNewPassword.IconOffsetRight = 10;
            txtNewPassword.IconSpacing = 8;
            txtNewPassword.Location = new Point(10, 153);
            txtNewPassword.MaxLength = 32767;
            txtNewPassword.MaxSuggestItems = 8;
            txtNewPassword.MoveToNextControlOnEnter = true;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Padding = new Padding(8, 12, 8, 12);
            txtNewPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtNewPassword.PlaceholderText = "Enter a new password";
            txtNewPassword.ShowClearButton = false;
            txtNewPassword.Size = new Size(280, 48);
            txtNewPassword.SuggestIcon = null;
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = false;
            txtNewPassword.ValidateEmail = false;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(55, 65, 81);
            lblConfirmPassword.Location = new Point(10, 215);
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
            txtConfirmPassword.BorderRadius = 10;
            txtConfirmPassword.BorderSize = 2;
            txtConfirmPassword.CustomAllowedCharacters = "";
            txtConfirmPassword.EnableSuggest = false;
            txtConfirmPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtConfirmPassword.FillColor = Color.FromArgb(250, 250, 252);
            txtConfirmPassword.Font = new Font("Segoe UI", 10.5F);
            txtConfirmPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtConfirmPassword.HasError = false;
            txtConfirmPassword.IconOffsetLeft = 10;
            txtConfirmPassword.IconOffsetRight = 10;
            txtConfirmPassword.IconSpacing = 8;
            txtConfirmPassword.Location = new Point(10, 238);
            txtConfirmPassword.MaxLength = 32767;
            txtConfirmPassword.MaxSuggestItems = 8;
            txtConfirmPassword.MoveToNextControlOnEnter = true;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(8, 12, 8, 12);
            txtConfirmPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.PlaceholderText = "Re-enter the new password";
            txtConfirmPassword.ShowClearButton = false;
            txtConfirmPassword.Size = new Size(280, 48);
            txtConfirmPassword.SuggestIcon = null;
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = false;
            txtConfirmPassword.ValidateEmail = false;
            // 
            // lnkForgotCurrentPassword
            // 
            lnkForgotCurrentPassword.ActiveLinkColor = Color.FromArgb(126, 87, 194);
            lnkForgotCurrentPassword.AutoSize = true;
            lnkForgotCurrentPassword.Cursor = Cursors.Hand;
            lnkForgotCurrentPassword.Font = new Font("Segoe UI", 8.5F);
            lnkForgotCurrentPassword.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkForgotCurrentPassword.LinkColor = Color.FromArgb(103, 78, 167);
            lnkForgotCurrentPassword.Location = new Point(135, 122);
            lnkForgotCurrentPassword.Name = "lnkForgotCurrentPassword";
            lnkForgotCurrentPassword.Size = new Size(168, 15);
            lnkForgotCurrentPassword.TabIndex = 10;
            lnkForgotCurrentPassword.TabStop = true;
            lnkForgotCurrentPassword.Text = "Forgot your current password?";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.BackgroundEndColor = Color.FromArgb(103, 78, 167);
            btnChangePassword.BackgroundStartColor = Color.FromArgb(126, 87, 194);
            btnChangePassword.BorderColor = Color.DarkGray;
            btnChangePassword.BorderRadius = 10;
            btnChangePassword.BorderSize = 0;
            btnChangePassword.CenterIconWithText = false;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.EnableHoverAnimation = false;
            btnChangePassword.EnableIconTinting = false;
            btnChangePassword.EnableRippleEffect = false;
            btnChangePassword.EnableShadow = false;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.GradientAngle = 90F;
            btnChangePassword.HoverAnimationSpeed = 20;
            btnChangePassword.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnChangePassword.HoverEndColor = Color.FromArgb(126, 87, 194);
            btnChangePassword.HoverIconColor = Color.White;
            btnChangePassword.HoverStartColor = Color.FromArgb(119, 92, 185);
            btnChangePassword.HoverTextColor = Color.White;
            btnChangePassword.IconColor = Color.White;
            btnChangePassword.IconMargin = 10;
            btnChangePassword.IconOffset = new Point(0, 0);
            btnChangePassword.IconSize = new Size(16, 16);
            btnChangePassword.IconSpacing = 5;
            btnChangePassword.IsLoading = false;
            btnChangePassword.LeftIcon = null;
            btnChangePassword.Location = new Point(120, 315);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.PressedEndColor = Color.FromArgb(145, 108, 211);
            btnChangePassword.PressedStartColor = Color.FromArgb(91, 69, 149);
            btnChangePassword.RightIcon = null;
            btnChangePassword.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnChangePassword.RippleSpeed = 15;
            btnChangePassword.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnChangePassword.ShadowOffset = new Point(1, 1);
            btnChangePassword.ShadowSize = 3;
            btnChangePassword.ShiftOnPress = false;
            btnChangePassword.Size = new Size(170, 48);
            btnChangePassword.TabIndex = 8;
            btnChangePassword.Text = "Update password";
            btnChangePassword.TextColor = Color.White;
            btnChangePassword.TextOffset = new Point(0, 0);
            btnChangePassword.Click += btnChangePassword_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = Color.FromArgb(248, 250, 252);
            btnCancel.BackgroundStartColor = Color.FromArgb(248, 250, 252);
            btnCancel.BorderColor = Color.FromArgb(226, 232, 240);
            btnCancel.BorderRadius = 10;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
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
            btnCancel.Location = new Point(10, 315);
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
            btnCancel.Size = new Size(100, 48);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = Color.FromArgb(71, 85, 105);
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlCreateNewPassword);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(btnClose);
            pnlMain.Controls.Add(btnMinimize);
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
            pnlMain.Location = new Point(3, 3);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(514, 674);
            pnlMain.TabIndex = 0;
            // 
            // frmForgetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(520, 680);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmForgetPassword";
            Padding = new Padding(3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reset Password";
            pnlCreateNewPassword.ResumeLayout(false);
            pnlCreateNewPassword.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblStatus;
        private ModernUI.Controls.NButton btnEditUsername;
        private ModernUI.Controls.NButton btnVerifiedCheck;
        private ModernUI.Controls.NButton btnVerifyUser;
        private NControls.NTextBox txtUserName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Panel pnlMain;
    }
}