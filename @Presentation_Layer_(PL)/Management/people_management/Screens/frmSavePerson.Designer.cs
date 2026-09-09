using System.Drawing;
using System.Windows.Forms;
using NControls;

namespace DVLD.PL.PeopleManagement
{
    partial class frmSavePerson
    {
        private System.ComponentModel.IContainer components = null;
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
        private NButton btnSave;
        private NButton btnCancel;

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
            btnSave = new NButton();
            btnCancel = new NButton();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersonPhoto).BeginInit();
            SuspendLayout();
            // 
            // headerControl
            // 
            headerControl.AllowMaximize = false;
            headerControl.AllowMinimize = false;
            headerControl.Size = new Size(820, 38);
            headerControl.TitleText = "DVLD / People Management / Save Person";
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
            pnlContainer.Location = new Point(20, 50);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(780, 420);
            pnlContainer.TabIndex = 1;
            // 
            // pbPersonPhoto
            // 
            pbPersonPhoto.BackColor = Color.FromArgb(248, 250, 252);
            pbPersonPhoto.Image = Properties.Resources.User;
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
            lnkUploadPhoto.LinkBehavior = LinkBehavior.NeverUnderline;
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
            lnkRemovePhoto.LinkBehavior = LinkBehavior.NeverUnderline;
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
            txtPersonID.BorderColor = Color.FromArgb(226, 232, 240);
            txtPersonID.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtPersonID.BorderRadius = 8;
            txtPersonID.BorderSize = 1;
            txtPersonID.CustomAllowedCharacters = "";
            txtPersonID.Enabled = false;
            txtPersonID.EnableSuggest = false;
            txtPersonID.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPersonID.FillColor = Color.FromArgb(248, 250, 252);
            txtPersonID.Font = new Font("Segoe UI", 10F);
            txtPersonID.ForeColor = Color.FromArgb(100, 116, 139);
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
            txtNationalNo.BorderColor = Color.FromArgb(226, 232, 240);
            txtNationalNo.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtNationalNo.BorderRadius = 8;
            txtNationalNo.BorderSize = 1;
            txtNationalNo.CustomAllowedCharacters = "";
            txtNationalNo.EnableSuggest = false;
            txtNationalNo.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtNationalNo.FillColor = Color.White;
            txtNationalNo.Font = new Font("Segoe UI", 10F);
            txtNationalNo.ForeColor = Color.FromArgb(15, 23, 42);
            txtNationalNo.HasError = false;
            txtNationalNo.IconOffsetLeft = 10;
            txtNationalNo.IconOffsetRight = 10;
            txtNationalNo.IconSpacing = 8;
            txtNationalNo.Location = new Point(310, 35);
            txtNationalNo.MaxLength = 50;
            txtNationalNo.MaxSuggestItems = 8;
            txtNationalNo.MoveToNextControlOnEnter = true;
            txtNationalNo.Name = "txtNationalNo";
            txtNationalNo.Padding = new Padding(8, 12, 8, 12);
            txtNationalNo.PlaceholderColor = Color.FromArgb(148, 163, 184);
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
            txtFirstName.AllowNumbers = false;
            txtFirstName.AllowSpaces = false;
            txtFirstName.AllowSymbols = false;
            txtFirstName.BackColor = Color.Transparent;
            txtFirstName.BorderColor = Color.FromArgb(226, 232, 240);
            txtFirstName.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtFirstName.BorderRadius = 8;
            txtFirstName.BorderSize = 1;
            txtFirstName.CustomAllowedCharacters = "";
            txtFirstName.EnableSuggest = false;
            txtFirstName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtFirstName.FillColor = Color.White;
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.ForeColor = Color.FromArgb(15, 23, 42);
            txtFirstName.HasError = false;
            txtFirstName.IconOffsetLeft = 10;
            txtFirstName.IconOffsetRight = 10;
            txtFirstName.IconSpacing = 8;
            txtFirstName.Location = new Point(20, 105);
            txtFirstName.MaxLength = 50;
            txtFirstName.MaxSuggestItems = 8;
            txtFirstName.MoveToNextControlOnEnter = true;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Padding = new Padding(8, 12, 8, 12);
            txtFirstName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtFirstName.PlaceholderText = "First";
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
            txtSecondName.AllowNumbers = false;
            txtSecondName.AllowSpaces = false;
            txtSecondName.AllowSymbols = false;
            txtSecondName.BackColor = Color.Transparent;
            txtSecondName.BorderColor = Color.FromArgb(226, 232, 240);
            txtSecondName.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtSecondName.BorderRadius = 8;
            txtSecondName.BorderSize = 1;
            txtSecondName.CustomAllowedCharacters = "";
            txtSecondName.EnableSuggest = false;
            txtSecondName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtSecondName.FillColor = Color.White;
            txtSecondName.Font = new Font("Segoe UI", 10F);
            txtSecondName.ForeColor = Color.FromArgb(15, 23, 42);
            txtSecondName.HasError = false;
            txtSecondName.IconOffsetLeft = 10;
            txtSecondName.IconOffsetRight = 10;
            txtSecondName.IconSpacing = 8;
            txtSecondName.Location = new Point(165, 105);
            txtSecondName.MaxLength = 50;
            txtSecondName.MaxSuggestItems = 8;
            txtSecondName.MoveToNextControlOnEnter = true;
            txtSecondName.Name = "txtSecondName";
            txtSecondName.Padding = new Padding(8, 12, 8, 12);
            txtSecondName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtSecondName.PlaceholderText = "Second";
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
            txtThirdName.AllowNumbers = false;
            txtThirdName.AllowSpaces = false;
            txtThirdName.AllowSymbols = false;
            txtThirdName.BackColor = Color.Transparent;
            txtThirdName.BorderColor = Color.FromArgb(226, 232, 240);
            txtThirdName.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtThirdName.BorderRadius = 8;
            txtThirdName.BorderSize = 1;
            txtThirdName.CustomAllowedCharacters = "";
            txtThirdName.EnableSuggest = false;
            txtThirdName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtThirdName.FillColor = Color.White;
            txtThirdName.Font = new Font("Segoe UI", 10F);
            txtThirdName.ForeColor = Color.FromArgb(15, 23, 42);
            txtThirdName.HasError = false;
            txtThirdName.IconOffsetLeft = 10;
            txtThirdName.IconOffsetRight = 10;
            txtThirdName.IconSpacing = 8;
            txtThirdName.Location = new Point(310, 105);
            txtThirdName.MaxLength = 50;
            txtThirdName.MaxSuggestItems = 8;
            txtThirdName.MoveToNextControlOnEnter = true;
            txtThirdName.Name = "txtThirdName";
            txtThirdName.Padding = new Padding(8, 12, 8, 12);
            txtThirdName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtThirdName.PlaceholderText = "Third";
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
            txtLastName.AllowNumbers = false;
            txtLastName.AllowSpaces = false;
            txtLastName.AllowSymbols = false;
            txtLastName.BackColor = Color.Transparent;
            txtLastName.BorderColor = Color.FromArgb(226, 232, 240);
            txtLastName.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtLastName.BorderRadius = 8;
            txtLastName.BorderSize = 1;
            txtLastName.CustomAllowedCharacters = "";
            txtLastName.EnableSuggest = false;
            txtLastName.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtLastName.FillColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.ForeColor = Color.FromArgb(15, 23, 42);
            txtLastName.HasError = false;
            txtLastName.IconOffsetLeft = 10;
            txtLastName.IconOffsetRight = 10;
            txtLastName.IconSpacing = 8;
            txtLastName.Location = new Point(455, 105);
            txtLastName.MaxLength = 50;
            txtLastName.MaxSuggestItems = 8;
            txtLastName.MoveToNextControlOnEnter = true;
            txtLastName.Name = "txtLastName";
            txtLastName.Padding = new Padding(8, 12, 8, 12);
            txtLastName.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtLastName.PlaceholderText = "Last";
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
            txtPhone.AllowArabicCharacters = false;
            txtPhone.AllowEnglishCharacters = false;
            txtPhone.AllowNumbers = true;
            txtPhone.AllowSpaces = false;
            txtPhone.AllowSymbols = true;
            txtPhone.BackColor = Color.Transparent;
            txtPhone.BorderColor = Color.FromArgb(226, 232, 240);
            txtPhone.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtPhone.BorderRadius = 8;
            txtPhone.BorderSize = 1;
            txtPhone.CustomAllowedCharacters = "+-";
            txtPhone.EnableSuggest = false;
            txtPhone.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtPhone.FillColor = Color.White;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.ForeColor = Color.FromArgb(15, 23, 42);
            txtPhone.HasError = false;
            txtPhone.IconOffsetLeft = 10;
            txtPhone.IconOffsetRight = 10;
            txtPhone.IconSpacing = 8;
            txtPhone.Location = new Point(20, 245);
            txtPhone.MaxLength = 20;
            txtPhone.MaxSuggestItems = 8;
            txtPhone.MoveToNextControlOnEnter = true;
            txtPhone.Name = "txtPhone";
            txtPhone.Padding = new Padding(8, 12, 8, 12);
            txtPhone.PlaceholderColor = Color.FromArgb(148, 163, 184);
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
            txtEmail.AllowArabicCharacters = false;
            txtEmail.AllowEnglishCharacters = true;
            txtEmail.AllowNumbers = true;
            txtEmail.AllowSpaces = false;
            txtEmail.AllowSymbols = true;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BorderColor = Color.FromArgb(226, 232, 240);
            txtEmail.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtEmail.BorderRadius = 8;
            txtEmail.BorderSize = 1;
            txtEmail.CustomAllowedCharacters = "@._-";
            txtEmail.EnableSuggest = false;
            txtEmail.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtEmail.FillColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.ForeColor = Color.FromArgb(15, 23, 42);
            txtEmail.HasError = false;
            txtEmail.IconOffsetLeft = 10;
            txtEmail.IconOffsetRight = 10;
            txtEmail.IconSpacing = 8;
            txtEmail.Location = new Point(310, 245);
            txtEmail.MaxLength = 100;
            txtEmail.MaxSuggestItems = 8;
            txtEmail.MoveToNextControlOnEnter = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(8, 12, 8, 12);
            txtEmail.PlaceholderColor = Color.FromArgb(148, 163, 184);
            txtEmail.PlaceholderText = "Email Address";
            txtEmail.ShowClearButton = false;
            txtEmail.Size = new Size(450, 40);
            txtEmail.SuggestIcon = null;
            txtEmail.TabIndex = 24;
            txtEmail.UseSystemPasswordChar = false;
            txtEmail.ValidateEmail = true;
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
            txtAddress.BorderColor = Color.FromArgb(226, 232, 240);
            txtAddress.BorderFocusColor = Color.FromArgb(124, 58, 237);
            txtAddress.BorderRadius = 8;
            txtAddress.BorderSize = 1;
            txtAddress.CustomAllowedCharacters = "";
            txtAddress.EnableSuggest = false;
            txtAddress.ErrorBorderColor = Color.FromArgb(239, 68, 68);
            txtAddress.FillColor = Color.White;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.ForeColor = Color.FromArgb(15, 23, 42);
            txtAddress.HasError = false;
            txtAddress.IconOffsetLeft = 10;
            txtAddress.IconOffsetRight = 10;
            txtAddress.IconSpacing = 8;
            txtAddress.Location = new Point(20, 320);
            txtAddress.MaxLength = 500;
            txtAddress.MaxSuggestItems = 8;
            txtAddress.MoveToNextControlOnEnter = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new Padding(8, 12, 8, 12);
            txtAddress.PlaceholderColor = Color.FromArgb(148, 163, 184);
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
            btnSave.BorderRadius = 8;
            btnSave.BorderSize = 0;
            btnSave.CenterIconWithText = true;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSave.IsLoading = false;
            btnSave.LeftIcon = null;
            btnSave.Location = new Point(540, 490);
            btnSave.Name = "btnSave";
            btnSave.RightIcon = null;
            btnSave.Size = new Size(125, 42);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save Person";
            btnSave.TextOffset = new Point(0, 0);
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.BorderRadius = 8;
            btnCancel.BorderSize = 1;
            btnCancel.CenterIconWithText = false;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnCancel.IsLoading = false;
            btnCancel.LeftIcon = null;
            btnCancel.Location = new Point(675, 490);
            btnCancel.Name = "btnCancel";
            btnCancel.RightIcon = null;
            btnCancel.Size = new Size(125, 42);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.TextOffset = new Point(0, 0);
            // 
            // frmSavePerson
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(820, 550);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(pnlContainer);
            Name = "frmSavePerson";
            Text = "DVLD / People Management / Save Person";
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
    }
}