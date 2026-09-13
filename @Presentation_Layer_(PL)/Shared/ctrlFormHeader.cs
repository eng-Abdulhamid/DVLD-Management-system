using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CustomizeControls;
using DVLD.PL.Login;
using DVLD.PL.Management.user_management;
using DVLD.PL.UsersManagement;

namespace DVLD.PL.Global
{
    public partial class ctrlFormHeader : UserControl
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HT_CAPTION = 0x2;

        private DateTime _lastClickTime = DateTime.MinValue;
        private Point _lastClickPos = Point.Empty;

        private bool _allowClose = true;
        private bool _allowMaximize = true;
        private bool _allowMinimize = true;
        private bool _showUserProfile = false;

        private Form? _parentFormRef;
        private Control? _parentControlRef;

        #region Custom Events for Extensibility
        public event EventHandler? OnCurrentUserInfoClicked;
        public event EventHandler? OnChangePasswordClicked;
        public event EventHandler? OnSettingsClicked;
        public event EventHandler? OnSignOutClicked;
        #endregion

        public ctrlFormHeader()
        {
            InitializeComponent();

            Dock = DockStyle.Top;

            if (!UIUtility.IsDesignMode)
            {
                RegisterEvents();
                InitializeUserContextMenu();
                UITheme.OnThemeChanged += HandleThemeChanged;
                AppSession.OnUserSessionChanged += HandleUserSessionChanged;
                ApplyThemeStyles();
            }
        }

        #region Properties

        [Category("Header Setup")]
        [DefaultValue(DockStyle.Top)]
        public override DockStyle Dock
        {
            get => base.Dock;
            set => base.Dock = value;
        }

