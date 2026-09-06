using DVLD.BLL.OperationResults;
using DVLD.PL.Configuration;
using DVLD.PL.Properties;
using System.Drawing.Imaging;
using System.Media;
using System.Runtime.InteropServices;
using Timer = System.Windows.Forms.Timer;
using static DVLD.PL.AppSession;

namespace DVLD.PL.Login
{
    public partial class frmLoginScreen : Form
    {
        private Timer? _lockoutTimer;
        private int _failedAttempts = 0;
        private int _lockoutSecondsRemaining = 0;
        private DVLD.BLL.Services.UserService _userService;
        public frmLoginScreen()
        {
            InitializeComponent();
            InitializeUIUXComponent();
            _userService = new DVLD.BLL.Services.UserService();
        }
        private void LoginScreen_Load(object sender, EventArgs e)
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
        #region UI UX Enhancements
        private void InitializeUIUXComponent()
        {
            ApplyWindowEnhancements();
            RegisterEvents();
            this.Icon = Resources.iconLoginIn;

            SetupPasswordVisibility();

            _lockoutTimer = new Timer();
            _lockoutTimer.Interval = 1000;
            _lockoutTimer.Tick += LockoutTimer_Tick;
        }
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WS_EX_COMPOSITED = 0x02000000;

        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
        private const int DWMWCP_ROUND = 2;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                cp.ExStyle |= WS_EX_COMPOSITED;
                return cp;
            }
        }

        private void ApplyWindowEnhancements()
        {
            try
            {
                int cornerPreference = DWMWCP_ROUND;
                DwmSetWindowAttribute(Handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref cornerPreference, sizeof(int));
            }
            catch { }
        }

        private void RegisterEvents()
        {
            this.MouseDown += OnDragWindow;
            pnlRightCanvas.MouseDown += OnDragWindow;

            btnClose.Click += (s, e) => Application.Exit();
            btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            btnClose.MouseEnter += (s, e) =>
            {
                btnClose.BackColor = Color.FromArgb(239, 68, 68);
                btnClose.ForeColor = Color.White;
            };
            btnClose.MouseLeave += (s, e) =>
            {
                btnClose.BackColor = Color.Transparent;
                btnClose.ForeColor = Color.FromArgb(148, 163, 184);
            };

            btnMinimize.MouseEnter += (s, e) =>
            {
                btnMinimize.BackColor = Color.FromArgb(241, 245, 249);
                btnMinimize.ForeColor = Color.FromArgb(15, 23, 42);
            };
            btnMinimize.MouseLeave += (s, e) =>
            {
                btnMinimize.BackColor = Color.Transparent;
                btnMinimize.ForeColor = Color.FromArgb(148, 163, 184);
            };
        }

        private void OnDragWindow(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
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
                {
                    using (ImageAttributes attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(matrix);

                        g.DrawImage(
                            source,
                            new Rectangle(0, 0, source.Width, source.Height),
                            0,
                            0,
                            source.Width,
                            source.Height,
                            GraphicsUnit.Pixel,
                            attributes
                        );
                    }
                }
            }

            return bitmap;
        }
        private void SetupPasswordVisibility()
        {
            txtPassword.UseSystemPasswordChar = true;

            Image icon = RecolorIcon(Resources.visibilityOff, Color.Black);

            txtPassword.AddIcon(
                icon,
                NControls.IconPosition.Right,
                20,
                20,
                true,
                TogglePasswordVisibility
            );
        }
        private void TogglePasswordVisibility(NControls.NTextBox txt)
        {
            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;
            txt.ClearIcons();

            Image icon = txt.UseSystemPasswordChar
                ? Resources.visibilityOff
                : Resources.visibilityOn;

            icon = RecolorIcon(icon, Color.Black);

            txt.AddIcon(
                icon,
                NControls.IconPosition.Right,
                20,
                20,
                true,
                TogglePasswordVisibility
            );
        }
        private async Task ShakeWindowAsync()
        {
            SystemSounds.Hand.Play();

            Point originalLocation = this.Location;
            int shakeAmplitude = 10;
            int[] shakePattern = { 1, -1, 1, -1, 1, -1, 0 };

            foreach (int direction in shakePattern)
            {
                this.Location = new Point(originalLocation.X + (direction * shakeAmplitude), originalLocation.Y);
                await Task.Delay(35);
            }

            this.Location = originalLocation;
        }

        private void CheckTextBoxsAreNotEmpty()
        {
            if (_lockoutSecondsRemaining > 0) return;
            btnLogin.Enabled = ((txtUserName.Text.Length > 0) && (txtPassword.Text.Length > 0));
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

            _lockoutTimer.Start();
        }
        private void LockoutTimer_Tick(object? sender, EventArgs e)
        {
            _lockoutSecondsRemaining--;

            if (_lockoutSecondsRemaining <= 0)
            {
                _lockoutTimer.Stop();

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
        #endregion
        private async Task<bool> CheckingLoginCredentials()
        {
            Task<OperationResult<bool>> Verify = _userService.AuthenticateUserAsync(txtUserName.Text, txtPassword.Text);

            // Do something while waiting for the verification to complete
            btnLogin.IsLoading = true;

            // Await the result of the verification
            OperationResult<bool> LoginResults = await Verify;

            btnLogin.IsLoading = false;

            return LoginResults.IsSuccess;
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.IsLoading = true;
            await Task.Delay(1500);
            btnLogin.IsLoading = false;

            bool isLoginSuccessful = await CheckingLoginCredentials();

            if (isLoginSuccessful)
            {
                _failedAttempts = 0;
                var user = await _userService.GetByUserNameAsync(txtUserName.Text);
                CurrentUser = user.Data;
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
                MessageBox.Show("Login Successful!");
            }
            else
            {
                //await ShakeWindowAsync();
                txtPassword.Shake();
                txtUserName.Shake();
                HandleFailedAttempt(3);
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
            frmForgetPassword resetPasswordScreen = new(txtUserName.Text);
            resetPasswordScreen.ShowDialog();
        }
    }
}