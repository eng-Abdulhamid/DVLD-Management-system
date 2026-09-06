using DVLD.BLL.DTOs;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.Login
{
    public partial class frmForgetPassword : Form
    {
        private readonly UserService _userService;
        private UserReadDTO _verifiedUser;
        private bool _accountVerified = false;
        private bool _isChangingPassword = false;

        private const int FORM_COLLAPSED_HEIGHT = 310;
        private const int FORM_EXPANDED_HEIGHT = 680;

        private Image _eyeOnIcon;
        private Image _eyeOffIcon;

        public frmForgetPassword(string UserName = "")
        {
            InitializeComponent();
            _userService = new UserService();
            if (!string.IsNullOrEmpty(UserName))
            {
                txtUserName.Text = UserName;
            }
            InitializeUIUX();
            PreloadIcons();
            RegisterEvents();
            SetupPasswordVisibility();

            this.Height = FORM_COLLAPSED_HEIGHT;
            pnlCreateNewPassword.Visible = false;
            SwitchToUnverifiedState();
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void InitializeUIUX()
        {
            int cornerPreference = 2;
            DwmSetWindowAttribute(Handle, 33, ref cornerPreference, sizeof(int));

            this.Icon = Resources.iconLoginIn;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void PreloadIcons()
        {
            Color iconColor = Color.FromArgb(71, 85, 105);
            _eyeOnIcon = RecolorIcon(Resources.visibilityOn, iconColor);
            _eyeOffIcon = RecolorIcon(Resources.visibilityOff, iconColor);
        }

        private void RegisterEvents()
        {
            btnClose.Click += (s, e) => Close();
            btnMinimize.Click += (s, e) => WindowState = FormWindowState.Minimized;

            pnlMain.MouseDown += DragWindow;
            lblHeader.MouseDown += DragWindow;

            btnVerifyUser.Click += BtnVerifyUser_Click;
            btnEditUsername.Click += BtnEditUsername_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
            btnCancel.Click += (s, e) => Close();

            txtUserName.TextChanged += (s, e) => txtUserName.HasError = false;
            txtOldPassword.TextChanged += ClearPasswordErrors;
            txtNewPassword.TextChanged += ClearPasswordErrors;
            txtConfirmPassword.TextChanged += ClearPasswordErrors;

            lnkForgotCurrentPassword.LinkClicked += (s, e) => MessageBox.Show("Email recovery will be available soon.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DragWindow(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private async Task AnimateFormHeight(bool expand)
        {
            int targetHeight = expand ? FORM_EXPANDED_HEIGHT : FORM_COLLAPSED_HEIGHT;
            int step = expand ? 25 : -25;

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

        private Image RecolorIcon(Image source, Color color)
        {
            Bitmap bitmap = new Bitmap(source.Width, source.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                ColorMatrix matrix = new ColorMatrix(new float[][]
                {
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { color.R / 255f, color.G / 255f, color.B / 255f, 0, 1 }
                });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(matrix);
                    g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height), 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return bitmap;
        }

        private void SetupPasswordVisibility()
        {
            txtOldPassword.UseSystemPasswordChar = true;
            txtNewPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            txtOldPassword.AddIcon(_eyeOffIcon, NControls.IconPosition.Right, 20, 20, true, TogglePasswordVisibility);
            txtNewPassword.AddIcon(_eyeOffIcon, NControls.IconPosition.Right, 20, 20, true, TogglePasswordVisibility);
            txtConfirmPassword.AddIcon(_eyeOffIcon, NControls.IconPosition.Right, 20, 20, true, TogglePasswordVisibility);
        }

        private void TogglePasswordVisibility(NControls.NTextBox txt)
        {
            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;
            txt.ClearIcons();
            Image icon = txt.UseSystemPasswordChar ? _eyeOffIcon : _eyeOnIcon;
            txt.AddIcon(icon, NControls.IconPosition.Right, 20, 20, true, TogglePasswordVisibility);
        }

        private async void SwitchToVerifiedState()
        {
            _accountVerified = true;

            txtUserName.Enabled = false;
            txtUserName.HasError = false;

            btnVerifyUser.Visible = false;
            btnVerifiedCheck.Visible = true;
            btnEditUsername.Visible = true;

            SetStatusMessage("Account verified successfully.", Color.FromArgb(22, 163, 74));

            await AnimateFormHeight(true);
            txtOldPassword.Focus();
        }

        private async void SwitchToUnverifiedState()
        {
            _accountVerified = false;
            _verifiedUser = new();

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
                TriggerFieldError(txtUserName, "Please enter your username.");
                return false;
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
            SetStatusMessage("Verifying...", Color.FromArgb(107, 114, 128));

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
                SetStatusMessage("Error reading account data.", Color.FromArgb(220, 38, 38));
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
            SetStatusMessage("Updating password...", Color.FromArgb(107, 114, 128));

            var user = await _userService.GetByUserNameAsync(txtUserName.Text.Trim());

            OperationResult<bool> result = await _userService.ChangePasswordAsync(txtUserName.Text, txtOldPassword.Text, txtNewPassword.Text);

            _isChangingPassword = false;
            btnChangePassword.IsLoading = false;
            if (!IsDisposed) btnChangePassword.Enabled = true;

            if (!result.IsSuccess)
            {
                HandleUpdateFailure(result.Message);
                return;
            }

            MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {

        }
    }
}