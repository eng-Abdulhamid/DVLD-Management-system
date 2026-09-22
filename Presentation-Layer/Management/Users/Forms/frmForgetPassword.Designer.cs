using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Login
{
    partial class frmForgetPassword
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblUsername;
        private CustomizeControls.NTextBox txtUserName;
        private NButton btnVerifyUser;
        private NButton btnVerifiedCheck;
        private NButton btnEditUsername;
        private System.Windows.Forms.ToolTip toolTip1;

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
            toolTip1 = new ToolTip(components);
            btnEditUsername = new NButton();
            btnVerifiedCheck = new NButton();
            btnVerifyUser = new NButton();
            txtUserName = new NTextBox();
            lblUsername = new Label();
            pnlMain = new Panel();
            pnlCreateNewPassword = new Panel();
            txtOldPassword = new NTextBox();
            lblOldPassword = new Label();
            lnkForgotCurrentPassword = new LinkLabel();
            ctrlPasswordInput = new DVLD.PL.UsersManagement.PasswordInputControl();
            btnChangePassword = new NButton();
            btnCancel = new NButton();
            pnlMain.SuspendLayout();
            pnlCreateNewPassword.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(505, 38);
            headerControl.TitleText = "DVLD - Reset Password";
            // 
            // btnEditUsername
            // 
            btnEditUsername.BackColor = Color.Transparent;
            btnEditUsername.BackgroundEndColor = SystemColors.Control;
            btnEditUsername.BackgroundStartColor = SystemColors.Control;
            btnEditUsername.BorderColor = Color.DarkGray;
            btnEditUsername.BorderRadius = 8;
            btnEditUsername.BorderSize = 1;
            btnEditUsername.ButtonType = enButtonType.Primary;
            btnEditUsername.CenterIconWithText = true;
            btnEditUsername.Cursor = Cursors.Hand;
            btnEditUsername.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnEditUsername.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnEditUsername.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnEditUsername.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnEditUsername.Location = new Point(428, 74);
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
            btnVerifiedCheck.ButtonType = enButtonType.Primary;
            btnVerifiedCheck.CenterIconWithText = true;
            btnVerifiedCheck.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnVerifiedCheck.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnVerifiedCheck.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnVerifiedCheck.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnVerifiedCheck.Location = new Point(364, 74);
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
            btnVerifyUser.ButtonType = enButtonType.Primary;
            btnVerifyUser.CenterIconWithText = true;
            btnVerifyUser.Cursor = Cursors.Hand;
            btnVerifyUser.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnVerifyUser.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnVerifyUser.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnVerifyUser.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnVerifyUser.Location = new Point(356, 74);
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
            txtUserName.AcceptsReturn = false;
            txtUserName.AcceptsTab = false;
            txtUserName.AllowArabicCharacters = false;
            txtUserName.AllowEnglishCharacters = true;
            txtUserName.AllowNumbers = true;
            txtUserName.AllowSpaces = false;
            txtUserName.AllowSymbols = true;
            txtUserName.AutoCompleteMode = AutoCompleteMode.None;
            txtUserName.AutoCompleteSource = AutoCompleteSource.None;
            txtUserName.BackColor = Color.Transparent;
            txtUserName.BorderColor = Color.FromArgb(226, 232, 240);
            txtUserName.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtUserName.BorderRadius = 8;
            txtUserName.BorderSize = 1;
            txtUserName.CharacterCasing = CharacterCasing.Normal;
            txtUserName.CustomAllowedCharacters = "";
            txtUserName.EnableIconTinting = true;
            txtUserName.EnableSuggest = false;
            txtUserName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtUserName.FillColor = Color.White;
            txtUserName.Font = new Font("Segoe UI", 10F);
            txtUserName.ForeColor = Color.FromArgb(15, 23, 42);
            txtUserName.HasError = false;
            txtUserName.HideSelection = true;
            txtUserName.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtUserName.IconColor = Color.FromArgb(148, 163, 184);
            txtUserName.IconOffsetLeft = 12;
            txtUserName.IconOffsetRight = 10;
            txtUserName.IconSize = new Size(18, 18);
            txtUserName.IconSpacing = 8;
            txtUserName.LeftIcon = Properties.Resources.User;
            txtUserName.LeftIconClickable = false;
            txtUserName.Location = new Point(50, 74);
            txtUserName.MaxLength = 50;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.Modified = false;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Multiline = false;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(8, 12, 8, 12);
            txtUserName.PasswordChar = '\0';
            txtUserName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.ReadOnly = false;
            txtUserName.RightIcon = null;
            txtUserName.RightIconClickable = false;
            txtUserName.ScrollBars = ScrollBars.None;
            txtUserName.SelectedText = "";
            txtUserName.SelectionLength = 0;
            txtUserName.SelectionStart = 0;
            txtUserName.ShortcutsEnabled = true;
            txtUserName.ShowClearButton = false;
            txtUserName.Size = new Size(300, 44);
            txtUserName.SuggestIcon = null;
            txtUserName.TabIndex = 0;
            txtUserName.TextAlign = HorizontalAlignment.Left;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            txtUserName.WordWrap = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(71, 85, 105);
            lblUsername.Location = new Point(50, 51);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(69, 17);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlCreateNewPassword);
            pnlMain.Controls.Add(btnChangePassword);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(lblUsername);
            pnlMain.Controls.Add(txtUserName);
            pnlMain.Controls.Add(btnVerifyUser);
            pnlMain.Controls.Add(btnVerifiedCheck);
            pnlMain.Controls.Add(btnEditUsername);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(2, 2);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(505, 638);
            pnlMain.TabIndex = 0;
            // 
            // pnlCreateNewPassword
            // 
            pnlCreateNewPassword.Anchor = AnchorStyles.None;
            pnlCreateNewPassword.Controls.Add(txtOldPassword);
            pnlCreateNewPassword.Controls.Add(lblOldPassword);
            pnlCreateNewPassword.Controls.Add(lnkForgotCurrentPassword);
            pnlCreateNewPassword.Controls.Add(ctrlPasswordInput);
            pnlCreateNewPassword.Location = new Point(30, 134);
            pnlCreateNewPassword.Name = "pnlCreateNewPassword";
            pnlCreateNewPassword.Size = new Size(395, 427);
            pnlCreateNewPassword.TabIndex = 17;
            pnlCreateNewPassword.Visible = false;
            // 
            // txtOldPassword
            // 
            txtOldPassword.AcceptsReturn = false;
            txtOldPassword.AcceptsTab = false;
            txtOldPassword.AllowArabicCharacters = true;
            txtOldPassword.AllowEnglishCharacters = true;
            txtOldPassword.AllowNumbers = true;
            txtOldPassword.AllowSpaces = true;
            txtOldPassword.AllowSymbols = true;
            txtOldPassword.Anchor = AnchorStyles.None;
            txtOldPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtOldPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtOldPassword.BackColor = Color.Transparent;
            txtOldPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtOldPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtOldPassword.BorderRadius = 8;
            txtOldPassword.BorderSize = 1;
            txtOldPassword.CharacterCasing = CharacterCasing.Normal;
            txtOldPassword.CustomAllowedCharacters = "";
            txtOldPassword.EnableIconTinting = true;
            txtOldPassword.EnableSuggest = false;
            txtOldPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtOldPassword.FillColor = Color.White;
            txtOldPassword.Font = new Font("Segoe UI", 10F);
            txtOldPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtOldPassword.HasError = false;
            txtOldPassword.HideSelection = true;
            txtOldPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtOldPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtOldPassword.IconOffsetLeft = 10;
            txtOldPassword.IconOffsetRight = 12;
            txtOldPassword.IconSize = new Size(18, 18);
            txtOldPassword.IconSpacing = 8;
            txtOldPassword.LeftIcon = null;
            txtOldPassword.LeftIconClickable = false;
            txtOldPassword.Location = new Point(18, 30);
            txtOldPassword.MaxLength = 50;
            txtOldPassword.MaxSuggestItems = 8;
            txtOldPassword.Modified = false;
            txtOldPassword.MoveToNextControlOnEnter = true;
            txtOldPassword.Multiline = false;
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Padding = new Padding(8, 12, 8, 12);
            txtOldPassword.PasswordChar = '●';
            txtOldPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtOldPassword.PlaceholderText = "Enter your current password";
            txtOldPassword.ReadOnly = false;
            txtOldPassword.RightIcon = Properties.Resources.visibilityOff;
            txtOldPassword.RightIconClickable = true;
            txtOldPassword.ScrollBars = ScrollBars.None;
            txtOldPassword.SelectedText = "";
            txtOldPassword.SelectionLength = 0;
            txtOldPassword.SelectionStart = 0;
            txtOldPassword.ShortcutsEnabled = true;
            txtOldPassword.ShowClearButton = false;
            txtOldPassword.Size = new Size(330, 44);
            txtOldPassword.SuggestIcon = null;
            txtOldPassword.TabIndex = 21;
            txtOldPassword.TextAlign = HorizontalAlignment.Left;
            txtOldPassword.UseSystemPasswordChar = true;
            txtOldPassword.ValidateEmail = false;
            txtOldPassword.WordWrap = true;
            // 
            // lblOldPassword
            // 
            lblOldPassword.Anchor = AnchorStyles.None;
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblOldPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblOldPassword.Location = new Point(18, 8);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(116, 17);
            lblOldPassword.TabIndex = 22;
            lblOldPassword.Text = "Current password";
            // 
            // lnkForgotCurrentPassword
            // 
            lnkForgotCurrentPassword.ActiveLinkColor = Color.FromArgb(126, 87, 194);
            lnkForgotCurrentPassword.Anchor = AnchorStyles.None;
            lnkForgotCurrentPassword.AutoSize = true;
            lnkForgotCurrentPassword.Cursor = Cursors.Hand;
            lnkForgotCurrentPassword.Font = new Font("Segoe UI", 8.5F);
            lnkForgotCurrentPassword.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkForgotCurrentPassword.LinkColor = Color.FromArgb(124, 58, 237);
            lnkForgotCurrentPassword.Location = new Point(148, 10);
            lnkForgotCurrentPassword.Name = "lnkForgotCurrentPassword";
            lnkForgotCurrentPassword.Size = new Size(141, 15);
            lnkForgotCurrentPassword.TabIndex = 23;
            lnkForgotCurrentPassword.TabStop = true;
            lnkForgotCurrentPassword.Text = "Forgot current password?";
            // 
            // ctrlPasswordInput
            // 
            ctrlPasswordInput.BackColor = Color.Transparent;
            ctrlPasswordInput.Location = new Point(10, 82);
            ctrlPasswordInput.Name = "ctrlPasswordInput";
            ctrlPasswordInput.Size = new Size(368, 345);
            ctrlPasswordInput.TabIndex = 24;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Anchor = AnchorStyles.None;
            btnChangePassword.BackColor = Color.Transparent;
            btnChangePassword.BackgroundEndColor = SystemColors.Control;
            btnChangePassword.BackgroundStartColor = SystemColors.Control;
            btnChangePassword.BorderColor = Color.DarkGray;
            btnChangePassword.BorderRadius = 8;
            btnChangePassword.BorderSize = 0;
            btnChangePassword.ButtonType = enButtonType.Primary;
            btnChangePassword.CenterIconWithText = true;
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnChangePassword.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnChangePassword.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnChangePassword.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnChangePassword.Location = new Point(321, 576);
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
            btnChangePassword.TabIndex = 15;
            btnChangePassword.Text = "Update password";
            btnChangePassword.TextColor = SystemColors.ControlText;
            btnChangePassword.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.ButtonType = enButtonType.Secondary;
            btnCancel.CenterIconWithText = true;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnCancel.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnCancel.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnCancel.DisabledTextColor = Color.FromArgb(148, 163, 184);
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
            btnCancel.Location = new Point(207, 576);
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
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlText;
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmForgetPassword
            // 
            AllowMaximize = false;
            AllowResize = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(509, 642);
            Controls.Add(pnlMain);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            MaximizeBox = false;
            Name = "frmForgetPassword";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "DVLD - Reset Password";
            Controls.SetChildIndex(pnlMain, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlCreateNewPassword.ResumeLayout(false);
            pnlCreateNewPassword.PerformLayout();
            ResumeLayout(false);
        }

        private Panel pnlCreateNewPassword;
        private NTextBox txtOldPassword;
        private Label lblOldPassword;
        private LinkLabel lnkForgotCurrentPassword;
        private UsersManagement.PasswordInputControl ctrlPasswordInput;
        private NButton btnChangePassword;
        private NButton btnCancel;
    }
}