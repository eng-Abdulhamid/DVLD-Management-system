using DVLDPL;

namespace DVLDPL
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed 
        /// should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.modernPanel1 = new CustomControls.ModernPanel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblPasswordWarning = new System.Windows.Forms.Label();
            this.lblUsernameWarning = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new ModernUIControls.ModernTextBoxPro();
            this.txtUsername = new ModernUIControls.ModernTextBoxPro();
            this.btnCancel = new ModernUI.Controls.ModernButton();
            this.btnLogin = new ModernUI.Controls.ModernButton();
            this.modernPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modernPanel1
            // 
            this.modernPanel1.AccentColor = System.Drawing.Color.DodgerBlue;
            this.modernPanel1.BackColor = System.Drawing.Color.White;
            this.modernPanel1.BadgeBackColor = System.Drawing.Color.Red;
            this.modernPanel1.BadgeForeColor = System.Drawing.Color.White;
            this.modernPanel1.BadgeValue = "";
            this.modernPanel1.BorderAnimationColor1 = System.Drawing.Color.LightSalmon;
            this.modernPanel1.BorderAnimationColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.modernPanel1.BorderAnimationSpeed = 4;
            this.modernPanel1.BorderRadius = 30;
            this.modernPanel1.BorderSize = 6;
            this.modernPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.modernPanel1.Controls.Add(this.lblWarning);
            this.modernPanel1.Controls.Add(this.lblPasswordWarning);
            this.modernPanel1.Controls.Add(this.lblUsernameWarning);
            this.modernPanel1.Controls.Add(this.linkLabel1);
            this.modernPanel1.Controls.Add(this.label2);
            this.modernPanel1.Controls.Add(this.label1);
            this.modernPanel1.Controls.Add(this.txtPassword);
            this.modernPanel1.Controls.Add(this.txtUsername);
            this.modernPanel1.Controls.Add(this.btnCancel);
            this.modernPanel1.Controls.Add(this.btnLogin);
            this.modernPanel1.CornerRadiusBottomLeft = 0;
            this.modernPanel1.CornerRadiusBottomRight = 0;
            this.modernPanel1.CornerRadiusTopLeft = 0;
            this.modernPanel1.CornerRadiusTopRight = 700;
            this.modernPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modernPanel1.EnableBorderAnimation = true;
            this.modernPanel1.EnableGradientBackground = true;
            this.modernPanel1.GradientAngle = 17F;
            this.modernPanel1.GradientColor1 = System.Drawing.Color.LightSalmon;
            this.modernPanel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.modernPanel1.Location = new System.Drawing.Point(0, 0);
            this.modernPanel1.Name = "modernPanel1";
            this.modernPanel1.Size = new System.Drawing.Size(959, 591);
            this.modernPanel1.TabIndex = 7;
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWarning.Location = new System.Drawing.Point(94, 436);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(57, 17);
            this.lblWarning.TabIndex = 14;
            this.lblWarning.Text = "warning";
            this.lblWarning.Visible = false;
            // 
            // lblPasswordWarning
            // 
            this.lblPasswordWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPasswordWarning.AutoSize = true;
            this.lblPasswordWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswordWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPasswordWarning.Location = new System.Drawing.Point(87, 299);
            this.lblPasswordWarning.Name = "lblPasswordWarning";
            this.lblPasswordWarning.Size = new System.Drawing.Size(57, 17);
            this.lblPasswordWarning.TabIndex = 13;
            this.lblPasswordWarning.Text = "warning";
            // 
            // lblUsernameWarning
            // 
            this.lblUsernameWarning.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsernameWarning.AutoSize = true;
            this.lblUsernameWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblUsernameWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUsernameWarning.Location = new System.Drawing.Point(87, 222);
            this.lblUsernameWarning.Name = "lblUsernameWarning";
            this.lblUsernameWarning.Size = new System.Drawing.Size(57, 17);
            this.lblUsernameWarning.TabIndex = 12;
            this.lblUsernameWarning.Text = "warning";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(94, 380);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(91, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forget password?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(73, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 24);
            this.label2.TabIndex = 10;
            this.label2.Text = "Please enter your username and password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hello again!";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.AnimationBorder = true;
            this.txtPassword.AnimationColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtPassword.AnimationColor2 = System.Drawing.Color.LightSalmon;
            this.txtPassword.AnimationColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtPassword.AnimationColor4 = System.Drawing.Color.LightSalmon;
            this.txtPassword.AnimationColorGeneric = System.Drawing.Color.HotPink;
            this.txtPassword.AnimationSpeed = 1;
            this.txtPassword.AnimUnfocus1 = System.Drawing.Color.Gray;
            this.txtPassword.AnimUnfocus2 = System.Drawing.Color.Gray;
            this.txtPassword.AnimUnfocus3 = System.Drawing.Color.Gray;
            this.txtPassword.AnimUnfocus4 = System.Drawing.Color.Gray;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.BorderColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderFocus1 = System.Drawing.Color.OrangeRed;
            this.txtPassword.BorderFocus2 = System.Drawing.Color.Yellow;
            this.txtPassword.BorderFocus3 = System.Drawing.Color.Orange;
            this.txtPassword.BorderFocus4 = System.Drawing.Color.Gold;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtPassword.BorderRadius = 7;
            this.txtPassword.BorderRadiusBottomLeft = 7;
            this.txtPassword.BorderRadiusBottomRight = 7;
            this.txtPassword.BorderRadiusTopLeft = 7;
            this.txtPassword.BorderRadiusTopRight = 7;
            this.txtPassword.BorderSize = 2;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.EnableGlow = false;
            this.txtPassword.FillColor = System.Drawing.Color.MintCream;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.GlowFocusOnly = true;
            this.txtPassword.GlowIntensity = 4;
            this.txtPassword.IconLeft = global::DVLDPL.Properties.Resources.locked_12714906;
            this.txtPassword.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtPassword.IconRight = null;
            this.txtPassword.IconRightSize = new System.Drawing.Size(20, 20);
            this.txtPassword.Location = new System.Drawing.Point(85, 318);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(292, 54);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.AnimationBorder = true;
            this.txtUsername.AnimationColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtUsername.AnimationColor2 = System.Drawing.Color.LightSalmon;
            this.txtUsername.AnimationColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtUsername.AnimationColor4 = System.Drawing.Color.LightSalmon;
            this.txtUsername.AnimationColorGeneric = System.Drawing.Color.White;
            this.txtUsername.AnimationSpeed = 1;
            this.txtUsername.AnimUnfocus1 = System.Drawing.Color.Gray;
            this.txtUsername.AnimUnfocus2 = System.Drawing.Color.Gray;
            this.txtUsername.AnimUnfocus3 = System.Drawing.Color.Gray;
            this.txtUsername.AnimUnfocus4 = System.Drawing.Color.Gray;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUsername.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUsername.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtUsername.BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUsername.BorderColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtUsername.BorderFocus1 = System.Drawing.Color.OrangeRed;
            this.txtUsername.BorderFocus2 = System.Drawing.Color.Yellow;
            this.txtUsername.BorderFocus3 = System.Drawing.Color.Orange;
            this.txtUsername.BorderFocus4 = System.Drawing.Color.Gold;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.HotPink;
            this.txtUsername.BorderRadius = 7;
            this.txtUsername.BorderRadiusBottomLeft = 7;
            this.txtUsername.BorderRadiusBottomRight = 7;
            this.txtUsername.BorderRadiusTopLeft = 7;
            this.txtUsername.BorderRadiusTopRight = 7;
            this.txtUsername.BorderSize = 2;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.EnableGlow = false;
            this.txtUsername.FillColor = System.Drawing.Color.MintCream;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.GlowFocusOnly = true;
            this.txtUsername.GlowIntensity = 4;
            this.txtUsername.IconLeft = global::DVLDPL.Properties.Resources.profile_16111522__2_;
            this.txtUsername.IconLeftSize = new System.Drawing.Size(30, 30);
            this.txtUsername.IconRight = null;
            this.txtUsername.IconRightSize = new System.Drawing.Size(20, 20);
            this.txtUsername.Location = new System.Drawing.Point(85, 242);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(292, 54);
            this.txtUsername.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.AnimationSpeed = 2.5F;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnCancel.BackgroundGradientStartColor = System.Drawing.Color.White;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.BorderColor1 = System.Drawing.Color.Black;
            this.btnCancel.BorderColor2 = System.Drawing.Color.Black;
            this.btnCancel.BorderColor3 = System.Drawing.Color.Black;
            this.btnCancel.BorderColor4 = System.Drawing.Color.Black;
            this.btnCancel.BorderGradientAngle = 45F;
            this.btnCancel.BorderHoverColor1 = System.Drawing.Color.LightSalmon;
            this.btnCancel.BorderHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCancel.BorderHoverColor3 = System.Drawing.Color.LightSalmon;
            this.btnCancel.BorderHoverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.EnableBorderAnimation = true;
            this.btnCancel.EnableCustomHoverFont = false;
            this.btnCancel.EnableCustomHoverIconSize = false;
            this.btnCancel.EnableHoverEffects = true;
            this.btnCancel.EnablePulseEffect = true;
            this.btnCancel.EnableShadow = true;
            this.btnCancel.FocusColor1 = System.Drawing.Color.Orange;
            this.btnCancel.FocusColor2 = System.Drawing.Color.Red;
            this.btnCancel.FocusColor3 = System.Drawing.Color.Gold;
            this.btnCancel.FocusColor4 = System.Drawing.Color.DarkOrange;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.GeneralBorderColor = System.Drawing.Color.Black;
            this.btnCancel.GeneralBorderHoverColor = System.Drawing.Color.Gray;
            this.btnCancel.GeneralHoverRadius = 10;
            this.btnCancel.GeneralRadius = 10;
            this.btnCancel.GlowOpacity = 180;
            this.btnCancel.GlowSpread = 6;
            this.btnCancel.HoverBackgroundColor = System.Drawing.Color.White;
            this.btnCancel.HoverFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.HoverIconSize = new System.Drawing.Size(22, 22);
            this.btnCancel.HoverIconTintColor = System.Drawing.Color.DimGray;
            this.btnCancel.HoverRadiusBottomLeft = 5;
            this.btnCancel.HoverRadiusBottomRight = 10;
            this.btnCancel.HoverRadiusTopLeft = 10;
            this.btnCancel.HoverRadiusTopRight = 5;
            this.btnCancel.HoverTextColor = System.Drawing.Color.Black;
            this.btnCancel.IconSize = new System.Drawing.Size(25, 25);
            this.btnCancel.IconTintColor = System.Drawing.Color.Black;
            this.btnCancel.IdleColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.IdleColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancel.LeftIcon = global::DVLDPL.Properties.Resources.delete_47751;
            this.btnCancel.Location = new System.Drawing.Point(246, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadiusBottomLeft = 10;
            this.btnCancel.RadiusBottomRight = 10;
            this.btnCancel.RadiusTopLeft = 10;
            this.btnCancel.RadiusTopRight = 10;
            this.btnCancel.RightIcon = null;
            this.btnCancel.ShadowBlur = 1;
            this.btnCancel.ShadowColor = System.Drawing.Color.Silver;
            this.btnCancel.ShadowOffset = new System.Drawing.Point(1, 1);
            this.btnCancel.ShadowOnlyOnHover = false;
            this.btnCancel.ShowGlowOnFocus = false;
            this.btnCancel.ShowGlowOnIdle = true;
            this.btnCancel.Size = new System.Drawing.Size(131, 60);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Close";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.TextIconSpacing = 8;
            this.btnCancel.TintIcons = true;
            this.btnCancel.UseGradientBackground = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogin.AnimationSpeed = 2.5F;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLogin.BackgroundGradientStartColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.BorderColor1 = System.Drawing.Color.Black;
            this.btnLogin.BorderColor2 = System.Drawing.Color.Black;
            this.btnLogin.BorderColor3 = System.Drawing.Color.Black;
            this.btnLogin.BorderColor4 = System.Drawing.Color.Black;
            this.btnLogin.BorderGradientAngle = 45F;
            this.btnLogin.BorderHoverColor1 = System.Drawing.Color.LightSalmon;
            this.btnLogin.BorderHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogin.BorderHoverColor3 = System.Drawing.Color.LightSalmon;
            this.btnLogin.BorderHoverColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLogin.BorderThickness = 1;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.EnableBorderAnimation = true;
            this.btnLogin.EnableCustomHoverFont = false;
            this.btnLogin.EnableCustomHoverIconSize = false;
            this.btnLogin.EnableHoverEffects = true;
            this.btnLogin.EnablePulseEffect = true;
            this.btnLogin.EnableShadow = true;
            this.btnLogin.FocusColor1 = System.Drawing.Color.Orange;
            this.btnLogin.FocusColor2 = System.Drawing.Color.Red;
            this.btnLogin.FocusColor3 = System.Drawing.Color.Gold;
            this.btnLogin.FocusColor4 = System.Drawing.Color.DarkOrange;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.GeneralBorderColor = System.Drawing.Color.Black;
            this.btnLogin.GeneralBorderHoverColor = System.Drawing.Color.Gray;
            this.btnLogin.GeneralHoverRadius = 10;
            this.btnLogin.GeneralRadius = 10;
            this.btnLogin.GlowOpacity = 180;
            this.btnLogin.GlowSpread = 6;
            this.btnLogin.HoverBackgroundColor = System.Drawing.Color.White;
            this.btnLogin.HoverFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.HoverIconSize = new System.Drawing.Size(20, 20);
            this.btnLogin.HoverIconTintColor = System.Drawing.Color.DimGray;
            this.btnLogin.HoverRadiusBottomLeft = 5;
            this.btnLogin.HoverRadiusBottomRight = 10;
            this.btnLogin.HoverRadiusTopLeft = 10;
            this.btnLogin.HoverRadiusTopRight = 5;
            this.btnLogin.HoverTextColor = System.Drawing.Color.Black;
            this.btnLogin.IconSize = new System.Drawing.Size(25, 25);
            this.btnLogin.IconTintColor = System.Drawing.Color.Black;
            this.btnLogin.IdleColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnLogin.IdleColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnLogin.LeftIcon = global::DVLDPL.Properties.Resources.log_in;
            this.btnLogin.Location = new System.Drawing.Point(90, 453);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.RadiusBottomLeft = 10;
            this.btnLogin.RadiusBottomRight = 10;
            this.btnLogin.RadiusTopLeft = 10;
            this.btnLogin.RadiusTopRight = 10;
            this.btnLogin.RightIcon = null;
            this.btnLogin.ShadowBlur = 1;
            this.btnLogin.ShadowColor = System.Drawing.Color.Silver;
            this.btnLogin.ShadowOffset = new System.Drawing.Point(1, 1);
            this.btnLogin.ShadowOnlyOnHover = false;
            this.btnLogin.ShowGlowOnFocus = false;
            this.btnLogin.ShowGlowOnIdle = true;
            this.btnLogin.Size = new System.Drawing.Size(150, 60);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextColor = System.Drawing.Color.Black;
            this.btnLogin.TextIconSpacing = 0;
            this.btnLogin.TintIcons = true;
            this.btnLogin.UseGradientBackground = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 591);
            this.Controls.Add(this.modernPanel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(812, 489);
            this.Name = "frmLogin";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.modernPanel1.ResumeLayout(false);
            this.modernPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.ModernPanel modernPanel1;
        private ModernUI.Controls.ModernButton btnCancel;
        private ModernUIControls.ModernTextBoxPro txtPassword;
        private ModernUIControls.ModernTextBoxPro txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblPasswordWarning;
        private System.Windows.Forms.Label lblUsernameWarning;
        private System.Windows.Forms.Label lblWarning;
        private ModernUI.Controls.ModernButton btnLogin;
    }
}