using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.AppConfigration;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using DVLD.PL.Theme;
using DVLD.PL.UsersManagement;
using Timer = System.Windows.Forms.Timer;

namespace DVLD.PL.Login
{
    public partial class frmLoginForm : BaseForm
    {
        private Timer? _lockoutTimer;
        private int _failedAttempts = 0;
        private int _lockoutSecondsRemaining = 0;
        private readonly UserService _userService;
        private ToolTip? _toolTips;

        // Login screen allows unauthenticated access
        protected override bool RequiresAuthentication => false;

        public frmLoginForm()
        {
            InitializeComponent();
            AllowMaximize = false;
            AllowResize = false;
            SetContextTitle("Login");
            btnLogin.ButtonType = CustomizeControls.enButtonType.Primary;
            _userService = new UserService();
            InitializeUI();
            base.ApplyTheme();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            LoadRememberedCredentials();
            CheckTextBoxsAreNotEmpty();
        }

        private void InitializeUI()
        {
            Icon = Resources.iconLoginIn;
            RegisterEvents();
            UIUtility.SetupPasswordVisibility(txtPassword);
            SetupToolTips();
            _lockoutTimer = new Timer { Interval = 1000 };
            _lockoutTimer.Tick += LockoutTimer_Tick;
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
            _toolTips.SetToolTip(txtPassword, "Enter your password");
            _toolTips.SetToolTip(btnLogin, "Securely sign in to the system");
            _toolTips.SetToolTip(chkRememberMe, "Remember credentials securely on this device");
            _toolTips.SetToolTip(lnkForgotPassword, "Reset your account password");
            _toolTips.SetToolTip(lnkSignUp, "Register a new profile");
        }

        private void RegisterEvents()
        {
            EnableWindowDragging(this);
            EnableWindowDragging(pnlRightCanvas);
            EnableWindowDragging(lblTitle);

            txtUserName.KeyDown += TextBox_KeyDown;
            txtPassword.KeyDown += TextBox_KeyDown;
        }

        private void TextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (btnLogin.Enabled)
                {
                    btnLogin_Click(btnLogin, EventArgs.Empty);
                }
            }
        }

        private void LoadRememberedCredentials()
        {
            string rememberedUserName = HandleConfigurationFile.GetValueByKey("RememberedUserName");
            string rememberedPassword = HandleConfigurationFile.GetSecureValue("RememberedPassword");

            if (!string.IsNullOrEmpty(rememberedUserName) && !string.IsNullOrEmpty(rememberedPassword))
            {
                txtUserName.Text = rememberedUserName;
                txtPassword.Text = rememberedPassword;
                chkRememberMe.Checked = true;
            }
        }

        private void CheckTextBoxsAreNotEmpty()
        {
            if (_lockoutSecondsRemaining > 0) return;
            btnLogin.Enabled = txtUserName.Text.Trim().Length > 0 && txtPassword.Text.Length > 0;
        }

        private void HandleFailedAttempt(int maxAttempts)
        {
            _failedAttempts++;

            if (_failedAttempts >= maxAttempts)
            {
                _lockoutSecondsRemaining = Math.Min(30 * (_failedAttempts - 2), 300);
                LockoutUser();
            }
            else
            {
                lblAttemptMessage.Visible = true;
                lblAttemptsCounter.Visible = false;
                lblAttemptMessage.Text = $"Invalid credentials. Attempts left: {maxAttempts - _failedAttempts}";
                txtUserName.Focus();
            }
        }

        private void LockoutUser()
        {
            btnLogin.Enabled = false;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;

            lblAttemptMessage.Visible = true;
            lblAttemptsCounter.Visible = true;

            lblAttemptMessage.Text = "Too many failed attempts. System locked.";
            lblAttemptsCounter.Text = $"Please wait {_lockoutSecondsRemaining} seconds...";

            ////NotificationTheme.ShowWarningToast("Too many failed attempts. Access temporarily locked.", "Security Notice");
            _lockoutTimer?.Start();
        }

        private void LockoutTimer_Tick(object? sender, EventArgs e)
        {
            _lockoutSecondsRemaining--;

            if (_lockoutSecondsRemaining <= 0)
            {
                _lockoutTimer?.Stop();

                lblAttemptMessage.Visible = false;
                lblAttemptsCounter.Visible = false;

                txtUserName.Enabled = true;
                txtPassword.Enabled = true;

                CheckTextBoxsAreNotEmpty();
            }
            else
            {
                lblAttemptsCounter.Text = $"Please wait {_lockoutSecondsRemaining} seconds...";
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.IsLoading = true;
            btnLogin.Enabled = false;

            OperationResult<bool> loginResults = await _userService.AuthenticateUserAsync(txtUserName.Text.Trim(), txtPassword.Text);

            if (loginResults.IsSuccess)
            {
                _failedAttempts = 0;
                var user = await _userService.GetByUserNameAsync(txtUserName.Text.Trim());

                if (user.IsSuccess && user.Data != null)
                {
                    AppSession.CurrentUser = user.Data;

                    lblAttemptMessage.Visible = false;
                    lblAttemptsCounter.Visible = false;
                    HandleCredentialsSaving();

                    Hide();
                    using (frmMainForm mainScreen = new frmMainForm())
                    {
                        mainScreen.ShowDialog();
                    }
                    Close();
                    return;
                }
                else
                {
                    ////NotificationTheme.ShowErrorToast("Failed to load user profile.", "Login Error");
                }
            }
            else
            {
                txtPassword.Shake();
                txtUserName.Shake();
                HandleFailedAttempt(3);
            }

            btnLogin.IsLoading = false;
            CheckTextBoxsAreNotEmpty();
        }

        private void HandleCredentialsSaving()
        {
            if (chkRememberMe.Checked)
            {
                HandleConfigurationFile.SetKeyAndValue("RememberedUserName", txtUserName.Text.Trim());
                HandleConfigurationFile.SetSecureValue("RememberedPassword", txtPassword.Text);
            }
            else
            {
                HandleConfigurationFile.DeleteKey("RememberedUserName");
                HandleConfigurationFile.DeleteKey("RememberedPassword");
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxsAreNotEmpty();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxsAreNotEmpty();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using frmForgetPassword resetPasswordScreen = new frmForgetPassword(txtUserName.Text.Trim());
            resetPasswordScreen.OnPasswordChange = (username, newPassword) =>
            {
                txtUserName.Text = username;
                txtPassword.Text = newPassword;
            };
            resetPasswordScreen.ShowDialog();
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmSaveUser addNewUser = new())
            {
                addNewUser.UserSaved += (userId) =>
                {
                    var userResult = _userService.GetByIdAsync(userId).Result;
                    if (userResult.IsSuccess && userResult.Data != null)
                    {
                        txtUserName.Text = userResult.Data.UserName;
                        txtPassword.Text = string.Empty;
                        txtPassword.Focus();
                    }
                };
                addNewUser?.ShowDialog();

            }
        }
    }
}