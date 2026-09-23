using System.ComponentModel;
using System.Runtime.InteropServices;
using CustomizeControls;
using DVLD.BLL.Services;
using DVLD.PL.ControlsTheme;
using DVLD.PL.Home;
using DVLD.PL.Login;
using DVLD.PL.Management.user_management;
using DVLD.PL.Properties;
using DVLD.PL.Theme;

namespace DVLD.PL.Global;

public partial class FormHeaderControl : UserControl
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

    public event EventHandler? OnSignOutClicked;

    public FormHeaderControl()
    {
        InitializeComponent();
        Dock = DockStyle.Top;

        if (!UIUtility.IsDesignMode)
        {
            SetupHeaderButtonsStructure();
            RegisterEvents();
            InitializeUserContextMenu();

            ThemeManager.ThemeChanged += HandleThemeChanged;

            if (ShowUserProfile)
            {
                AppSession.OnUserSessionChanged += UpdateUserProfileDisplay;
            }

            ApplyHeaderTheme();
        }
    }

    private void SetupHeaderButtonsStructure()
    {
        // One-time Layout & Behavior configuration
        btnClose.BorderRadius = 0;
        btnClose.BorderSize = 0;
        btnClose.MiddleIcon = Resources.Close;
        btnClose.IconSize = new Size(14, 14);
        btnClose.Text = string.Empty;

        btnMaximize.BorderRadius = 0;
        btnMaximize.BorderSize = 0;
        btnMaximize.IconSize = new Size(14, 14);
        btnMaximize.Text = string.Empty;

        btnMinimize.BorderRadius = 0;
        btnMinimize.BorderSize = 0;
        btnMinimize.MiddleIcon = null;
        btnMinimize.Text = "—";

        btnUserProfile.BorderRadius = 0;
        btnUserProfile.BorderSize = 0;
        btnUserProfile.RightIcon = Resources.down;

        btnSwitchMode.BorderRadius = 0;
        btnSwitchMode.BorderSize = 0;
        btnSwitchMode.Text = string.Empty;
        btnSwitchMode.CenterIconWithText = false;
        btnSwitchMode.EnableIconTinting = false;
        btnSwitchMode.IconSize = new Size(16, 16);

        pnlWindowControls.BackColor = Color.Transparent;
    }

    private void ApplyHeaderTheme()
    {
        var formTheme = ThemeManager.Current.theme.Form;
        var colors = ThemeManager.Current.theme.Colors;
        Color transparent = Color.Transparent;

        // Apply Header Background
        BackColor = formTheme.HeaderBackground;
        lblTitle.ForeColor = formTheme.HeaderForeground;

        // Close Button (uses FormTheme dedicated colors)
        btnClose.BackColor = transparent;
        btnClose.BackgroundStartColor = transparent;
        btnClose.BackgroundEndColor = transparent;
        btnClose.HoverStartColor = formTheme.CloseButtonHoverColor;
        btnClose.HoverEndColor = formTheme.CloseButtonHoverColor;
        btnClose.PressedStartColor = formTheme.CloseButtonPressedColor;
        btnClose.PressedEndColor = formTheme.CloseButtonPressedColor;
        btnClose.ForeColor = formTheme.HeaderForeground;

        // Standard Window Controls (Maximize, Minimize, Switch, Profile)
        ApplyWindowControlColors(btnMaximize, formTheme);
        ApplyWindowControlColors(btnMinimize, formTheme);
        ApplyWindowControlColors(btnUserProfile, formTheme);
        ApplyWindowControlColors(btnSwitchMode, formTheme);

        btnUserProfile.ForeColor = formTheme.HeaderForeground;
        btnMinimize.ForeColor = formTheme.HeaderForeground;

        UpdateSwitchModeIcon();
        Invalidate(true);
    }

    private static void ApplyWindowControlColors(NButton btn, FormTheme formTheme)
    {
        Color transparent = Color.Transparent;

        btn.BackColor = transparent;
        btn.BackgroundStartColor = transparent;
        btn.BackgroundEndColor = transparent;
        btn.HoverStartColor = formTheme.WindowControlHoverColor;
        btn.HoverEndColor = formTheme.WindowControlHoverColor;
        btn.PressedStartColor = formTheme.WindowControlPressedColor;
        btn.PressedEndColor = formTheme.WindowControlPressedColor;
    }

    private void UpdateSwitchModeIcon()
    {
        btnSwitchMode.MiddleIcon = ThemeManager.Mode switch
        {
            enMode.DefaultDark or enMode.CustomDark => Resources.light,
            _ => Resources.dark
        };

        btnSwitchMode.Invalidate();
    }

    private void SwitchThemeMode()
    {
        enMode newMode = ThemeManager.Mode switch
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
    [DefaultValue(false)]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public bool ShowUserProfile
    {
        get;
        set
        {
            field = value;
            if (btnUserProfile != null) btnUserProfile.Visible = value;
            if (value) UpdateUserProfileDisplay();
        }
    } = false;

    private void InitializeUserContextMenu()
    {
        var theme = ThemeManager.Current.theme.Colors;

        var colorTable = new NMenuColorTable
        {
            CustomBackground = theme.Surface,
            CustomItemSelected = theme.SelectionBackground,
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

    private void HandleThemeChanged(object? sender, EventArgs e)
    {
        if (IsDisposed || !IsHandleCreated) return;

        if (InvokeRequired)
        {
            BeginInvoke(new Action(() => HandleThemeChanged(null, e)));
            return;
        }

        ApplyHeaderTheme();
        InitializeUserContextMenu();
    }

    private void UpdateUserProfileDisplay()
    {
        if (!ShowUserProfile) return;

        if (AppSession.IsAuthenticated)
        {
            btnUserProfile.Text = $"{AppSession.CurrentUserName}";
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
            _parentControlRef.BackColorChanged -= Parent_BackColorChanged;
        }

        _parentControlRef = Parent;

        if (_parentControlRef != null)
        {
            _parentControlRef.BackColorChanged += Parent_BackColorChanged;
            SendToBack();
        }
    }

    private void Parent_BackColorChanged(object? sender, EventArgs e)
    {
        if (Parent != null && ThemeManager.Current?.theme?.Form != null)
        {
            BackColor = ThemeManager.Current.theme.Form.HeaderBackground;
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

        UpdateSwitchModeIcon();
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
        btnSwitchMode.Click += BtnSwitchMode_Click;
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

        if (ParentForm is BaseForm baseForm)
        {
            baseForm.ToggleMaximize();
        }
        else
        {
            ParentForm.WindowState = ParentForm.WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
        }

        UpdateMaximizeIcon();
    }

    private void UpdateMaximizeIcon()
    {
        if (ParentForm == null) return;

        btnMaximize.MiddleIcon = ParentForm.WindowState == FormWindowState.Maximized
            ? Resources.maximize
            : Resources.maximize;

        btnMaximize.Invalidate();
    }

    private bool CheckUserAuthentication()
    {
        return !AppSession.IsAuthenticated;
    }

    private async Task RefreshCurrentUserSessionAsync()
    {
        UserService userServices = new();
        var result = await userServices.GetByIdAsync(AppSession.CurrentUserID);

        if (result.IsSuccess && result.Data != null)
        {
            AppSession.CurrentUser = result.Data;
            UpdateUserProfileDisplay();
        }
    }

    private void BtnUserProfile_Click(object? sender, EventArgs e)
    {
        if (CheckUserAuthentication() || contextMenuUser == null) return;

        Point screenPos = btnUserProfile.PointToScreen(new Point(btnUserProfile.Width, btnUserProfile.Height));
        contextMenuUser.Show(screenPos.X - contextMenuUser.PreferredSize.Width, screenPos.Y);
    }

    private async void ItemCurrentUserInfo_Click(object? sender, EventArgs e)
    {
        if (CheckUserAuthentication()) return;

        using frmUserCard frm = new(AppSession.CurrentUserID);
        frm.OnEditedSuccessfully += async () => await RefreshCurrentUserSessionAsync();
        frm.OnDeletedSuccessfully += () => Application.Restart();

        if (ParentForm != null)
        {
            await frm.ShowDialogAsync(ParentForm);
        }
    }

    private async void ItemChangePassword_Click(object? sender, EventArgs e)
    {
        if (!AppSession.IsAuthenticated) return;

        using frmForgetPassword frm = new(AppSession.CurrentUserName, "Change Password", false);
        frm.OnPasswordChange += (username, newPassword) => Application.Restart();

        if (ParentForm != null)
        {
            await frm.ShowDialogAsync(ParentForm);
        }
    }

    private async void ItemSettings_Click(object? sender, EventArgs e)
    {
        if (!AppSession.IsAuthenticated) return;

        using var frm = new frmAppearanceSettings();
        if (ParentForm != null)
        {
            await frm.ShowDialogAsync(ParentForm);
        }
    }

    private void ItemSignOut_Click(object? sender, EventArgs e)
    {
        AppSession.LogOut();
        OnSignOutClicked?.Invoke(this, EventArgs.Empty);
    }
}