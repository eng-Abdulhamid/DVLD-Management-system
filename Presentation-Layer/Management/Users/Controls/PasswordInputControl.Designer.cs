namespace DVLD.PL.UsersManagement
{
    partial class PasswordInputControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNewPassword = new Label();
            txtNewPassword = new CustomizeControls.NTextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new CustomizeControls.NTextBox();
            picCheckIfMeetMinimumLength = new PictureBox();
            picCheckIfMeetUppercase = new PictureBox();
            picCheckIfMeetLowercase = new PictureBox();
            picCheckIfMeetNumber = new PictureBox();
            picCheckIfMeetSpecial = new PictureBox();
            lblMinimumLength = new Label();
            lblUppercase = new Label();
            lblLowercase = new Label();
            lblNumber = new Label();
            lblSpecial = new Label();
            toolTip1 = new ToolTip(components);
            btnRandomPassword = new CustomizeControls.NButton();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetMinimumLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetUppercase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetLowercase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetSpecial).BeginInit();
            SuspendLayout();
            // 
            // lblNewPassword
            // 
            lblNewPassword.Anchor = AnchorStyles.None;
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblNewPassword.Location = new Point(5, -3);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(97, 17);
            lblNewPassword.TabIndex = 0;
            lblNewPassword.Text = "New password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.AcceptsReturn = false;
            txtNewPassword.AcceptsTab = false;
            txtNewPassword.AllowArabicCharacters = false;
            txtNewPassword.AllowEnglishCharacters = true;
            txtNewPassword.AllowNumbers = true;
            txtNewPassword.AllowSpaces = false;
            txtNewPassword.AllowSymbols = false;
            txtNewPassword.Anchor = AnchorStyles.None;
            txtNewPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtNewPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtNewPassword.BackColor = Color.Transparent;
            txtNewPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtNewPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtNewPassword.BorderRadius = 8;
            txtNewPassword.BorderSize = 1;
            txtNewPassword.CharacterCasing = CharacterCasing.Normal;
            txtNewPassword.CustomAllowedCharacters = "!@#$%^&*()-_=+";
            txtNewPassword.EnableIconTinting = true;
            txtNewPassword.EnableSuggest = false;
            txtNewPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtNewPassword.FillColor = Color.White;
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtNewPassword.HasError = false;
            txtNewPassword.HideSelection = true;
            txtNewPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtNewPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtNewPassword.IconOffsetLeft = 10;
            txtNewPassword.IconOffsetRight = 12;
            txtNewPassword.IconSize = new Size(18, 18);
            txtNewPassword.IconSpacing = 8;
            txtNewPassword.LeftIcon = null;
            txtNewPassword.LeftIconClickable = false;
            txtNewPassword.Location = new Point(5, 19);
            txtNewPassword.MaxLength = 128;
            txtNewPassword.MaxSuggestItems = 8;
            txtNewPassword.Modified = false;
            txtNewPassword.MoveToNextControlOnEnter = true;
            txtNewPassword.Multiline = false;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Padding = new Padding(8, 12, 8, 12);
            txtNewPassword.PasswordChar = '\0';
            txtNewPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtNewPassword.PlaceholderText = "Enter a new password";
            txtNewPassword.ReadOnly = false;
            txtNewPassword.RightIcon = Properties.Resources.visibilityOff;
            txtNewPassword.RightIconClickable = true;
            txtNewPassword.ScrollBars = ScrollBars.None;
            txtNewPassword.SelectedText = "";
            txtNewPassword.SelectionLength = 0;
            txtNewPassword.SelectionStart = 0;
            txtNewPassword.ShortcutsEnabled = true;
            txtNewPassword.ShowClearButton = false;
            txtNewPassword.Size = new Size(330, 44);
            txtNewPassword.SuggestIcon = null;
            txtNewPassword.TabIndex = 0;
            txtNewPassword.TextAlign = HorizontalAlignment.Left;
            toolTip1.SetToolTip(txtNewPassword, "Enter a new secure password");
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.ValidateEmail = false;
            txtNewPassword.WordWrap = true;
            txtNewPassword.TextChanged += NewPassword_TextChanged;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Anchor = AnchorStyles.None;
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblConfirmPassword.Location = new Point(5, 75);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(147, 17);
            lblConfirmPassword.TabIndex = 1;
            lblConfirmPassword.Text = "Confirm new password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.AcceptsReturn = false;
            txtConfirmPassword.AcceptsTab = false;
            txtConfirmPassword.AllowArabicCharacters = false;
            txtConfirmPassword.AllowEnglishCharacters = true;
            txtConfirmPassword.AllowNumbers = true;
            txtConfirmPassword.AllowSpaces = false;
            txtConfirmPassword.AllowSymbols = false;
            txtConfirmPassword.Anchor = AnchorStyles.None;
            txtConfirmPassword.AutoCompleteMode = AutoCompleteMode.None;
            txtConfirmPassword.AutoCompleteSource = AutoCompleteSource.None;
            txtConfirmPassword.BackColor = Color.Transparent;
            txtConfirmPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtConfirmPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtConfirmPassword.BorderRadius = 8;
            txtConfirmPassword.BorderSize = 1;
            txtConfirmPassword.CharacterCasing = CharacterCasing.Normal;
            txtConfirmPassword.CustomAllowedCharacters = "!@#$%^&*()-_=+";
            txtConfirmPassword.EnableIconTinting = true;
            txtConfirmPassword.EnableSuggest = false;
            txtConfirmPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtConfirmPassword.FillColor = Color.White;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtConfirmPassword.HasError = false;
            txtConfirmPassword.HideSelection = true;
            txtConfirmPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtConfirmPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.IconOffsetLeft = 10;
            txtConfirmPassword.IconOffsetRight = 12;
            txtConfirmPassword.IconSize = new Size(18, 18);
            txtConfirmPassword.IconSpacing = 8;
            txtConfirmPassword.LeftIcon = null;
            txtConfirmPassword.LeftIconClickable = false;
            txtConfirmPassword.Location = new Point(5, 97);
            txtConfirmPassword.MaxLength = 128;
            txtConfirmPassword.MaxSuggestItems = 8;
            txtConfirmPassword.Modified = false;
            txtConfirmPassword.MoveToNextControlOnEnter = true;
            txtConfirmPassword.Multiline = false;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(8, 12, 8, 12);
            txtConfirmPassword.PasswordChar = '\0';
            txtConfirmPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.PlaceholderText = "Re-enter the new password";
            txtConfirmPassword.ReadOnly = false;
            txtConfirmPassword.RightIcon = Properties.Resources.visibilityOff;
            txtConfirmPassword.RightIconClickable = true;
            txtConfirmPassword.ScrollBars = ScrollBars.None;
            txtConfirmPassword.SelectedText = "";
            txtConfirmPassword.SelectionLength = 0;
            txtConfirmPassword.SelectionStart = 0;
            txtConfirmPassword.ShortcutsEnabled = true;
            txtConfirmPassword.ShowClearButton = false;
            txtConfirmPassword.Size = new Size(330, 44);
            txtConfirmPassword.SuggestIcon = null;
            txtConfirmPassword.TabIndex = 1;
            txtConfirmPassword.TextAlign = HorizontalAlignment.Left;
            toolTip1.SetToolTip(txtConfirmPassword, "Re-enter the new password");
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.ValidateEmail = false;
            txtConfirmPassword.WordWrap = true;
            // 
            // picCheckIfMeetMinimumLength
            // 
            picCheckIfMeetMinimumLength.Anchor = AnchorStyles.None;
            picCheckIfMeetMinimumLength.Image = Properties.Resources.unChecked;
            picCheckIfMeetMinimumLength.Location = new Point(5, 186);
            picCheckIfMeetMinimumLength.Name = "picCheckIfMeetMinimumLength";
            picCheckIfMeetMinimumLength.Size = new Size(19, 19);
            picCheckIfMeetMinimumLength.SizeMode = PictureBoxSizeMode.Zoom;
            picCheckIfMeetMinimumLength.TabIndex = 10;
            picCheckIfMeetMinimumLength.TabStop = false;
            // 
            // picCheckIfMeetUppercase
            // 
            picCheckIfMeetUppercase.Anchor = AnchorStyles.None;
            picCheckIfMeetUppercase.Image = Properties.Resources.unChecked;
            picCheckIfMeetUppercase.Location = new Point(5, 216);
            picCheckIfMeetUppercase.Name = "picCheckIfMeetUppercase";
            picCheckIfMeetUppercase.Size = new Size(19, 19);
            picCheckIfMeetUppercase.SizeMode = PictureBoxSizeMode.Zoom;
            picCheckIfMeetUppercase.TabIndex = 11;
            picCheckIfMeetUppercase.TabStop = false;
            // 
            // picCheckIfMeetLowercase
            // 
            picCheckIfMeetLowercase.Anchor = AnchorStyles.None;
            picCheckIfMeetLowercase.Image = Properties.Resources.unChecked;
            picCheckIfMeetLowercase.Location = new Point(5, 246);
            picCheckIfMeetLowercase.Name = "picCheckIfMeetLowercase";
            picCheckIfMeetLowercase.Size = new Size(19, 19);
            picCheckIfMeetLowercase.SizeMode = PictureBoxSizeMode.Zoom;
            picCheckIfMeetLowercase.TabIndex = 12;
            picCheckIfMeetLowercase.TabStop = false;
            // 
            // picCheckIfMeetNumber
            // 
            picCheckIfMeetNumber.Anchor = AnchorStyles.None;
            picCheckIfMeetNumber.Image = Properties.Resources.unChecked;
            picCheckIfMeetNumber.Location = new Point(5, 276);
            picCheckIfMeetNumber.Name = "picCheckIfMeetNumber";
            picCheckIfMeetNumber.Size = new Size(19, 19);
            picCheckIfMeetNumber.SizeMode = PictureBoxSizeMode.Zoom;
            picCheckIfMeetNumber.TabIndex = 13;
            picCheckIfMeetNumber.TabStop = false;
            // 
            // picCheckIfMeetSpecial
            // 
            picCheckIfMeetSpecial.Anchor = AnchorStyles.None;
            picCheckIfMeetSpecial.Image = Properties.Resources.unChecked;
            picCheckIfMeetSpecial.Location = new Point(5, 306);
            picCheckIfMeetSpecial.Name = "picCheckIfMeetSpecial";
            picCheckIfMeetSpecial.Size = new Size(19, 19);
            picCheckIfMeetSpecial.SizeMode = PictureBoxSizeMode.Zoom;
            picCheckIfMeetSpecial.TabIndex = 14;
            picCheckIfMeetSpecial.TabStop = false;
            // 
            // lblMinimumLength
            // 
            lblMinimumLength.Anchor = AnchorStyles.None;
            lblMinimumLength.AutoSize = true;
            lblMinimumLength.Font = new Font("Segoe UI", 11.25F);
            lblMinimumLength.Location = new Point(27, 188);
            lblMinimumLength.Name = "lblMinimumLength";
            lblMinimumLength.Size = new Size(134, 20);
            lblMinimumLength.TabIndex = 20;
            lblMinimumLength.Text = "8 to 128 characters";
            // 
            // lblUppercase
            // 
            lblUppercase.Anchor = AnchorStyles.None;
            lblUppercase.AutoSize = true;
            lblUppercase.Font = new Font("Segoe UI", 11.25F);
            lblUppercase.Location = new Point(27, 218);
            lblUppercase.Name = "lblUppercase";
            lblUppercase.Size = new Size(199, 20);
            lblUppercase.TabIndex = 21;
            lblUppercase.Text = "At least one uppercase letter";
            // 
            // lblLowercase
            // 
            lblLowercase.Anchor = AnchorStyles.None;
            lblLowercase.AutoSize = true;
            lblLowercase.Font = new Font("Segoe UI", 11.25F);
            lblLowercase.Location = new Point(27, 248);
            lblLowercase.Name = "lblLowercase";
            lblLowercase.Size = new Size(197, 20);
            lblLowercase.TabIndex = 22;
            lblLowercase.Text = "At least one lowercase letter";
            // 
            // lblNumber
            // 
            lblNumber.Anchor = AnchorStyles.None;
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Segoe UI", 11.25F);
            lblNumber.Location = new Point(27, 278);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(143, 20);
            lblNumber.TabIndex = 23;
            lblNumber.Text = "At least one number";
            // 
            // lblSpecial
            // 
            lblSpecial.Anchor = AnchorStyles.None;
            lblSpecial.AutoSize = true;
            lblSpecial.Font = new Font("Segoe UI", 11.25F);
            lblSpecial.Location = new Point(27, 308);
            lblSpecial.Name = "lblSpecial";
            lblSpecial.Size = new Size(203, 20);
            lblSpecial.TabIndex = 24;
            lblSpecial.Text = "At least one special character";
            // 
            // btnRandomPassword
            // 
            btnRandomPassword.BackColor = Color.Transparent;
            btnRandomPassword.BackgroundEndColor = SystemColors.Control;
            btnRandomPassword.BackgroundStartColor = SystemColors.Control;
            btnRandomPassword.BorderColor = Color.DarkGray;
            btnRandomPassword.BorderRadius = 0;
            btnRandomPassword.BorderSize = 1;
            btnRandomPassword.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnRandomPassword.CenterIconWithText = false;
            btnRandomPassword.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnRandomPassword.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnRandomPassword.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnRandomPassword.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnRandomPassword.EnableHoverAnimation = false;
            btnRandomPassword.EnableIconTinting = false;
            btnRandomPassword.EnableRippleEffect = false;
            btnRandomPassword.EnableShadow = false;
            btnRandomPassword.Font = new Font("Segoe UI", 9.5F);
            btnRandomPassword.ForeColor = SystemColors.ControlText;
            btnRandomPassword.GradientAngle = 90F;
            btnRandomPassword.HoverAnimationSpeed = 25;
            btnRandomPassword.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnRandomPassword.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnRandomPassword.HoverIconColor = Color.White;
            btnRandomPassword.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnRandomPassword.HoverTextColor = SystemColors.ControlText;
            btnRandomPassword.IconColor = Color.White;
            btnRandomPassword.IconMargin = 10;
            btnRandomPassword.IconOffset = new Point(0, 0);
            btnRandomPassword.IconSize = new Size(16, 16);
            btnRandomPassword.IconSpacing = 5;
            btnRandomPassword.IsLoading = false;
            btnRandomPassword.LeftIcon = null;
            btnRandomPassword.Location = new Point(156, 152);
            btnRandomPassword.MiddleIcon = null;
            btnRandomPassword.Name = "btnRandomPassword";
            btnRandomPassword.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnRandomPassword.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnRandomPassword.RightIcon = null;
            btnRandomPassword.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnRandomPassword.RippleSpeed = 15;
            btnRandomPassword.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnRandomPassword.ShadowOffset = new Point(1, 1);
            btnRandomPassword.ShadowSize = 3;
            btnRandomPassword.ShiftOnPress = false;
            btnRandomPassword.Size = new Size(181, 29);
            btnRandomPassword.TabIndex = 25;
            btnRandomPassword.Text = "Generate Random Password";
            btnRandomPassword.TextColor = SystemColors.ControlText;
            btnRandomPassword.TextOffset = new Point(0, 0);
            toolTip1.SetToolTip(btnRandomPassword, "Generate Random Password Meet the requirments");
            btnRandomPassword.Click += btnRandomPassword_Click;
            // 
            // PasswordInputControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(btnRandomPassword);
            Controls.Add(lblSpecial);
            Controls.Add(lblNumber);
            Controls.Add(lblLowercase);
            Controls.Add(lblUppercase);
            Controls.Add(lblMinimumLength);
            Controls.Add(picCheckIfMeetSpecial);
            Controls.Add(picCheckIfMeetNumber);
            Controls.Add(picCheckIfMeetLowercase);
            Controls.Add(picCheckIfMeetUppercase);
            Controls.Add(picCheckIfMeetMinimumLength);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtNewPassword);
            Name = "PasswordInputControl";
            Size = new Size(361, 335);
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetMinimumLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetUppercase).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetLowercase).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCheckIfMeetSpecial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNewPassword;
        private CustomizeControls.NTextBox txtNewPassword;
        private Label lblConfirmPassword;
        private CustomizeControls.NTextBox txtConfirmPassword;
        private PictureBox picCheckIfMeetMinimumLength;
        private PictureBox picCheckIfMeetUppercase;
        private PictureBox picCheckIfMeetLowercase;
        private PictureBox picCheckIfMeetNumber;
        private PictureBox picCheckIfMeetSpecial;
        private Label lblMinimumLength;
        private Label lblUppercase;
        private Label lblLowercase;
        private Label lblNumber;
        private Label lblSpecial;
        private ToolTip toolTip1;
        private CustomizeControls.NButton btnRandomPassword;
    }
}