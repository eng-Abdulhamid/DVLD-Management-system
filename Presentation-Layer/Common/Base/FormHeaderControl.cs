using System.ComponentModel;
using System.Runtime.InteropServices;
using CustomizeControls;
using DVLD.BLL.Services;
using DVLD.PL.Home;
using DVLD.PL.Login;
using DVLD.PL.Management.user_management;
using DVLD.PL.Properties;
using DVLD.PL.Theme;

namespace DVLD.PL.Global
{
    public partial class FormHeaderControl : UserControl
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(
            IntPtr hWnd,
            int msg,
            int wParam,
            int lParam);

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HT_CAPTION = 0x2;

        private DateTime _lastClickTime = DateTime.MinValue;
        private Point _lastClickPos = Point.Empty;

        private Form? _parentFormRef;
        private Control? _parentControlRef;

        public event EventHandler? OnSignOutClicked;

        public FormHeaderControl()
        {
            InitializeComponent();

            Dock = DockStyle.Top;

            if (!UIUtility.IsDesignMode)
            {
                RegisterEvents();
                InitializeUserContextMenu();

                ThemeManager.ThemeChanged += HandleThemeChanged;

                if (ShowUserProfile)
                {
                    AppSession.OnUserSessionChanged += UpdateUserProfileDisplay;
                }

                SetButtonsType();

                ApplyHeaderTheme();
            }
        }

        private void SetButtonsType()
        {
            btnClose.ButtonType = enButtonType.Danger;
            btnMaximize.ButtonType = enButtonType.Secondary;
            btnMinimize.ButtonType = enButtonType.Secondary;
            btnUserProfile.ButtonType = enButtonType.Secondary;
            btnSwitchMode.ButtonType = enButtonType.Secondary;
        }

        private void ApplyHeaderTheme()
        {
            ThemeApplicator.Apply(this);

            ApplyCustomizeThemeForHeaderButtons();
            UpdateSwitchModeIcon();

            pnlWindowControls.BackColor = Color.Transparent;

            Invalidate(true);
        }

        private void ApplyCustomizeThemeForHeaderButtons()
        {
            Color transparent = Color.Transparent;
            ThemePalette theme = ThemeManager.Current;

            // =========================
            // Close
            // =========================

            btnClose.BackgroundStartColor = transparent;
            btnClose.BackgroundEndColor = transparent;

            btnClose.HoverStartColor = Color.FromArgb(232, 17, 35);
            btnClose.HoverEndColor = Color.FromArgb(232, 17, 35);

            btnClose.PressedStartColor = Color.FromArgb(241, 112, 122);
            btnClose.PressedEndColor = Color.FromArgb(241, 112, 122);

            btnClose.BorderRadius = 0;
            btnClose.BorderSize = 0;
            btnClose.BackColor = transparent;

            btnClose.Text = string.Empty;
            btnClose.MiddleIcon = Resources.Close;
            btnClose.IconSize = new Size(16, 16);

            // =========================
            // Maximize
            // =========================

            btnMaximize.BackgroundStartColor = transparent;
            btnMaximize.BackgroundEndColor = transparent;

            btnMaximize.HoverStartColor = theme.BorderHover;
            btnMaximize.HoverEndColor = theme.BorderHover;

            btnMaximize.PressedStartColor = theme.Border;
            btnMaximize.PressedEndColor = theme.Border;

            btnMaximize.BorderRadius = 0;
            btnMaximize.BorderSize = 0;
            btnMaximize.BackColor = transparent;

            btnMaximize.Text = string.Empty;
            btnMaximize.MiddleIcon = Resources.maximize;
            btnMaximize.IconSize = new Size(16, 16);

            // =========================
            // Minimize
            // =========================

            btnMinimize.BackgroundStartColor = transparent;
            btnMinimize.BackgroundEndColor = transparent;

            btnMinimize.HoverStartColor = theme.BorderHover;
            btnMinimize.HoverEndColor = theme.BorderHover;

            btnMinimize.PressedStartColor = theme.Border;
            btnMinimize.PressedEndColor = theme.Border;

            btnMinimize.BorderRadius = 0;
            btnMinimize.BorderSize = 0;
            btnMinimize.BackColor = transparent;

            btnMinimize.Text = "—";
            btnMinimize.MiddleIcon = null;

            // =========================
            // User Profile
            // =========================

            btnUserProfile.BackgroundStartColor = transparent;
            btnUserProfile.BackgroundEndColor = transparent;

            btnUserProfile.HoverStartColor = theme.BorderHover;
            btnUserProfile.HoverEndColor = theme.BorderHover;

            btnUserProfile.PressedStartColor = theme.Border;
            btnUserProfile.PressedEndColor = theme.Border;

            btnUserProfile.BorderRadius = 0;
            btnUserProfile.BorderSize = 0;
            btnUserProfile.BackColor = transparent;

            btnUserProfile.RightIcon = Resources.down;

            // =========================
            // Theme Switch
            // =========================

            btnSwitchMode.BackgroundStartColor = transparent;
            btnSwitchMode.BackgroundEndColor = transparent;

            btnSwitchMode.HoverStartColor = theme.BorderHover;
            btnSwitchMode.HoverEndColor = theme.BorderHover;

            btnSwitchMode.PressedStartColor = theme.Border;
            btnSwitchMode.PressedEndColor = theme.Border;

            btnSwitchMode.BorderRadius = 0;
            btnSwitchMode.BorderSize = 0;
            btnSwitchMode.BackColor = transparent;

            btnSwitchMode.Text = string.Empty;
            btnSwitchMode.CenterIconWithText = false;
            btnSwitchMode.EnableIconTinting = false;
            btnSwitchMode.IconSize = new Size(17, 17);

            UpdateSwitchModeIcon();
        }

