using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using NControls;
using Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLDPL.PeopleManagement
{
    public partial class frmSavePerson : Form
    {
        public frmSavePerson(int PersonID = -1)
        {
            InitializeComponent();
            InitializeGenderComboBox();
            InitializeNationalityComboBox();
            cmbNationality.Items.AddRange(new object[] { "Palestine", "Jordan" });
            personServices = new PersonServices(); 
            if (PersonID > 0)
            {
                OperationResult<PersonReadDTO> personDetailsResults = personServices.FindByPersonID(PersonID);
                if (personDetailsResults.IsSuccess)
                {
                    // Populate the form with the retrieved person data
                    PopulateForm(personDetailsResults.Data);
                    Mode = enMode.UpdateExisting;
                    _StoredPersonData = ConvertFromReadPersonToAddPersonDTO(personDetailsResults.Data);
                }
            }
        }
        enum enMode
        {
            AddNew,
            UpdateExisting
        }
        public event Action<int> PersonSaved;
        private enMode Mode = enMode.AddNew;
        PersonAddDTO _StoredPersonData = new PersonAddDTO();
        private readonly PersonServices personServices;

        private void PopulateForm(PersonReadDTO personData)
        {
            if (personData == null) return;
            txtPersonID.Text = personData.PersonID.ToString();
            txtNationalNo.Text = personData.NationalNo;
            txtFirstName.Text = personData.FirstName;
            txtSecondName.Text = personData.SecondName;
            txtThirdName.Text = personData.ThirdName;
            txtLastName.Text = personData.LastName;
            txtAdress.Text = personData.Email;
            txtPhone.Text = personData.Phone;
            dtpBirthDate.Value = personData.DateOfBirth;
            cmbGender.SelectedItem = personData.Gender.ToString();
            picPersonImage.Tag = personData.ImagePath;
            picPersonImage.Image = !string.IsNullOrEmpty(personData.ImagePath) && File.Exists(personData.ImagePath) ? Image.FromFile(personData.ImagePath) : Properties.Resources.user;
        }
        #region Initialization
        private void InitializeGenderComboBox()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new object[] { "Male", "Female" }); 
            if (cmbGender.Items.Count > 0)
                cmbGender.SelectedIndex = 0;
        }
        private void InitializeNationalityComboBox()
        {
            cmbNationality.Items.Clear();


            if (cmbNationality.Items.Count > 0)
                cmbNationality.SelectedIndex = 0;
        }
        #endregion


        #region Events
        private void ValidateControls_ValuedChanged(object sender, EventArgs e)
        {
            UpdateSubmitButtonState();
        }
        private void lblUploadNewPicutre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Person Image";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    try
                    {
                        picPersonImage.Image?.Dispose();

                        using (var stream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            picPersonImage.Image = Image.FromStream(stream);
                        }

                        picPersonImage.Tag = selectedFilePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not load the image: {ex.Message}", "Image Load Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Notification.Show("User cancelled the operation.", IconType.Info);
            this.Close();
        }
        private void MockDataForTesting_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "Abdulhamid";
            txtSecondName.Text = "Hani";
            txtThirdName.Text = "Abdulhamid";
            txtLastName.Text = "Abusaada";
            txtAdress.Text = "bodisaada@gmail.com";
            txtPhone.Text = "0597508160";
            txtNationalNo.Text = "424321651";
            dtpBirthDate.Value = new DateTime(2006, 10, 31);
            cmbNationality.SelectedIndex = 0;
        }
        #endregion


        #region Maping
        private enGender GetSelectedGender()
        {
            return enGender.Both;
        }
        private int GetSelectedNationalityCountryID()
        {
            return 1;
        }
        private int GetThePersonID()
        {
            if (txtPersonID.Text.Trim().Length > 0)
            {
                int personID;
                if (int.TryParse(txtPersonID.Text.Trim(), out personID))
                {
                    return personID;
                }
            }
            return -1;
        }
        private PersonAddDTO ConvertFromReadPersonToAddPersonDTO(PersonReadDTO personRead)
        {
            return new PersonAddDTO
            {
                FirstName = personRead.FirstName,
                SecondName = personRead.SecondName,
                ThirdName = personRead.ThirdName,
                LastName = personRead.LastName,
                DateOfBirth = personRead.DateOfBirth,
                Gender = personRead.Gender,
                Address = personRead.Address,
                Phone = personRead.Phone,
                Email = personRead.Email,
                NationalityCountryID = personRead.NationalityCountryID,
                ImagePath = personRead.ImagePath,
                NationalNo = personRead.NationalNo
            };
        }
        private PersonAddDTO CreatePersonAddDTO()
        {
            PersonAddDTO NewPersonData = new PersonAddDTO
            {
                NationalNo = txtNationalNo.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                SecondName = txtSecondName.Text.Trim(),
                ThirdName = txtThirdName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                DateOfBirth = dtpBirthDate.Value,
                Gender = GetSelectedGender(),
                Address = txtAdress.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtAdress.Text.Trim(),
                NationalityCountryID = GetSelectedNationalityCountryID(),
                ImagePath = picPersonImage.Tag as string
            };
            return NewPersonData;

        }
        private PersonUpdateDTO CreatePersonUpdateDTO()
        {
            PersonAddDTO NewPersonData = CreatePersonAddDTO();
            return new PersonUpdateDTO
            {
                PersonID = GetThePersonID(),
                FirstName = NewPersonData.FirstName,
                SecondName = NewPersonData.SecondName,
                ThirdName = NewPersonData.ThirdName,
                LastName = NewPersonData.LastName,
                DateOfBirth = NewPersonData.DateOfBirth,
                Gender = NewPersonData.Gender,
                Address = NewPersonData.Address,
                Phone = NewPersonData.Phone,
                Email = NewPersonData.Email,
                NationalityCountryID= NewPersonData.NationalityCountryID,
                ImagePath = picPersonImage.Tag as string,
                NationalNo = NewPersonData.NationalNo
            };
        }
        #endregion
        
        
        #region Validation
        private bool ValidateWhetherDataNeedsUpdateOrNot()
        {
            return
                _StoredPersonData.FirstName != txtFirstName.Text.Trim() ||
                _StoredPersonData.SecondName != txtSecondName.Text.Trim() ||
                _StoredPersonData.ThirdName != txtThirdName.Text.Trim() ||
                _StoredPersonData.LastName != txtLastName.Text.Trim() ||
                _StoredPersonData.Email != txtAdress.Text.Trim() ||
                _StoredPersonData.Phone != txtPhone.Text.Trim() ||
                _StoredPersonData.NationalNo != txtNationalNo.Text.Trim() ||
                _StoredPersonData.Gender != GetSelectedGender() ||
                _StoredPersonData.ImagePath != (picPersonImage.Tag as string);
        }
        private bool ValidateConstraintnsColumns()
        {
            if (txtNationalNo.Text != _StoredPersonData.NationalNo)
            {
                if (personServices.IsNationalNoExists(txtNationalNo.Text))
                {
                    Notification.Show("National number already exists.");
                    epValidation.SetError(txtNationalNo, "Please enter another National no.");
                    txtNationalNo.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool ValidateDateOfBirth()
        {
            if (dtpBirthDate.Value.Date >= DateTime.Now.Date)
            {
                epValidation.Clear();
                epValidation.SetError(dtpBirthDate, "Please enter a valid birth date.");
                dtpBirthDate.Focus();
                Notification.Show("Please enter a valid birth date.", IconType.Warning);
                return false;
            }
            return true;
        }
        private bool ValidateEmail()
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(txtAdress.Text.Trim());

                if (email.Address != txtAdress.Text.Trim())
                {
                    epValidation.Clear();
                    epValidation.SetError(txtAdress, "Invalid Email Address.");
                    txtAdress.Focus();
                    Notification.Show("Invalid Email Address.", IconType.Warning);
                    return false;
                }
            }
            catch
            {
                epValidation.SetError(txtAdress, "Invalid Email Address. ");
                txtAdress.Focus();
                Notification.Show("Invalid Email Address. Please try again with this format: username@domain.com", IconType.Warning);
                return false;
            }
            return true;
        }
        private bool ValidateComboBoxes()
        {
            if (cmbNationality.SelectedIndex < 0)
            {
                epValidation.Clear();
                epValidation.SetError(cmbNationality, "Please select a nationality.");
                cmbNationality.Focus();
                Notification.Show("Please select a nationality.", IconType.Warning);
                return false;
            }

            if (cmbGender.SelectedIndex < 0)
            {
                epValidation.Clear();

                epValidation.SetError(cmbGender, "Please select a gender.");
                cmbGender.Focus();
                Notification.Show("Please select a gender.", IconType.Warning);
                return false;
            }
            return true;


        }
        private bool ValidateDataBeforeSubmit()
        {
            epValidation.Clear();
            
            return ValidateDateOfBirth() && ValidateEmail() && ValidateComboBoxes() && ValidateConstraintnsColumns();
        }
        private void UpdateSubmitButtonState()
        {
            btnSubmit.Enabled = !string.IsNullOrWhiteSpace(txtNationalNo.Text) && !string.IsNullOrWhiteSpace(txtFirstName.Text) && !string.IsNullOrWhiteSpace(txtSecondName.Text) && !string.IsNullOrWhiteSpace(txtThirdName.Text) && !string.IsNullOrWhiteSpace(txtLastName.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) && !string.IsNullOrWhiteSpace(txtAdress.Text) && cmbGender.SelectedIndex >= 0 && cmbNationality.SelectedIndex >= 0 && dtpBirthDate.Value.Date < DateTime.Now.Date;
        }
        #endregion


        #region Save Person
        private void PerformAddNewPerson()
        {
            int personID = personServices.AddNew(CreatePersonAddDTO());
            if (personID > 0)
            {
                txtPersonID.Text = personID.ToString();
                Notification.Show("Person added successfully!", IconType.Success);
                this.Text = $"Update Person {personID} Details";
                Mode = enMode.UpdateExisting;
                _StoredPersonData = CreatePersonAddDTO();
                PersonSaved?.Invoke(personID);
            }
            else
            {
                Notification.Show("Failed to add person. Please check the details and try again.", IconType.Error);
            }

        }
        private void PerformUpdateExistingPerson()
        {
            int personID = GetThePersonID();
            if (personID <= 0)
            {
                Notification.Show("Please check the details and try again.", IconType.Error);
                return;
            }
            bool isUpdated = personServices.UpdateByPersonID(CreatePersonUpdateDTO());
            if (isUpdated)
            {
                Notification.Show("Person updated successfully!", IconType.Success);
                PersonSaved?.Invoke(personID);
                _StoredPersonData = CreatePersonAddDTO();

            }
            else
            {
                Notification.Show("Failed to update person. Please check the details and try again.", IconType.Error);
            }
        }

        private void Save()
        {
            if (!(ValidateDataBeforeSubmit())) return;

            if (Mode == enMode.AddNew)
            {
                PerformAddNewPerson();
            }
            else
            {
                if (ValidateWhetherDataNeedsUpdateOrNot())
                    PerformUpdateExistingPerson();
            }

        }
        #endregion

        private void lblDeletePicture_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            picPersonImage.Image = Properties.Resources.user;
            picPersonImage.Tag = "";
        }
    }
}