        [Category("Header Setup")]
        [Description("The title text displayed on the header.")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TitleText
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        [Category("Header Setup")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowClose
        {
            get => _allowClose;
            set
            {
                _allowClose = value;
                if (btnClose != null) btnClose.Visible = value;
            }
        }

        [Category("Header Setup")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMaximize
        {
            get => _allowMaximize;
            set
            {
                _allowMaximize = value;
                if (btnMaximize != null) btnMaximize.Visible = value;
            }
        }

        [Category("Header Setup")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMinimize
        {
            get => _allowMinimize;
            set
            {
                _allowMinimize = value;
                if (btnMinimize != null) btnMinimize.Visible = value;
            }
        }

        [Category("Header Setup")]
        [Description("Show or hide the current user profile badge and settings menu.")]
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowUserProfile
        {
            get => _showUserProfile;
            set
            {
                _showUserProfile = value;
                if (btnUserProfile != null)
                {
                    btnUserProfile.Visible = value;
                }
                if (value)
                {
                    UpdateUserProfileDisplay();
                }
            }
        }

        #endregion

        #region Menu & Theme Initialization

        private void InitializeUserContextMenu()
        {
            var colorTable = new NMenuColorTable
            {
                CustomBackground = Color.White,
                CustomItemSelected = Color.FromArgb(241, 245, 249),
                CustomSeparator = Color.FromArgb(226, 232, 240)
            };

            contextMenuUser.Renderer = new NMenuRenderer(colorTable)
            {
                ItemTextColor = Color.FromArgb(30, 41, 59),
                ItemHoverTextColor = Color.FromArgb(15, 23, 42),
                AccentColor = Color.FromArgb(124, 58, 237),
                DangerTextColor = Color.FromArgb(220, 38, 38),
                DangerHoverBackground = Color.FromArgb(254, 242, 242)
            };
        }

        private void HandleThemeChanged()
        {
            if (IsHandleCreated && !IsDisposed)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(ApplyThemeStyles);
                }
                else
                {
                    ApplyThemeStyles();
                }
            }
        }

        private void HandleUserSessionChanged()
        {
            if (IsHandleCreated && !IsDisposed)
            {
                if (InvokeRequired)
                {
                    BeginInvoke(UpdateUserProfileDisplay);
                }
                else
                {
                    UpdateUserProfileDisplay();
                }
            }
        }

        private void UpdateUserProfileDisplay()
        {
            if (!_showUserProfile) return;

            if (AppSession.IsAuthenticated)
            {
                btnUserProfile.Text = $"👤  {AppSession.CurrentUserName}  ▾";
                btnUserProfile.Visible = true;
            }
            else
            {
                btnUserProfile.Text = "👤  Guest  ▾";
                btnUserProfile.Visible = false;
            }
        }

        private void ApplyThemeStyles()
        {
            lblTitle.ForeColor = UITheme.TextPrimary;

            btnMinimize.ForeColor = UITheme.TextSecondary;
            btnMaximize.ForeColor = UITheme.TextSecondary;
            btnClose.ForeColor = UITheme.TextSecondary;
            btnUserProfile.ForeColor = UITheme.TextPrimary;

            SetupHoverEffect(btnClose, UITheme.Danger, Color.White);
            SetupHoverEffect(btnMaximize, UITheme.SelectionBg, UITheme.TextPrimary);
            SetupHoverEffect(btnMinimize, UITheme.SelectionBg, UITheme.TextPrimary);
            SetupHoverEffect(btnUserProfile, UITheme.SelectionBg, UITheme.TextPrimary);

            Invalidate(true);
        }

        #endregion

        #region Window Dragging & Lifecycle Events

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (_parentControlRef != null)
            {
                _parentControlRef.BackColorChanged -= Parent_BackColorChanged;
            }

            _parentControlRef = Parent;
            if (_parentControlRef != null)
            {
                BackColor = _parentControlRef.BackColor;
                _parentControlRef.BackColorChanged += Parent_BackColorChanged;

                SendToBack();
            }
        }

        private void Parent_BackColorChanged(object? sender, EventArgs e)
        {
            if (Parent != null)
            {
                BackColor = Parent.BackColor;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SendToBack();

            if (btnClose != null) btnClose.Visible = _allowClose;
            if (btnMaximize != null) btnMaximize.Visible = _allowMaximize;
            if (btnMinimize != null) btnMinimize.Visible = _allowMinimize;
            if (btnUserProfile != null) btnUserProfile.Visible = _showUserProfile;

            UnhookParentFormEvents();
            _parentFormRef = ParentForm;

            if (_parentFormRef != null)
            {
                _parentFormRef.Resize += ParentForm_Resize;
                UpdateMaximizeIcon();
            }

            UpdateUserProfileDisplay();
            ApplyThemeStyles();
        }

        private void ParentForm_Resize(object? sender, EventArgs e)
        {
            UpdateMaximizeIcon();
        }

        private void UnhookParentFormEvents()
        {
            if (_parentFormRef != null)
            {
                _parentFormRef.Resize -= ParentForm_Resize;
                _parentFormRef = null;
            }
        }

        private void RegisterEvents()
        {
            MouseDown += Header_MouseDown;
            lblTitle.MouseDown += Header_MouseDown;

            btnClose.Click += (s, e) => ParentForm?.Close();
            btnMinimize.Click += (s, e) =>
            {
                if (ParentForm != null)
                {
                    ParentForm.WindowState = FormWindowState.Minimized;
                }
            };
            btnMaximize.Click += (s, e) => ToggleMaximize();

            btnUserProfile.Click += BtnUserProfile_Click;
            itemCurrentUserInfo.Click += ItemCurrentUserInfo_Click;
            itemChangePassword.Click += ItemChangePassword_Click;
            itemSettings.Click += ItemSettings_Click;
            itemSignOut.Click += ItemSignOut_Click;
        }

        private void Header_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || ParentForm == null) return;

            Point currentScreenPos = Cursor.Position;
            TimeSpan timeDifference = DateTime.Now - _lastClickTime;
            int deltaX = Math.Abs(currentScreenPos.X - _lastClickPos.X);
            int deltaY = Math.Abs(currentScreenPos.Y - _lastClickPos.Y);

            if (timeDifference.TotalMilliseconds <= SystemInformation.DoubleClickTime
                && deltaX <= SystemInformation.DoubleClickSize.Width
                && deltaY <= SystemInformation.DoubleClickSize.Height)
            {
                _lastClickTime = DateTime.MinValue;
                _lastClickPos = Point.Empty;

                if (_allowMaximize)
                {
                    ToggleMaximize();
                }
                return;
            }

            _lastClickTime = DateTime.Now;
            _lastClickPos = currentScreenPos;

            if (ParentForm.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void ToggleMaximize()
        {
            if (ParentForm == null || !_allowMaximize) return;

            if (ParentForm is frmBase baseForm)
            {
                baseForm.ToggleMaximize();
            }
            else
            {
                ParentForm.WindowState = (ParentForm.WindowState == FormWindowState.Maximized)
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
            }

            UpdateMaximizeIcon();
        }

        private void UpdateMaximizeIcon()
        {
            if (ParentForm == null) return;
            btnMaximize.Text = (ParentForm.WindowState == FormWindowState.Maximized) ? "🗗" : "🗖";
        }

        private static void SetupHoverEffect(Button btn, Color hoverBackColor, Color hoverForeColor)
        {
            Color defaultBackColor = Color.Transparent;
            Color defaultForeColor = btn.ForeColor;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = hoverBackColor;
                btn.ForeColor = hoverForeColor;
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = defaultBackColor;
                btn.ForeColor = defaultForeColor;
            };
        }

        #endregion

        #region User Profile Actions (Smart Fallbacks + Extensibility)

        private void BtnUserProfile_Click(object? sender, EventArgs e)
        {
            if (contextMenuUser == null || !AppSession.IsAuthenticated) return;

            Point screenPos = btnUserProfile.PointToScreen(new Point(btnUserProfile.Width, btnUserProfile.Height));
            contextMenuUser.Show(screenPos.X - contextMenuUser.PreferredSize.Width, screenPos.Y);
        }

        private void ItemCurrentUserInfo_Click(object? sender, EventArgs e)
        {
            if (OnCurrentUserInfoClicked != null)
            {
                OnCurrentUserInfoClicked.Invoke(this, EventArgs.Empty);
                return;
            }

            if (!AppSession.IsAuthenticated) return;

            using (frmUserCard frm = new(AppSession.CurrentUserID))
            {
                frm.ShowDialog(ParentForm);
            }
        }

        private void ItemChangePassword_Click(object? sender, EventArgs e)
        {
            if (OnChangePasswordClicked != null)
            {
                OnChangePasswordClicked.Invoke(this, EventArgs.Empty);
                return;
            }

            if (!AppSession.IsAuthenticated) return;

            using (frmForgetPassword frm = new(AppSession.CurrentUserName))
            {
                frm.ShowDialog(ParentForm);
            }
        }

        private void ItemSettings_Click(object? sender, EventArgs e)
        {
            if (OnSettingsClicked != null)
            {
                OnSettingsClicked.Invoke(this, EventArgs.Empty);
                return;
            }

            UITheme.ShowInfoToast("Settings feature is currently under development.", "Under Construction");
        }

        private void ItemSignOut_Click(object? sender, EventArgs e)
        {
            if (OnSignOutClicked != null)
            {
                OnSignOutClicked.Invoke(this, EventArgs.Empty);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?",
                "Confirm Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppSession.LogOut();
                ParentForm?.Close();
            }
        }

        #endregion
    }
}