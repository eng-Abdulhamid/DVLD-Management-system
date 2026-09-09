using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using System;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.Login
{
    public partial class frmForgetPassword : frmBase
    {
        private readonly UserService _userService;
        private UserReadDTO _verifiedUser;
        private bool _accountVerified = false;
        private bool _isChangingPassword = false;

        private const int FORM_COLLAPSED_HEIGHT = 310;
        private const int FORM_EXPANDED_HEIGHT = 680;

        private ToolTip? _toolTips;

        public Action<string, string>? OnPasswordChange;

        public frmForgetPassword(string UserName = "")
        {
            InitializeComponent();

            this.ApplyStandardFormTheme();
            this.AllowMaximize = false;
            this.AllowResize = false;

            _userService = new UserService();

            if (!string.IsNullOrEmpty(UserName))
            {
                txtUserName.Text = UserName;
            }

            this.Icon = Resources.iconLoginIn;

            RegisterEvents();
            SetupPasswordVisibility();
            SetupToolTips();
            ApplyStyles();

            this.Height = FORM_COLLAPSED_HEIGHT;
            pnlCreateNewPassword.Visible = false;
            SwitchToUnverifiedState();
        }

        private void ApplyStyles()
        {
            btnVerifyUser.ApplyPrimaryStyle();
            btnChangePassword.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();
            btnEditUsername.ApplySecondaryStyle();

            txtUserName.ApplyStandardStyle();
            txtOldPassword.ApplyStandardStyle();
            txtNewPassword.ApplyStandardStyle();
            txtConfirmPassword.ApplyStandardStyle();

            txtUserName.IconColor = Color.FromArgb(148, 163, 184);
            txtUserName.HoverIconColor = UITheme.Primary;
            txtOldPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtOldPassword.HoverIconColor = UITheme.Primary;
            txtNewPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtNewPassword.HoverIconColor = UITheme.Primary;
            txtConfirmPassword.IconColor = Color.FromArgb(148, 163, 184);
            txtConfirmPassword.HoverIconColor = UITheme.Primary;

            btnEditUsername.IconColor = UITheme.NeutralText;
            btnEditUsername.HoverIconColor = UITheme.TextPrimary;
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

            _toolTips.SetToolTip(txtUserName, "Enter your registered username");
            _toolTips.SetToolTip(btnVerifyUser, "Verify account existence");
            _toolTips.SetToolTip(btnEditUsername, "Change username");
            _toolTips.SetToolTip(txtOldPassword, "Enter current password");
            _toolTips.SetToolTip(txtNewPassword, "Enter a new secure password");
            _toolTips.SetToolTip(txtConfirmPassword, "Re-enter new password");
            _toolTips.SetToolTip(btnChangePassword, "Commit new password");
            _toolTips.SetToolTip(btnCancel, "Cancel operation and return");
            _toolTips.SetToolTip(lnkForgotCurrentPassword, "Request password recovery");
        }

        private void RegisterEvents()
        {
            EnableWindowDragging(pnlMain);
            EnableWindowDragging(lblHeader);

            btnVerifyUser.Click += BtnVerifyUser_Click;
            btnEditUsername.Click += BtnEditUsername_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnCancel.Click += (s, e) => Close();

            txtUserName.TextChanged += (s, e) => txtUserName.HasError = false;
            txtOldPassword.TextChanged += ClearPasswordErrors;
            txtNewPassword.TextChanged += ClearPasswordErrors;
            txtConfirmPassword.TextChanged += ClearPasswordErrors;
        }

        private async Task AnimateFormHeight(bool expand)
        {
            int targetHeight = expand ? FORM_EXPANDED_HEIGHT : FORM_COLLAPSED_HEIGHT;
            int step = expand ? 24 : -24;
            int centerY = this.Top + (this.Height / 2);

            if (expand) pnlCreateNewPassword.Visible = true;

            while ((expand && this.Height < targetHeight) || (!expand && this.Height > targetHeight))
            {
                this.Height += step;
                this.Top = centerY - (this.Height / 2);
                await Task.Delay(1);
            }

            this.Height = targetHeight;
            this.Top = centerY - (this.Height / 2);

            if (!expand) pnlCreateNewPassword.Visible = false;
        }

        private void SetupPasswordVisibility()
        {
            HookPasswordToggle(txtOldPassword);
            HookPasswordToggle(txtNewPassword);
            HookPasswordToggle(txtConfirmPassword);
        }

        private void HookPasswordToggle(NControls.NTextBox box)
        {
            box.UseSystemPasswordChar = true;
            box.RightIcon = Resources.visibilityOff;
            box.RightIconClickable = true;

            box.RightIconClick += (s, e) =>
            {
                box.UseSystemPasswordChar = !box.UseSystemPasswordChar;
                box.RightIcon = box.UseSystemPasswordChar
                    ? Resources.visibilityOff
                    : Resources.visibilityOn;
            };
        }

        private async void SwitchToVerifiedState()
        {
            _accountVerified = true;
            txtUserName.Enabled = false;
            txtUserName.HasError = false;

            btnVerifyUser.Visible = false;
            btnVerifiedCheck.Visible = true;
            btnEditUsername.Visible = true;

            SetStatusMessage("Account verified successfully.", Color.FromArgb(16, 137, 62));

            await AnimateFormHeight(true);
            txtOldPassword.Focus();
        }

        private async void SwitchToUnverifiedState()
        {
            _accountVerified = false;
            _verifiedUser = new UserReadDTO();

            btnVerifyUser.Visible = true;
            btnVerifyUser.Enabled = true;

            btnVerifiedCheck.Visible = false;
            btnEditUsername.Visible = false;

            ResetPasswordFields();
            lblStatus.Visible = false;

            await AnimateFormHeight(false);

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
            string username = txtUserName.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
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

        private async void BtnVerifyUser_Click(object? sender, EventArgs e)
        {
            if (_accountVerified || !ValidateUsernameField()) return;

            ToggleLoadingState(true);
            SetStatusMessage("Verifying account...", Color.FromArgb(100, 116, 139));

            string username = txtUserName.Text.Trim();
            var result = await _userService.GetByUserNameAsync(username);

            ToggleLoadingState(false);

            if (result == null || !result.IsSuccess || result.Data == null)
            {
                TriggerFieldError(txtUserName, "No account found with this username.");
                btnVerifyUser.Enabled = true;
                return;
            }

            if (!TryGetUserId(result.Data, out int userId))
            {
                SetStatusMessage("Error reading account details.", Color.FromArgb(220, 38, 38));
                txtUserName.Enabled = true;
                btnVerifyUser.Enabled = true;
                return;
            }

            _verifiedUser = result.Data;
            SwitchToVerifiedState();
        }

        private void BtnEditUsername_Click(object? sender, EventArgs e)
        {
            SwitchToUnverifiedState();
        }

        private async void BtnChangePassword_Click(object? sender, EventArgs e)
        {
            if (!_accountVerified || _isChangingPassword || !ValidatePasswordFields()) return;

            _isChangingPassword = true;
            btnChangePassword.IsLoading = true;
            btnChangePassword.Enabled = false;
            SetStatusMessage("Updating password...", Color.FromArgb(100, 116, 139));

            OperationResult<bool> result = await _userService.ChangePasswordAsync(txtUserName.Text.Trim(), txtOldPassword.Text, txtNewPassword.Text);

            _isChangingPassword = false;
            btnChangePassword.IsLoading = false;
            if (!IsDisposed) btnChangePassword.Enabled = true;

            if (!result.IsSuccess)
            {
                HandleUpdateFailure(result.Message);
                return;
            }

            OnPasswordChange?.Invoke(txtUserName.Text.Trim(), txtNewPassword.Text);
            UITheme.ShowSuccessToast("Your password has been changed successfully.", "Security Updated");
            Close();
        }

        private void HandleUpdateFailure(string? message)
        {
            if (message == "Last password is incorrect.")
            {
                TriggerFieldError(txtOldPassword, "Current password is incorrect.");
            }
            else
            {
                SetStatusMessage(message ?? "Failed to update.", Color.FromArgb(220, 38, 38));
                UITheme.ShowErrorToast(message ?? "Failed to update password.", "Update Failed");
            }
        }

        private bool ValidatePasswordFields()
        {
            if (string.IsNullOrWhiteSpace(txtOldPassword.Text))
                return TriggerFieldError(txtOldPassword, "Please enter your current password.");

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                return TriggerFieldError(txtNewPassword, "Please enter a new password.");

            if (txtNewPassword.Text == txtOldPassword.Text)
                return TriggerFieldError(txtNewPassword, "New password must be different.");

            if (txtNewPassword.Text != txtConfirmPassword.Text)
                return TriggerFieldError(txtConfirmPassword, "Passwords do not match.");

            return true;
        }

        private bool TriggerFieldError(NControls.NTextBox control, string message)
        {
            control.HasError = true;
            control.Shake();
            SetStatusMessage(message, Color.FromArgb(220, 38, 38));
            control.Focus();
            return false;
        }

        private bool TryGetUserId(object user, out int userId)
        {
            userId = -1;
            PropertyInfo? property = user.GetType().GetProperty("UserID")
                                  ?? user.GetType().GetProperty("UserId")
                                  ?? user.GetType().GetProperty("ID")
                                  ?? user.GetType().GetProperty("Id");

            if (property == null || property.GetValue(user) == null) return false;
            return int.TryParse(property.GetValue(user)!.ToString(), out userId);
        }
    }
}