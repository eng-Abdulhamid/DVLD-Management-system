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
            this.pnlRightCanvas = new System.Windows.Forms.Panel();
            this.lblAttemptsCounter = new System.Windows.Forms.Label();
            this.lblAttemptMessage = new System.Windows.Forms.Label();
            this.lnkPasswordStatus = new System.Windows.Forms.LinkLabel();
            this.lblSignUpPrompt = new System.Windows.Forms.Label();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new NControls.NTextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new NControls.NTextBox();
            this.chkRememberMe = new NControls.NCheckBox();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new ModernUI.Controls.NButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlRightCanvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRightCanvas
            // 
            this.pnlRightCanvas.BackColor = System.Drawing.Color.White;
            this.pnlRightCanvas.Controls.Add(this.lblAttemptsCounter);
            this.pnlRightCanvas.Controls.Add(this.lblAttemptMessage);
            this.pnlRightCanvas.Controls.Add(this.lnkPasswordStatus);
            this.pnlRightCanvas.Controls.Add(this.lblSignUpPrompt);
            this.pnlRightCanvas.Controls.Add(this.lnkSignUp);
            this.pnlRightCanvas.Controls.Add(this.lblUserName);
            this.pnlRightCanvas.Controls.Add(this.txtUserName);
            this.pnlRightCanvas.Controls.Add(this.lblPassword);
            this.pnlRightCanvas.Controls.Add(this.txtPassword);
            this.pnlRightCanvas.Controls.Add(this.chkRememberMe);
            this.pnlRightCanvas.Controls.Add(this.lnkForgotPassword);
            this.pnlRightCanvas.Controls.Add(this.btnLogin);
            this.pnlRightCanvas.Controls.Add(this.label1);
            this.pnlRightCanvas.Controls.Add(this.btnClose);
            this.pnlRightCanvas.Controls.Add(this.btnMinimize);
            this.pnlRightCanvas.Controls.Add(this.lblTitle);
            this.pnlRightCanvas.Controls.Add(this.lblSubtitle);
            this.pnlRightCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightCanvas.Location = new System.Drawing.Point(2, 2);
            this.pnlRightCanvas.Name = "pnlRightCanvas";
            this.pnlRightCanvas.Size = new System.Drawing.Size(506, 599);
            this.pnlRightCanvas.TabIndex = 1;
            // 
            // lblAttemptsCounter
            // 
            this.lblAttemptsCounter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAttemptsCounter.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42); // Navy Dark
            this.lblAttemptsCounter.Location = new System.Drawing.Point(86, 500);
            this.lblAttemptsCounter.Name = "lblAttemptsCounter";
            this.lblAttemptsCounter.Size = new System.Drawing.Size(340, 20);
            this.lblAttemptsCounter.TabIndex = 21;
            this.lblAttemptsCounter.Text = "Please wait 30 seconds...";
            this.lblAttemptsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttemptsCounter.Visible = false; // مخفي افتراضياً
            // 
            // lblAttemptMessage
            // 
            this.lblAttemptMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblAttemptMessage.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68); // Red
            this.lblAttemptMessage.Location = new System.Drawing.Point(86, 480);
            this.lblAttemptMessage.Name = "lblAttemptMessage";
            this.lblAttemptMessage.Size = new System.Drawing.Size(340, 20);
            this.lblAttemptMessage.TabIndex = 20;
            this.lblAttemptMessage.Text = "Too many failed attempts.";
            this.lblAttemptMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttemptMessage.Visible = false; // مخفي افتراضياً
            // 
            // lnkPasswordStatus
            // 
            this.lnkPasswordStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lnkPasswordStatus.AutoSize = true;
            this.lnkPasswordStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lnkPasswordStatus.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkPasswordStatus.LinkColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lnkPasswordStatus.Location = new System.Drawing.Point(340, 274);
            this.lnkPasswordStatus.Name = "lnkPasswordStatus";
            this.lnkPasswordStatus.Size = new System.Drawing.Size(86, 15);
            this.lnkPasswordStatus.TabIndex = 22;
            this.lnkPasswordStatus.TabStop = true;
            this.lnkPasswordStatus.Tag = "0";
            this.lnkPasswordStatus.Text = "Show password";
            this.lnkPasswordStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblSignUpPrompt
            // 
            this.lblSignUpPrompt.AutoSize = true;
            this.lblSignUpPrompt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSignUpPrompt.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSignUpPrompt.Location = new System.Drawing.Point(143, 545);
            this.lblSignUpPrompt.Name = "lblSignUpPrompt";
            this.lblSignUpPrompt.Size = new System.Drawing.Size(143, 17);
            this.lblSignUpPrompt.TabIndex = 19;
            this.lblSignUpPrompt.Text = "Don't have an account?";
            // 
            // lnkSignUp
            // 
            this.lnkSignUp.ActiveLinkColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lnkSignUp.AutoSize = true;
            this.lnkSignUp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkSignUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkSignUp.LinkColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lnkSignUp.Location = new System.Drawing.Point(289, 545);
            this.lnkSignUp.Name = "lnkSignUp";
            this.lnkSignUp.Size = new System.Drawing.Size(55, 17);
            this.lnkSignUp.TabIndex = 5;
            this.lnkSignUp.TabStop = true;
            this.lnkSignUp.Text = "Sign Up";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblUserName.Location = new System.Drawing.Point(84, 187);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 17);
            this.lblUserName.TabIndex = 12;
            this.lblUserName.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtUserName.BorderFocusColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.txtUserName.BorderRadius = 8;
            this.txtUserName.BorderSize = 1;
            this.txtUserName.EnableSuggest = false;
            this.txtUserName.FillColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUserName.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtUserName.IconOffsetLeft = 10;
            this.txtUserName.IconOffsetRight = 10;
            this.txtUserName.IconSpacing = 8;
            this.txtUserName.Location = new System.Drawing.Point(86, 210);
            this.txtUserName.MaxSuggestItems = 8;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Padding = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.txtUserName.PlaceholderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.txtUserName.PlaceholderText = "Enter your user name";
            this.txtUserName.ShowClearButton = true;
            this.txtUserName.Size = new System.Drawing.Size(340, 44);
            this.txtUserName.SuggestIcon = null;
            this.txtUserName.TabIndex = 0;
            this.txtUserName.UseSystemPasswordChar = false;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPassword.Location = new System.Drawing.Point(84, 272);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 17);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.txtPassword.BorderFocusColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.EnableSuggest = false;
            this.txtPassword.FillColor = System.Drawing.Color.White;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtPassword.IconOffsetLeft = 10;
            this.txtPassword.IconOffsetRight = 10;
            this.txtPassword.IconSpacing = 8;
            this.txtPassword.Location = new System.Drawing.Point(86, 295);
            this.txtPassword.MaxSuggestItems = 8;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.txtPassword.PlaceholderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.txtPassword.PlaceholderText = "Enter your password";
            this.txtPassword.ShowClearButton = false;
            this.txtPassword.Size = new System.Drawing.Size(340, 44);
            this.txtPassword.SuggestIcon = null;
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AnimationSpeed = 25;
            this.chkRememberMe.AutoCheck = true;
            this.chkRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.BorderRadius = 4;
            this.chkRememberMe.BorderSize = 1;
            this.chkRememberMe.BoxBackColor = System.Drawing.Color.White;
            this.chkRememberMe.BoxBorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.chkRememberMe.BoxSize = 18;
            this.chkRememberMe.CheckAlign = NControls.NCheckAlign.Left;
            this.chkRememberMe.Checked = false;
            this.chkRememberMe.CheckedColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.chkRememberMe.CheckMarkColor = System.Drawing.Color.White;
            this.chkRememberMe.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkRememberMe.CheckThickness = 2F;
            this.chkRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberMe.DisabledColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.chkRememberMe.DisabledTextColor = System.Drawing.Color.FromArgb(160, 166, 175);
            this.chkRememberMe.EnableAnimation = true;
            this.chkRememberMe.EnableRipple = false;
            this.chkRememberMe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRememberMe.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.chkRememberMe.HoverBorderColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.chkRememberMe.Location = new System.Drawing.Point(86, 357);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.RippleColor = System.Drawing.Color.FromArgb(40, 0, 120, 215);
            this.chkRememberMe.Size = new System.Drawing.Size(125, 24);
            this.chkRememberMe.Style = NControls.NCheckBoxStyle.Rounded;
            this.chkRememberMe.SwitchOffTrackColor = System.Drawing.Color.FromArgb(220, 224, 230);
            this.chkRememberMe.SwitchThumbColor = System.Drawing.Color.White;
            this.chkRememberMe.SwitchWidth = 38;
            this.chkRememberMe.TabIndex = 2;
            this.chkRememberMe.Text = "Remember me";
            this.chkRememberMe.TextSpacing = 8;
            this.chkRememberMe.ThreeState = false;
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lnkForgotPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lnkForgotPassword.Location = new System.Drawing.Point(318, 361);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(100, 15);
            this.lnkForgotPassword.TabIndex = 4;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot Password?";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundEndColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnLogin.BackgroundStartColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderRadius = 8;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.CenterIconWithText = false;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.EnableHoverAnimation = true;
            this.btnLogin.EnableIconTinting = false;
            this.btnLogin.EnableRippleEffect = true;
            this.btnLogin.EnableShadow = false;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.GradientAngle = 90F;
            this.btnLogin.HoverAnimationSpeed = 25;
            this.btnLogin.HoverBorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.HoverEndColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLogin.HoverIconColor = System.Drawing.Color.White;
            this.btnLogin.HoverStartColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLogin.HoverTextColor = System.Drawing.Color.White;
            this.btnLogin.IconColor = System.Drawing.Color.White;
            this.btnLogin.IconMargin = 10;
            this.btnLogin.IconOffset = new System.Drawing.Point(0, 0);
            this.btnLogin.IconSize = new System.Drawing.Size(16, 16);
            this.btnLogin.IconSpacing = 5;
            this.btnLogin.LeftIcon = null;
            this.btnLogin.Location = new System.Drawing.Point(86, 426);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedEndColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnLogin.PressedStartColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnLogin.RightIcon = null;
            this.btnLogin.RippleColor = System.Drawing.Color.FromArgb(60, 255, 255, 255);
            this.btnLogin.RippleSpeed = 16;
            this.btnLogin.ShadowColor = System.Drawing.Color.FromArgb(60, 0, 0, 0);
            this.btnLogin.ShadowOffset = new System.Drawing.Point(1, 1);
            this.btnLogin.ShadowSize = 3;
            this.btnLogin.ShiftOnPress = false;
            this.btnLogin.Size = new System.Drawing.Size(340, 48);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.TextOffset = new System.Drawing.Point(0, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Driving License Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnClose.Location = new System.Drawing.Point(474, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnMinimize.Location = new System.Drawing.Point(438, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 9;
            this.btnMinimize.Text = "—";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTitle.Location = new System.Drawing.Point(131, 67);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(241, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome Back";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtitle.Location = new System.Drawing.Point(60, 112);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(380, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Please enter your details to sign in";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.ClientSize = new System.Drawing.Size(510, 603);
            this.Controls.Add(this.pnlRightCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginScreen";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.pnlRightCanvas.ResumeLayout(false);
            this.pnlRightCanvas.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.LinkLabel lnkPasswordStatus;
        private System.Windows.Forms.Label lblAttemptsCounter;
        private System.Windows.Forms.Label lblAttemptMessage;
    }
}