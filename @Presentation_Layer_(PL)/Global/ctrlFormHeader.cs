using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVLD.PL.Global
{
    public partial class ctrlFormHeader : UserControl
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0x00A1;
        private const int HT_CAPTION = 0x2;

        private DateTime _lastClickTime = DateTime.MinValue;
        private Point _lastClickPos = Point.Empty;

        private bool _allowClose = true;
        private bool _allowMaximize = true;
        private bool _allowMinimize = true;

        public ctrlFormHeader()
        {
            InitializeComponent();
            RegisterEvents();
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
        [Description("Show or hide the Close button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowClose
        {
            get => _allowClose;
            set
            {
                _allowClose = value;
                if (btnClose != null)
                {
                    btnClose.Visible = value;
                }
            }
        }

        [Category("Header Setup")]
        [Description("Show or hide the Maximize/Restore button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMaximize
        {
            get => _allowMaximize;
            set
            {
                _allowMaximize = value;
                if (btnMaximize != null)
                {
                    btnMaximize.Visible = value;
                }
            }
        }

        [Category("Header Setup")]
        [Description("Show or hide the Minimize button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AllowMinimize
        {
            get => _allowMinimize;
            set
            {
                _allowMinimize = value;
                if (btnMinimize != null)
                {
                    btnMinimize.Visible = value;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (btnClose != null) btnClose.Visible = _allowClose;
            if (btnMaximize != null) btnMaximize.Visible = _allowMaximize;
            if (btnMinimize != null) btnMinimize.Visible = _allowMinimize;

            if (this.ParentForm != null)
            {
                this.ParentForm.Resize += ParentForm_Resize;
                UpdateMaximizeIcon();
            }
        }

        private void ParentForm_Resize(object? sender, EventArgs e)
        {
            UpdateMaximizeIcon();
        }

        private void RegisterEvents()
        {
            this.MouseDown += Header_MouseDown;
            lblTitle.MouseDown += Header_MouseDown;

            btnClose.Click += (s, e) => this.ParentForm?.Close();
            btnMinimize.Click += (s, e) =>
            {
                if (this.ParentForm != null)
                {
                    this.ParentForm.WindowState = FormWindowState.Minimized;
                }
            };
            btnMaximize.Click += (s, e) => ToggleMaximize();

            SetupHoverEffect(btnClose, Color.FromArgb(239, 68, 68), Color.White);
            SetupHoverEffect(btnMaximize, Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
            SetupHoverEffect(btnMinimize, Color.FromArgb(241, 245, 249), Color.FromArgb(15, 23, 42));
        }

        private void Header_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || this.ParentForm == null) return;

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

            if (this.ParentForm.WindowState == FormWindowState.Normal)
            {
                ReleaseCapture();
                SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void ToggleMaximize()
        {
            if (this.ParentForm == null || !_allowMaximize) return;

            if (this.ParentForm is frmBase baseForm)
            {
                baseForm.ToggleMaximize();
            }
            else
            {
                this.ParentForm.WindowState = (this.ParentForm.WindowState == FormWindowState.Maximized)
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
            }

            UpdateMaximizeIcon();
        }

        private void UpdateMaximizeIcon()
        {
            if (this.ParentForm == null) return;
            btnMaximize.Text = (this.ParentForm.WindowState == FormWindowState.Maximized) ? "🗗" : "🗖";
        }

        private void SetupHoverEffect(Button btn, Color hoverBackColor, Color hoverForeColor)
        {
            Color defaultBackColor = Color.Transparent;
            Color defaultForeColor = Color.FromArgb(148, 163, 184);

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