        private void UpdateSwitchModeIcon()
        {
            /*
             * Light -> show dark icon
             * Dark  -> show light icon
             */

            btnSwitchMode.MiddleIcon =
                ThemeManager.Mode switch
                {
                    enMode.DefaultDark => Resources.light,
                    enMode.CustomDark => Resources.light,

                    enMode.DefaultLight => Resources.dark,
                    enMode.CustomLight => Resources.dark,

                    _ => Resources.dark
                };

            btnSwitchMode.Invalidate();
        }

        private void SwitchThemeMode()
        {
            enMode newMode =
                ThemeManager.Mode switch
                {
                    enMode.DefaultLight => enMode.DefaultDark,
                    enMode.DefaultDark => enMode.DefaultLight,

                    enMode.CustomLight => enMode.DefaultDark,
                    enMode.CustomDark => enMode.DefaultLight,

                    _ => enMode.DefaultLight
                };

            ThemeManager.SetMode(newMode);
        }

        private void BtnSwitchMode_Click(object? sender, EventArgs e)
        {
            SwitchThemeMode();
        }

        [Category("Header Setup")]
        [DefaultValue(DockStyle.Top)]
        public override DockStyle Dock
        {
            get => base.Dock;
            set => base.Dock = value;
        }

        [Category("Header Setup")]
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
            get;
            set
            {
                field = value;

                if (btnClose != null)
                    btnClose.Visible = value;
            }
        } = true;

        [Category("Header Setup")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMaximize
        {
            get;
            set
            {
                field = value;

                if (btnMaximize != null)
                    btnMaximize.Visible = value;
            }
        } = true;

        [Category("Header Setup")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMinimize
        {
            get;
            set
            {
                field = value;

                if (btnMinimize != null)
                    btnMinimize.Visible = value;
            }
        } = true;

        [Category("Header Setup")]
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ShowUserProfile
        {
            get;
            set
            {
                field = value;

                if (btnUserProfile != null)
                    btnUserProfile.Visible = value;

                if (value)
                    UpdateUserProfileDisplay();
            }
        } = false;

        private void InitializeUserContextMenu()
        {
            var theme = ThemeManager.Current;

            var colorTable = new NMenuColorTable
            {
                CustomBackground = theme.Surface,
                CustomItemSelected = theme.SelectionBg,
                CustomSeparator = theme.Border
            };

            contextMenuUser.Renderer = new NMenuRenderer(colorTable)
            {
                ItemTextColor = theme.TextPrimary,
                ItemHoverTextColor = theme.TextPrimary,
                AccentColor = theme.Primary,
                DangerTextColor = theme.Danger,
                DangerHoverBackground = theme.Surface
            };
        }

        private void HandleThemeChanged(
            object? sender,
            ThemeManager.ModeEventsArgs e)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action(
                        () => HandleThemeChanged(null, e)));

                return;
            }

            ApplyHeaderTheme();
            InitializeUserContextMenu();
        }

        private void UpdateUserProfileDisplay()
        {
            if (!ShowUserProfile)
                return;

            if (AppSession.IsAuthenticated)
            {
                btnUserProfile.Text =
                    $"{AppSession.CurrentUserName}";

                btnUserProfile.Visible = true;
            }
            else
            {
                btnUserProfile.Text = "Guest";
                btnUserProfile.Visible = false;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (_parentControlRef != null)
            {
                _parentControlRef.BackColorChanged -=
                    Parent_BackColorChanged;
            }

            _parentControlRef = Parent;

            if (_parentControlRef != null)
            {
                BackColor = _parentControlRef.BackColor;

                _parentControlRef.BackColorChanged +=
                    Parent_BackColorChanged;

                SendToBack();
            }
        }

        private void Parent_BackColorChanged(
            object? sender,
            EventArgs e)
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

            if (btnClose != null)
                btnClose.Visible = AllowClose;

            if (btnMaximize != null)
                btnMaximize.Visible = AllowMaximize;

            if (btnMinimize != null)
                btnMinimize.Visible = AllowMinimize;

            if (btnUserProfile != null)
                btnUserProfile.Visible = ShowUserProfile;

            UnhookParentFormEvents();

            _parentFormRef = ParentForm;

            if (_parentFormRef != null)
            {
                _parentFormRef.Resize += ParentForm_Resize;
                UpdateMaximizeIcon();
            }

            UpdateSwitchModeIcon();
        }

        private void ParentForm_Resize(
            object? sender,
            EventArgs e)
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

            btnClose.Click +=
                (s, e) => ParentForm?.Close();

            btnMinimize.Click +=
                (s, e) =>
                {
                    if (ParentForm != null)
                    {
                        ParentForm.WindowState =
                            FormWindowState.Minimized;
                    }
                };

            btnMaximize.Click +=
                (s, e) => ToggleMaximize();

            btnSwitchMode.Click +=
                BtnSwitchMode_Click;

            btnUserProfile.Click +=
                BtnUserProfile_Click;

            itemCurrentUserInfo.Click +=
                ItemCurrentUserInfo_Click;

            itemChangePassword.Click +=
                ItemChangePassword_Click;

            itemSettings.Click +=
                ItemSettings_Click;

            itemSignOut.Click +=
                ItemSignOut_Click;
        }

        private void Header_MouseDown(
            object? sender,
            MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left ||
                ParentForm == null)
            {
                return;
            }

            Point currentScreenPos = Cursor.Position;

            TimeSpan timeDifference =
                DateTime.Now - _lastClickTime;

            int deltaX =
                Math.Abs(
                    currentScreenPos.X -
                    _lastClickPos.X);

            int deltaY =
                Math.Abs(
                    currentScreenPos.Y -
                    _lastClickPos.Y);

            if (timeDifference.TotalMilliseconds <=
                    SystemInformation.DoubleClickTime
                && deltaX <=
                    SystemInformation.DoubleClickSize.Width
                && deltaY <=
                    SystemInformation.DoubleClickSize.Height)
            {
                _lastClickTime =
                    DateTime.MinValue;

                _lastClickPos =
                    Point.Empty;

                if (AllowMaximize)
                {
                    ToggleMaximize();
                }

                return;
            }

            _lastClickTime = DateTime.Now;
            _lastClickPos = currentScreenPos;

            if (ParentForm.WindowState ==
                FormWindowState.Normal)
            {
                ReleaseCapture();

                SendMessage(
                    ParentForm.Handle,
                    WM_NCLBUTTONDOWN,
                    HT_CAPTION,
                    0);
            }
        }

        public void ToggleMaximize()
        {
            if (ParentForm == null ||
                !AllowMaximize)
            {
                return;
            }

            if (ParentForm is BaseForm baseForm)
            {
                baseForm.ToggleMaximize();
            }
            else
            {
                ParentForm.WindowState =
                    ParentForm.WindowState ==
                    FormWindowState.Maximized
                        ? FormWindowState.Normal
                        : FormWindowState.Maximized;
            }

            UpdateMaximizeIcon();
        }

        private void UpdateMaximizeIcon()
        {
            if (ParentForm == null)
                return;

            btnMaximize.MiddleIcon =
                ParentForm.WindowState ==
                FormWindowState.Maximized
                    ? Resources.maximize
                    : Resources.maximize;

            btnMaximize.Invalidate();
        }

        private bool CheckUserAuthentication()
        {
            if (!AppSession.IsAuthenticated)
            {
                NotificationTheme.ShowInfoToast(
                    "There is no user in the system. Please Log in again.");

                return true;
            }

            return false;
        }

        private async Task RefreshCurrentUserSessionAsync()
        {
            UserService userServices =
                new UserService();

            var result =
                await userServices.GetByIdAsync(
                    AppSession.CurrentUserID);

            if (result.IsSuccess &&
                result.Data != null)
            {
                AppSession.CurrentUser =
                    result.Data;

                UpdateUserProfileDisplay();
            }
        }

        private void BtnUserProfile_Click(
            object? sender,
            EventArgs e)
        {
            if (CheckUserAuthentication())
                return;

            if (contextMenuUser == null)
                return;

            Point screenPos =
                btnUserProfile.PointToScreen(
                    new Point(
                        btnUserProfile.Width,
                        btnUserProfile.Height));

            contextMenuUser.Show(
                screenPos.X -
                contextMenuUser.PreferredSize.Width,
                screenPos.Y);
        }

        private async void ItemCurrentUserInfo_Click(
            object? sender,
            EventArgs e)
        {
            if (CheckUserAuthentication())
                return;

            using (frmUserCard frm =
                   new(AppSession.CurrentUserID))
            {
                frm.OnEditedSuccessfully +=
                    async () =>
                    {
                        await RefreshCurrentUserSessionAsync();
                    };

                frm.OnDeletedSuccessfully +=
                    () =>
                    {
                        NotificationTheme.ShowSuccessToast(
                            "Your account has been deleted successfully. The application will now restart.");

                        Application.Restart();
                    };

                if (ParentForm != null)
                {
                    await frm.ShowDialogAsync(
                        ParentForm);
                }
            }
        }

        private async void ItemChangePassword_Click(
            object? sender,
            EventArgs e)
        {
            if (!AppSession.IsAuthenticated)
            {
                NotificationTheme.ShowInfoToast(
                    "There is no user in the system. Please Log in again.");
            }

            using (frmForgetPassword frm =
                   new(
                       AppSession.CurrentUserName,
                       "Change Password",
                       false))
            {
                frm.OnPasswordChange +=
                    (username, newPassword) =>
                    {
                        Application.Restart();
                    };

                if (ParentForm != null)
                {
                    await frm.ShowDialogAsync(
                        ParentForm);
                }
            }
        }

        private async void ItemSettings_Click(
            object? sender,
            EventArgs e)
        {
            if (!AppSession.IsAuthenticated)
            {
                NotificationTheme.ShowInfoToast(
                    "There is no user in the system. Please Log in again.");
            }

            using (var frm =
                   new frmAppSettings())
            {
                if (ParentForm != null)
                {
                    await frm.ShowDialogAsync(
                        ParentForm);
                }
            }
        }

        private void ItemSignOut_Click(
            object? sender,
            EventArgs e)
        {
            AppSession.LogOut();

            OnSignOutClicked?.Invoke(
                this,
                EventArgs.Empty);
        }
    }
}
