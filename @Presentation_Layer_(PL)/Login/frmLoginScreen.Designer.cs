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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginScreen));
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
            label1 = new Label();
            btnClose = new Button();
            btnMinimize = new Button();
            lblTitle = new Label();
            lblSubtitle = new Label();
            pnlRightCanvas.SuspendLayout();
            SuspendLayout();
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
            pnlRightCanvas.Controls.Add(label1);
            pnlRightCanvas.Controls.Add(btnClose);
            pnlRightCanvas.Controls.Add(btnMinimize);
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
            lnkSignUp.LinkColor = Color.FromArgb(18, 44, 199);
            lnkSignUp.Name = "lnkSignUp";
            lnkSignUp.TabStop = true;
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
            txtUserName.BorderFocusColor = Color.FromArgb(103, 78, 167);
            txtUserName.BorderRadius = 10;
            txtUserName.BorderSize = 2;
            txtUserName.CustomAllowedCharacters = "";
            txtUserName.EnableSuggest = false;
            txtUserName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtUserName.FillColor = Color.FromArgb(250, 250, 252);
            txtUserName.ForeColor = Color.FromArgb(15, 23, 42);
            txtUserName.HasError = false;
            txtUserName.IconOffsetLeft = 10;
            txtUserName.IconOffsetRight = 10;
            txtUserName.IconSpacing = 8;
            txtUserName.MaxLength = 20;
            txtUserName.MaxSuggestItems = 8;
            txtUserName.MoveToNextControlOnEnter = true;
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtUserName.PlaceholderText = "Enter your user name";
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
            txtPassword.BorderFocusColor = Color.FromArgb(103, 78, 167);
            txtPassword.BorderRadius = 10;
            txtPassword.BorderSize = 2;
            txtPassword.CustomAllowedCharacters = "";
            txtPassword.EnableSuggest = false;
            txtPassword.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPassword.FillColor = Color.FromArgb(250, 250, 252);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HasError = false;
            txtPassword.IconOffsetLeft = 10;
            txtPassword.IconOffsetRight = 10;
            txtPassword.IconSpacing = 8;
            txtPassword.MaxLength = 20;
            txtPassword.MaxSuggestItems = 8;
            txtPassword.MoveToNextControlOnEnter = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Enter your password";
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
            chkRememberMe.CheckAlign = NControls.NCheckAlign.Left;
            chkRememberMe.Checked = false;
            chkRememberMe.CheckedColor = Color.FromArgb(59, 130, 246);
            chkRememberMe.CheckMarkColor = Color.White;
            chkRememberMe.CheckState = CheckState.Unchecked;
            chkRememberMe.CheckThickness = 2F;
            chkRememberMe.Cursor = Cursors.Hand;
            chkRememberMe.DisabledColor = Color.FromArgb(220, 224, 230);
            chkRememberMe.DisabledTextColor = Color.FromArgb(160, 166, 175);
            chkRememberMe.EnableAnimation = true;
            chkRememberMe.EnableRipple = false;
            chkRememberMe.ForeColor = Color.FromArgb(71, 85, 105);
            chkRememberMe.HoverBorderColor = Color.FromArgb(59, 130, 246);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.RippleColor = Color.FromArgb(40, 0, 120, 215);
            chkRememberMe.Style = NControls.NCheckBoxStyle.Rounded;
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
            lnkForgotPassword.LinkColor = Color.FromArgb(18, 44, 199);
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.LinkClicked += lnkForgotPassword_LinkClicked;
            // 
            // btnLogin
            // 
            resources.ApplyResources(btnLogin, "btnLogin");
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BackgroundEndColor = Color.FromArgb(103, 78, 167);
            btnLogin.BackgroundStartColor = Color.FromArgb(126, 87, 194);
            btnLogin.BorderColor = Color.FromArgb(103, 78, 167);
            btnLogin.BorderRadius = 8;
            btnLogin.BorderSize = 0;
            btnLogin.CenterIconWithText = false;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.EnableHoverAnimation = true;
            btnLogin.EnableIconTinting = false;
            btnLogin.EnableRippleEffect = true;
            btnLogin.EnableShadow = false;
            btnLogin.ForeColor = Color.White;
            btnLogin.GradientAngle = 90F;
            btnLogin.HoverAnimationSpeed = 25;
            btnLogin.HoverBorderColor = Color.FromArgb(145, 108, 211);
            btnLogin.HoverEndColor = Color.FromArgb(126, 87, 194);
            btnLogin.HoverIconColor = Color.White;
            btnLogin.HoverStartColor = Color.FromArgb(119, 92, 185);
            btnLogin.HoverTextColor = Color.White;
            btnLogin.IconColor = Color.White;
            btnLogin.IconMargin = 10;
            btnLogin.IconOffset = new Point(0, 0);
            btnLogin.IconSize = new Size(32, 32);
            btnLogin.IconSpacing = 5;
            btnLogin.IsLoading = false;
            btnLogin.LeftIcon = null;
            btnLogin.Name = "btnLogin";
            btnLogin.PressedEndColor = Color.FromArgb(145, 108, 211);
            btnLogin.PressedStartColor = Color.FromArgb(91, 69, 149);
            btnLogin.RightIcon = null;
            btnLogin.RippleColor = Color.FromArgb(60, 255, 255, 255);
            btnLogin.RippleSpeed = 16;
            btnLogin.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnLogin.ShadowOffset = new Point(1, 1);
            btnLogin.ShadowSize = 3;
            btnLogin.ShiftOnPress = false;
            btnLogin.TextColor = Color.White;
            btnLogin.TextOffset = new Point(0, 0);
            btnLogin.Click += btnLogin_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.FromArgb(148, 163, 184);
            label1.Name = "label1";
            // 
            // btnClose
            // 
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = Color.FromArgb(148, 163, 184);
            btnClose.Name = "btnClose";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnMinimize
            // 
            resources.ApplyResources(btnMinimize, "btnMinimize");
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.ForeColor = Color.FromArgb(148, 163, 184);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.BackColor = Color.Transparent;
            lblTitle.ForeColor = Color.FromArgb(20, 3, 46);
            lblTitle.Name = "lblTitle";
            // 
            // lblSubtitle
            // 
            resources.ApplyResources(lblSubtitle, "lblSubtitle");
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.ForeColor = Color.FromArgb(70, 60, 87);
            lblSubtitle.Name = "lblSubtitle";
            // 
            // frmLoginScreen
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(124, 58, 237);
            Controls.Add(pnlRightCanvas);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLoginScreen";
            Load += LoginScreen_Load;
            pnlRightCanvas.ResumeLayout(false);
            pnlRightCanvas.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
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
    }
}