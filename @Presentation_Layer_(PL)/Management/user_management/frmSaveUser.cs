using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.PeopleManagement;
using static DVLD.PL.Global.UITheme;

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
            }
            else
            {
                lblTitle.Text = "Edit User";
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

            // Lock person search and show direct edit link
            gbSearchFilter.Enabled = false;
            lnkEditPerson.Visible = true;

            txtUserName.Text = user.UserName;
            chkIsActive.Checked = user.IsActive;

            // Password cannot be changed from general edit form
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            txtPassword.PlaceholderText = "••••••••";
            txtConfirmPassword.PlaceholderText = "••••••••";

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
                    _selectedPersonId = personId;
                    await ctrlPersonCard1.LoadPersonInfoAsync(personId);
                    lnkEditPerson.Visible = true;
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

            try
            {
                if (_mode == Mode.AddNew)
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        txtPassword.Shake();
                        return;
                    }

                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        txtConfirmPassword.Shake();
                        UITheme.ShowErrorToast("Passwords do not match.");
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
                        UITheme.ShowWarningToast(result.Message, "Registration Failed");
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
                        UITheme.ShowWarningToast(result.Message, "Update Failed");
                    }
                }
            }
            finally
            {
                btnSave.IsLoading = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }
    }
}