namespace DVLD.PL.PeopleManagement
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

        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            pbPersonPhoto = new PictureBox();
            lnkUploadPhoto = new LinkLabel();
            lnkRemovePhoto = new LinkLabel();
            lblPersonID = new Label();
            txtPersonID = new NControls.NTextBox();
            lblNationalNo = new Label();
            txtNationalNo = new NControls.NTextBox();
            lblFirstName = new Label();
            txtFirstName = new NControls.NTextBox();
            lblSecondName = new Label();
            txtSecondName = new NControls.NTextBox();
            lblThirdName = new Label();
            txtThirdName = new NControls.NTextBox();
            lblLastName = new Label();
            txtLastName = new NControls.NTextBox();
            lblGender = new Label();
            cmbGender = new ComboBox();
            lblDateOfBirth = new Label();
            dtpBirthDate = new DateTimePicker();
            lblCountry = new Label();
            cmbCountry = new ComboBox();
            lblPhone = new Label();
            txtPhone = new NControls.NTextBox();
            lblEmail = new Label();
            txtEmail = new NControls.NTextBox();
            lblAddress = new Label();
            txtAddress = new NControls.NTextBox();
            btnSave = new ModernUI.Controls.NButton();
            btnCancel = new ModernUI.Controls.NButton();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonPhoto).BeginInit();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.Size = new Size(816, 31);
            headerControl.TitleText = "DVLD/Home/People Management/Save person";
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(pbPersonPhoto);
            pnlContainer.Controls.Add(lnkUploadPhoto);
            pnlContainer.Controls.Add(lnkRemovePhoto);
            pnlContainer.Controls.Add(lblPersonID);
            pnlContainer.Controls.Add(txtPersonID);
            pnlContainer.Controls.Add(lblNationalNo);
            pnlContainer.Controls.Add(txtNationalNo);
            pnlContainer.Controls.Add(lblFirstName);
            pnlContainer.Controls.Add(txtFirstName);
            pnlContainer.Controls.Add(lblSecondName);
            pnlContainer.Controls.Add(txtSecondName);
            pnlContainer.Controls.Add(lblThirdName);
            pnlContainer.Controls.Add(txtThirdName);
            pnlContainer.Controls.Add(lblLastName);
            pnlContainer.Controls.Add(txtLastName);
            pnlContainer.Controls.Add(lblGender);
            pnlContainer.Controls.Add(cmbGender);
            pnlContainer.Controls.Add(lblDateOfBirth);
            pnlContainer.Controls.Add(dtpBirthDate);
            pnlContainer.Controls.Add(lblCountry);
            pnlContainer.Controls.Add(cmbCountry);
            pnlContainer.Controls.Add(lblPhone);
            pnlContainer.Controls.Add(txtPhone);
            pnlContainer.Controls.Add(lblEmail);
            pnlContainer.Controls.Add(txtEmail);
            pnlContainer.Controls.Add(lblAddress);
            pnlContainer.Controls.Add(txtAddress);
            pnlContainer.Location = new Point(20, 60);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(780, 420);
            pnlContainer.TabIndex = 1;
            // 
            // pbPersonPhoto
            // 
            pbPersonPhoto.BackColor = Color.FromArgb(248, 250, 252);
            pbPersonPhoto.Location = new Point(630, 20);
            pbPersonPhoto.Name = "pbPersonPhoto";
            pbPersonPhoto.Size = new Size(130, 140);
            pbPersonPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbPersonPhoto.TabIndex = 0;
            pbPersonPhoto.TabStop = false;
            // 
            // lnkUploadPhoto
            // 
            lnkUploadPhoto.AutoSize = true;
            lnkUploadPhoto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lnkUploadPhoto.LinkColor = Color.FromArgb(124, 58, 237);
            lnkUploadPhoto.Location = new Point(632, 168);
            lnkUploadPhoto.Name = "lnkUploadPhoto";
            lnkUploadPhoto.Size = new Size(80, 15);
            lnkUploadPhoto.TabIndex = 1;
            lnkUploadPhoto.TabStop = true;
            lnkUploadPhoto.Text = "Upload Photo";
            // 
            // lnkRemovePhoto
            // 
            lnkRemovePhoto.AutoSize = true;
            lnkRemovePhoto.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lnkRemovePhoto.LinkColor = Color.FromArgb(239, 68, 68);
            lnkRemovePhoto.Location = new Point(712, 168);
            lnkRemovePhoto.Name = "lnkRemovePhoto";
            lnkRemovePhoto.Size = new Size(50, 15);
            lnkRemovePhoto.TabIndex = 2;
            lnkRemovePhoto.TabStop = true;
            lnkRemovePhoto.Text = "Remove";
            // 
            // lblPersonID
            // 
            lblPersonID.AutoSize = true;
            lblPersonID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPersonID.ForeColor = Color.FromArgb(71, 85, 105);
            lblPersonID.Location = new Point(20, 15);
            lblPersonID.Name = "lblPersonID";
            lblPersonID.Size = new Size(59, 15);
            lblPersonID.TabIndex = 3;
            lblPersonID.Text = "Person ID";
            // 
            // txtPersonID
            // 
            txtPersonID.AllowArabicCharacters = true;
            txtPersonID.AllowEnglishCharacters = true;
            txtPersonID.AllowNumbers = true;
            txtPersonID.AllowSpaces = true;
            txtPersonID.AllowSymbols = true;
            txtPersonID.BackColor = Color.Transparent;
            txtPersonID.BorderColor = Color.FromArgb(220, 220, 220);
            txtPersonID.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtPersonID.BorderRadius = 24;
            txtPersonID.BorderSize = 1;
            txtPersonID.CustomAllowedCharacters = "";
            txtPersonID.Enabled = false;
            txtPersonID.EnableSuggest = false;
            txtPersonID.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPersonID.FillColor = Color.White;
            txtPersonID.HasError = false;
            txtPersonID.IconOffsetLeft = 10;
            txtPersonID.IconOffsetRight = 10;
            txtPersonID.IconSpacing = 8;
            txtPersonID.Location = new Point(20, 35);
            txtPersonID.MaxLength = 32767;
            txtPersonID.MaxSuggestItems = 8;
            txtPersonID.MoveToNextControlOnEnter = true;
            txtPersonID.Name = "txtPersonID";
            txtPersonID.Padding = new Padding(8, 12, 8, 12);
            txtPersonID.PlaceholderColor = Color.DarkGray;
            txtPersonID.PlaceholderText = "";
            txtPersonID.ShowClearButton = false;
            txtPersonID.Size = new Size(260, 40);
            txtPersonID.SuggestIcon = null;
            txtPersonID.TabIndex = 4;
            txtPersonID.UseSystemPasswordChar = false;
            txtPersonID.ValidateEmail = false;
            // 
            // lblNationalNo
            // 
            lblNationalNo.AutoSize = true;
            lblNationalNo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblNationalNo.ForeColor = Color.FromArgb(71, 85, 105);
            lblNationalNo.Location = new Point(310, 15);
            lblNationalNo.Name = "lblNationalNo";
            lblNationalNo.Size = new Size(74, 15);
            lblNationalNo.TabIndex = 5;
            lblNationalNo.Text = "National No.";
            // 
            // txtNationalNo
            // 
            txtNationalNo.AllowArabicCharacters = true;
            txtNationalNo.AllowEnglishCharacters = true;
            txtNationalNo.AllowNumbers = true;
            txtNationalNo.AllowSpaces = true;
            txtNationalNo.AllowSymbols = true;
            txtNationalNo.BackColor = Color.Transparent;
            txtNationalNo.BorderColor = Color.FromArgb(220, 220, 220);
            txtNationalNo.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtNationalNo.BorderRadius = 24;
            txtNationalNo.BorderSize = 1;
            txtNationalNo.CustomAllowedCharacters = "";
            txtNationalNo.EnableSuggest = false;
            txtNationalNo.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtNationalNo.FillColor = Color.White;
            txtNationalNo.HasError = false;
            txtNationalNo.IconOffsetLeft = 10;
            txtNationalNo.IconOffsetRight = 10;
            txtNationalNo.IconSpacing = 8;
            txtNationalNo.Location = new Point(310, 35);
            txtNationalNo.MaxLength = 32767;
            txtNationalNo.MaxSuggestItems = 8;
            txtNationalNo.MoveToNextControlOnEnter = true;
            txtNationalNo.Name = "txtNationalNo";
            txtNationalNo.Padding = new Padding(8, 12, 8, 12);
            txtNationalNo.PlaceholderColor = Color.DarkGray;
            txtNationalNo.PlaceholderText = "National Number";
            txtNationalNo.ShowClearButton = false;
            txtNationalNo.Size = new Size(280, 40);
            txtNationalNo.SuggestIcon = null;
            txtNationalNo.TabIndex = 6;
            txtNationalNo.UseSystemPasswordChar = false;
            txtNationalNo.ValidateEmail = false;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(71, 85, 105);
            lblFirstName.Location = new Point(20, 85);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(64, 15);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.AllowArabicCharacters = true;
            txtFirstName.AllowEnglishCharacters = true;
            txtFirstName.AllowNumbers = true;
            txtFirstName.AllowSpaces = true;
            txtFirstName.AllowSymbols = true;
            txtFirstName.BackColor = Color.Transparent;
            txtFirstName.BorderColor = Color.FromArgb(220, 220, 220);
            txtFirstName.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtFirstName.BorderRadius = 24;
            txtFirstName.BorderSize = 1;
            txtFirstName.CustomAllowedCharacters = "";
            txtFirstName.EnableSuggest = false;
            txtFirstName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtFirstName.FillColor = Color.White;
            txtFirstName.HasError = false;
            txtFirstName.IconOffsetLeft = 10;
            txtFirstName.IconOffsetRight = 10;
            txtFirstName.IconSpacing = 8;
            txtFirstName.Location = new Point(20, 105);
            txtFirstName.MaxLength = 32767;
            txtFirstName.MaxSuggestItems = 8;
            txtFirstName.MoveToNextControlOnEnter = true;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Padding = new Padding(8, 12, 8, 12);
            txtFirstName.PlaceholderColor = Color.DarkGray;
            txtFirstName.PlaceholderText = "First Name";
            txtFirstName.ShowClearButton = false;
            txtFirstName.Size = new Size(130, 40);
            txtFirstName.SuggestIcon = null;
            txtFirstName.TabIndex = 8;
            txtFirstName.UseSystemPasswordChar = false;
            txtFirstName.ValidateEmail = false;
            // 
            // lblSecondName
            // 
            lblSecondName.AutoSize = true;
            lblSecondName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSecondName.ForeColor = Color.FromArgb(71, 85, 105);
            lblSecondName.Location = new Point(165, 85);
            lblSecondName.Name = "lblSecondName";
            lblSecondName.Size = new Size(82, 15);
            lblSecondName.TabIndex = 9;
            lblSecondName.Text = "Second Name";
            // 
            // txtSecondName
            // 
            txtSecondName.AllowArabicCharacters = true;
            txtSecondName.AllowEnglishCharacters = true;
            txtSecondName.AllowNumbers = true;
            txtSecondName.AllowSpaces = true;
            txtSecondName.AllowSymbols = true;
            txtSecondName.BackColor = Color.Transparent;
            txtSecondName.BorderColor = Color.FromArgb(220, 220, 220);
            txtSecondName.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtSecondName.BorderRadius = 24;
            txtSecondName.BorderSize = 1;
            txtSecondName.CustomAllowedCharacters = "";
            txtSecondName.EnableSuggest = false;
            txtSecondName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtSecondName.FillColor = Color.White;
            txtSecondName.HasError = false;
            txtSecondName.IconOffsetLeft = 10;
            txtSecondName.IconOffsetRight = 10;
            txtSecondName.IconSpacing = 8;
            txtSecondName.Location = new Point(165, 105);
            txtSecondName.MaxLength = 32767;
            txtSecondName.MaxSuggestItems = 8;
            txtSecondName.MoveToNextControlOnEnter = true;
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Padding = new Padding(8, 12, 8, 12);
            txtSecondName.PlaceholderColor = Color.DarkGray;
            txtSecondName.PlaceholderText = "Second Name";
            txtSecondName.ShowClearButton = false;
            txtSecondName.Size = new Size(130, 40);
            txtSecondName.SuggestIcon = null;
            txtSecondName.TabIndex = 10;
            txtSecondName.UseSystemPasswordChar = false;
            txtSecondName.ValidateEmail = false;
            // 
            // lblThirdName
            // 
            lblThirdName.AutoSize = true;
            lblThirdName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblThirdName.ForeColor = Color.FromArgb(71, 85, 105);
            lblThirdName.Location = new Point(310, 85);
            lblThirdName.Name = "lblThirdName";
            lblThirdName.Size = new Size(70, 15);
            lblThirdName.TabIndex = 11;
            lblThirdName.Text = "Third Name";
            // 
            // txtThirdName
            // 
            txtThirdName.AllowArabicCharacters = true;
            txtThirdName.AllowEnglishCharacters = true;
            txtThirdName.AllowNumbers = true;
            txtThirdName.AllowSpaces = true;
            txtThirdName.AllowSymbols = true;
            txtThirdName.BackColor = Color.Transparent;
            txtThirdName.BorderColor = Color.FromArgb(220, 220, 220);
            txtThirdName.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtThirdName.BorderRadius = 24;
            txtThirdName.BorderSize = 1;
            txtThirdName.CustomAllowedCharacters = "";
            txtThirdName.EnableSuggest = false;
            txtThirdName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtThirdName.FillColor = Color.White;
            txtThirdName.HasError = false;
            txtThirdName.IconOffsetLeft = 10;
            txtThirdName.IconOffsetRight = 10;
            txtThirdName.IconSpacing = 8;
            txtThirdName.Location = new Point(310, 105);
            txtThirdName.MaxLength = 32767;
            txtThirdName.MaxSuggestItems = 8;
            txtThirdName.MoveToNextControlOnEnter = true;
            txtThirdName.Name = "txtThirdName";
            txtThirdName.Padding = new Padding(8, 12, 8, 12);
            txtThirdName.PlaceholderColor = Color.DarkGray;
            txtThirdName.PlaceholderText = "Third Name";
            txtThirdName.ShowClearButton = false;
            txtThirdName.Size = new Size(130, 40);
            txtThirdName.SuggestIcon = null;
            txtThirdName.TabIndex = 12;
            txtThirdName.UseSystemPasswordChar = false;
            txtThirdName.ValidateEmail = false;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(71, 85, 105);
            lblLastName.Location = new Point(455, 85);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(63, 15);
            lblLastName.TabIndex = 13;
            lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.AllowArabicCharacters = true;
            txtLastName.AllowEnglishCharacters = true;
            txtLastName.AllowNumbers = true;
            txtLastName.AllowSpaces = true;
            txtLastName.AllowSymbols = true;
            txtLastName.BackColor = Color.Transparent;
            txtLastName.BorderColor = Color.FromArgb(220, 220, 220);
            txtLastName.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtLastName.BorderRadius = 24;
            txtLastName.BorderSize = 1;
            txtLastName.CustomAllowedCharacters = "";
            txtLastName.EnableSuggest = false;
            txtLastName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtLastName.FillColor = Color.White;
            txtLastName.HasError = false;
            txtLastName.IconOffsetLeft = 10;
            txtLastName.IconOffsetRight = 10;
            txtLastName.IconSpacing = 8;
            txtLastName.Location = new Point(455, 105);
            txtLastName.MaxLength = 32767;
            txtLastName.MaxSuggestItems = 8;
            txtLastName.MoveToNextControlOnEnter = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Padding = new Padding(8, 12, 8, 12);
            txtLastName.PlaceholderColor = Color.DarkGray;
            txtLastName.PlaceholderText = "Last Name";
            txtLastName.ShowClearButton = false;
            txtLastName.Size = new Size(135, 40);
            txtLastName.SuggestIcon = null;
            txtLastName.TabIndex = 14;
            txtLastName.UseSystemPasswordChar = false;
            txtLastName.ValidateEmail = false;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblGender.ForeColor = Color.FromArgb(71, 85, 105);
            lblGender.Location = new Point(20, 160);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(45, 15);
            lblGender.TabIndex = 15;
            lblGender.Text = "Gender";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Font = new Font("Segoe UI", 10F);
            cmbGender.Location = new Point(20, 180);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(170, 25);
            cmbGender.TabIndex = 16;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDateOfBirth.ForeColor = Color.FromArgb(71, 85, 105);
            lblDateOfBirth.Location = new Point(215, 160);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new Size(74, 15);
            lblDateOfBirth.TabIndex = 17;
            lblDateOfBirth.Text = "Date of Birth";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Font = new Font("Segoe UI", 10F);
            dtpBirthDate.Format = DateTimePickerFormat.Short;
            dtpBirthDate.Location = new Point(215, 180);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(170, 25);
            dtpBirthDate.TabIndex = 18;
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCountry.ForeColor = Color.FromArgb(71, 85, 105);
            lblCountry.Location = new Point(410, 160);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(49, 15);
            lblCountry.TabIndex = 19;
            lblCountry.Text = "Country";
            // 
            // cmbCountry
            // 
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.Font = new Font("Segoe UI", 10F);
            cmbCountry.Location = new Point(410, 180);
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(180, 25);
            cmbCountry.TabIndex = 20;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhone.Location = new Point(20, 225);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(41, 15);
            lblPhone.TabIndex = 21;
            lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            txtPhone.AllowArabicCharacters = true;
            txtPhone.AllowEnglishCharacters = true;
            txtPhone.AllowNumbers = true;
            txtPhone.AllowSpaces = true;
            txtPhone.AllowSymbols = true;
            txtPhone.BackColor = Color.Transparent;
            txtPhone.BorderColor = Color.FromArgb(220, 220, 220);
            txtPhone.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtPhone.BorderRadius = 24;
            txtPhone.BorderSize = 1;
            txtPhone.CustomAllowedCharacters = "";
            txtPhone.EnableSuggest = false;
            txtPhone.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPhone.FillColor = Color.White;
            txtPhone.HasError = false;
            txtPhone.IconOffsetLeft = 10;
            txtPhone.IconOffsetRight = 10;
            txtPhone.IconSpacing = 8;
            txtPhone.Location = new Point(20, 245);
            txtPhone.MaxLength = 32767;
            txtPhone.MaxSuggestItems = 8;
            txtPhone.MoveToNextControlOnEnter = true;
            txtPhone.Name = "txtPhone";
            txtPhone.Padding = new Padding(8, 12, 8, 12);
            txtPhone.PlaceholderColor = Color.DarkGray;
            txtPhone.PlaceholderText = "Phone Number";
            txtPhone.ShowClearButton = false;
            txtPhone.Size = new Size(260, 40);
            txtPhone.SuggestIcon = null;
            txtPhone.TabIndex = 22;
            txtPhone.UseSystemPasswordChar = false;
            txtPhone.ValidateEmail = false;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(310, 225);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 23;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.AllowArabicCharacters = true;
            txtEmail.AllowEnglishCharacters = true;
            txtEmail.AllowNumbers = true;
            txtEmail.AllowSpaces = true;
            txtEmail.AllowSymbols = true;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BorderColor = Color.FromArgb(220, 220, 220);
            txtEmail.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtEmail.BorderRadius = 24;
            txtEmail.BorderSize = 1;
            txtEmail.CustomAllowedCharacters = "";
            txtEmail.EnableSuggest = false;
            txtEmail.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtEmail.FillColor = Color.White;
            txtEmail.HasError = false;
            txtEmail.IconOffsetLeft = 10;
            txtEmail.IconOffsetRight = 10;
            txtEmail.IconSpacing = 8;
            txtEmail.Location = new Point(310, 245);
            txtEmail.MaxLength = 32767;
            txtEmail.MaxSuggestItems = 8;
            txtEmail.MoveToNextControlOnEnter = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(8, 12, 8, 12);
            txtEmail.PlaceholderColor = Color.DarkGray;
            txtEmail.PlaceholderText = "Email Address";
            txtEmail.ShowClearButton = false;
            txtEmail.Size = new Size(450, 40);
            txtEmail.SuggestIcon = null;
            txtEmail.TabIndex = 24;
            txtEmail.UseSystemPasswordChar = false;
            txtEmail.ValidateEmail = false;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(71, 85, 105);
            lblAddress.Location = new Point(20, 300);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(49, 15);
            lblAddress.TabIndex = 25;
            lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.AllowArabicCharacters = true;
            txtAddress.AllowEnglishCharacters = true;
            txtAddress.AllowNumbers = true;
            txtAddress.AllowSpaces = true;
            txtAddress.AllowSymbols = true;
            txtAddress.BackColor = Color.Transparent;
            txtAddress.BorderColor = Color.FromArgb(220, 220, 220);
            txtAddress.BorderFocusColor = Color.FromArgb(200, 200, 200);
            txtAddress.BorderRadius = 24;
            txtAddress.BorderSize = 1;
            txtAddress.CustomAllowedCharacters = "";
            txtAddress.EnableSuggest = false;
            txtAddress.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtAddress.FillColor = Color.White;
            txtAddress.HasError = false;
            txtAddress.IconOffsetLeft = 10;
            txtAddress.IconOffsetRight = 10;
            txtAddress.IconSpacing = 8;
            txtAddress.Location = new Point(20, 320);
            txtAddress.MaxLength = 32767;
            txtAddress.MaxSuggestItems = 8;
            txtAddress.MoveToNextControlOnEnter = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new Padding(8, 12, 8, 12);
            txtAddress.PlaceholderColor = Color.DarkGray;
            txtAddress.PlaceholderText = "Full Address";
            txtAddress.ShowClearButton = false;
            txtAddress.Size = new Size(740, 40);
            txtAddress.SuggestIcon = null;
            txtAddress.TabIndex = 26;
            txtAddress.UseSystemPasswordChar = false;
            txtAddress.ValidateEmail = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Transparent;
            btnSave.BackgroundEndColor = SystemColors.Control;
            btnSave.BackgroundStartColor = SystemColors.Control;
            btnSave.BorderColor = Color.DarkGray;
            btnSave.BorderRadius = 0;
            btnSave.BorderSize = 1;
            btnSave.CenterIconWithText = false;
            btnSave.EnableHoverAnimation = false;
            btnSave.EnableIconTinting = false;
            btnSave.EnableRippleEffect = false;
            btnSave.EnableShadow = false;
            btnSave.Font = new Font("Segoe UI", 9F);
            btnSave.ForeColor = SystemColors.ControlText;
            btnSave.GradientAngle = 90F;
            btnSave.HoverAnimationSpeed = 20;
            btnSave.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnSave.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnSave.HoverIconColor = Color.White;
            btnSave.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnSave.HoverTextColor = SystemColors.ControlText;
            btnSave.IconColor = Color.White;
            btnSave.IconMargin = 10;
            btnSave.IconOffset = new Point(0, 0);
            btnSave.IconSize = new Size(16, 16);
            btnSave.IconSpacing = 5;
            btnSave.IsLoading = false;
            btnSave.LeftIcon = null;
            btnSave.Location = new Point(540, 500);
            btnSave.Name = "btnSave";
            btnSave.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnSave.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnSave.RightIcon = null;
            btnSave.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnSave.RippleSpeed = 15;
            btnSave.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnSave.ShadowOffset = new Point(1, 1);
            btnSave.ShadowSize = 3;
            btnSave.ShiftOnPress = false;
            btnSave.Size = new Size(125, 42);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Person";
            btnSave.TextColor = SystemColors.ControlText;
            btnSave.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BackgroundEndColor = SystemColors.Control;
            btnCancel.BackgroundStartColor = SystemColors.Control;
            btnCancel.BorderColor = Color.DarkGray;
            btnCancel.BorderRadius = 0;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.EnableHoverAnimation = false;
            btnCancel.EnableIconTinting = false;
            btnCancel.EnableRippleEffect = false;
            btnCancel.EnableShadow = false;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = SystemColors.ControlText;
            btnCancel.GradientAngle = 90F;
            btnCancel.HoverAnimationSpeed = 20;
            btnCancel.HoverBorderColor = Color.FromArgb(0, 120, 215);
            btnCancel.HoverEndColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverIconColor = Color.White;
            btnCancel.HoverStartColor = Color.FromArgb(229, 241, 251);
            btnCancel.HoverTextColor = SystemColors.ControlText;
            btnCancel.IconColor = Color.White;
            btnCancel.IconMargin = 10;
            btnCancel.IconOffset = new Point(0, 0);
            btnCancel.IconSize = new Size(16, 16);
            btnCancel.IconSpacing = 5;
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(675, 500);
            btnCancel.Name = "btnCancel";
            btnCancel.PressedEndColor = Color.FromArgb(204, 228, 247);
            btnCancel.PressedStartColor = Color.FromArgb(204, 228, 247);
            btnCancel.RightIcon = null;
            btnCancel.RippleColor = Color.FromArgb(70, 0, 0, 0);
            btnCancel.RippleSpeed = 15;
            btnCancel.ShadowColor = Color.FromArgb(60, 0, 0, 0);
            btnCancel.ShadowOffset = new Point(1, 1);
            btnCancel.ShadowSize = 3;
            btnCancel.ShiftOnPress = false;
            btnCancel.Size = new Size(125, 42);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.TextColor = SystemColors.ControlText;
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmSavePerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(820, 560);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pnlContainer);
            Name = "frmSavePerson";
            Text = "DVLD/Home/People Management/Save person";
            Load += frmSavePerson_Load;
            Controls.SetChildIndex(pnlContainer, 0);
            Controls.SetChildIndex(btnSave, 0);
            Controls.SetChildIndex(btnCancel, 0);
            Controls.SetChildIndex(headerControl, 0);
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonPhoto).EndInit();
            ResumeLayout(false);
        }
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.PictureBox pbPersonPhoto;
        private System.Windows.Forms.LinkLabel lnkUploadPhoto;
        private System.Windows.Forms.LinkLabel lnkRemovePhoto;
        private System.Windows.Forms.Label lblPersonID;
        private NControls.NTextBox txtPersonID;
        private System.Windows.Forms.Label lblNationalNo;
        private NControls.NTextBox txtNationalNo;
        private System.Windows.Forms.Label lblFirstName;
        private NControls.NTextBox txtFirstName;
        private System.Windows.Forms.Label lblSecondName;
        private NControls.NTextBox txtSecondName;
        private System.Windows.Forms.Label lblThirdName;
        private NControls.NTextBox txtThirdName;
        private System.Windows.Forms.Label lblLastName;
        private NControls.NTextBox txtLastName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label lblPhone;
        private NControls.NTextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private NControls.NTextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private NControls.NTextBox txtAddress;
        private ModernUI.Controls.NButton btnSave;
        private ModernUI.Controls.NButton btnCancel;
    }
}