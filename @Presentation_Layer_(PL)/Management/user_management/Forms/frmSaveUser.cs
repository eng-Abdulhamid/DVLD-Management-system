using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Login;
using DVLD.PL.PeopleManagement;
using NControls;
using System;
using System.Drawing;
using System.Linq.Expressions;
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

        private int SelectedPersonId
        {
            get => _selectedPersonId;
            set
            {
                _selectedPersonId = value;
                btnNext.Enabled = (_selectedPersonId > 0);
            }
        }

        private readonly UserService _userService;

        public event Action<int>? UserSaved;

        public frmSaveUser(int userId = -1)
        {
            InitializeComponent();
            this.ApplyStandardFormTheme();

            _userId = userId;
            _mode = (_userId <= 0) ? Mode.AddNew : Mode.UpdateExisting;
            _userService = new UserService();

            SetContextTitle(_mode == Mode.AddNew ? "Add New User" : "Edit User");
            ApplyStyles();
            RegisterEvents();
        }

        private void ApplyStyles()
        {
            btnSave.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();
            btnNext.ApplySecondaryStyle();
            btnPrev.ApplySecondaryStyle();
            btnSearchPerson.ApplySecondaryStyle();
            btnAddNewPerson.ApplySecondaryStyle();
            btnSelectPerson.ApplySecondaryStyle();

            txtUserName.ApplyStandardStyle();
            txtPassword.ApplyStandardStyle();
            txtConfirmPassword.ApplyStandardStyle();
            txtSearchNationalNo.ApplyStandardStyle();
            chkIsActive.ApplyStandardStyle();
        }
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == (Keys.Enter)) 
        //    {
        //        _ = PerformSaveAsync();
        //        return true; 
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private async void frmSaveUser_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_mode == Mode.AddNew)
            {
                tcWizard.SelectedTab = tpPersonSelection;
                btnSave.Enabled = false;
                btnSave.ApplyDisabledStyle();
                lnkEditPerson.Visible = false;

                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblConfirmPassword.Visible = true;
                txtConfirmPassword.Visible = true;

                lnkEditPassword.Visible = false;
            }
            else
            {
                btnSave.Text = "Update User";

                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblConfirmPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                chkIsActive.Location = new Point(186, 124);
                lnkEditPassword.Visible = true;

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
            SelectedPersonId = user.PersonID;

            await ctrlPersonCard1.LoadPersonInfoAsync(SelectedPersonId);

            lnkEditPerson.Visible = true;
            txtUserName.Text = user.UserName;
            chkIsActive.Checked = user.IsActive;

            tcWizard.SelectedTab = tpLoginInfo;
            btnNext.Visible = false;
            btnSave.Enabled = true;
            btnSave.ApplyPrimaryStyle();
        }

        private void RegisterEvents()
        {
            btnSearchPerson.Click += async (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearchNationalNo.Text)) return;

                await ctrlPersonCard1.LoadPersonInfoByNationalNoAsync(txtSearchNationalNo.Text.Trim());

                if (ctrlPersonCard1.PersonID > 0)
                {
                    if (await _userService.IsPersonLinkedToUserAsync(ctrlPersonCard1.PersonID))
                    {
                        UITheme.ShowWarningToast("This person is already linked to an account.");
                        SelectedPersonId = -1;
                        return;
                    }

                    SelectedPersonId = ctrlPersonCard1.PersonID;
                    lnkEditPerson.Visible = true;
                }
                else
                {
                    SelectedPersonId = -1;
                }
            };

            btnSelectPerson.Click += SelectPerson_Click;

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
                if (SelectedPersonId <= 0) return;
                using frmSavePerson frm = new frmSavePerson(SelectedPersonId);
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
                if (SelectedPersonId <= 0)
                {
                    UITheme.ShowWarningToast("Please select a valid person first.");
                    return;
                }

                tcWizard.SelectedTab = tpLoginInfo;
                btnPrev.Enabled = true;
                btnPrev.ApplySecondaryStyle();
                btnNext.Visible = false;
            };

            btnPrev.Click += (s, e) =>
            {
                tcWizard.SelectedTab = tpPersonSelection;
                btnNext.Visible = true;
            };

            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += async (s, e) => await PerformSaveAsync();
        }
        private void CheckPasswordSimilarity()
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                txtConfirmPassword.Shake();
                UITheme.ShowErrorToast("Passwords do not match.");
            }
        }
        private async Task AddNew()
        {
            var dto = new UserAddDTO(SelectedPersonId, txtUserName.Text.Trim(), txtPassword.Text, chkIsActive.Checked);
            var taskResult = _userService.AddAsync(dto);

            btnSave.IsLoading = true;

            var result = await taskResult;

            btnSave.IsLoading = false;

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
        private async Task UpdatePerson()
        {
            var dto = new UserUpdateDTO(_userId, SelectedPersonId, txtUserName.Text.Trim(), chkIsActive.Checked);
            var taskResult = _userService.UpdateAsync(dto);

            btnSave.IsLoading = true;

            var result = await taskResult;

            btnSave.IsLoading = false;
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
        private void UpdateSaveButtonStatus(bool Enabled)
        {
            btnSave.Enabled = Enabled;
            btnCancel.Enabled = Enabled;
            if (Enabled) btnSave.ApplyPrimaryStyle();
            else btnSave.ApplyDisabledStyle();
        }
        private async Task PerformSaveAsync()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                txtUserName.Shake();
                return;
            }
            UpdateSaveButtonStatus(false);
            btnSave.IsLoading = false;
            switch (_mode)
            {
                case Mode.AddNew:
                    {
                        if (string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            txtPassword.Shake();
                            return;
                        }

                        CheckPasswordSimilarity();

                        await AddNew(); 
                        break;
                    }
                case Mode.UpdateExisting:
                    {
                        await UpdatePerson();
                        break;
                    }
            }
            UpdateSaveButtonStatus(true);
            
        }

        private void SelectPerson_Click(object? sender, EventArgs e)
        {
            using var selectPersonForm = new frmPeopleManagement(frmPeopleManagement.enMode.SelectPerson);
            selectPersonForm.OnPersonSelected += async (personId) =>
            {
                if (await _userService.IsPersonLinkedToUserAsync(personId))
                {
                    UITheme.ShowWarningToast("This person already has an associated user account.");
                    return;
                }

                await LoadPersonInfo(personId);
            };
            selectPersonForm.ShowDialog();
        }

        private async Task LoadPersonInfo(int personId)
        {
            SelectedPersonId = personId;
            await ctrlPersonCard1.LoadPersonInfoAsync(personId);
            lnkEditPerson.Visible = true;
        }

        private bool CheckTextBoxsIfCanSave()
        {
            return (
                (!string.IsNullOrEmpty(txtUserName.Text)) &&
                (!string.IsNullOrEmpty(txtPassword.Text)) &&
                (!string.IsNullOrEmpty(txtConfirmPassword.Text))
                );
        }

        private void CheckTextBoxsIfCanSave_TextChange(object sender, EventArgs e)
        {
            UpdateSaveButtonStatus
                (
                    _mode == Mode.AddNew ?
                    CheckTextBoxsIfCanSave() :
                    !string.IsNullOrEmpty(txtUserName.Text)
                );
        }
    }
}