using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CustomizeControls;
using DVLD.BLL.Services;
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

        private Form? _parentFormRef;
        private Control? _parentControlRef;

        #region Custom Events for Extensibility
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
                if (ShowUserProfile)
                {
                    AppSession.OnUserSessionChanged += UpdateUserProfileDisplay;
                }
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
            get;
            set
            {
                field = value;
                if (btnClose != null) btnClose.Visible = value;
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
                if (btnMaximize != null) btnMaximize.Visible = value;
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
                if (btnMinimize != null) btnMinimize.Visible = value;
            }
        } = true;

        [Category("Header Setup")]
        [Description("Show or hide the current user profile badge and settings menu.")]
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
                {
                    btnUserProfile.Visible = value;
                }
                if (value)
                {
                    UpdateUserProfileDisplay();
                }
            }
        } = false;

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

        private void UpdateUserProfileDisplay()
        {
            if (!ShowUserProfile) return;

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

            if (btnClose != null) btnClose.Visible = AllowClose;
            if (btnMaximize != null) btnMaximize.Visible = AllowMaximize;
            if (btnMinimize != null) btnMinimize.Visible = AllowMinimize;
            if (btnUserProfile != null) btnUserProfile.Visible = ShowUserProfile;

            UnhookParentFormEvents();
            _parentFormRef = ParentForm;

            if (_parentFormRef != null)
            {
                _parentFormRef.Resize += ParentForm_Resize;
                UpdateMaximizeIcon();
            }
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

                if (AllowMaximize)
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
            if (ParentForm == null || !AllowMaximize) return;

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

        #region User Profile Actions

        private bool CheckUserAuthentication()
        {
            if (!AppSession.IsAuthenticated)
            {
                UITheme.ShowInfoToast("There is no user in the system. Please Log in again.");
                return true;
            }
            return false;
        }

        private async Task RefreshCurrentUserSessionAsync()
        {
            UserService userServices = new UserService();
            var result = await userServices.GetByIdAsync(AppSession.CurrentUserID);

            if (result.IsSuccess && result.Data != null)
            {
                AppSession.CurrentUser = result.Data;
                UpdateUserProfileDisplay();
            }
        }

        private void BtnUserProfile_Click(object? sender, EventArgs e)
        {
            if (CheckUserAuthentication()) return;
            if (contextMenuUser == null) return;

            using (var editUserForm = new frmUserCard(AppSession.CurrentUserID))
            {
                editUserForm.OnEditedSuccessfully += async () =>
                {
                    await RefreshCurrentUserSessionAsync();
                };

                editUserForm.OnDeletedSuccessfully += () =>
                {
                    UITheme.ShowSuccessToast("Your account has been deleted successfully. The application will now restart.");
                    Application.Restart();
                };

                Point screenPos = btnUserProfile.PointToScreen(new Point(btnUserProfile.Width, btnUserProfile.Height));
                contextMenuUser.Show(screenPos.X - contextMenuUser.PreferredSize.Width, screenPos.Y);
            }
        }

        private void ItemCurrentUserInfo_Click(object? sender, EventArgs e)
        {
            if (CheckUserAuthentication()) return;

            using (frmUserCard frm = new(AppSession.CurrentUserID))
            {
                frm.OnEditedSuccessfully += async () =>
                {
                    await RefreshCurrentUserSessionAsync();
                };

                frm.OnDeletedSuccessfully += () =>
                {
                    UITheme.ShowSuccessToast("Your account has been deleted successfully. The application will now restart.");
                    Application.Restart();
                };

                frm.ShowDialog(ParentForm);
            }
        }

        private void ItemChangePassword_Click(object? sender, EventArgs e)
        {
            if (!AppSession.IsAuthenticated)
            {
                UITheme.ShowInfoToast("There is no user in the system. Please Log in again.");
            }
            using (frmForgetPassword frm = new(AppSession.CurrentUserName, "Change Passowrd", false))
            {
                frm.OnPasswordChange += (username, newPassword) =>
                {
                    Application.Restart();
                };
                frm.ShowDialog(ParentForm);
            }
        }

        private void ItemSettings_Click(object? sender, EventArgs e)
        {

        }

        private void ItemSignOut_Click(object? sender, EventArgs e)
        {
            AppSession.LogOut();
        }

        #endregion
    }
}