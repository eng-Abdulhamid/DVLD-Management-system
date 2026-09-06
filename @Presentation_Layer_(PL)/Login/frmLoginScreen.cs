using DVLD.PL.Configuration;
using DVLD.PL.Properties;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer; 

namespace DVLD.PL.Login
{
    public partial class frmLoginScreen : Form
    {
        private Timer _lockoutTimer;
        private int _failedAttempts = 0;
        private int _lockoutSecondsRemaining = 0;

        public frmLoginScreen()
        {
            InitializeComponent();
            ApplyWindowEnhancements();
            RegisterEvents();
            this.Icon = Resources.iconLoginScreen;

            _lockoutTimer = new Timer();
            _lockoutTimer.Interval = 1000;
            _lockoutTimer.Tick += LockoutTimer_Tick;
        }

        #region UI 
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

            this.Resize += OnFormResized;
        }

        private void OnDragWindow(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void OnFormResized(object? sender, EventArgs e)
        {
        }
        #endregion

        private void CheckTextBoxsAreNotEmpty()
        {
            btnLogin.Enabled = ((txtUserName.Text.Length > 0) && (txtPassword.Text.Length > 0));
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxsAreNotEmpty();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            CheckTextBoxsAreNotEmpty();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lnkPasswordStatus.Tag?.ToString(), out int result))
            {
                if (result == 0)
                {
                    txtPassword.UseSystemPasswordChar = false;
                    lnkPasswordStatus.Tag = 1;
                    lnkPasswordStatus.Text = "Hide password";
                }
                else
                {
                    txtPassword.UseSystemPasswordChar = true;
                    lnkPasswordStatus.Tag = 0;
                    lnkPasswordStatus.Text = "Show password";
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isLoginSuccessful = false;

            if (isLoginSuccessful)
            {
                _failedAttempts = 0;
                MessageBox.Show("Login Successful!");
            }
            else
            {
                HandleFailedAttempt(3);
            }
        }

        private void HandleFailedAttempt(int attemptsNumber)
        {
            _failedAttempts++;

            if (_failedAttempts >= attemptsNumber)
            {
                _lockoutSecondsRemaining = Math.Min(30 * (_failedAttempts - 2), 300);
                

                LockoutUser();
            }
            else
            {
                lblAttemptMessage.Visible = true;
                lblAttemptsCounter.Visible = false;
                lblAttemptMessage.Text = $"Invalid username or password. Attempts left: {attemptsNumber - _failedAttempts}";
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
    }
}