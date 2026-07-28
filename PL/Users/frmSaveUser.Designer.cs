using DVLDPL;

namespace Users
{
    partial class frmSaveUser
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaveUser));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.modernPanel1 = new CustomControls.ModernPanel();
            this.cbIsAcive = new CustomControls.ModernComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new ModernUIControls.ModernTextBoxPro();
            this.lblSecondName = new System.Windows.Forms.Label();
            this.txtPersonID = new ModernUIControls.ModernTextBoxPro();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblUserIDValue = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblEditPersonInfo = new System.Windows.Forms.LinkLabel();
            this.lblSelectPerson = new System.Windows.Forms.LinkLabel();
            this.cmpImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSaveDontBackHome = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveBackToHome = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPassword = new ModernUIControls.ModernTextBoxPro();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.modernPanel1.SuspendLayout();
            this.cmpImage.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.pbTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(12);
            this.pnlHeader.Size = new System.Drawing.Size(614, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblTitle.Location = new System.Drawing.Point(81, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(124, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Save User";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.modernPanel1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16);
            this.pnlContent.Size = new System.Drawing.Size(614, 380);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // modernPanel1
            // 
            this.modernPanel1.AccentColor = System.Drawing.Color.MediumSlateBlue;
            this.modernPanel1.BackColor = System.Drawing.Color.White;
            this.modernPanel1.BadgeBackColor = System.Drawing.Color.Red;
            this.modernPanel1.BadgeForeColor = System.Drawing.Color.White;
            this.modernPanel1.BadgeValue = "";
            this.modernPanel1.BorderAnimationColor1 = System.Drawing.Color.Honeydew;
            this.modernPanel1.BorderAnimationColor2 = System.Drawing.Color.LavenderBlush;
            this.modernPanel1.BorderAnimationSpeed = 5;
            this.modernPanel1.BorderRadius = 15;
            this.modernPanel1.BorderSize = 4;
            this.modernPanel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.modernPanel1.Controls.Add(this.cbIsAcive);
            this.modernPanel1.Controls.Add(this.lblGender);
            this.modernPanel1.Controls.Add(this.txtPassword);
            this.modernPanel1.Controls.Add(this.lblPassword);
            this.modernPanel1.Controls.Add(this.txtUsername);
            this.modernPanel1.Controls.Add(this.lblSecondName);
            this.modernPanel1.Controls.Add(this.txtPersonID);
            this.modernPanel1.Controls.Add(this.lblFirstName);
            this.modernPanel1.Controls.Add(this.lblUserIDValue);
            this.modernPanel1.Controls.Add(this.lblUserID);
            this.modernPanel1.Controls.Add(this.lblEditPersonInfo);
            this.modernPanel1.Controls.Add(this.lblSelectPerson);
            this.modernPanel1.CornerRadiusBottomLeft = 15;
            this.modernPanel1.CornerRadiusBottomRight = 15;
            this.modernPanel1.CornerRadiusTopLeft = 15;
            this.modernPanel1.CornerRadiusTopRight = 15;
            this.modernPanel1.EnableBorderAnimation = true;
            this.modernPanel1.EnableGradientBackground = false;
            this.modernPanel1.GradientAngle = 90F;
            this.modernPanel1.GradientColor1 = System.Drawing.Color.White;
            this.modernPanel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.modernPanel1.Location = new System.Drawing.Point(19, 19);
            this.modernPanel1.Name = "modernPanel1";
            this.modernPanel1.Size = new System.Drawing.Size(564, 201);
            this.modernPanel1.TabIndex = 4;
            // 
            // cbIsAcive
            // 
            this.cbIsAcive.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cbIsAcive.BackColor = System.Drawing.Color.White;
            this.cbIsAcive.BorderColor = System.Drawing.Color.Silver;
            this.cbIsAcive.BorderRadius = 8;
            this.cbIsAcive.BorderWidth = 1;
            this.cbIsAcive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbIsAcive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsAcive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbIsAcive.FocusBorderColor = System.Drawing.Color.SlateGray;
            this.cbIsAcive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbIsAcive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.cbIsAcive.FormattingEnabled = true;
            this.cbIsAcive.ItemHeight = 20;
            this.cbIsAcive.Items.AddRange(new object[] {
            "Active",
            "Not Active"});
            this.cbIsAcive.ItemsBackgroundColor = System.Drawing.Color.White;
            this.cbIsAcive.ItemsHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(252)))));
            this.cbIsAcive.ItemsSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.cbIsAcive.Location = new System.Drawing.Point(264, 70);
            this.cbIsAcive.MaxDropDownItems = 10;
            this.cbIsAcive.Name = "cbIsAcive";
            this.cbIsAcive.Size = new System.Drawing.Size(132, 26);
            this.cbIsAcive.TabIndex = 17;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblGender.Location = new System.Drawing.Point(261, 52);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(60, 15);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "Is Active*";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblPassword.Location = new System.Drawing.Point(261, 128);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 15);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.AnimationBorder = true;
            this.txtUsername.AnimationColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.txtUsername.AnimationColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.txtUsername.AnimationColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.txtUsername.AnimationColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtUsername.AnimationColorGeneric = System.Drawing.Color.HotPink;
            this.txtUsername.AnimationSpeed = 20;
            this.txtUsername.AnimUnfocus1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtUsername.AnimUnfocus2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUsername.AnimUnfocus3 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtUsername.AnimUnfocus4 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.Silver;
            this.txtUsername.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUsername.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtUsername.BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUsername.BorderColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtUsername.BorderFocus1 = System.Drawing.Color.OrangeRed;
            this.txtUsername.BorderFocus2 = System.Drawing.Color.Yellow;
            this.txtUsername.BorderFocus3 = System.Drawing.Color.Orange;
            this.txtUsername.BorderFocus4 = System.Drawing.Color.Gold;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.SlateGray;
            this.txtUsername.BorderRadius = 8;
            this.txtUsername.BorderRadiusBottomLeft = 8;
            this.txtUsername.BorderRadiusBottomRight = 8;
            this.txtUsername.BorderRadiusTopLeft = 8;
            this.txtUsername.BorderRadiusTopRight = 8;
            this.txtUsername.BorderSize = 1;
            this.txtUsername.EnableGlow = false;
            this.txtUsername.FillColor = System.Drawing.Color.White;
            this.txtUsername.GlowFocusOnly = true;
            this.txtUsername.GlowIntensity = 4;
            this.txtUsername.IconLeft = null;
            this.txtUsername.IconLeftSize = new System.Drawing.Size(20, 20);
            this.txtUsername.IconRight = null;
            this.txtUsername.IconRightSize = new System.Drawing.Size(20, 20);
            this.txtUsername.Location = new System.Drawing.Point(77, 145);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.Size = new System.Drawing.Size(132, 31);
            this.txtUsername.TabIndex = 14;
            // 
            // lblSecondName
            // 
            this.lblSecondName.AutoSize = true;
            this.lblSecondName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblSecondName.Location = new System.Drawing.Point(77, 128);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(64, 15);
            this.lblSecondName.TabIndex = 4;
            this.lblSecondName.Text = "Username";
            // 
            // txtPersonID
            // 
            this.txtPersonID.AnimationBorder = true;
            this.txtPersonID.AnimationColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.txtPersonID.AnimationColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.txtPersonID.AnimationColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.txtPersonID.AnimationColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPersonID.AnimationColorGeneric = System.Drawing.Color.HotPink;
            this.txtPersonID.AnimationSpeed = 20;
            this.txtPersonID.AnimUnfocus1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPersonID.AnimUnfocus2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPersonID.AnimUnfocus3 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPersonID.AnimUnfocus4 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPersonID.BackColor = System.Drawing.Color.Transparent;
            this.txtPersonID.BorderColor = System.Drawing.Color.Silver;
            this.txtPersonID.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPersonID.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPersonID.BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPersonID.BorderColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPersonID.BorderFocus1 = System.Drawing.Color.OrangeRed;
            this.txtPersonID.BorderFocus2 = System.Drawing.Color.Yellow;
            this.txtPersonID.BorderFocus3 = System.Drawing.Color.Orange;
            this.txtPersonID.BorderFocus4 = System.Drawing.Color.Gold;
            this.txtPersonID.BorderFocusColor = System.Drawing.Color.SlateGray;
            this.txtPersonID.BorderRadius = 8;
            this.txtPersonID.BorderRadiusBottomLeft = 8;
            this.txtPersonID.BorderRadiusBottomRight = 8;
            this.txtPersonID.BorderRadiusTopLeft = 8;
            this.txtPersonID.BorderRadiusTopRight = 8;
            this.txtPersonID.BorderSize = 1;
            this.txtPersonID.Enabled = false;
            this.txtPersonID.EnableGlow = false;
            this.txtPersonID.FillColor = System.Drawing.Color.White;
            this.txtPersonID.GlowFocusOnly = true;
            this.txtPersonID.GlowIntensity = 4;
            this.txtPersonID.IconLeft = null;
            this.txtPersonID.IconLeftSize = new System.Drawing.Size(20, 20);
            this.txtPersonID.IconRight = null;
            this.txtPersonID.IconRightSize = new System.Drawing.Size(20, 20);
            this.txtPersonID.Location = new System.Drawing.Point(77, 68);
            this.txtPersonID.Name = "txtPersonID";
            this.txtPersonID.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPersonID.PlaceholderText = "";
            this.txtPersonID.Size = new System.Drawing.Size(132, 31);
            this.txtPersonID.TabIndex = 13;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblFirstName.Location = new System.Drawing.Point(77, 51);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(61, 15);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Person ID";
            // 
            // lblUserIDValue
            // 
            this.lblUserIDValue.AutoSize = true;
            this.lblUserIDValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserIDValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblUserIDValue.Location = new System.Drawing.Point(79, 14);
            this.lblUserIDValue.Name = "lblUserIDValue";
            this.lblUserIDValue.Size = new System.Drawing.Size(33, 19);
            this.lblUserIDValue.TabIndex = 1;
            this.lblUserIDValue.Text = "N/A";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblUserID.Location = new System.Drawing.Point(10, 14);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(61, 19);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "User ID:";
            // 
            // lblEditPersonInfo
            // 
            this.lblEditPersonInfo.AutoSize = true;
            this.lblEditPersonInfo.DisabledLinkColor = System.Drawing.Color.Silver;
            this.lblEditPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonInfo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEditPersonInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lblEditPersonInfo.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblEditPersonInfo.Location = new System.Drawing.Point(141, 48);
            this.lblEditPersonInfo.Name = "lblEditPersonInfo";
            this.lblEditPersonInfo.Size = new System.Drawing.Size(96, 15);
            this.lblEditPersonInfo.TabIndex = 16;
            this.lblEditPersonInfo.TabStop = true;
            this.lblEditPersonInfo.Text = "Edit Person Info.";
            this.lblEditPersonInfo.VisitedLinkColor = System.Drawing.Color.DarkGray;
            this.lblEditPersonInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectAnotherPerson_LinkClicked);
            // 
            // lblSelectPerson
            // 
            this.lblSelectPerson.AutoSize = true;
            this.lblSelectPerson.DisabledLinkColor = System.Drawing.Color.Silver;
            this.lblSelectPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectPerson.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSelectPerson.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lblSelectPerson.LinkColor = System.Drawing.Color.SteelBlue;
            this.lblSelectPerson.Location = new System.Drawing.Point(80, 100);
            this.lblSelectPerson.Name = "lblSelectPerson";
            this.lblSelectPerson.Size = new System.Drawing.Size(128, 15);
            this.lblSelectPerson.TabIndex = 18;
            this.lblSelectPerson.TabStop = true;
            this.lblSelectPerson.Text = "Select another Person";
            this.lblSelectPerson.VisitedLinkColor = System.Drawing.Color.DarkGray;
            this.lblSelectPerson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSelectPerson_LinkClicked);
            // 
            // cmpImage
            // 
            this.cmpImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setImageToolStripMenuItem,
            this.removeImageToolStripMenuItem});
            this.cmpImage.Name = "cmpImage";
            this.cmpImage.Size = new System.Drawing.Size(166, 48);
            // 
            // setImageToolStripMenuItem
            // 
            this.setImageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setImageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(118)))), ((int)(((byte)(232)))));
            this.setImageToolStripMenuItem.Name = "setImageToolStripMenuItem";
            this.setImageToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.setImageToolStripMenuItem.Text = "Set image";
            this.setImageToolStripMenuItem.Click += new System.EventHandler(this.setImageToolStripMenuItem_Click);
            // 
            // removeImageToolStripMenuItem
            // 
            this.removeImageToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeImageToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.removeImageToolStripMenuItem.Name = "removeImageToolStripMenuItem";
            this.removeImageToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.removeImageToolStripMenuItem.Text = "Remove image";
            this.removeImageToolStripMenuItem.Click += new System.EventHandler(this.removeImageToolStripMenuItem_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnSaveDontBackHome);
            this.pnlButtons.Controls.Add(this.lblWarning);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSaveBackToHome);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 444);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(16);
            this.pnlButtons.Size = new System.Drawing.Size(614, 64);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnSaveDontBackHome
            // 
            this.btnSaveDontBackHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDontBackHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnSaveDontBackHome.FlatAppearance.BorderSize = 0;
            this.btnSaveDontBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDontBackHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveDontBackHome.ForeColor = System.Drawing.Color.White;
            this.btnSaveDontBackHome.Location = new System.Drawing.Point(170, 14);
            this.btnSaveDontBackHome.Name = "btnSaveDontBackHome";
            this.btnSaveDontBackHome.Size = new System.Drawing.Size(202, 36);
            this.btnSaveDontBackHome.TabIndex = 15;
            this.btnSaveDontBackHome.Text = "Save and don\'t back home";
            this.btnSaveDontBackHome.UseVisualStyleBackColor = false;
            this.btnSaveDontBackHome.Click += new System.EventHandler(this.btnSaveDontBackHome_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblWarning.Location = new System.Drawing.Point(16, 20);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 15);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(44, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSaveBackToHome
            // 
            this.btnSaveBackToHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveBackToHome.BackColor = System.Drawing.Color.Green;
            this.btnSaveBackToHome.FlatAppearance.BorderSize = 0;
            this.btnSaveBackToHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBackToHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveBackToHome.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnSaveBackToHome.Location = new System.Drawing.Point(378, 14);
            this.btnSaveBackToHome.Name = "btnSaveBackToHome";
            this.btnSaveBackToHome.Size = new System.Drawing.Size(220, 36);
            this.btnSaveBackToHome.TabIndex = 14;
            this.btnSaveBackToHome.Text = "Save and back to home";
            this.btnSaveBackToHome.UseVisualStyleBackColor = false;
            this.btnSaveBackToHome.Click += new System.EventHandler(this.btnSaveBackToHome_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimationBorder = true;
            this.txtPassword.AnimationColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(0)))));
            this.txtPassword.AnimationColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(0)))));
            this.txtPassword.AnimationColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.txtPassword.AnimationColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPassword.AnimationColorGeneric = System.Drawing.Color.HotPink;
            this.txtPassword.AnimationSpeed = 20;
            this.txtPassword.AnimUnfocus1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPassword.AnimUnfocus2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.AnimUnfocus3 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtPassword.AnimUnfocus4 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtPassword.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPassword.BorderColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderFocus1 = System.Drawing.Color.OrangeRed;
            this.txtPassword.BorderFocus2 = System.Drawing.Color.Yellow;
            this.txtPassword.BorderFocus3 = System.Drawing.Color.Orange;
            this.txtPassword.BorderFocus4 = System.Drawing.Color.Gold;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.SlateGray;
            this.txtPassword.BorderRadius = 8;
            this.txtPassword.BorderRadiusBottomLeft = 8;
            this.txtPassword.BorderRadiusBottomRight = 8;
            this.txtPassword.BorderRadiusTopLeft = 8;
            this.txtPassword.BorderRadiusTopRight = 8;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.EnableGlow = false;
            this.txtPassword.FillColor = System.Drawing.Color.White;
            this.txtPassword.GlowFocusOnly = true;
            this.txtPassword.GlowIntensity = 4;
            this.txtPassword.IconLeft = null;
            this.txtPassword.IconLeftSize = new System.Drawing.Size(20, 20);
            this.txtPassword.IconRight = null;
            this.txtPassword.IconRightSize = new System.Drawing.Size(20, 20);
            this.txtPassword.Location = new System.Drawing.Point(264, 145);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPassword.PlaceholderText = "";
            this.txtPassword.Size = new System.Drawing.Size(132, 31);
            this.txtPassword.TabIndex = 15;
            // 
            // pbTitle
            // 
            this.pbTitle.Location = new System.Drawing.Point(30, 6);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(51, 50);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitle.TabIndex = 3;
            this.pbTitle.TabStop = false;
            // 
            // frmSaveUser
            // 
            this.AcceptButton = this.btnSaveBackToHome;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(614, 508);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(630, 375);
            this.Name = "frmSaveUser";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Person";
            this.Load += new System.EventHandler(this.frmSaveUser_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.modernPanel1.ResumeLayout(false);
            this.modernPanel1.PerformLayout();
            this.cmpImage.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblSecondName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveBackToHome;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Label lblUserIDValue;
        private System.Windows.Forms.Button btnSaveDontBackHome;
        private System.Windows.Forms.ContextMenuStrip cmpImage;
        private System.Windows.Forms.ToolStripMenuItem setImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeImageToolStripMenuItem;
        private ModernUIControls.ModernTextBoxPro txtPersonID;
        private ModernUIControls.ModernTextBoxPro txtPassword;
        private ModernUIControls.ModernTextBoxPro txtUsername;
        private System.Windows.Forms.LinkLabel lblEditPersonInfo;
        private CustomControls.ModernComboBox cbIsAcive;
        private CustomControls.ModernPanel modernPanel1;
        private System.Windows.Forms.LinkLabel lblSelectPerson;
    }
}