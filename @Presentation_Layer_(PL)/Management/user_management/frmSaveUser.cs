using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Login;
using DVLD.PL.PeopleManagement;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.UsersManagement
{
    public partial class frmSaveUser : frmBase
    {
        private enum Mode { AddNew = 0, UpdateExisting = 1 }

        private readonly Mode _mode;
        private readonly int _userId;
        private int _selectedPersonId = -1;
        private readonly UserService _userService;

        public event Action<int>? UserSaved;

        public frmSaveUser(int userId = -1)
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

            _userId = userId;
            _mode = (_userId <= 0) ? Mode.AddNew : Mode.UpdateExisting;
            _userService = new UserService();

            ApplyStyles();
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnSave.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();
            btnNext.ApplyPrimaryStyle();
            btnSearchPerson.ApplySecondaryStyle();
            btnAddNewPerson.ApplySecondaryStyle();
            btnSelectPerson.ApplySecondaryStyle();

            txtUserName.ApplyStandardStyle();
            txtPassword.ApplyStandardStyle();
            txtConfirmPassword.ApplyStandardStyle();
            txtSearchNationalNo.ApplyStandardStyle();
            chkIsActive.ApplyStandardStyle();
        }

        private async void frmSaveUser_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_mode == Mode.AddNew)
            {
                lblTitle.Text = "Add New User";
                tcWizard.SelectedTab = tpPersonSelection;
                btnSave.Enabled = false;
                lnkEditPerson.Visible = false;

                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;

                lnkEditPassword.Visible = false;
                chkIsActive.Location = new Point(36, 275);
            }
            else
            {
                lblTitle.Text = "Edit User";
                btnSave.Text = "Update User";

                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                txtConfirmPassword.Visible = false;

                lnkEditPassword.Visible = true;
                lnkEditPassword.Location = new Point(36, 115);
                chkIsActive.Location = new Point(36, 160);

                await LoadUserDataAsync();
            }
        }

        private async Task LoadUserDataAsync()
        {
            var result = await _userService.GetByIdAsync(_userId);
            if (!result.IsSuccess || result.Data == null)
            {
                UITheme.ShowErrorToast("User record not found.");
                this.Close();
                return;
            }

            var user = result.Data;
            _selectedPersonId = user.PersonID;

            await ctrlPersonCard1.LoadPersonInfoAsync(_selectedPersonId);


            lnkEditPerson.Visible = true;

            txtUserName.Text = user.UserName;
            chkIsActive.Checked = user.IsActive;

            tcWizard.SelectedTab = tpLoginInfo;
            btnNext.Visible = false;
            btnSave.Enabled = true;
        }

        private void RegisterEvents()
        {
            btnSearchPerson.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchNationalNo.Text)) return;
                await ctrlPersonCard1.LoadPersonInfoByNationalNoAsync(txtSearchNationalNo.Text.Trim());
                if (ctrlPersonCard1.PersonID > 0)
                {
                    _selectedPersonId = ctrlPersonCard1.PersonID;
                    lnkEditPerson.Visible = true;
                }
            };

            btnAddNewPerson.Click += (s, e) =>
            {
                using frmSavePerson frm = new frmSavePerson();
                frm.PersonSaved += async (personId) =>
                {
                    await LoadPersonInfo(personId);
                };
                frm.ShowDialog();
            };

            lnkEditPerson.LinkClicked += (s, e) =>
            {
                if (_selectedPersonId <= 0) return;
                using frmSavePerson frm = new frmSavePerson(_selectedPersonId);
                frm.PersonSaved += async (personId) => await ctrlPersonCard1.LoadPersonInfoAsync(personId);
                frm.ShowDialog();
            };

            lnkEditPassword.LinkClicked += (s, e) =>
            {
                using frmForgetPassword frm = new frmForgetPassword(txtUserName.Text.Trim(), "Edit Password");
                frm.AllowEditUsername = false;
                frm.ShowDialog();
            };

            btnNext.Click += (s, e) =>
            {
                if (_selectedPersonId <= 0)
                {
                    UITheme.ShowWarningToast("Please select a valid person first.");
                    return;
                }
                tcWizard.SelectedTab = tpLoginInfo;
                btnSave.Enabled = true;
            };

            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += async (s, e) => await PerformSaveAsync();
        }

        private async Task PerformSaveAsync()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Shake();
                return;
            }

            btnSave.IsLoading = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            if (_mode == Mode.AddNew)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    txtPassword.Shake();
                    btnSave.IsLoading = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    txtConfirmPassword.Shake();
                    UITheme.ShowErrorToast("Passwords do not match.");
                    btnSave.IsLoading = false;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    return;
                }

                var dto = new UserAddDTO(_selectedPersonId, txtUserName.Text.Trim(), txtPassword.Text, chkIsActive.Checked);
                var result = await _userService.AddAsync(dto);

                if (result.IsSuccess)
                {
                    UITheme.ShowSuccessToast("User registered successfully.");
                    UserSaved?.Invoke(result.Data);
                    this.Close();
                }
                else
                {
                    UITheme.ShowWarningToast(result.Message ?? "Failed to save user.", "Registration Failed");
                }
            }
            else
            {
                var dto = new UserUpdateDTO(_userId, _selectedPersonId, txtUserName.Text.Trim(), chkIsActive.Checked);

                var result = await _userService.UpdateAsync(dto);

                if (result.IsSuccess)
                {
                    UITheme.ShowSuccessToast("User updated successfully.");
                    UserSaved?.Invoke(_userId);
                    this.Close();
                }
                else
                {
                    UITheme.ShowWarningToast(result.Message ?? "Failed to update user.", "Update Failed");
                }
            }

            btnSave.IsLoading = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void SelectPerson_Click(object sender, EventArgs e)
        {
            using(var selectPersonForm = new frmPeopleManagement(frmPeopleManagement.enMode.SelectPerson))
            {
                selectPersonForm.OnPersonSelected += async (personId) =>
                {
                    await LoadPersonInfo(personId);
                };
                selectPersonForm.ShowDialog();
            }
        }
        private async Task LoadPersonInfo(int personId)
        {
            _selectedPersonId = personId;
            await ctrlPersonCard1.LoadPersonInfoAsync(personId);
            lnkEditPerson.Visible = true;
        }
    }
}