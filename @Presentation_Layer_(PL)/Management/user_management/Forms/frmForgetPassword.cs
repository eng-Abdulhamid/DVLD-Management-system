using DVLD.BLL.DTOs;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using DVLD.PL.Theme;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.Login
{
    public partial class frmForgetPassword : frmBase
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

        public frmForgetPassword(string userName = "", string customTitle = "Forget Password", bool allowEditUsername = true)
        {
            InitializeComponent();
            this.AllowMaximize = false;
            this.AllowResize = false;

            SetContextTitle("Forget or Change Password");

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
            {
                txtUserName.Text = userName;
            }

            this.Icon = Resources.iconLoginIn;

            RegisterEvents();
            SetupPasswordVisibility();
            SetupToolTips();
            ToggleFormExpansion(false);
            SwitchToUnverifiedState();
            base.ApplyTheme();
        }
        protected override bool RequiresAuthentication => false;
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
            toolTip1.SetToolTip(txtNewPassword, "Enter a new secure password");
            toolTip1.SetToolTip(txtConfirmPassword, "Re-enter new password");
            toolTip1.SetToolTip(btnChangePassword, "Commit new password");
            toolTip1.SetToolTip(btnCancel, "Cancel operation and return");
            toolTip1.SetToolTip(lnkForgotCurrentPassword, "Request password recovery");
        }

        private void RegisterEvents()
        {
            EnableWindowDragging(pnlMain);

            btnVerifyUser.Click += async (s, e) => await VerifyAccountAsync(txtUserName.Text.Trim());
            btnEditUsername.Click += BtnEditUsername_Click;
            btnChangePassword.Click += async (s, e) => await PerformPasswordChangeAsync();
            btnCancel.Click += (s, e) => Close();

            txtUserName.TextChanged += (s, e) => txtUserName.HasError = false;
            txtOldPassword.TextChanged += ClearPasswordErrors;
            txtNewPassword.TextChanged += ClearPasswordErrors;
            txtConfirmPassword.TextChanged += ClearPasswordErrors; 
            this.Load += async (s, e) =>
            {
                if (UIUtility.IsDesignMode) return;

                if (!string.IsNullOrWhiteSpace(_initialUsername))
                {
                    await VerifyAccountAsync(_initialUsername);
                }
            };

        }

        private void ToggleFormExpansion(bool expand)
        {
            int targetHeight = expand ? FORM_EXPANDED_HEIGHT : FORM_COLLAPSED_HEIGHT;
            if (this.Height == targetHeight) return;

            // Instantly snap to the correct size to avoid UI thread lag and visual tearing
            int centerY = this.Top + (this.Height / 2);
            this.Height = targetHeight;
            this.Top = centerY - (this.Height / 2);

            pnlCreateNewPassword.Visible = expand;
        }

        private void SetupPasswordVisibility()
        {
            HookPasswordToggle(txtOldPassword);
            HookPasswordToggle(txtNewPassword);
            HookPasswordToggle(txtConfirmPassword);
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

        private void SwitchToVerifiedState()
        {
            _accountVerified = true;
            txtUserName.Enabled = false;
            txtUserName.HasError = false;

            btnVerifyUser.Visible = false;
            btnVerifiedCheck.Visible = true;
            btnEditUsername.Visible = string.IsNullOrWhiteSpace(_initialUsername) || _allowEditUsername;

            SetStatusMessage("Account verified successfully.", Color.FromArgb(16, 137, 62));

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
            lblStatus.Visible = false;

            ToggleFormExpansion(false);

            txtUserName.Enabled = true;
            txtUserName.Focus();
        }

        private void ResetPasswordFields()
        {
            txtOldPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
        }

        private void SetStatusMessage(string message, Color color)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
            lblStatus.Visible = !string.IsNullOrWhiteSpace(message);
        }

        private void ClearPasswordErrors(object? sender, EventArgs e)
        {
            txtOldPassword.HasError = false;
            txtNewPassword.HasError = false;
            txtConfirmPassword.HasError = false;
        }

        private bool ValidateUsernameField()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                return TriggerFieldError(txtUserName, "Please enter your username.");
            }
            return true;
        }

        private void ToggleLoadingState(bool isLoading)
        {
            btnVerifyUser.IsLoading = isLoading;
            btnVerifyUser.Enabled = !isLoading;
            txtUserName.Enabled = !isLoading;
        }

        private async Task VerifyAccountAsync(string username)
        {
            if (_accountVerified || !ValidateUsernameField()) return;

            ToggleLoadingState(true);
            SetStatusMessage("Verifying account...", Color.FromArgb(100, 116, 139));

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

        private void BtnEditUsername_Click(object? sender, EventArgs e)
        {
            SwitchToUnverifiedState();
        }

        private async Task PerformPasswordChangeAsync()
        {
            if (!_accountVerified || _isChangingPassword || !ValidatePasswordFields()) return;

            _isChangingPassword = true;
            btnChangePassword.IsLoading = true;
            btnChangePassword.Enabled = false;
            SetStatusMessage("Updating password...", Color.FromArgb(100, 116, 139));

            var result = await _userService.ChangePasswordAsync(txtUserName.Text.Trim(), txtOldPassword.Text, txtNewPassword.Text);

            _isChangingPassword = false;
            btnChangePassword.IsLoading = false;

            if (!IsDisposed) btnChangePassword.Enabled = true;

            if (!result.IsSuccess)
            {
                HandleUpdateFailure(result.Message);
                return;
            }

            OnPasswordChange?.Invoke(txtUserName.Text.Trim(), txtNewPassword.Text);
            NotificationTheme.ShowSuccessToast("Your password has been changed successfully.", "Security Updated");
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
                SetStatusMessage(message ?? "Failed to update.", Color.FromArgb(220, 38, 38));
                NotificationTheme.ShowErrorToast(message ?? "Failed to update password.", "Update Failed");
            }
        }

        private bool ValidatePasswordFields()
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
                return TriggerFieldError(txtOldPassword, "Please enter your current password.");

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                return TriggerFieldError(txtNewPassword, "Please enter a new password.");

            if (txtNewPassword.Text.Length < 6)
                return TriggerFieldError(txtNewPassword, "Password must be at least 6 characters.");

            if (txtNewPassword.Text == txtOldPassword.Text)
                return TriggerFieldError(txtNewPassword, "New password must be different.");

            if (txtNewPassword.Text != txtConfirmPassword.Text)
                return TriggerFieldError(txtConfirmPassword, "Passwords do not match.");

            return true;
        }

        private bool TriggerFieldError(CustomizeControls.NTextBox control, string message)
        {
            control.HasError = true;
            control.Shake();
            SetStatusMessage(message, Color.FromArgb(220, 38, 38));
            control.Focus();
            return false;
        }
    }
}