using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using DVLD.PL.Theme;
using System.ComponentModel;

namespace DVLD.PL.Login
{
    public partial class frmForgetPassword : BaseForm
    {
        private readonly UserService _userService;
        private UserReadDTO _verifiedUser = new();
        private bool _accountVerified = false;
        private bool _isChangingPassword = false;
        private readonly string _initialUsername;
        private bool _allowEditUsername = false;

        private const int FORM_COLLAPSED_HEIGHT = 310;
        private const int FORM_EXPANDED_HEIGHT = 680;

        public Action<string, string>? OnPasswordChange;

        [Category("Behavior")]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowEditUsername
        {
            get => _allowEditUsername;
            set
            {
                _allowEditUsername = value;
                if (_accountVerified)
                {
                    btnEditUsername.Visible = string.IsNullOrWhiteSpace(_initialUsername) || _allowEditUsername;
                }
            }
        }
        protected override bool RequiresAuthentication => false;

        public frmForgetPassword(string userName = "", string customTitle = "Forget Password", bool allowEditUsername = true)
        {
            InitializeComponent();
            SetContextTitle("Forget or Change Password");
            if (!UIUtility.IsDesignMode)
            {
                _userService = new UserService();
                _initialUsername = userName;
                _allowEditUsername = allowEditUsername;
                btnVerifiedCheck.Enabled = false;

                if (!string.IsNullOrWhiteSpace(customTitle))
                {
                    this.Text = customTitle;
                    headerControl.TitleText = customTitle;
                }

                if (!string.IsNullOrEmpty(userName))
                    txtUserName.Text = userName;


                RegisterEvents();
                HookPasswordToggle(txtOldPassword);
                SetupToolTips();
                ToggleFormExpansion(false);
                SwitchToUnverifiedState();
                base.ApplyTheme();
            }
        }
        private void RegisterEvents()
        {
            EnableWindowDragging(pnlMain);

            btnVerifyUser.Click += async (s, e) => await VerifyAccountAsync(txtUserName.Text.Trim());
            btnEditUsername.Click += BtnEditUsername_Click;
            btnChangePassword.Click += btnChangePassword_Click;
            btnCancel.Click += BtnCancel_Click; ;

            txtUserName.TextChanged += TxtUserName_TextChanged; ;
            txtOldPassword.TextChanged += OldPassword_TextChange;
            this.Load += FrmForgetPassword_Load; 
        }
        private void OldPassword_TextChange(object? sender, EventArgs e)
        {
            txtOldPassword.HasError = false;
        }
        private void BtnEditUsername_Click(object? sender, EventArgs e)
        {
            SwitchToUnverifiedState();
        }
        private async void btnChangePassword_Click(object? sender, EventArgs e)
        {
            await PerformPasswordChangeAsync();
        }
        private async void FrmForgetPassword_Load(object? sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (!string.IsNullOrWhiteSpace(_initialUsername))
            {
                await VerifyAccountAsync(_initialUsername);
            }
        }
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }
        private void TxtUserName_TextChanged(object? sender, EventArgs e)
        {
            txtUserName.HasError = false;
        }
        private void HookPasswordToggle(CustomizeControls.NTextBox box)
        {
            box.UseSystemPasswordChar = true;
            box.RightIcon = Resources.visibilityOff;
            box.RightIconClickable = true;

            box.RightIconClick += (s, e) =>
            {
                box.UseSystemPasswordChar = !box.UseSystemPasswordChar;
                box.RightIcon = box.UseSystemPasswordChar ? Resources.visibilityOff : Resources.visibilityOn;
            };
        }
        private void SetupToolTips()
        {
            toolTip1.InitialDelay = 400;
            toolTip1.ReshowDelay = 100;
            toolTip1.UseAnimation = true;
            toolTip1.UseFading = true;

            toolTip1.SetToolTip(txtUserName, "Enter your registered username");
            toolTip1.SetToolTip(btnVerifyUser, "Verify account existence");
            toolTip1.SetToolTip(btnEditUsername, "Change username");
            toolTip1.SetToolTip(txtOldPassword, "Enter current password");
            toolTip1.SetToolTip(btnChangePassword, "Commit new password");
            toolTip1.SetToolTip(btnCancel, "Cancel operation and return");
            toolTip1.SetToolTip(lnkForgotCurrentPassword, "Request password recovery");
        }
        private void ToggleFormExpansion(bool expand)
        {
            int targetHeight = expand ? FORM_EXPANDED_HEIGHT : FORM_COLLAPSED_HEIGHT;
            if (this.Height == targetHeight) return;

            int centerY = this.Top + (this.Height / 2);
            this.Height = targetHeight;
            this.Top = centerY - (this.Height / 2);

            pnlCreateNewPassword.Visible = expand;
        }
        private void SwitchToVerifiedState()
        {
            _accountVerified = true;
            txtUserName.Enabled = false;
            txtUserName.HasError = false;

            btnVerifyUser.Visible = false;
            btnVerifiedCheck.Visible = true;
            btnEditUsername.Visible = string.IsNullOrWhiteSpace(_initialUsername) || _allowEditUsername;

            ToggleFormExpansion(true);
            txtOldPassword.Focus();
        }
        private void SwitchToUnverifiedState()
        {
            _accountVerified = false;
            _verifiedUser = new UserReadDTO();

            btnVerifyUser.Visible = true;
            btnVerifyUser.Enabled = true;

            btnVerifiedCheck.Visible = false;
            btnEditUsername.Visible = false;

            ResetPasswordFields();

            ToggleFormExpansion(false);

            txtUserName.Enabled = true;
            txtUserName.Focus();
        }
        private void ResetPasswordFields()
        {
            txtOldPassword.Text = string.Empty;
            ctrlPasswordInput.ResetPassword();
        }
        private bool ValidateUsernameField()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                TriggerFieldError(txtUserName, "Please enter your username.");
                return false;
            }
            return true;
        }      
        private async Task VerifyAccountAsync(string username)
        {
            if (_accountVerified || !ValidateUsernameField()) return;

            ToggleLoadingState(true);

            var result = await _userService.GetByUserNameAsync(username);

            ToggleLoadingState(false);

            if (!result.IsSuccess || result.Data == null)
            {
                TriggerFieldError(txtUserName, result.Message ?? "No account found with this username.");
                return;
            }

            _verifiedUser = result.Data;

            SwitchToVerifiedState();
        }
        private void ToggleLoadingState(bool isLoading)
        {
            btnVerifyUser.IsLoading = isLoading;
            btnVerifyUser.Enabled = !isLoading;
            txtUserName.Enabled = !isLoading;
        }
        private async Task PerformPasswordChangeAsync()
        {
            if (!_accountVerified || _isChangingPassword || !ctrlPasswordInput.ValidatePassword()) return;

            _isChangingPassword = true;
            btnChangePassword.IsLoading = true;
            btnChangePassword.Enabled = false;

            var result = await _userService.ChangePasswordAsync(txtUserName.Text.Trim(), txtOldPassword.Text, ctrlPasswordInput.NewPassword);

            _isChangingPassword = false;
            btnChangePassword.IsLoading = false;

            if (!IsDisposed) btnChangePassword.Enabled = true;

            if (!result.IsSuccess)
            {
                HandleUpdateFailure(result.Message);
                return;
            }

            OnPasswordChange?.Invoke(txtUserName.Text.Trim(), ctrlPasswordInput.NewPassword);
            NotificationTheme.ShowSuccessToast("Your password has been changed successfully.", "Update");
            Close();
        }

        private void HandleUpdateFailure(string? message)
        {
            if (message?.Contains("Last password is incorrect", StringComparison.OrdinalIgnoreCase) == true)
            {
                TriggerFieldError(txtOldPassword, "Current password is incorrect.");
            }
            else
            {
                NotificationTheme.ShowErrorToast(message ?? "Failed to update password.", "Update Failed");
            }
        }
        private void TriggerFieldError(CustomizeControls.NTextBox control, string message)
        {
            control.HasError = true;
            control.Shake();
            NotificationTheme.ShowErrorToast(message, "Validation Error");
            control.Focus();
        }

        

    }
}