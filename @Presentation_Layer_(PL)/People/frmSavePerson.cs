using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using DVLDPL.Properties;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLDPL
{
    public partial class frmSavePerson : Form
    {
        private string _imagePath = "";
        private enMode _Mode;
        IPersonServices _PersonServices = new PersonServices();
        private enMode Mode
        {
            get => _Mode;
            set
            {
                _Mode = value;
                switch (_Mode)
                {
                    case enMode.AddNew:
                    {
                        this.Text = "Add New Person";
                        this.lblTitle.Text = "Add New Person";
                        pbTitle.Image = Resources.user_add_21995;
                        break;
                    }
                    case enMode.Edit:
                    {
                        this.Text = "Edit Person";
                        this.lblTitle.Text = "Edit Person";
                        pbTitle.Image = Resources.user_edit_21991;
                        break;
                    }
            }
        }
        }
        public Action<int> onSaveSuccessfully;
        public enum enMode { AddNew = 1, Edit = 2 }
        private void _FillPersonInfoToControls(PersonReadDTO Person)
        {
            txtAddress.Text = Person.Address;
            txtEmail.Text = Person.Email;
            txtFirstName.Text = Person.FirstName;
            txtLastName.Text = Person.LastName;
            txtSecondName.Text = Person.SecondName;
            txtThirdName.Text = Person.ThirdName;
            txtPhone.Text = Person.Phone;
            txtNationalNo.Text = Person.NationalNo;
            if(Person.Gendor == enGendor.Male)
            {
                rbMale.Checked= true;
            }
            else
            {
                rbFemale.Checked = false;
            }
            dtpDateOfBirth.Text = Person.DateOfBirth.ToString("M/dd/yyyy");
            ICountryServices Services = new CountryServices();
            OperationResult<CountryReadDTO> result = Services.FindByCountryID(Person.NationalityCountryID); 
            if (result.IsSuccess)
            {
                int Counter = 0;
                foreach (string country in cbCountriesList.Items)
                {
                    if (country == result.Data.CountryName)
                    {
                        cbCountriesList.SelectedIndex = Counter;
                        break;
                    }
                    Counter++;
                }
            }
            if (!string.IsNullOrEmpty(Person.ImagePath))
            {
                pbPersonalImage.ImageLocation = Person.ImagePath;
            }
        }
        public frmSavePerson(int PersonID = -1)
        {
            InitializeComponent();
            InitializeForm();
            rbMale.Checked = true;
            if (PersonID == -1)
            {
                this.Mode = enMode.AddNew;
                lblPersonIDValue.Text = "N/A";
            }
            else
            {
                this.Mode = enMode.Edit;
                lblPersonIDValue.Text = PersonID.ToString();
                OperationResult<PersonReadDTO> result = _PersonServices.FindByPersonID(PersonID);
                if (result.IsSuccess)
                {
                    _FillPersonInfoToControls(result.Data);
                }
            }

        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_imagePath))
            {
                pbPersonalImage.Image = rbMale.Checked ? Resources.man : Resources.woman;
            }
        }
        private void _FillCountriesInComboBox()
        {
            ICountryServices Services = new CountryServices();
            OperationResults<CountryReadDTO> result = Services.GetAllWithoutFilter();
            if (result.IsSuccess)
            {
                if (result.DataList.Count > 0)
                {
                    int Counter = 0;
                    int PalestineIndex = 0;
                    foreach(string CountryName in result.DataList.Select(c => c.CountryName))
                    {
                        cbCountriesList.Items.Add(CountryName);
                        if (CountryName == "State of Palestine")
                        {
                            PalestineIndex = Counter;
                        }
                        Counter++;
                    }
                    cbCountriesList.SelectedIndex = PalestineIndex;
                }
                else
                {
                    cbCountriesList.Items.Add("--");
                    cbCountriesList.SelectedIndex = 0;
                }
            }
        }
        #region Methods
        private void InitializeForm()
        {
            // Configure DateTimePicker to show only date
            dtpDateOfBirth.Format = DateTimePickerFormat.Short;
            dtpDateOfBirth.ShowUpDown = false;
            dtpDateOfBirth.Value = DateTime.Now.AddYears(-25);

            // Add event handlers for validation
            txtFirstName.TextChanged += ValidateField;
            txtSecondName.TextChanged += ValidateField;
            txtLastName.TextChanged += ValidateField;
            txtNationalNo.TextChanged += ValidateField;
            txtPhone.TextChanged += ValidatePhoneField;
            txtEmail.TextChanged += ValidateEmailField;
            txtAddress.TextChanged += ValidateField;
            // LinkLabel for image
            llblSetImage.LinkClicked += LlblSetImage_LinkClicked;
            llblRemoveImage.LinkClicked += LlblRemoveImage_LinkClicked;

            // Buttons
            btnCancel.Click += (s, e) => this.Close();

            // Hide warning label initially
            lblWarning.Visible = false;
            
            _FillCountriesInComboBox();

        }

        private void ValidateField(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt != null)
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    txt.BackColor = Color.FromArgb(255, 240, 245);
                    errorProvider.SetError(txt, "This field is required");
                }
                else
                {
                    txt.BackColor = Color.White;
                    errorProvider.SetError(txt, "");
                }
            }
        }

        private void ValidatePhoneField(object sender, EventArgs e)
        {
            txtPhone.Text = _GetOnlyIntFromString(txtPhone.Text);
            TextBox txt = txtPhone;
            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (!Regex.IsMatch(txt.Text, @"^\d{7,}$"))
                {
                    txt.BackColor = Color.FromArgb(255, 240, 245);
                    errorProvider.SetError(txt, "Phone must contain only numbers (7+ digits)");
                }
                else
                {
                    txt.BackColor = Color.White;
                    errorProvider.SetError(txt, "");
                }
            }
            else
            {
                txt.BackColor = Color.FromArgb(255, 240, 245);
                errorProvider.SetError(txt, "This field is required");
            }
        }

        private void ValidateEmailField(object sender, EventArgs e)
        {
            TextBox txt = txtEmail;
            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (!Regex.IsMatch(txt.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    txt.BackColor = Color.FromArgb(255, 240, 245);
                    errorProvider.SetError(txt, "Invalid email format");
                }
                else
                {
                    txt.BackColor = Color.White;
                    errorProvider.SetError(txt, "");
                }
            }
            else
            {
                txt.BackColor = Color.White;
                errorProvider.SetError(txt, "");
            }
        }

        private void LlblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                ofd.Title = "Select Person Image";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _imagePath = ofd.FileName;
                        pbPersonalImage.Image = System.Drawing.Image.FromFile(_imagePath);
                    }
                    catch (Exception ex)
                    {
                        Notification.Show("Can't uploading image!", type: IconType.Error, 1);
                    }
                }
            }
        }

        private void LlblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _imagePath = "";
            //pbPersonalImage.Image = rbMale.Checked ? Resources.man : Resources.woman;
        }
        private string _GetOnlyIntFromString(string str)
        {
            string intOnly = "";
            for(int i = 0;i<str.Length;i++)
            {
                if (char.IsDigit(str[i]) || ((str[i] == '+') && (i == 0)))
                {
                    intOnly += str[i];
                }
            }
            return intOnly;
        }
        private bool ValidateAllFields()
        {
            bool isValid = true;

            // Validate required text fields
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.FromArgb(255, 240, 245);
                isValid = false;
                errorProvider.SetError(txtFirstName, "First Name should't be empty!");
            }
            else
            {
                errorProvider.SetError(txtFirstName, "");
            }

            if (string.IsNullOrEmpty(txtSecondName.Text))
            {
                txtSecondName.BackColor = Color.FromArgb(255, 240, 245);
                isValid = false;
                errorProvider.SetError(txtSecondName, "Second Name should't be empty!");

            }
            else
            {
                errorProvider.SetError(txtSecondName, "");
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                txtLastName.BackColor = Color.FromArgb(255, 240, 245);
                isValid = false;
                errorProvider.SetError(txtLastName, "Last Name should't be empty!");

            }
            else
            {
                errorProvider.SetError(txtLastName, "");
            }


            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                txtNationalNo.BackColor = Color.FromArgb(255, 240, 245);
                isValid = false;
                errorProvider.SetError(txtNationalNo, "National No. should't be empty!");

            }
            else
            {
                errorProvider.SetError(txtNationalNo, "");
            }


            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                txtAddress.BackColor = Color.FromArgb(255, 240, 245);
                errorProvider.SetError(txtAddress, "Address should't be empty!");
                isValid = false;

            }
            else
            {
                errorProvider.SetError(txtAddress, "");
            }
            // Validate phone
            if (string.IsNullOrEmpty(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text, @"^\d{7,}$"))
            {
                txtPhone.BackColor = Color.FromArgb(255, 240, 245);
                isValid = false;
                errorProvider.SetError(txtPhone, "Phone should't be empty/At least 7+ digits.");
            }
            else
            {
                errorProvider.SetError(txtPhone, "");
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                // Validate email
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    txtEmail.BackColor = Color.FromArgb(255, 240, 245);
                    isValid = false;
                    errorProvider.SetError(txtEmail, "Email should't be empty/Check if email is valid.");

                }
                else
                {
                    errorProvider.SetError(txtEmail, "");

                }

            }
            // Validate Gendor
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                isValid = false; 
                errorProvider.SetError(rbMale, "Please select your gendor.");
                errorProvider.SetError(rbFemale, "Please select your gendor.");

            }
            else
            {
                errorProvider.SetError(rbMale, "");
                errorProvider.SetError(rbFemale, "");

            }


            // Validate country
            if (cbCountriesList.SelectedIndex == -1)
            {
                errorProvider.SetError(rbMale, "Please select your country.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(rbMale, "");
            }
            return isValid;
        }

        #endregion
        
        private int _GetCountryIDFromCountryNameSelected()
        {
            ICountryServices Services = new CountryServices();
            OperationResults<CountryReadDTO> result = Services.GetByFilter
                (
                    new SearchCriteria<CountryServices.enFields>()
                    {
                        OrderBy = CountryServices.enFields.CountryName,
                        SearchBy = CountryServices.enFields.CountryName,
                        SearchType = enSearchType.Contain,
                        SearchString = cbCountriesList.Text,
                        PageNumber = 0,
                        SizeInEveryPage = 5
                    }
                );

            if (result.IsSuccess)
            {
                return result.DataList[0].CountryID;
            }
            else
                return -1;
        }

        private bool _AddNewPerson()
        {
            bool isAddedd = false;
            PersonAddDTO NewPerson = new PersonAddDTO()
            {
                NationalNo = txtNationalNo.Text,
                FirstName = txtFirstName.Text,
                SecondName = txtSecondName.Text,
                ThirdName = txtThirdName.Text,
                LastName = txtLastName.Text,
                DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text),
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                NationalityCountryID = _GetCountryIDFromCountryNameSelected(),
                ImagePath = _imagePath
            };
            NewPerson.Gendor = rbMale.Checked ? enGendor.Male : enGendor.Female;
            PersonServices PServices = new PersonServices();
            int PersonID = PServices.AddNew(NewPerson);
            if (PersonID > 0)
            {
                lblPersonIDValue.Text = PersonID.ToString();
                this.Mode = enMode.Edit;
                onSaveSuccessfully?.Invoke(PersonID);
                isAddedd = true;
            }
            return isAddedd;
        }
        private bool _EditPerson()
        {
            bool isEdited = false;
            PersonUpdateDTO Person = new PersonUpdateDTO();
            lblPersonIDValue.Text = _GetOnlyIntFromString(lblPersonIDValue.Text);
            Person.PersonID = Convert.ToInt32(lblPersonIDValue.Text);
            if (!string.IsNullOrEmpty(lblPersonIDValue.Text))
            {
                OperationResult<PersonReadDTO> result = _PersonServices.FindByPersonID(Convert.ToInt32(lblPersonIDValue.Text));
                if (result.IsSuccess)
                {
                    
                    Person.Email = txtEmail.Text;
                    Person.Phone = txtPhone.Text;
                    Person.FirstName = txtFirstName.Text;
                    Person.SecondName = txtSecondName.Text;
                    Person.ThirdName = txtThirdName.Text;
                    Person.Gendor = rbMale.Checked ? enGendor.Male : enGendor.Female;
                    Person.LastName = txtLastName.Text;
                    Person.Address = txtAddress.Text;
                    Person.DateOfBirth = Convert.ToDateTime(dtpDateOfBirth.Text);
                    Person.NationalNo = txtNationalNo.Text;
                    Person.NationalityCountryID = _GetCountryIDFromCountryNameSelected();
                    Person.ImagePath = _imagePath;
                    isEdited = _PersonServices.UpdateByPersonID(Person);
                    if (isEdited)
                    {
                        onSaveSuccessfully?.Invoke(Person.PersonID);
                        Notification.Show("Person Updated successfully", type:IconType.Success, 1);
                    }
                    else
                    {
                        Notification.Show("Person Not Updated!", type: IconType.Error, 1);
                    }
                }
                else
                {
                    Notification.Show("This Person is not Exist in the System!", type: IconType.Error, 1);
                    isEdited = false;
                }
            }            
            return isEdited;
        }
        private bool _SavePerson()
        {
            bool IsSave = false;
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        IsSave = _AddNewPerson();
                        break;
                    }
                case enMode.Edit:
                    {
                        IsSave = _EditPerson();
                        break;
                    }
            }
            return IsSave;
        }
        private void frmSavePerson_Load(object sender, EventArgs e)
        {
            string minimumDate = DateTime.Now.AddYears(-18).ToString("M/dd/yyyy");
            dtpDateOfBirth.MinDate = Convert.ToDateTime(minimumDate);
        }

        private void setImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LlblSetImage_LinkClicked(null, null);
        }

        private void removeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LlblRemoveImage_LinkClicked(null, null);
        }
        private void Save()
        {
            if (!ValidateAllFields())
            {
                lblWarning.Text = "⚠ Please fill all required fields correctly";
                lblWarning.Visible = true;
                return;
            }

            _SavePerson();
            lblWarning.Visible = false;

        }
        private void btnSaveDontBackHome_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnSaveBackToHome_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
    }
}
