using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Login
{
    partial class frmLoginScreen
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlRightCanvas;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUserName;
        private NControls.NTextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private NControls.NTextBox txtPassword;
        private NControls.NCheckBox chkRememberMe;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private ModernUI.Controls.NButton btnLogin;
        private System.Windows.Forms.Label lblSignUpPrompt;
        private System.Windows.Forms.LinkLabel lnkSignUp;
        private System.Windows.Forms.Label lblAttemptsCounter;
        private System.Windows.Forms.Label lblAttemptMessage;

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
            pnlRightCanvas = new Panel();
            lblAttemptsCounter = new Label();
            lblAttemptMessage = new Label();
            lblSignUpPrompt = new Label();
            lnkSignUp = new LinkLabel();
            lblUserName = new Label();
            txtUserName = new NControls.NTextBox();
            lblPassword = new Label();
            txtPassword = new NControls.NTextBox();
            chkRememberMe = new NControls.NCheckBox();
            lnkForgotPassword = new LinkLabel();
            btnLogin = new ModernUI.Controls.NButton();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlRightCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(520, 38);
            headerControl.TitleText = "DVLD - Sign In";
            // 
            // pnlRightCanvas
            // 
            pnlRightCanvas.BackColor = Color.White;
            pnlRightCanvas.Controls.Add(lblAttemptsCounter);
            pnlRightCanvas.Controls.Add(lblAttemptMessage);
            pnlRightCanvas.Controls.Add(lblSignUpPrompt);
            pnlRightCanvas.Controls.Add(lnkSignUp);
            pnlRightCanvas.Controls.Add(lblUserName);
            pnlRightCanvas.Controls.Add(txtUserName);
            pnlRightCanvas.Controls.Add(lblPassword);
            pnlRightCanvas.Controls.Add(txtPassword);
            pnlRightCanvas.Controls.Add(chkRememberMe);
            pnlRightCanvas.Controls.Add(lnkForgotPassword);
            pnlRightCanvas.Controls.Add(btnLogin);
            pnlRightCanvas.Controls.Add(lblTitle);
            pnlRightCanvas.Controls.Add(lblSubtitle);
            pnlRightCanvas.Dock = DockStyle.Fill;
            pnlRightCanvas.Location = new Point(2, 40);
            pnlRightCanvas.Name = "pnlRightCanvas";
            pnlRightCanvas.Size = new Size(516, 598);
            pnlRightCanvas.TabIndex = 0;
            // 
            // lblAttemptsCounter
            // 
            lblAttemptsCounter.AutoSize = true;
            lblAttemptsCounter.BackColor = Color.Transparent;
            lblAttemptsCounter.Font = new Font("Segoe UI", 9F);
            lblAttemptsCounter.ForeColor = Color.FromArgb(15, 23, 42);
            lblAttemptsCounter.Location = new Point(48, 550);
            lblAttemptsCounter.Name = "lblAttemptsCounter";
            lblAttemptsCounter.Size = new Size(0, 15);
            lblAttemptsCounter.TabIndex = 11;
            // 
            // lblAttemptMessage
            // 
            lblAttemptMessage.AutoSize = true;
            lblAttemptMessage.BackColor = Color.Transparent;
            lblAttemptMessage.Font = new Font("Segoe UI", 9F);
            lblAttemptMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblAttemptMessage.Location = new Point(48, 528);
            lblAttemptMessage.Name = "lblAttemptMessage";
            lblAttemptMessage.Size = new Size(0, 15);
            lblAttemptMessage.TabIndex = 10;
            // 
            // lblSignUpPrompt
            // 
            lblSignUpPrompt.AutoSize = true;
            lblSignUpPrompt.BackColor = Color.Transparent;
            lblSignUpPrompt.Font = new Font("Segoe UI", 9F);
            lblSignUpPrompt.ForeColor = Color.FromArgb(100, 116, 139);
            lblSignUpPrompt.Location = new Point(140, 485);
            lblSignUpPrompt.Name = "lblSignUpPrompt";
            lblSignUpPrompt.Size = new Size(131, 15);
            lblSignUpPrompt.TabIndex = 8;
            lblSignUpPrompt.Text = "Don't have an account?";
            // 
            // lnkSignUp
            // 
            lnkSignUp.ActiveLinkColor = Color.FromArgb(85, 105, 224);
            lnkSignUp.AutoSize = true;
            lnkSignUp.BackColor = Color.Transparent;
            lnkSignUp.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lnkSignUp.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSignUp.LinkColor = Color.FromArgb(124, 58, 237);
            lnkSignUp.Location = new Point(275, 485);
            lnkSignUp.Name = "lnkSignUp";
            lnkSignUp.Size = new Size(49, 15);
            lnkSignUp.TabIndex = 9;
            lnkSignUp.TabStop = true;
            lnkSignUp.Text = "Sign up";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.BackColor = Color.Transparent;
            lblUserName.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(71, 85, 105);
            lblUserName.Location = new Point(48, 168);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(69, 17);
            lblUserName.TabIndex = 2;
            lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            txtUserName.AllowArabicCharacters = false;
            txtUserName.AllowEnglishCharacters = true;
            txtUserName.AllowNumbers = true;
            txtUserName.AllowSpaces = false;
            txtUserName.AllowSymbols = false;
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
            txtUserName.Location = new Point(48, 192);
            txtUserName.MaxLength = 50;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(8, 12, 8, 12);
            txtUserName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.RightIcon = null;
            txtUserName.RightIconClickable = false;
            txtUserName.ShowClearButton = true;
            txtUserName.Size = new Size(420, 44);
            txtUserName.SuggestIcon = null;
            txtUserName.TabIndex = 3;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(48, 252);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(66, 17);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.AllowArabicCharacters = false;
            txtPassword.AllowEnglishCharacters = true;
            txtPassword.AllowNumbers = true;
            txtPassword.AllowSpaces = false;
            txtPassword.AllowSymbols = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.FromArgb(226, 232, 240);
            txtPassword.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtPassword.BorderRadius = 8;
            txtPassword.BorderSize = 1;
            txtPassword.CustomAllowedCharacters = "";
            txtPassword.EnableIconTinting = true;
            txtPassword.EnableSuggest = false;
            txtPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPassword.FillColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HasError = false;
            txtPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtPassword.IconOffsetLeft = 10;
            txtPassword.IconOffsetRight = 12;
            txtPassword.IconSize = new Size(18, 18);
            txtPassword.IconSpacing = 8;
            txtPassword.LeftIcon = null;
            txtPassword.LeftIconClickable = false;
            txtPassword.Location = new Point(48, 276);
            txtPassword.MaxLength = 50;
            txtPassword.MaxSuggestItems = 8;
            txtPassword.MoveToNextControlOnEnter = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(8, 12, 8, 12);
            txtPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.RightIcon = Properties.Resources.visibilityOff;
            txtPassword.RightIconClickable = true;
            txtPassword.ShowClearButton = false;
            txtPassword.Size = new Size(420, 44);
            txtPassword.SuggestIcon = null;
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.ValidateEmail = false;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AnimationSpeed = 25;
            chkRememberMe.AutoCheck = true;
            chkRememberMe.BackColor = Color.Transparent;
            chkRememberMe.BorderRadius = 4;
            chkRememberMe.BorderSize = 1;
            chkRememberMe.BoxBackColor = Color.White;
            chkRememberMe.BoxBorderColor = Color.FromArgb(203, 213, 225);
            chkRememberMe.BoxSize = 18;
            chkRememberMe.CheckAlign = NControls.NCheckAlign.Left;
            chkRememberMe.Checked = false;
            chkRememberMe.CheckedColor = Color.FromArgb(124, 58, 237);
            chkRememberMe.CheckMarkColor = Color.White;
            chkRememberMe.CheckState = CheckState.Unchecked;
            chkRememberMe.CheckThickness = 2F;
            chkRememberMe.Cursor = Cursors.Hand;
            chkRememberMe.DisabledColor = Color.FromArgb(220, 224, 230);
            chkRememberMe.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkRememberMe.EnableAnimation = true;
            chkRememberMe.EnableRipple = false;
            chkRememberMe.Font = new Font("Segoe UI", 9F);
            chkRememberMe.ForeColor = Color.FromArgb(71, 85, 105);
            chkRememberMe.HoverBorderColor = Color.FromArgb(124, 58, 237);
            chkRememberMe.Location = new Point(48, 335);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.RippleColor = Color.FromArgb(40, 124, 58, 237);
            chkRememberMe.Size = new Size(130, 24);
            chkRememberMe.Style = NControls.NCheckBoxStyle.Rounded;
            chkRememberMe.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkRememberMe.SwitchThumbColor = Color.White;
            chkRememberMe.SwitchWidth = 38;
            chkRememberMe.TabIndex = 6;
            chkRememberMe.Text = "Remember me";
            chkRememberMe.TextSpacing = 8;
            chkRememberMe.ThreeState = false;
            // 
            // lnkForgotPassword
            // 
            lnkForgotPassword.ActiveLinkColor = Color.FromArgb(85, 105, 224);
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.BackColor = Color.Transparent;
            lnkForgotPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lnkForgotPassword.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkForgotPassword.LinkColor = Color.FromArgb(124, 58, 237);
            lnkForgotPassword.Location = new Point(366, 339);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.Size = new Size(100, 15);
            lnkForgotPassword.TabIndex = 7;
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Forgot Password?";
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BorderRadius = 8;
            btnLogin.BorderSize = 0;
            btnLogin.CenterIconWithText = true;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnLogin.IsLoading = false;
            btnLogin.LeftIcon = null;
            btnLogin.Location = new Point(48, 390);
            btnLogin.Name = "btnLogin";
            btnLogin.RightIcon = null;
            btnLogin.Size = new Size(420, 46);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Sign In";
            btnLogin.TextOffset = new Point(0, 0);
            btnLogin.Click += btnLogin_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(44, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(207, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome back";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(48, 82);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(256, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please enter your credentials to continue.";
            // 
            // frmLoginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            ClientSize = new Size(520, 640);
            Controls.Add(pnlRightCanvas);
            Name = "frmLoginScreen";
            Text = "DVLD - Sign In";
            Load += LoginScreen_Load;
            Controls.SetChildIndex(pnlRightCanvas, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlRightCanvas.ResumeLayout(false);
            pnlRightCanvas.PerformLayout();
            ResumeLayout(false);
        }
    }
}