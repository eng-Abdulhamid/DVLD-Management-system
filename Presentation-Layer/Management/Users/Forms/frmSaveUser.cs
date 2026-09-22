using CustomizeControls;
using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Login;
using DVLD.PL.PeopleManagement;
using DVLD.PL.Theme;
namespace DVLD.PL.UsersManagement
{
    public partial class frmSaveUser : BaseForm
    {
        private enum Mode { AddNew = 0, UpdateExisting = 1 }

        private readonly Mode _mode;
        private readonly int _userId;
        private int SelectedPersonId
        {
            get;
            set
            {
                field = value;
                btnNext.Enabled = (field > 0);
            }
        }

        private readonly UserService _userService;

        public event Action<int>? UserSaved;
        public frmSaveUser(int userId = -1)
        {
            InitializeComponent();
            SetContextTitle(_mode == Mode.AddNew ? "Add New User" : "Edit User");

            _userId = userId;
            _mode = (_userId <= 0) ? Mode.AddNew : Mode.UpdateExisting;
            _userService = new UserService();

            RegisterEvents();
            base.ApplyTheme();
        }

        #region Event Handlers
        private void RegisterEvents()
        {
            btnSearchPerson.Click += HandleSearchPersonEvent_Click;

            btnSelectPerson.Click += HandleSelectPersonEvent_Click;

            btnAddNewPerson.Click += HandleNewPersonEvent_Click;

            lnkEditPerson.LinkClicked += HandleEditPersonEvent_LinkClicked;
            lnkEditPassword.LinkClicked += HandleEditPasswordEvent_LinkClicked;

            btnNext.Click += HandleNextButtonEvent_Clicked;

            btnPrev.Click += HandlePreviousButtonEvent_Clicked;

            btnCancel.Click += CancelButton_Click;
            btnSave.Click += HandleSaveButtonEvent_Clicked;
        }
        private async void HandleSearchPersonEvent_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchNationalNo.Text)) return;

            await ctrlPersonCard1.LoadPersonInfoByNationalNoAsync(txtSearchNationalNo.Text.Trim());

            if (ctrlPersonCard1.PersonID > 0)
            {
                if (await _userService.IsPersonLinkedToUserAsync(ctrlPersonCard1.PersonID))
                {
                    NotificationTheme.ShowWarningToast("This person is already linked to an account.");
                    ctrlPersonCard1.ResetCard();
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
        }
        private void HandleSelectPersonEvent_Click(object? sender, EventArgs e)
        {
            using var selectPersonForm = new frmPeopleManagement(frmPeopleManagement.enMode.SelectPerson);
            selectPersonForm.OnPersonSelected += async (personId) =>
            {
                if (await _userService.IsPersonLinkedToUserAsync(personId))
                {
                    NotificationTheme.ShowWarningToast("This person already has an associated user account.");
                    return;
                }

                await LoadPersonInfo(personId);
            };
            selectPersonForm.ShowDialog();
        }
        private async void HandleNewPersonEvent_Click(object? sender, EventArgs e)
        {
            using frmSavePerson frm = new frmSavePerson();
            frm.PersonSaved += async (personId) =>
            {
                await LoadPersonInfo(personId);
            };
            await frm.ShowDialogAsync();
        }
        private async Task LoadPersonInfo(int personId)
        {
            SelectedPersonId = personId;
            await ctrlPersonCard1.LoadPersonInfoAsync(personId);
            lnkEditPerson.Visible = true;
        }

        private async void HandleEditPersonEvent_LinkClicked(object? sender, EventArgs e)
        {
            if (SelectedPersonId <= 0) return;
            using frmSavePerson frm = new frmSavePerson(SelectedPersonId);
            frm.PersonSaved += async (personId) => await ctrlPersonCard1.LoadPersonInfoAsync(personId);
            await frm.ShowDialogAsync();
        }
        private async void HandleEditPasswordEvent_LinkClicked(object? sender, EventArgs e)
        {
            using frmForgetPassword frm = new frmForgetPassword(txtUserName.Text.Trim(), "Edit Password");
            frm.AllowEditUsername = false;
            await frm.ShowDialogAsync();
        }
        private void HandleNextButtonEvent_Clicked(object? sender, EventArgs e)
        {
            if (SelectedPersonId <= 0)
            {
                NotificationTheme.ShowWarningToast("Please select a valid person first.");
                return;
            }

            tcWizard.SelectedTab = tpLoginInfo;
            btnPrev.Enabled = true;
            btnPrev.ApplySecondaryStyle();
            btnNext.Visible = false;
        }
        private void HandlePreviousButtonEvent_Clicked(object? sender, EventArgs e)
        {
            tcWizard.SelectedTab = tpPersonSelection;
            btnNext.Visible = true;
        }
        private void CancelButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
        private async void HandleSaveButtonEvent_Clicked(object? sender, EventArgs e)
        {
            await PerformSaveAsync();
        }
        #endregion
        private async void frmSaveUser_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_mode == Mode.AddNew)
            {
                SwitchAddMode();
            }
            else
            {
                await SwitchUpdateMode();
            }
        }
        private void SwitchAddMode()
        {
            tcWizard.SelectedTab = tpPersonSelection;
            btnSave.Enabled = false;
            btnSave.ApplyDisabledStyle();
            lnkEditPerson.Visible = false;

            ctrlInputPassword.Visible = true;
            lnkEditPassword.Visible = false;
        }
        private async Task SwitchUpdateMode()
        {
            btnSave.Text = "Update User";

            ctrlInputPassword.Visible = false;

            lnkEditPassword.Visible = true;

            await LoadUserDataAsync();
        }
        private async Task LoadUserDataAsync()
        {
            var result = await _userService.GetByIdAsync(_userId);
            if (!result.IsSuccess || result.Data == null)
            {
                NotificationTheme.ShowErrorToast("User record not found.");
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
        #region Perform Save Operations
        private async Task PerformSaveAsync()
        {
            if (!ValidateUsernameField()) return;

            UpdateSaveButtonStatus(false);
            btnSave.IsLoading = false;

            await SaveDependsOnCurrentMode();

            UpdateSaveButtonStatus(true);

        }
        private bool ValidateUsernameField()
        {
            if (!ValidateRequiredField(txtUserName))
            {
                NotificationTheme.ShowErrorToast($"Please enter your user name.", "Validation Error");
                return false;
            }
            return true;
        }
        private bool ValidateRequiredField(NTextBox txtBox)
        {
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.HasError = true;
                txtBox.Shake();
                txtBox.Focus();

                return false;
            }

            txtBox.HasError = false;
            return true;
        }
        private async Task SaveDependsOnCurrentMode()
        {
            switch (_mode)
            {
                case Mode.AddNew:
                    {
                        await AddNew();
                        break;
                    }
                case Mode.UpdateExisting:
                    {
                        await UpdateUser();
                        break;
                    }
            }
        }
        private async Task AddNew()
        {
            var dto = new UserAddDTO(SelectedPersonId, txtUserName.Text.Trim(), ctrlInputPassword.NewPassword, chkIsActive.Checked);
            var taskResult = _userService.AddAsync(dto);

            btnSave.IsLoading = true;

            var result = await taskResult;

            btnSave.IsLoading = false;

            if (result.IsSuccess)
            {
                NotificationTheme.ShowSuccessToast("User registered successfully.");
                UserSaved?.Invoke(result.Data);
                this.Close();
            }
            else
            {
                NotificationTheme.ShowWarningToast(result.Message ?? "Failed to save user.", "Registration Failed");
            }

        }
        private async Task UpdateUser()
        {
            var updatedDto = new UserUpdateDTO(_userId, SelectedPersonId, txtUserName.Text.Trim(), chkIsActive.Checked);
            var taskResult = _userService.UpdateAsync(updatedDto);

            btnSave.IsLoading = true;

            var result = await taskResult;

            btnSave.IsLoading = false;
            if (result.IsSuccess)
            {
                if (AppSession.CurrentUser?.UserID == _userId)
                {
                    AppSession.CurrentUser = new UserReadDTO()
                    {
                        UserID = updatedDto.UserID,
                        PersonID = updatedDto.PersonID,
                        IsActive = updatedDto.IsActive,
                        UserName = updatedDto.UserName
                    };
                }
                NotificationTheme.ShowSuccessToast("User updated successfully.");
                UserSaved?.Invoke(_userId);
                this.Close();
            }
            else
            {
                NotificationTheme.ShowWarningToast(result.Message ?? "Failed to update user.", "Update Failed");
            }
        }
        #endregion
        private bool CheckTextBoxsIfCanSave()
        {
            return ((!string.IsNullOrEmpty(txtUserName.Text)) &&
                ctrlInputPassword.IsValid);
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
        private void UpdateSaveButtonStatus(bool Enabled)
        {
            btnSave.Enabled = Enabled;
            btnCancel.Enabled = Enabled;
            if (Enabled) btnSave.ApplyPrimaryStyle();
            else btnSave.ApplyDisabledStyle();
        }
        private void btnSelectPerson_Click(object sender, EventArgs e)
        {

        }

        private void lnkEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HandleEditPersonEvent_LinkClicked(sender, e);
        }
    }
}