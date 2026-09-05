namespace DVLDPL.PeopleManagement
{
    partial class frmSavePerson
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
            this.txtAdress = new NControls.NTextBox();
            this.lbllall = new System.Windows.Forms.Label();
            this.cmbGendor = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
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
            this.lblDeletePicture = new System.Windows.Forms.LinkLabel();
            this.btnSubmitAndClose = new System.Windows.Forms.Button();
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
            this.txtPersonID.Location = new System.Drawing.Point(180, 46);
            this.txtPersonID.MaxSuggestItems = 4;
            this.txtPersonID.Name = "txtPersonID";
            this.txtPersonID.Padding = new System.Windows.Forms.Padding(8);
            this.txtPersonID.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPersonID.PlaceholderText = "Person ID";
            this.txtPersonID.ShowClearButton = true;
            this.txtPersonID.Size = new System.Drawing.Size(285, 38);
            this.txtPersonID.SuggestIcon = null;
            this.txtPersonID.SuggestList = new string[0];
            this.txtPersonID.TabIndex = 100;
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
            this.txtNationalNo.Tag = "National No";
            this.txtNationalNo.UseSystemPasswordChar = false;
            this.txtNationalNo.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
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
            this.txtFirstName.Location = new System.Drawing.Point(35, 234);
            this.txtFirstName.MaxSuggestItems = 4;
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Padding = new System.Windows.Forms.Padding(8);
            this.txtFirstName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtFirstName.PlaceholderText = "First name";
            this.txtFirstName.ShowClearButton = true;
            this.txtFirstName.Size = new System.Drawing.Size(172, 38);
            this.txtFirstName.SuggestIcon = null;
            this.txtFirstName.SuggestList = new string[0];
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.Tag = "First name";
            this.txtFirstName.UseSystemPasswordChar = false;
            this.txtFirstName.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
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
            this.txtSecondName.Location = new System.Drawing.Point(227, 234);
            this.txtSecondName.MaxSuggestItems = 4;
            this.txtSecondName.Name = "txtSecondName";
            this.txtSecondName.Padding = new System.Windows.Forms.Padding(8);
            this.txtSecondName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSecondName.PlaceholderText = "Second name";
            this.txtSecondName.ShowClearButton = true;
            this.txtSecondName.Size = new System.Drawing.Size(172, 38);
            this.txtSecondName.SuggestIcon = null;
            this.txtSecondName.SuggestList = new string[0];
            this.txtSecondName.TabIndex = 5;
            this.txtSecondName.Tag = "Second name";
            this.txtSecondName.UseSystemPasswordChar = false;
            this.txtSecondName.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
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
            this.txtThirdName.Location = new System.Drawing.Point(419, 234);
            this.txtThirdName.MaxSuggestItems = 4;
            this.txtThirdName.Name = "txtThirdName";
            this.txtThirdName.Padding = new System.Windows.Forms.Padding(8);
            this.txtThirdName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtThirdName.PlaceholderText = "Third name";
            this.txtThirdName.ShowClearButton = true;
            this.txtThirdName.Size = new System.Drawing.Size(172, 38);
            this.txtThirdName.SuggestIcon = null;
            this.txtThirdName.SuggestList = new string[0];
            this.txtThirdName.TabIndex = 6;
            this.txtThirdName.Tag = "Third name";
            this.txtThirdName.UseSystemPasswordChar = false;
            this.txtThirdName.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
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
            this.txtLastName.Location = new System.Drawing.Point(611, 234);
            this.txtLastName.MaxSuggestItems = 4;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Padding = new System.Windows.Forms.Padding(8);
            this.txtLastName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLastName.PlaceholderText = "Last name";
            this.txtLastName.ShowClearButton = true;
            this.txtLastName.Size = new System.Drawing.Size(174, 38);
            this.txtLastName.SuggestIcon = null;
            this.txtLastName.SuggestList = new string[0];
            this.txtLastName.TabIndex = 7;
            this.txtLastName.Tag = "Last name";
            this.txtLastName.UseSystemPasswordChar = false;
            this.txtLastName.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
            // 
            // cmbNationality
            // 
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(292, 310);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(236, 25);
            this.cmbNationality.TabIndex = 9;
            this.cmbNationality.SelectedValueChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label1.Location = new System.Drawing.Point(292, 294);
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
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Tag = "Phone number";
            this.txtPhone.UseSystemPasswordChar = false;
            this.txtPhone.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
            // 
            // txtAdress
            // 
            this.txtAdress.BackColor = System.Drawing.Color.Transparent;
            this.txtAdress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(213)))), ((int)(((byte)(221)))));
            this.txtAdress.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtAdress.BorderRadius = 16;
            this.txtAdress.BorderSize = 1;
            this.txtAdress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAdress.EnableSuggest = true;
            this.txtAdress.FillColor = System.Drawing.Color.White;
            this.txtAdress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAdress.IconOffsetLeft = 10;
            this.txtAdress.IconOffsetRight = 10;
            this.txtAdress.IconSpacing = 10;
            this.txtAdress.Location = new System.Drawing.Point(180, 117);
            this.txtAdress.MaxSuggestItems = 4;
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Padding = new System.Windows.Forms.Padding(8);
            this.txtAdress.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAdress.PlaceholderText = "Email";
            this.txtAdress.ShowClearButton = true;
            this.txtAdress.Size = new System.Drawing.Size(285, 38);
            this.txtAdress.SuggestIcon = null;
            this.txtAdress.SuggestList = new string[0];
            this.txtAdress.TabIndex = 2;
            this.txtAdress.Tag = "Email";
            this.txtAdress.UseSystemPasswordChar = false;
            this.txtAdress.TextChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
            // 
            // lbllall
            // 
            this.lbllall.AutoSize = true;
            this.lbllall.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.lbllall.Location = new System.Drawing.Point(549, 294);
            this.lbllall.Name = "lbllall";
            this.lbllall.Size = new System.Drawing.Size(45, 15);
            this.lbllall.TabIndex = 51;
            this.lbllall.Text = "Gendor";
            // 
            // cmbGendor
            // 
            this.cmbGendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGendor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGendor.FormattingEnabled = true;
            this.cmbGendor.Location = new System.Drawing.Point(549, 310);
            this.cmbGendor.Name = "cmbGendor";
            this.cmbGendor.Size = new System.Drawing.Size(236, 25);
            this.cmbGendor.TabIndex = 10;
            this.cmbGendor.SelectedValueChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Enabled = false;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(485, 365);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(145, 42);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // epValidation
            // 
            this.epValidation.ContainerControl = this;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(35, 310);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(236, 25);
            this.dtpBirthDate.TabIndex = 8;
            this.dtpBirthDate.ValueChanged += new System.EventHandler(this.ValidateControls_ValuedChanged);
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
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(80)))), ((int)(((byte)(95)))));
            this.label2.Location = new System.Drawing.Point(35, 220);
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
            this.label3.Location = new System.Drawing.Point(227, 220);
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
            this.label4.Location = new System.Drawing.Point(419, 220);
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
            this.label5.Location = new System.Drawing.Point(611, 220);
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
            this.label6.Location = new System.Drawing.Point(495, 26);
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
            this.label7.Location = new System.Drawing.Point(180, 26);
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
            this.lblUploadNewPicutre.TabIndex = 11;
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
            this.label8.Location = new System.Drawing.Point(32, 294);
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
            this.label9.Location = new System.Drawing.Point(180, 100);
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
            this.label10.Location = new System.Drawing.Point(495, 100);
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
            // lblDeletePicture
            // 
            this.lblDeletePicture.AutoSize = true;
            this.lblDeletePicture.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeletePicture.LinkColor = System.Drawing.Color.Red;
            this.lblDeletePicture.Location = new System.Drawing.Point(29, 182);
            this.lblDeletePicture.Name = "lblDeletePicture";
            this.lblDeletePicture.Size = new System.Drawing.Size(142, 17);
            this.lblDeletePicture.TabIndex = 102;
            this.lblDeletePicture.TabStop = true;
            this.lblDeletePicture.Text = "Delete Current Picutre";
            this.lblDeletePicture.VisitedLinkColor = System.Drawing.Color.Black;
            this.lblDeletePicture.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeletePicture_LinkClicked);
            // 
            // btnSubmitAndClose
            // 
            this.btnSubmitAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubmitAndClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitAndClose.Enabled = false;
            this.btnSubmitAndClose.FlatAppearance.BorderSize = 0;
            this.btnSubmitAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitAndClose.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitAndClose.ForeColor = System.Drawing.Color.White;
            this.btnSubmitAndClose.Location = new System.Drawing.Point(260, 365);
            this.btnSubmitAndClose.Name = "btnSubmitAndClose";
            this.btnSubmitAndClose.Size = new System.Drawing.Size(219, 42);
            this.btnSubmitAndClose.TabIndex = 103;
            this.btnSubmitAndClose.Text = "Submit and Close the window";
            this.btnSubmitAndClose.UseVisualStyleBackColor = false;
            this.btnSubmitAndClose.Click += new System.EventHandler(this.btnSubmitAndClose_Click);
            // 
            // frmSavePerson
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(820, 428);
            this.Controls.Add(this.btnSubmitAndClose);
            this.Controls.Add(this.lblDeletePicture);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUploadNewPicutre);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lbllall);
            this.Controls.Add(this.cmbGendor);
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
            this.Controls.Add(this.txtAdress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNationalNo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPersonID);
            this.Controls.Add(this.picPersonImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(836, 467);
            this.MinimumSize = new System.Drawing.Size(836, 467);
            this.Name = "frmSavePerson";
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
        private NControls.NTextBox txtAdress;
        private System.Windows.Forms.Label lbllall;
        private System.Windows.Forms.ComboBox cmbGendor;
        private System.Windows.Forms.Button btnSubmit;
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
        private System.Windows.Forms.LinkLabel lblDeletePicture;
        private System.Windows.Forms.Button btnSubmitAndClose;
    }
}