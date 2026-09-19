using DVLD.PL.Theme;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace DVLD.PL.Global
{
    public partial class frmBase : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        // Win32 Message Constants
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int WM_NCLBUTTONDBLCLK = 0x00A3;
        private const int WM_NCHITTEST = 0x0084;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;

        private const int DWMWA_WINDOW_CORNER_PREFERENCE = 33;
        private const int DWMWCP_ROUND = 2;
        private const int DWMWCP_DONOTROUND = 1;

        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(124, 58, 237);
        private bool _allowResize = true;

        private bool _allowClose = true;
        private bool _allowMaximize = true;
        private bool _allowMinimize = true;

        private FormWindowState _lastWindowState = FormWindowState.Normal;

        protected virtual bool RequiresAuthentication => true;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000; // CS_DROPSHADOW
                return cp;
            }
        }

        public frmBase()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw, true);
            UpdateStyles();

            BackColor = Color.White;
            UpdatePadding();
            if (!UIUtility.IsDesignMode)
            {
                AppSession.OnUserSessionChanged += HandleUserSessionChanged;
            }
            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;

            SyncHeaderProperties();
        }
        protected void ApplyTheme()
        {
            ThemeApplicator.Apply(this);
            Invalidate(true);
        }
        private void ThemeManager_ThemeChanged(
        object? sender,
        EventArgs e)
        {
            ThemeApplicator.Apply(this);
        }

        public void SetContextTitle(string currentScreenTitle)
        {
            Form? parent = Owner ?? ActiveForm;

            if (parent is frmBase baseParent && baseParent != this && !string.IsNullOrWhiteSpace(baseParent.Text))
            {
                string fullPath = $"{baseParent.Text} / {currentScreenTitle}";
                Text = fullPath;
                if (headerControl != null)
                {
                    headerControl.TitleText = fullPath;
                }
            }
            else
            {
                Text = currentScreenTitle;
            }
        }

        #region Standard Window Properties (Shadowed)

        [Category("Window Style")]
        [Description("Controls whether the window can be maximized.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool MaximizeBox
        {
            get => _allowMaximize;
            set
            {
                _allowMaximize = value;
                base.MaximizeBox = value;
                if (headerControl != null) headerControl.AllowMaximize = value;
            }
        }

        [Category("Window Style")]
        [Description("Controls whether the window can be minimized.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool MinimizeBox
        {
            get => _allowMinimize;
            set
            {
                _allowMinimize = value;
                base.MinimizeBox = value;
                if (headerControl != null) headerControl.AllowMinimize = value;
            }
        }

        #endregion

        #region Custom Properties

        [Category("Window Frame")]
        [Description("Enables or disables resizing the form from its edges.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowResize
        {
            get => _allowResize;
            set => _allowResize = value;
        }

        [Category("Window Frame")]
        [Description("The color of the outer border.")]
        [DefaultValue(typeof(Color), "124, 58, 237")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color CustomBorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Window Frame")]
        [Description("The thickness of the outer border.")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CustomBorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = Math.Max(1, value);
                UpdatePadding();
                Invalidate();
            }
        }

        [Category("Window Header Setup")]
        [Description("Enables or disables the Close button on the header.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowClose
        {
            get => _allowClose;
            set
            {
                _allowClose = value;
                if (headerControl != null) headerControl.AllowClose = value;
            }
        }

        [Category("Window Header Setup")]
        [Description("Enables or disables the Maximize button on the header.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMaximize
        {
            get => MaximizeBox;
            set => MaximizeBox = value;
        }

        [Category("Window Header Setup")]
        [Description("Enables or disables the Minimize button on the header.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMinimize
        {
            get => MinimizeBox;
            set => MinimizeBox = value;
        }


        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Security gatekeeper: verify session before presenting any authenticated view
            if (!UIUtility.IsDesignMode && RequiresAuthentication && !AppSession.IsAuthenticated)
            {
                BeginInvoke(new Action(() =>
                {
                    Close();
                }));
                return;
            }

            UpdateWorkingAreaBounds();
            ApplyCornerPreference(true);
            SyncHeaderProperties();

            if (!UIUtility.IsDesignMode)
            {
                _ = InitializeDataAsync();
            }
        }

        // Extensibility hook for asynchronous data fetching in derived forms
        protected virtual Task InitializeDataAsync() => Task.CompletedTask;


        private void HandleThemeChanged(object s, ThemeManager.ModeEventsArgs e)
        {
            if (IsDisposed || !IsHandleCreated) return;

            ThemeApplicator.Apply(this);
            Invalidate(true);
        }

        private void HandleUserSessionChanged()
        {
            
        }

        private void SyncHeaderProperties()
        {
            if (headerControl == null) return;

            headerControl.SendToBack();
            headerControl.TitleText = Text;
            headerControl.AllowClose = _allowClose;
            headerControl.AllowMaximize = _allowMaximize;
            headerControl.AllowMinimize = _allowMinimize;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState != _lastWindowState)
            {
                _lastWindowState = WindowState;
                SuspendLayout();

                UpdatePadding();
                ApplyCornerPreference(WindowState != FormWindowState.Maximized);

                ResumeLayout(true);
            }

            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (headerControl != null)
            {
                headerControl.TitleText = Text;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (WindowState != FormWindowState.Maximized && _borderSize > 0)
            {
                using var brush = new SolidBrush(_borderColor);
                e.Graphics.FillRectangle(brush, 0, 0, Width, _borderSize);
                e.Graphics.FillRectangle(brush, 0, Height - _borderSize, Width, _borderSize);
                e.Graphics.FillRectangle(brush, 0, 0, _borderSize, Height);
                e.Graphics.FillRectangle(brush, Width - _borderSize, 0, _borderSize, Height);
            }
        }

        private void UpdatePadding()
        {
            Padding = (WindowState == FormWindowState.Maximized) ? Padding.Empty : new Padding(_borderSize);
        }

        private void UpdateWorkingAreaBounds()
        {
            Rectangle workingArea = Screen.FromHandle(Handle).WorkingArea;
            MaximizedBounds = new Rectangle(0, 0, workingArea.Width, workingArea.Height);
        }

        private void ApplyCornerPreference(bool round)
        {
            if (Environment.OSVersion.Version.Build >= 22000)
            {
                try
                {
                    int cornerPreference = round ? DWMWCP_ROUND : DWMWCP_DONOTROUND;
                    DwmSetWindowAttribute(Handle, DWMWA_WINDOW_CORNER_PREFERENCE, ref cornerPreference, sizeof(int));
                }
                catch { }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK && m.WParam.ToInt32() == HTCAPTION)
            {
                if (_allowMaximize) ToggleMaximize();
                return;
            }

            base.WndProc(ref m);

            // Handle custom non-client resize hit-testing
            if (_allowResize && WindowState == FormWindowState.Normal && m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                int x = unchecked((short)(long)m.LParam);
                int y = unchecked((short)((long)m.LParam >> 16));
                Point clientPoint = PointToClient(new Point(x, y));

                int grip = Math.Max(6, _borderSize * 3);

                bool isLeft = clientPoint.X <= grip;
                bool isRight = clientPoint.X >= ClientSize.Width - grip;
                bool isTop = clientPoint.Y <= grip;
                bool isBottom = clientPoint.Y >= ClientSize.Height - grip;

                if (isTop && isLeft) m.Result = (IntPtr)HTTOPLEFT;
                else if (isTop && isRight) m.Result = (IntPtr)HTTOPRIGHT;
                else if (isBottom && isLeft) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (isBottom && isRight) m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (isLeft) m.Result = (IntPtr)HTLEFT;
                else if (isRight) m.Result = (IntPtr)HTRIGHT;
                else if (isTop) m.Result = (IntPtr)HTTOP;
                else if (isBottom) m.Result = (IntPtr)HTBOTTOM;
            }
        }

        public void ToggleMaximize()
        {
            if (!_allowMaximize) return;

            WindowState = (WindowState == FormWindowState.Normal)
                ? FormWindowState.Maximized
                : FormWindowState.Normal;
        }

        protected void EnableWindowDragging(Control control)
        {
            control.MouseDown += HandleDragMouseDown;
        }

        private void HandleDragMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}