using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Configuration;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using Timer = System.Windows.Forms.Timer;
using static DVLD.PL.Global.AppSession;

namespace DVLD.PL.Login
{
    public partial class frmLoginScreen : frmBase
    {
        private Timer? _lockoutTimer;
        private int _failedAttempts = 0;
        private int _lockoutSecondsRemaining = 0;
        private readonly UserService _userService;
        private ToolTip _toolTips;

        public frmLoginScreen()
        {
            InitializeComponent();

            this.AllowMaximize = false;
            this.AllowResize = false;

            _userService = new UserService();
            InitializeUI();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {
            LoadRememberedCredentials();
        }

        private void InitializeUI()
        {
            this.Icon = Resources.iconLoginIn;
            RegisterEvents();
            SetupPasswordVisibility();
            SetupToolTips();
            ApplyStyles();

            _lockoutTimer = new Timer { Interval = 1000 };
            _lockoutTimer.Tick += LockoutTimer_Tick;
        }

        private void ApplyStyles()
        {
            btnLogin.ApplyPrimaryStyle();
            txtUserName.ApplyStandardStyle();
            txtPassword.ApplyStandardStyle();
            chkRememberMe.ApplyStandardStyle();
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
            _toolTips.SetToolTip(btnLogin, "Securely log in to the system");
            _toolTips.SetToolTip(chkRememberMe, "Save credentials for future logins");
            _toolTips.SetToolTip(lnkForgotPassword, "Reset your password");
            _toolTips.SetToolTip(lnkSignUp, "Create a new account");
        }

        private void RegisterEvents()
        {
            EnableWindowDragging(this);
            EnableWindowDragging(pnlRightCanvas);
        }

        private void LoadRememberedCredentials()
        {
            string rememberedUserName = HandleConfigurationFile.GetValueByKey("RememberedUserName");
            string rememberedPassword = HandleConfigurationFile.GetValueByKey("RememberedPassword");

            if (!string.IsNullOrEmpty(rememberedUserName) && !string.IsNullOrEmpty(rememberedPassword))
            {
                txtUserName.Text = rememberedUserName;
                txtPassword.Text = rememberedPassword;
                chkRememberMe.Checked = true;
            }
        }

        private void SetupPasswordVisibility()
        {
            txtPassword.UseSystemPasswordChar = true;
            Image eyeOff = UIUtility.RecolorIcon(Resources.visibilityOn, Color.FromArgb(71, 85, 105));
            Image eyeOn = UIUtility.RecolorIcon(Resources.visibilityOff, Color.FromArgb(71, 85, 105));

            txtPassword.AddIcon(eyeOn, NControls.IconPosition.Right, 20, 20, true,
                (t) => UIUtility.TogglePasswordVisibility(t, eyeOn, eyeOff));
        }

        private void CheckTextBoxsAreNotEmpty()
        {
            if (_lockoutSecondsRemaining > 0) return;
            btnLogin.Enabled = txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0;
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
                lblAttemptMessage.Text = $"Invalid username or password. Attempts left: {maxAttempts - _failedAttempts}";
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

            try
            {
                OperationResult<bool> loginResults = await _userService.AuthenticateUserAsync(txtUserName.Text, txtPassword.Text);

                if (loginResults.IsSuccess)
                {
                    _failedAttempts = 0;
                    var user = await _userService.GetByUserNameAsync(txtUserName.Text);
                    CurrentUser = user.Data;

                    lblAttemptMessage.Visible = false;
                    lblAttemptsCounter.Visible = false;
                    HandleCredentialsSaving();

                    this.Hide();
                    using (frmMainScreen mainScreen = new frmMainScreen())
                    {
                        mainScreen.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    txtPassword.Shake();
                    txtUserName.Shake();
                    HandleFailedAttempt(3);
                }
            }
            finally
            {
                btnLogin.IsLoading = false;
                CheckTextBoxsAreNotEmpty();
            }
        }

        private void HandleCredentialsSaving()
        {
            if (chkRememberMe.Checked)
            {
                HandleConfigurationFile.SetKeyAndValue("RememberedUserName", txtUserName.Text);
                HandleConfigurationFile.SetKeyAndValue("RememberedPassword", txtPassword.Text);
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
            using frmForgetPassword resetPasswordScreen = new frmForgetPassword(txtUserName.Text);
            resetPasswordScreen.OnPasswordChange = (username, newPassword) =>
            {
                txtUserName.Text = username;
                txtPassword.Text = newPassword;
            };
            resetPasswordScreen.ShowDialog();
        }
    }
}