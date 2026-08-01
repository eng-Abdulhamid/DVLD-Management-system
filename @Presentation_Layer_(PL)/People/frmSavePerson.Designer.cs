using DVLDPL.Properties;

namespace DVLDPL
{
    partial class frmSavePerson
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlPhoto = new System.Windows.Forms.Panel();
            this.pbPersonalImage = new System.Windows.Forms.PictureBox();
            this.cmpImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.llblRemoveImage = new System.Windows.Forms.LinkLabel();
            this.llblSetImage = new System.Windows.Forms.LinkLabel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblPersonIDValue = new System.Windows.Forms.Label();
            this.lblPersonID = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblSecondName = new System.Windows.Forms.Label();
            this.txtSecondName = new System.Windows.Forms.TextBox();
            this.lblThirdName = new System.Windows.Forms.Label();
            this.txtThirdName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.txtNationalNo = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cbCountriesList = new CustomControls.ModernComboBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnSaveDontBackHome = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveBackToHome = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalImage)).BeginInit();
            this.cmpImage.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(900, 64);
            this.pnlHeader.TabIndex = 0;
            // 
            // pbTitle
            // 
            this.pbTitle.Location = new System.Drawing.Point(32, 6);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(51, 50);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitle.TabIndex = 3;
            this.pbTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblTitle.Location = new System.Drawing.Point(81, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Save Person";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlPhoto);
            this.pnlContent.Controls.Add(this.pnlForm);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(16);
            this.pnlContent.Size = new System.Drawing.Size(900, 592);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // pnlPhoto
            // 
            this.pnlPhoto.BackColor = System.Drawing.Color.White;
            this.pnlPhoto.Controls.Add(this.pbPersonalImage);
            this.pnlPhoto.Controls.Add(this.llblRemoveImage);
            this.pnlPhoto.Controls.Add(this.llblSetImage);
            this.pnlPhoto.Location = new System.Drawing.Point(680, 16);
            this.pnlPhoto.Name = "pnlPhoto";
            this.pnlPhoto.Padding = new System.Windows.Forms.Padding(12);
            this.pnlPhoto.Size = new System.Drawing.Size(204, 270);
            this.pnlPhoto.TabIndex = 2;
            // 
            // pbPersonalImage
            // 
            this.pbPersonalImage.ContextMenuStrip = this.cmpImage;
            this.pbPersonalImage.Location = new System.Drawing.Point(12, 12);
            this.pbPersonalImage.Name = "pbPersonalImage";
            this.pbPersonalImage.Size = new System.Drawing.Size(180, 220);
            this.pbPersonalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonalImage.TabIndex = 0;
            this.pbPersonalImage.TabStop = false;
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
            // llblRemoveImage
            // 
            this.llblRemoveImage.AutoSize = true;
            this.llblRemoveImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llblRemoveImage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.llblRemoveImage.Location = new System.Drawing.Point(106, 245);
            this.llblRemoveImage.Name = "llblRemoveImage";
            this.llblRemoveImage.Size = new System.Drawing.Size(86, 15);
            this.llblRemoveImage.TabIndex = 13;
            this.llblRemoveImage.TabStop = true;
            this.llblRemoveImage.Text = "Remove Image";
            // 
            // llblSetImage
            // 
            this.llblSetImage.AutoSize = true;
            this.llblSetImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.llblSetImage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(118)))), ((int)(((byte)(232)))));
            this.llblSetImage.Location = new System.Drawing.Point(9, 245);
            this.llblSetImage.Name = "llblSetImage";
            this.llblSetImage.Size = new System.Drawing.Size(59, 15);
            this.llblSetImage.TabIndex = 12;
            this.llblSetImage.TabStop = true;
            this.llblSetImage.Text = "Set Image";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblPersonIDValue);
            this.pnlForm.Controls.Add(this.lblPersonID);
            this.pnlForm.Controls.Add(this.lblFirstName);
            this.pnlForm.Controls.Add(this.txtFirstName);
            this.pnlForm.Controls.Add(this.lblSecondName);
            this.pnlForm.Controls.Add(this.txtSecondName);
            this.pnlForm.Controls.Add(this.lblThirdName);
            this.pnlForm.Controls.Add(this.txtThirdName);
            this.pnlForm.Controls.Add(this.lblLastName);
            this.pnlForm.Controls.Add(this.txtLastName);
            this.pnlForm.Controls.Add(this.lblNationalNo);
            this.pnlForm.Controls.Add(this.txtNationalNo);
            this.pnlForm.Controls.Add(this.lblGender);
            this.pnlForm.Controls.Add(this.rbMale);
            this.pnlForm.Controls.Add(this.rbFemale);
            this.pnlForm.Controls.Add(this.lblDateOfBirth);
            this.pnlForm.Controls.Add(this.dtpDateOfBirth);
            this.pnlForm.Controls.Add(this.lblAddress);
            this.pnlForm.Controls.Add(this.txtAddress);
            this.pnlForm.Controls.Add(this.lblPhone);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblCountry);
            this.pnlForm.Controls.Add(this.cbCountriesList);
            this.pnlForm.Location = new System.Drawing.Point(16, 16);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(16);
            this.pnlForm.Size = new System.Drawing.Size(658, 323);
            this.pnlForm.TabIndex = 3;
            // 
            // lblPersonIDValue
            // 
            this.lblPersonIDValue.AutoSize = true;
            this.lblPersonIDValue.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPersonIDValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPersonIDValue.Location = new System.Drawing.Point(95, 16);
            this.lblPersonIDValue.Name = "lblPersonIDValue";
            this.lblPersonIDValue.Size = new System.Drawing.Size(33, 19);
            this.lblPersonIDValue.TabIndex = 1;
            this.lblPersonIDValue.Text = "N/A";
            // 
            // lblPersonID
            // 
            this.lblPersonID.AutoSize = true;
            this.lblPersonID.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPersonID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblPersonID.Location = new System.Drawing.Point(16, 16);
            this.lblPersonID.Name = "lblPersonID";
            this.lblPersonID.Size = new System.Drawing.Size(77, 19);
            this.lblPersonID.TabIndex = 0;
            this.lblPersonID.Text = "Person ID:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblFirstName.Location = new System.Drawing.Point(16, 54);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 15);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "First Name *";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtFirstName.Location = new System.Drawing.Point(16, 72);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(140, 23);
            this.txtFirstName.TabIndex = 0;
            // 
            // lblSecondName
            // 
            this.lblSecondName.AutoSize = true;
            this.lblSecondName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblSecondName.Location = new System.Drawing.Point(171, 54);
            this.lblSecondName.Name = "lblSecondName";
            this.lblSecondName.Size = new System.Drawing.Size(92, 15);
            this.lblSecondName.TabIndex = 4;
            this.lblSecondName.Text = "Second Name *";
            // 
            // txtSecondName
            // 
            this.txtSecondName.BackColor = System.Drawing.Color.White;
            this.txtSecondName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSecondName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtSecondName.Location = new System.Drawing.Point(171, 72);
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Size = new System.Drawing.Size(140, 23);
            this.txtSecondName.TabIndex = 1;
            // 
            // lblThirdName
            // 
            this.lblThirdName.AutoSize = true;
            this.lblThirdName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThirdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblThirdName.Location = new System.Drawing.Point(326, 54);
            this.lblThirdName.Name = "lblThirdName";
            this.lblThirdName.Size = new System.Drawing.Size(72, 15);
            this.lblThirdName.TabIndex = 6;
            this.lblThirdName.Text = "Third Name";
            // 
            // txtThirdName
            // 
            this.txtThirdName.BackColor = System.Drawing.Color.White;
            this.txtThirdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThirdName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtThirdName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtThirdName.Location = new System.Drawing.Point(326, 72);
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Size = new System.Drawing.Size(140, 23);
            this.txtThirdName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblLastName.Location = new System.Drawing.Point(481, 54);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(73, 15);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "Last Name *";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.White;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtLastName.Location = new System.Drawing.Point(481, 72);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(161, 23);
            this.txtLastName.TabIndex = 3;
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblNationalNo.Location = new System.Drawing.Point(16, 109);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(83, 15);
            this.lblNationalNo.TabIndex = 10;
            this.lblNationalNo.Text = "National No. *";
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.BackColor = System.Drawing.Color.White;
            this.txtNationalNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNationalNo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtNationalNo.Location = new System.Drawing.Point(16, 127);
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Size = new System.Drawing.Size(200, 23);
            this.txtNationalNo.TabIndex = 4;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblGender.Location = new System.Drawing.Point(238, 109);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(57, 15);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "Gender *";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.rbMale.Location = new System.Drawing.Point(240, 127);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(51, 19);
            this.rbMale.TabIndex = 5;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.rbFemale.Location = new System.Drawing.Point(314, 127);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(63, 19);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblDateOfBirth.Location = new System.Drawing.Point(389, 109);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(88, 15);
            this.lblDateOfBirth.TabIndex = 15;
            this.lblDateOfBirth.Text = "Date of Birth *";
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(392, 127);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(250, 23);
            this.dtpDateOfBirth.TabIndex = 7;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblAddress.Location = new System.Drawing.Point(16, 164);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 15);
            this.lblAddress.TabIndex = 17;
            this.lblAddress.Text = "Address *";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtAddress.Location = new System.Drawing.Point(16, 182);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(626, 50);
            this.txtAddress.TabIndex = 8;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblPhone.Location = new System.Drawing.Point(16, 245);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(50, 15);
            this.lblPhone.TabIndex = 19;
            this.lblPhone.Text = "Phone *";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtPhone.Location = new System.Drawing.Point(16, 263);
            this.txtPhone.MaxLength = 16;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(128, 23);
            this.txtPhone.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblEmail.Location = new System.Drawing.Point(178, 245);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 15);
            this.lblEmail.TabIndex = 21;
            this.lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.txtEmail.Location = new System.Drawing.Point(178, 263);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(189, 23);
            this.txtEmail.TabIndex = 10;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCountry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.lblCountry.Location = new System.Drawing.Point(392, 245);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(59, 15);
            this.lblCountry.TabIndex = 23;
            this.lblCountry.Text = "Country *";
            // 
            // cbCountriesList
            // 
            this.cbCountriesList.AccentColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(118)))), ((int)(((byte)(232)))));
            this.cbCountriesList.BackColor = System.Drawing.Color.White;
            this.cbCountriesList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(118)))), ((int)(((byte)(232)))));
            this.cbCountriesList.BorderRadius = 6;
            this.cbCountriesList.BorderWidth = 2;
            this.cbCountriesList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbCountriesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountriesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCountriesList.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.cbCountriesList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCountriesList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(47)))), ((int)(((byte)(62)))));
            this.cbCountriesList.FormattingEnabled = true;
            this.cbCountriesList.ItemHeight = 30;
            this.cbCountriesList.ItemsBackgroundColor = System.Drawing.Color.White;
            this.cbCountriesList.ItemsHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.cbCountriesList.ItemsSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.cbCountriesList.Location = new System.Drawing.Point(392, 263);
            this.cbCountriesList.MaxDropDownItems = 10;
            this.cbCountriesList.Name = "cbCountriesList";
            this.cbCountriesList.Size = new System.Drawing.Size(250, 36);
            this.cbCountriesList.TabIndex = 11;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnSaveDontBackHome);
            this.pnlButtons.Controls.Add(this.lblWarning);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSaveBackToHome);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 656);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(16);
            this.pnlButtons.Size = new System.Drawing.Size(900, 64);
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
            this.btnSaveDontBackHome.Location = new System.Drawing.Point(456, 14);
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
            this.btnCancel.Location = new System.Drawing.Point(330, 14);
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
            this.btnSaveBackToHome.Location = new System.Drawing.Point(664, 14);
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
            // frmSavePerson
            // 
            this.AcceptButton = this.btnSaveBackToHome;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(900, 720);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(916, 759);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(916, 759);
            this.Name = "frmSavePerson";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Save Person";
            this.Load += new System.EventHandler(this.frmSavePerson_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlPhoto.ResumeLayout(false);
            this.pnlPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonalImage)).EndInit();
            this.cmpImage.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlPhoto;
        private System.Windows.Forms.PictureBox pbPersonalImage;
        private System.Windows.Forms.LinkLabel llblRemoveImage;
        private System.Windows.Forms.LinkLabel llblSetImage;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblPersonID;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblSecondName;
        private System.Windows.Forms.TextBox txtSecondName;
        private System.Windows.Forms.Label lblThirdName;
        private System.Windows.Forms.TextBox txtThirdName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.TextBox txtNationalNo;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCountry;
        private CustomControls.ModernComboBox cbCountriesList;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveBackToHome;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Label lblPersonIDValue;
        private System.Windows.Forms.Button btnSaveDontBackHome;
        private System.Windows.Forms.ContextMenuStrip cmpImage;
        private System.Windows.Forms.ToolStripMenuItem setImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeImageToolStripMenuItem;
    }
}