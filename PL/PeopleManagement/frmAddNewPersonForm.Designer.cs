namespace DVLDPL.PeopleManagement
{
    partial class frmAddNewPersonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            this.txtPersonID = new NControls.NTextBox();
            this.txtNationalNo = new NControls.NTextBox();
            this.txtFirstName = new NControls.NTextBox();
            this.txtSecondName = new NControls.NTextBox();
            this.txtThirdName = new NControls.NTextBox();
            this.txtLastName = new NControls.NTextBox();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new NControls.NTextBox();
            this.txtEmail = new NControls.NTextBox();
            this.lbllall = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.epValidation = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblUploadNewPicutre = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.picPersonImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPersonID
            // 
            this.txtPersonID.BackColor = System.Drawing.Color.Transparent;
            this.txtPersonID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtPersonID.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtPersonID.BorderRadius = 16;
            this.txtPersonID.BorderSize = 1;
            this.txtPersonID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPersonID.Enabled = false;
            this.txtPersonID.EnableSuggest = true;
            this.txtPersonID.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.txtPersonID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPersonID.IconOffsetLeft = 10;
            this.txtPersonID.IconOffsetRight = 10;
            this.txtPersonID.IconSpacing = 10;
            this.txtPersonID.Location = new System.Drawing.Point(180, 45);
            this.txtPersonID.MaxSuggestItems = 4;
            this.txtPersonID.Name = "txtPersonID";
            this.txtPersonID.Padding = new System.Windows.Forms.Padding(8);
            this.txtPersonID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPersonID.PlaceholderText = "Person ID";
            this.txtPersonID.ShowClearButton = true;
            this.txtPersonID.Size = new System.Drawing.Size(285, 38);
            this.txtPersonID.SuggestIcon = null;
            this.txtPersonID.SuggestList = new string[0];
            this.txtPersonID.TabIndex = 36;
            this.txtPersonID.UseSystemPasswordChar = false;
            // 
            // txtNationalNo
            // 
            this.txtNationalNo.BackColor = System.Drawing.Color.Transparent;
            this.txtNationalNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtNationalNo.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtNationalNo.BorderRadius = 16;
            this.txtNationalNo.BorderSize = 1;
            this.txtNationalNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationalNo.EnableSuggest = true;
            this.txtNationalNo.FillColor = System.Drawing.Color.White;
            this.txtNationalNo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNationalNo.IconOffsetLeft = 10;
            this.txtNationalNo.IconOffsetRight = 10;
            this.txtNationalNo.IconSpacing = 10;
            this.txtNationalNo.Location = new System.Drawing.Point(495, 45);
            this.txtNationalNo.MaxSuggestItems = 4;
            this.txtNationalNo.Name = "txtNationalNo";
            this.txtNationalNo.Padding = new System.Windows.Forms.Padding(8);
            this.txtNationalNo.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNationalNo.PlaceholderText = "National no.";
            this.txtNationalNo.ShowClearButton = true;
            this.txtNationalNo.Size = new System.Drawing.Size(290, 38);
            this.txtNationalNo.SuggestIcon = null;
            this.txtNationalNo.SuggestList = new string[0];
            this.txtNationalNo.TabIndex = 1;
            this.txtNationalNo.UseSystemPasswordChar = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtFirstName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtFirstName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtFirstName.BorderRadius = 16;
            this.txtFirstName.BorderSize = 1;
            this.txtFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFirstName.EnableSuggest = true;
            this.txtFirstName.FillColor = System.Drawing.Color.White;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFirstName.IconOffsetLeft = 10;
            this.txtFirstName.IconOffsetRight = 10;
            this.txtFirstName.IconSpacing = 10;
            this.txtFirstName.Location = new System.Drawing.Point(35, 209);
            this.txtFirstName.MaxSuggestItems = 4;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Padding = new System.Windows.Forms.Padding(8);
            this.txtFirstName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFirstName.PlaceholderText = "First name";
            this.txtFirstName.ShowClearButton = true;
            this.txtFirstName.Size = new System.Drawing.Size(172, 38);
            this.txtFirstName.SuggestIcon = null;
            this.txtFirstName.SuggestList = new string[0];
            this.txtFirstName.TabIndex = 2;
            this.txtFirstName.UseSystemPasswordChar = false;
            // 
            // txtSecondName
            // 
            this.txtSecondName.BackColor = System.Drawing.Color.Transparent;
            this.txtSecondName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtSecondName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtSecondName.BorderRadius = 16;
            this.txtSecondName.BorderSize = 1;
            this.txtSecondName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecondName.EnableSuggest = true;
            this.txtSecondName.FillColor = System.Drawing.Color.White;
            this.txtSecondName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSecondName.IconOffsetLeft = 10;
            this.txtSecondName.IconOffsetRight = 10;
            this.txtSecondName.IconSpacing = 10;
            this.txtSecondName.Location = new System.Drawing.Point(227, 209);
            this.txtSecondName.MaxSuggestItems = 4;
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Padding = new System.Windows.Forms.Padding(8);
            this.txtSecondName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSecondName.PlaceholderText = "Second name";
            this.txtSecondName.ShowClearButton = true;
            this.txtSecondName.Size = new System.Drawing.Size(172, 38);
            this.txtSecondName.SuggestIcon = null;
            this.txtSecondName.SuggestList = new string[0];
            this.txtSecondName.TabIndex = 3;
            this.txtSecondName.UseSystemPasswordChar = false;
            // 
            // txtThirdName
            // 
            this.txtThirdName.BackColor = System.Drawing.Color.Transparent;
            this.txtThirdName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtThirdName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtThirdName.BorderRadius = 16;
            this.txtThirdName.BorderSize = 1;
            this.txtThirdName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThirdName.EnableSuggest = true;
            this.txtThirdName.FillColor = System.Drawing.Color.White;
            this.txtThirdName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtThirdName.IconOffsetLeft = 10;
            this.txtThirdName.IconOffsetRight = 10;
            this.txtThirdName.IconSpacing = 10;
            this.txtThirdName.Location = new System.Drawing.Point(419, 209);
            this.txtThirdName.MaxSuggestItems = 4;
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Padding = new System.Windows.Forms.Padding(8);
            this.txtThirdName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtThirdName.PlaceholderText = "Third name";
            this.txtThirdName.ShowClearButton = true;
            this.txtThirdName.Size = new System.Drawing.Size(172, 38);
            this.txtThirdName.SuggestIcon = null;
            this.txtThirdName.SuggestList = new string[0];
            this.txtThirdName.TabIndex = 4;
            this.txtThirdName.UseSystemPasswordChar = false;
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtLastName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtLastName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtLastName.BorderRadius = 16;
            this.txtLastName.BorderSize = 1;
            this.txtLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLastName.EnableSuggest = true;
            this.txtLastName.FillColor = System.Drawing.Color.White;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLastName.IconOffsetLeft = 10;
            this.txtLastName.IconOffsetRight = 10;
            this.txtLastName.IconSpacing = 10;
            this.txtLastName.Location = new System.Drawing.Point(611, 209);
            this.txtLastName.MaxSuggestItems = 4;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Padding = new System.Windows.Forms.Padding(8);
            this.txtLastName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLastName.PlaceholderText = "Last name";
            this.txtLastName.ShowClearButton = true;
            this.txtLastName.Size = new System.Drawing.Size(174, 38);
            this.txtLastName.SuggestIcon = null;
            this.txtLastName.SuggestList = new string[0];
            this.txtLastName.TabIndex = 5;
            this.txtLastName.UseSystemPasswordChar = false;
            // 
            // cmbNationality
            // 
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(292, 286);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(236, 25);
            this.cmbNationality.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label1.Location = new System.Drawing.Point(292, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nationality";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.Transparent;
            this.txtPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtPhone.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtPhone.BorderRadius = 16;
            this.txtPhone.BorderSize = 1;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.EnableSuggest = true;
            this.txtPhone.FillColor = System.Drawing.Color.White;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.IconOffsetLeft = 10;
            this.txtPhone.IconOffsetRight = 10;
            this.txtPhone.IconSpacing = 10;
            this.txtPhone.Location = new System.Drawing.Point(495, 117);
            this.txtPhone.MaxSuggestItems = 4;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Padding = new System.Windows.Forms.Padding(8);
            this.txtPhone.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPhone.PlaceholderText = "Phone";
            this.txtPhone.ShowClearButton = true;
            this.txtPhone.Size = new System.Drawing.Size(290, 38);
            this.txtPhone.SuggestIcon = null;
            this.txtPhone.SuggestList = new string[0];
            this.txtPhone.TabIndex = 9;
            this.txtPhone.UseSystemPasswordChar = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtEmail.BorderRadius = 16;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.EnableSuggest = true;
            this.txtEmail.FillColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.IconOffsetLeft = 10;
            this.txtEmail.IconOffsetRight = 10;
            this.txtEmail.IconSpacing = 10;
            this.txtEmail.Location = new System.Drawing.Point(180, 117);
            this.txtEmail.MaxSuggestItems = 4;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Padding = new System.Windows.Forms.Padding(8);
            this.txtEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.ShowClearButton = true;
            this.txtEmail.Size = new System.Drawing.Size(285, 38);
            this.txtEmail.SuggestIcon = null;
            this.txtEmail.SuggestList = new string[0];
            this.txtEmail.TabIndex = 10;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // lbllall
            // 
            this.lbllall.AutoSize = true;
            this.lbllall.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lbllall.Location = new System.Drawing.Point(549, 270);
            this.lbllall.Name = "lbllall";
            this.lbllall.Size = new System.Drawing.Size(45, 15);
            this.lbllall.TabIndex = 51;
            this.lbllall.Text = "Gender";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(549, 286);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(236, 25);
            this.cmbGender.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(485, 365);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(145, 42);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Submit";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(35, 286);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(236, 25);
            this.dtpBirthDate.TabIndex = 53;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnCancel.Location = new System.Drawing.Point(640, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 42);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label2.Location = new System.Drawing.Point(35, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 55;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label3.Location = new System.Drawing.Point(227, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 56;
            this.label3.Text = "Second Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label4.Location = new System.Drawing.Point(419, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 57;
            this.label4.Text = "Third Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label5.Location = new System.Drawing.Point(611, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label6.Location = new System.Drawing.Point(495, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 59;
            this.label6.Text = "National Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label7.Location = new System.Drawing.Point(180, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 60;
            this.label7.Text = "Person ID";
            // 
            // lblUploadNewPicutre
            // 
            this.lblUploadNewPicutre.AutoSize = true;
            this.lblUploadNewPicutre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadNewPicutre.LinkColor = System.Drawing.Color.Blue;
            this.lblUploadNewPicutre.Location = new System.Drawing.Point(35, 158);
            this.lblUploadNewPicutre.Name = "lblUploadNewPicutre";
            this.lblUploadNewPicutre.Size = new System.Drawing.Size(126, 17);
            this.lblUploadNewPicutre.TabIndex = 61;
            this.lblUploadNewPicutre.TabStop = true;
            this.lblUploadNewPicutre.Text = "Upload new picture";
            this.lblUploadNewPicutre.VisitedLinkColor = System.Drawing.Color.Black;
            this.lblUploadNewPicutre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUploadNewPicutre_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label8.Location = new System.Drawing.Point(32, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 62;
            this.label8.Text = "Date of Birth";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label9.Location = new System.Drawing.Point(180, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 63;
            this.label9.Text = "Email address";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label10.Location = new System.Drawing.Point(495, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 15);
            this.label10.TabIndex = 64;
            this.label10.Text = "Phone number";
            // 
            // picPersonImage
            // 
            this.picPersonImage.Image = global::DVLDPL.Properties.Resources.user__1_;
            this.picPersonImage.InitialImage = null;
            this.picPersonImage.Location = new System.Drawing.Point(35, 30);
            this.picPersonImage.Name = "picPersonImage";
            this.picPersonImage.Size = new System.Drawing.Size(125, 125);
            this.picPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPersonImage.TabIndex = 52;
            this.picPersonImage.TabStop = false;
            this.picPersonImage.Tag = "";
            // 
            // frmAddNewPersonForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(820, 428);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUploadNewPicutre);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbllall);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNationality);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtThirdName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSecondName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNationalNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPersonID);
            this.Controls.Add(this.picPersonImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(836, 467);
            this.MinimumSize = new System.Drawing.Size(836, 467);
            this.Name = "frmAddNewPersonForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Person Form";
            ((System.ComponentModel.ISupportInitialize)(this.epValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NControls.NTextBox txtPersonID;
        private NControls.NTextBox txtNationalNo;
        private NControls.NTextBox txtFirstName;
        private NControls.NTextBox txtSecondName;
        private NControls.NTextBox txtThirdName;
        private NControls.NTextBox txtLastName;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.Label label1;
        private NControls.NTextBox txtPhone;
        private NControls.NTextBox txtEmail;
        private System.Windows.Forms.Label lbllall;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider epValidation;
        private System.Windows.Forms.PictureBox picPersonImage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblUploadNewPicutre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}