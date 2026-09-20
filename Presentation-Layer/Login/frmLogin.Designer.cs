using System.Drawing;
using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Login
{
    partial class frmLoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlRightCanvas;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUserName;
        private NTextBox txtUserName;
        private Label lblPassword;
        private NTextBox txtPassword;
        private NCheckBox chkRememberMe;
        private LinkLabel lnkForgotPassword;
        private NButton btnLogin;
        private Label lblSignUpPrompt;
        private LinkLabel lnkSignUp;
        private Label lblAttemptsCounter;
        private Label lblAttemptMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_lockoutTimer != null)
                {
                    _lockoutTimer.Stop();
                    _lockoutTimer.Tick -= LockoutTimer_Tick;
                    _lockoutTimer.Dispose();
                    _lockoutTimer = null;
                }

                _toolTips?.Dispose();
                _toolTips = null;

                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginForm));
            pnlRightCanvas = new Panel();
            lblAttemptsCounter = new Label();
            lblAttemptMessage = new Label();
            lblSignUpPrompt = new Label();
            lnkSignUp = new LinkLabel();
            lblUserName = new Label();
            txtUserName = new NTextBox();
            lblPassword = new Label();
            txtPassword = new NTextBox();
            chkRememberMe = new NCheckBox();
            lnkForgotPassword = new LinkLabel();
            btnLogin = new NButton();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlRightCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // headerControl
            // 
            resources.ApplyResources(headerControl, "headerControl");
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.TitleText = "DVLD - Sign In";
            // 
            // pnlRightCanvas
            // 
            resources.ApplyResources(pnlRightCanvas, "pnlRightCanvas");
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
            pnlRightCanvas.Name = "pnlRightCanvas";
            // 
            // lblAttemptsCounter
            // 
            resources.ApplyResources(lblAttemptsCounter, "lblAttemptsCounter");
            lblAttemptsCounter.BackColor = Color.Transparent;
            lblAttemptsCounter.ForeColor = Color.FromArgb(15, 23, 42);
            lblAttemptsCounter.Name = "lblAttemptsCounter";
            // 
            // lblAttemptMessage
            // 
            resources.ApplyResources(lblAttemptMessage, "lblAttemptMessage");
            lblAttemptMessage.BackColor = Color.Transparent;
            lblAttemptMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblAttemptMessage.Name = "lblAttemptMessage";
            // 
            // lblSignUpPrompt
            // 
            resources.ApplyResources(lblSignUpPrompt, "lblSignUpPrompt");
            lblSignUpPrompt.BackColor = Color.Transparent;
            lblSignUpPrompt.ForeColor = Color.FromArgb(100, 116, 139);
            lblSignUpPrompt.Name = "lblSignUpPrompt";
            // 
            // lnkSignUp
            // 
            resources.ApplyResources(lnkSignUp, "lnkSignUp");
            lnkSignUp.ActiveLinkColor = Color.FromArgb(85, 105, 224);
            lnkSignUp.BackColor = Color.Transparent;
            lnkSignUp.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkSignUp.LinkColor = Color.FromArgb(124, 58, 237);
            lnkSignUp.Name = "lnkSignUp";
            lnkSignUp.TabStop = true;
            lnkSignUp.LinkClicked += lnkSignUp_LinkClicked;
            // 
            // lblUserName
            // 
            resources.ApplyResources(lblUserName, "lblUserName");
            lblUserName.BackColor = Color.Transparent;
            lblUserName.ForeColor = Color.FromArgb(71, 85, 105);
            lblUserName.Name = "lblUserName";
            // 
            // txtUserName
            // 
            resources.ApplyResources(txtUserName, "txtUserName");
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
            txtUserName.MaxLength = 50;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtUserName.PlaceholderText = "Enter your username";
            txtUserName.RightIcon = null;
            txtUserName.RightIconClickable = false;
            txtUserName.ShowClearButton = true;
            txtUserName.SuggestIcon = null;
            txtUserName.UseSystemPasswordChar = false;
            txtUserName.ValidateEmail = false;
            txtUserName.TextChanged += txtUserName_TextChanged;
            // 
            // lblPassword
            // 
            resources.ApplyResources(lblPassword, "lblPassword");
            lblPassword.BackColor = Color.Transparent;
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Name = "lblPassword";
            // 
            // txtPassword
            // 
            resources.ApplyResources(txtPassword, "txtPassword");
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
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HasError = false;
            txtPassword.HoverIconColor = Color.FromArgb(15, 23, 42);
            txtPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtPassword.IconOffsetLeft = 10;
            txtPassword.IconOffsetRight = 12;
            txtPassword.IconSize = new Size(18, 18);
            txtPassword.IconSpacing = 8;
            txtPassword.LeftIcon = null;
            txtPassword.LeftIconClickable = false;
            txtPassword.MaxLength = 50;
            txtPassword.MaxSuggestItems = 8;
            txtPassword.MoveToNextControlOnEnter = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.RightIcon = Properties.Resources.visibilityOff;
            txtPassword.RightIconClickable = true;
            txtPassword.ShowClearButton = false;
            txtPassword.SuggestIcon = null;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.ValidateEmail = false;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // chkRememberMe
            // 
            resources.ApplyResources(chkRememberMe, "chkRememberMe");
            chkRememberMe.AnimationSpeed = 25;
            chkRememberMe.AutoCheck = true;
            chkRememberMe.BackColor = Color.Transparent;
            chkRememberMe.BorderRadius = 4;
            chkRememberMe.BorderSize = 1;
            chkRememberMe.BoxBackColor = Color.White;
            chkRememberMe.BoxBorderColor = Color.FromArgb(203, 213, 225);
            chkRememberMe.BoxSize = 18;
            chkRememberMe.CheckAlign = NCheckAlign.Left;
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
            chkRememberMe.ForeColor = Color.FromArgb(71, 85, 105);
            chkRememberMe.HoverBorderColor = Color.FromArgb(124, 58, 237);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.RippleColor = Color.FromArgb(40, 124, 58, 237);
            chkRememberMe.Style = NCheckBoxStyle.Rounded;
            chkRememberMe.SwitchOffTrackColor = Color.FromArgb(220, 224, 230);
            chkRememberMe.SwitchThumbColor = Color.White;
            chkRememberMe.SwitchWidth = 38;
            chkRememberMe.TextSpacing = 8;
            chkRememberMe.ThreeState = false;
            // 
            // lnkForgotPassword
            // 
            resources.ApplyResources(lnkForgotPassword, "lnkForgotPassword");
            lnkForgotPassword.ActiveLinkColor = Color.FromArgb(85, 105, 224);
            lnkForgotPassword.BackColor = Color.Transparent;
            lnkForgotPassword.LinkBehavior = LinkBehavior.NeverUnderline;
            lnkForgotPassword.LinkColor = Color.FromArgb(124, 58, 237);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // btnLogin
            // 
            resources.ApplyResources(btnLogin, "btnLogin");
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BackgroundEndColor = SystemColors.Control;
            btnLogin.BackgroundStartColor = SystemColors.Control;
            btnLogin.BorderColor = Color.DarkGray;
            btnLogin.BorderRadius = 8;
            btnLogin.BorderSize = 0;
            btnLogin.CenterIconWithText = true;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.DisabledBorderColor = Color.FromArgb(226, 232, 240);
            btnLogin.DisabledEndColor = Color.FromArgb(241, 245, 249);
            btnLogin.DisabledStartColor = Color.FromArgb(241, 245, 249);
            btnLogin.DisabledTextColor = Color.FromArgb(148, 163, 184);
            btnLogin.EnableHoverAnimation = false;
            btnLogin.EnableIconTinting = false;
            btnLogin.EnableRippleEffect = false;
            btnLogin.EnableShadow = false;
            btnLogin.ForeColor = SystemColors.ControlText;
            btnLogin.GradientAngle = 90F;
            btnLogin.HoverAnimationSpeed = 25;
            btnLogin.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnLogin.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnLogin.HoverIconColor = Color.White;
            btnLogin.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnLogin.HoverTextColor = SystemColors.ControlText;
            btnLogin.IconColor = Color.White;
            btnLogin.IconMargin = 10;
            btnLogin.IconOffset = new Point(0, 0);
            btnLogin.IconSize = new Size(16, 16);
            btnLogin.IconSpacing = 5;
            btnLogin.IsLoading = false;
            btnLogin.LeftIcon = null;
            btnLogin.MiddleIcon = null;
            btnLogin.Name = "btnLogin";
            btnLogin.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnLogin.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnLogin.RightIcon = null;
            btnLogin.RippleColor = Color.FromArgb(50, 0, 0, 0);
            btnLogin.RippleSpeed = 15;
            btnLogin.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            btnLogin.ShadowOffset = new Point(1, 1);
            btnLogin.ShadowSize = 3;
            btnLogin.ShiftOnPress = false;
            btnLogin.TextColor = SystemColors.ControlText;
            btnLogin.TextOffset = new Point(0, 0);
            btnLogin.Click += btnLogin_Click;
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Name = "lblTitle";
            // 
            // lblSubtitle
            // 
            resources.ApplyResources(lblSubtitle, "lblSubtitle");
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Name = "lblSubtitle";
            // 
            // frmLoginScreen
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlRightCanvas);
            CustomBorderColor = Color.FromArgb(226, 232, 240);
            ForeColor = Color.FromArgb(15, 23, 42);
            Name = "frmLoginScreen";
            Load += LoginScreen_Load;
            Controls.SetChildIndex(pnlRightCanvas, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlRightCanvas.ResumeLayout(false);
            pnlRightCanvas.PerformLayout();
            ResumeLayout(false);
        }
    }
}