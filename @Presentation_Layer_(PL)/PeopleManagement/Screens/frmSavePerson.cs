using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmSavePerson : frmBase
    {
        private enum Mode { AddNew = 0, UpdateExisting = 1 }

        private Mode _mode;
        private int _personId;
        private readonly PersonService _personService;
        private PersonReadDTO? _existingPerson;
        private ToolTip _toolTips;

        public event Action<int>? PersonSaved;

        public frmSavePerson(int personId = -1)
        {
            InitializeComponent();

            this.AllowMaximize = false;
            this.AllowResize = false;

            _personId = personId;
            _mode = (_personId <= 0) ? Mode.AddNew : Mode.UpdateExisting;
            _personService = new PersonService();

            ApplyStyles();
            RegisterEvents();
            SetupToolTips();
        }

        private void ApplyStyles()
        {
            btnSave.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();

            txtPersonID.ApplyStandardStyle();
            txtNationalNo.ApplyStandardStyle();
            txtFirstName.ApplyStandardStyle();
            txtSecondName.ApplyStandardStyle();
            txtThirdName.ApplyStandardStyle();
            txtLastName.ApplyStandardStyle();
            txtPhone.ApplyStandardStyle();
            txtEmail.ApplyStandardStyle();
            txtAddress.ApplyStandardStyle();

            cmbGender.ApplyStandardStyle();
            cmbCountry.ApplyStandardStyle();
        }

        private async void frmSavePerson_Load(object sender, EventArgs e)
        {
            PopulateInitialDropdowns();

            if (_mode == Mode.AddNew)
            {
                txtPersonID.Text = "Auto Assigned";
                dtpBirthDate.MaxDate = DateTime.Today.AddYears(-18);
                dtpBirthDate.Value = dtpBirthDate.MaxDate;
            }
            else
            {
                await LoadPersonDataAsync();
            }
        }

        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 400,
                ReshowDelay = 100,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(txtNationalNo, "Unique national identification number");
            _toolTips.SetToolTip(txtFirstName, "Enter primary name");
            _toolTips.SetToolTip(txtPhone, "Contact phone number");
            _toolTips.SetToolTip(txtEmail, "Personal or business email address");
            _toolTips.SetToolTip(btnSave, "Save and commit changes");
            _toolTips.SetToolTip(btnCancel, "Discard changes and exit");
        }

        private void RegisterEvents()
        {
            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += async (s, e) => await PerformSaveAsync();

            lnkUploadPhoto.LinkClicked += (s, e) => SelectProfileImage();
            lnkRemovePhoto.LinkClicked += (s, e) => RemoveProfileImage();
        }

        private void PopulateInitialDropdowns()
        {
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.SelectedIndex = 0;

            cmbCountry.Items.Clear();
            cmbCountry.Items.AddRange(new object[] { "Palestine", "Jordan", "Egypt", "Syria", "Lebanon" });
            cmbCountry.SelectedIndex = 0;
        }

        private async Task LoadPersonDataAsync()
        {
            OperationResult<PersonReadDTO> result = await _personService.GetByIdAsync(_personId);

            if (!result.IsSuccess || result.Data == null)
            {
                MessageBox.Show("Failed to load person data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _existingPerson = result.Data;

            txtPersonID.Text = _existingPerson.PersonID.ToString();
            txtNationalNo.Text = _existingPerson.NationalNo;
            txtFirstName.Text = _existingPerson.FirstName;
            txtSecondName.Text = _existingPerson.SecondName;
            txtThirdName.Text = _existingPerson.ThirdName;
            txtLastName.Text = _existingPerson.LastName;
            txtPhone.Text = _existingPerson.Phone;
            txtEmail.Text = _existingPerson.Email;
            txtAddress.Text = _existingPerson.Address;
            dtpBirthDate.Value = _existingPerson.DateOfBirth;
            cmbGender.SelectedItem = _existingPerson.Gendor.ToString();

            if (!string.IsNullOrWhiteSpace(_existingPerson.CountryName))
            {
                if (!cmbCountry.Items.Contains(_existingPerson.CountryName))
                {
                    cmbCountry.Items.Add(_existingPerson.CountryName);
                }
                cmbCountry.SelectedItem = _existingPerson.CountryName;
            }

            if (!string.IsNullOrWhiteSpace(_existingPerson.ImagePath) && File.Exists(_existingPerson.ImagePath))
            {
                using var stream = new FileStream(_existingPerson.ImagePath, FileMode.Open, FileAccess.Read);
                pbPersonPhoto.Image = Image.FromStream(stream);
                pbPersonPhoto.Tag = _existingPerson.ImagePath;
            }
            else
            {
                pbPersonPhoto.Image = Resources.User;
                pbPersonPhoto.Tag = string.Empty;
            }
        }

        private void SelectProfileImage()
        {
            using OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Person Photo"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using var stream = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read);
                pbPersonPhoto.Image = Image.FromStream(stream);
                pbPersonPhoto.Tag = dialog.FileName;
            }
        }

        private void RemoveProfileImage()
        {
            pbPersonPhoto.Image = Resources.User;
            pbPersonPhoto.Tag = string.Empty;
        }

        private bool ValidateFormInputs()
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                txtNationalNo.Shake();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                txtFirstName.Shake();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                txtSecondName.Shake();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                txtLastName.Shake();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.Shake();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var addr = new MailAddress(txtEmail.Text.Trim());
                    if (addr.Address != txtEmail.Text.Trim())
                    {
                        txtEmail.Shake();
                        return false;
                    }
                }
                catch
                {
                    txtEmail.Shake();
                    return false;
                }
            }

            return true;
        }

        private async Task PerformSaveAsync()
        {
            if (!ValidateFormInputs()) return;

            btnSave.IsLoading = true;
            btnSave.Enabled = false;

            Gendor selectedGender = (cmbGender.Text == "Female") ? Gendor.Female : Gendor.Male;
            string photoPath = pbPersonPhoto.Tag?.ToString() ?? string.Empty;

            if (_mode == Mode.AddNew)
            {
                PersonAddDTO addDto = new PersonAddDTO(
                    txtNationalNo.Text.Trim(),
                    txtFirstName.Text.Trim(),
                    txtSecondName.Text.Trim(),
                    txtThirdName.Text.Trim(),
                    txtLastName.Text.Trim(),
                    dtpBirthDate.Value,
                    selectedGender,
                    txtAddress.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtEmail.Text.Trim(),
                    cmbCountry.SelectedIndex + 1,
                    photoPath);

                OperationResult<int> result = await _personService.AddAsync(addDto);

                btnSave.IsLoading = false;
                btnSave.Enabled = true;

                if (result.IsSuccess && result.Data > 0)
                {
                    MessageBox.Show("Person added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PersonSaved?.Invoke(result.Data);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                PersonUpdateDTO updateDto = new PersonUpdateDTO
                {
                    PersonID = _personId,
                    NationalNo = txtNationalNo.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    SecondName = txtSecondName.Text.Trim(),
                    ThirdName = txtThirdName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    DateOfBirth = dtpBirthDate.Value,
                    Gendor = selectedGender,
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NationalityCountryID = cmbCountry.SelectedIndex + 1,
                    ImagePath = photoPath
                };

                OperationResult<bool> result = await _personService.UpdateAsync(updateDto);

                btnSave.IsLoading = false;
                btnSave.Enabled = true;

                if (result.IsSuccess)
                {
                    MessageBox.Show("Person updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PersonSaved?.Invoke(_personId);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}