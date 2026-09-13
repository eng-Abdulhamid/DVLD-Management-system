using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DVLD.PL.Common;

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

        private Form? _parentFormRef;
        private Control? _parentControlRef;

        public ctrlFormHeader()
        {
            InitializeComponent();

            if (!UIUtility.IsDesignMode)
            {
                RegisterEvents();
                UITheme.OnThemeChanged += HandleThemeChanged;
                ApplyThemeStyles();
            }
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

        private void ApplyThemeStyles()
        {
            lblTitle.ForeColor = UITheme.TextPrimary;

            btnMinimize.ForeColor = UITheme.TextSecondary;
            btnMaximize.ForeColor = UITheme.TextSecondary;
            btnClose.ForeColor = UITheme.TextSecondary;

            SetupHoverEffect(btnClose, UITheme.Danger, Color.White);
            SetupHoverEffect(btnMaximize, UITheme.SelectionBg, UITheme.TextPrimary);
            SetupHoverEffect(btnMinimize, UITheme.SelectionBg, UITheme.TextPrimary);

            Invalidate(true);
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
                BackColor = _parentControlRef.BackColor;
                _parentControlRef.BackColorChanged += Parent_BackColorChanged;
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

            if (btnClose != null) btnClose.Visible = _allowClose;
            if (btnMaximize != null) btnMaximize.Visible = _allowMaximize;
            if (btnMinimize != null) btnMinimize.Visible = _allowMinimize;

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
        }

        private void Header_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || ParentForm == null) return;

            Point currentScreenPos = Cursor.Position;
            TimeSpan timeDifference = DateTime.Now - _lastClickTime;
            int deltaX = Math.Abs(currentScreenPos.X - _lastClickPos.X);
            int deltaY = Math.Abs(currentScreenPos.Y - _lastClickPos.Y);

            // Double click validation for window maximize toggle
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
    }
}