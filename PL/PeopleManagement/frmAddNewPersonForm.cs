using CustomControls;
using DTOs;
using Services;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLDPL.PeopleManagement
{
    public partial class frmAddNewPersonForm : Form
    {
        enum enMode
        {
            AddNew,
            UpdateExisting
        }
        private enMode Mode = enMode.AddNew;
        public frmAddNewPersonForm()
        {
            InitializeComponent();
            InitializeGenderComboBox();
            InitializeNationalityComboBox();
        }
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
        private PersonAddDTO CreatePersonAddDTO()
        {
            return new PersonAddDTO
            {
                NationalNo = txtNationalNo.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                SecondName = txtSecondName.Text.Trim(),
                ThirdName = txtThirdName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                DateOfBirth = dtpBirthDate.Value,
                Gender = GetSelectedGender(),
                Address = txtEmail.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                NationalityCountryID = GetSelectedNationalityCountryID(),
                ImagePath = picPersonImage.Tag as string
            };
        }
        private PersonUpdateDTO CreatePersonUpdateDTO()
        {
            PersonAddDTO personDetails = CreatePersonAddDTO();
            return new PersonUpdateDTO
            {
                PersonID = GetThePersonID(),
                FirstName = personDetails.FirstName,
                SecondName = personDetails.SecondName,
                ThirdName = personDetails.ThirdName,
                LastName = personDetails.LastName,
                DateOfBirth = personDetails.DateOfBirth,
                Gender = personDetails.Gender,
                Address = personDetails.Address,
                Phone = personDetails.Phone,
                Email = personDetails.Email,
                NationalityCountryID= personDetails.NationalityCountryID,
                ImagePath = personDetails.ImagePath,
                NationalNo = personDetails.NationalNo
            };
        }
        private void PerformAddNewPerson()
        {
            PersonServices personServices = new PersonServices();
            int personID = personServices.AddNew(CreatePersonAddDTO());
            if (personID > 0)
            {
                txtPersonID.Text = personID.ToString();
                Notification.Show("Person added successfully!", IconType.Success);
                this.Text = $"Update Person {personID} Details";
                Mode = enMode.UpdateExisting;
            }
            else
            {
                Notification.Show("Failed to add person. Please check the details and try again.", IconType.Error);
            }

        }
        
        
        private void UpdateExistingPerson()
        {
            PersonServices personServices = new PersonServices();
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
            }
            else
            {
                Notification.Show("Failed to update person. Please check the details and try again.", IconType.Error);
            }
        }
        private bool ValidateTheTextBoxes()
        {
            epValidation.Clear();

            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                epValidation.SetError(txtNationalNo, "National Number is required.");
                txtNationalNo.Focus();
                Notification.Show("National Number is required.", IconType.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                epValidation.SetError(txtFirstName, "First Name is required.");
                txtFirstName.Focus();
                Notification.Show("First Name is required.", IconType.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                epValidation.SetError(txtSecondName, "Second Name is required.");
                txtSecondName.Focus();
                Notification.Show("Second Name is required.", IconType.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtThirdName.Text))
            {
                epValidation.SetError(txtThirdName, "Third Name is required.");
                txtThirdName.Focus();
                Notification.Show("Third Name is required.", IconType.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                epValidation.SetError(txtLastName, "Last Name is required.");
                txtLastName.Focus();
                Notification.Show("Last Name is required.", IconType.Warning);
                return false;
            }

            if (dtpBirthDate.Value.Date >= DateTime.Now.Date)
            {
                epValidation.SetError(dtpBirthDate, "Please enter a valid birth date.");
                dtpBirthDate.Focus();
                Notification.Show("Please enter a valid birth date.", IconType.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                epValidation.SetError(txtPhone, "Phone Number is required.");
                txtPhone.Focus();
                Notification.Show("Phone Number is required.", IconType.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                epValidation.SetError(txtEmail, "Email is required.");
                txtEmail.Focus();
                Notification.Show("Email is required.", IconType.Warning);
                return false;
            }

            try
            {
                var email = new System.Net.Mail.MailAddress(txtEmail.Text.Trim());

                if (email.Address != txtEmail.Text.Trim())
                {
                    epValidation.SetError(txtEmail, "Invalid Email Address.");
                    txtEmail.Focus();
                    Notification.Show("Invalid Email Address.", IconType.Warning);
                    return false;
                }
            }
            catch
            {
                epValidation.SetError(txtEmail, "Invalid Email Address.");
                txtEmail.Focus();
                Notification.Show("Invalid Email Address.", IconType.Warning);
                return false;
            }

            if (cmbNationality.SelectedIndex < 0)
            {
                epValidation.SetError(cmbNationality, "Please select a nationality.");
                cmbNationality.Focus();
                Notification.Show("Please select a nationality.", IconType.Warning);
                return false;
            }

            if (cmbGender.SelectedIndex < 0)
            {
                epValidation.SetError(cmbGender, "Please select a gender.");
                cmbGender.Focus();
                Notification.Show("Please select a gender.", IconType.Warning);
                return false;
            }

            return true;
        }
        private void PerformAddPersonOperation()
        {
            if (!ValidateTheTextBoxes()) return;

            if (Mode == enMode.AddNew)
            {
                PerformAddNewPerson();
            }
            else
            {
                UpdateExistingPerson();
            }
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformAddPersonOperation();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Notification.Show("User cancelled the operation.", IconType.Info);
            this.Close();
        }
    }
}
