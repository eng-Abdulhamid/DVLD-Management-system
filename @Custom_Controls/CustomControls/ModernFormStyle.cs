using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace DVLDPresentationLayerWInFormApp.CustomControls
{
    public class ModernFormStyle : Component
    {
        #region Fields
        private Form _form;
        private Color _primaryColor = Color.FromArgb(45, 118, 232);
        private Color _secondaryColor = Color.FromArgb(54, 45, 46);
        private Color _accentColor = Color.FromArgb(238, 82, 83);
        private Color _backgroundColor = Color.FromArgb(245, 245, 245);
        private Color _foregroundColor = Color.Black;
        private Color _borderColor = Color.FromArgb(200, 200, 200);
        private Color _shadowColor = Color.FromArgb(100, 0, 0, 0);
        private int _borderRadius = 8;
        private int _borderThickness = 1;
        private int _shadowSize = 8;
        private bool _enableShadow = true;
        private bool _enableBorderRadius = true;
        private bool _enableGradient = true;
        private bool _enableAnimation = true;
        private bool _enableGlassEffect = false;
        private bool _enableCustomTitleBar = false;
        private float _gradientAngle = 45f;
        private bool _isDarkTheme = false;
        private int _cornerRadiusTopLeft = 8;
        private int _cornerRadiusTopRight = 8;
        private int _cornerRadiusBottomLeft = 8;
        private int _cornerRadiusBottomRight = 8;
        private float _shadowOpacity = 0.3f;
        private bool _showFormBorder = true;
        private Color _titleBarBackColor = Color.FromArgb(45, 118, 232);
        private Color _titleBarForeColor = Color.White;
        private int _titleBarHeight = 32;
        private bool _enableTitleBarGradient = true;
        private bool _enableTransparency = false;
        private float _transparency = 1f;
        private Timer _animationTimer;
        private float _animationProgress = 0f;
        private bool _isAnimating = false;
        private Color _hoverColor = Color.FromArgb(60, 130, 250);
        private Color _clickColor = Color.FromArgb(30, 90, 200);
        private bool _enableDragWindowMove = true;
        private bool _enableDoubleClickMaximize = true;
        private Point _dragStartPoint;
        private bool _isDragging = false;
        #endregion

        #region Constructor
        public ModernFormStyle()
        {
            _animationTimer = new Timer();
            _animationTimer.Interval = 16;
            _animationTimer.Tick += AnimationTimer_Tick;
            InitializeTheme();
        }

        public ModernFormStyle(IContainer container) : this()
        {
            container?.Add(this);
        }
        #endregion

        #region Properties

        #region Theme Properties
        [Category("Modern Form - Theme")]
        [Description("The form to apply modern styling to")]
        public Form Form
        {
            get => _form;
            set { _form = value; ApplyModernStyle(); }
        }

        [Category("Modern Form - Theme")]
        [Description("Primary color for the form")]
        public Color PrimaryColor
        {
            get => _primaryColor;
            set { _primaryColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Theme")]
        [Description("Secondary color for the form")]
        public Color SecondaryColor
        {
            get => _secondaryColor;
            set { _secondaryColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Theme")]
        [Description("Accent color for highlights")]
        public Color AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Theme")]
        [Description("Background color")]
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; }
        }

        [Category("Modern Form - Theme")]
        [Description("Foreground/Text color")]
        public Color ForegroundColor
        {
            get => _foregroundColor;
            set { _foregroundColor = value; }
        }

        [Category("Modern Form - Theme")]
        [Description("Use dark theme")]
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set { _isDarkTheme = value; ApplyTheme(); }
        }
        #endregion

        #region Style Properties
        [Category("Modern Form - Style")]
        [Description("Border color")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Style")]
        [Description("Border thickness in pixels")]
        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = Math.Max(0, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Style")]
        [Description("Border radius for all corners")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = Math.Max(0, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Style")]
        [Description("Enable border radius")]
        public bool EnableBorderRadius
        {
            get => _enableBorderRadius;
            set { _enableBorderRadius = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Style")]
        [Description("Show form border")]
        public bool ShowFormBorder
        {
            get => _showFormBorder;
            set { _showFormBorder = value; _form?.Invalidate(); }
        }
        #endregion

        #region Corner Radius Properties
        [Category("Modern Form - Corner Radius")]
        [Description("Top-left corner radius")]
        public int CornerRadiusTopLeft
        {
            get => _cornerRadiusTopLeft;
            set { _cornerRadiusTopLeft = Math.Max(0, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Corner Radius")]
        [Description("Top-right corner radius")]
        public int CornerRadiusTopRight
        {
            get => _cornerRadiusTopRight;
            set { _cornerRadiusTopRight = Math.Max(0, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Corner Radius")]
        [Description("Bottom-left corner radius")]
        public int CornerRadiusBottomLeft
        {
            get => _cornerRadiusBottomLeft;
            set { _cornerRadiusBottomLeft = Math.Max(0, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Corner Radius")]
        [Description("Bottom-right corner radius")]
        public int CornerRadiusBottomRight
        {
            get => _cornerRadiusBottomRight;
            set { _cornerRadiusBottomRight = Math.Max(0, value); _form?.Invalidate(); }
        }
        #endregion

        #region Shadow Properties
        [Category("Modern Form - Shadow")]
        [Description("Enable shadow effect")]
        public bool EnableShadow
        {
            get => _enableShadow;
            set { _enableShadow = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Shadow")]
        [Description("Shadow size in pixels")]
        public int ShadowSize
        {
            get => _shadowSize;
            set { _shadowSize = Math.Max(0, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Shadow")]
        [Description("Shadow color")]
        public Color ShadowColor
        {
            get => _shadowColor;
            set { _shadowColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Shadow")]
        [Description("Shadow opacity (0-1)")]
        public float ShadowOpacity
        {
            get => _shadowOpacity;
            set { _shadowOpacity = Math.Max(0f, Math.Min(1f, value)); _form?.Invalidate(); }
        }
        #endregion

        #region Gradient Properties
        [Category("Modern Form - Gradient")]
        [Description("Enable gradient background")]
        public bool EnableGradient
        {
            get => _enableGradient;
            set { _enableGradient = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Gradient")]
        [Description("Gradient angle in degrees")]
        public float GradientAngle
        {
            get => _gradientAngle;
            set { _gradientAngle = value; _form?.Invalidate(); }
        }
        #endregion

        #region Glass Effect Properties
        [Category("Modern Form - Glass Effect")]
        [Description("Enable glass effect")]
        public bool EnableGlassEffect
        {
            get => _enableGlassEffect;
            set { _enableGlassEffect = value; }
        }

        [Category("Modern Form - Glass Effect")]
        [Description("Enable transparency")]
        public bool EnableTransparency
        {
            get => _enableTransparency;
            set { _enableTransparency = value; }
        }

        [Category("Modern Form - Glass Effect")]
        [Description("Transparency level (0-1)")]
        public float Transparency
        {
            get => _transparency;
            set { _transparency = Math.Max(0f, Math.Min(1f, value)); }
        }
        #endregion

        #region Title Bar Properties
        [Category("Modern Form - Title Bar")]
        [Description("Enable custom title bar")]
        public bool EnableCustomTitleBar
        {
            get => _enableCustomTitleBar;
            set { _enableCustomTitleBar = value; }
        }

        [Category("Modern Form - Title Bar")]
        [Description("Title bar background color")]
        public Color TitleBarBackColor
        {
            get => _titleBarBackColor;
            set { _titleBarBackColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Title Bar")]
        [Description("Title bar foreground color")]
        public Color TitleBarForeColor
        {
            get => _titleBarForeColor;
            set { _titleBarForeColor = value; _form?.Invalidate(); }
        }

        [Category("Modern Form - Title Bar")]
        [Description("Title bar height in pixels")]
        public int TitleBarHeight
        {
            get => _titleBarHeight;
            set { _titleBarHeight = Math.Max(24, value); _form?.Invalidate(); }
        }

        [Category("Modern Form - Title Bar")]
        [Description("Enable title bar gradient")]
        public bool EnableTitleBarGradient
        {
            get => _enableTitleBarGradient;
            set { _enableTitleBarGradient = value; _form?.Invalidate(); }
        }
        #endregion

        #region Animation Properties
        [Category("Modern Form - Animation")]
        [Description("Enable animations")]
        public bool EnableAnimation
        {
            get => _enableAnimation;
            set { _enableAnimation = value; }
        }

        [Category("Modern Form - Animation")]
        [Description("Hover color")]
        public Color HoverColor
        {
            get => _hoverColor;
            set { _hoverColor = value; }
        }

        [Category("Modern Form - Animation")]
        [Description("Click color")]
        public Color ClickColor
        {
            get => _clickColor;
            set { _clickColor = value; }
        }
        #endregion

        #region Behavior Properties
        [Category("Modern Form - Behavior")]
        [Description("Enable drag window move")]
        public bool EnableDragWindowMove
        {
            get => _enableDragWindowMove;
            set { _enableDragWindowMove = value; }
        }

        [Category("Modern Form - Behavior")]
        [Description("Enable double-click to maximize")]
        public bool EnableDoubleClickMaximize
        {
            get => _enableDoubleClickMaximize;
            set { _enableDoubleClickMaximize = value; }
        }
        #endregion

        #endregion

        #region Private Methods
        private void InitializeTheme()
        {
            _primaryColor = Color.FromArgb(45, 118, 232);
            _secondaryColor = Color.FromArgb(54, 45, 46);
            _accentColor = Color.FromArgb(238, 82, 83);
            _backgroundColor = Color.FromArgb(245, 245, 245);
        }

        private void ApplyTheme()
        {
            if (_isDarkTheme)
            {
                _backgroundColor = Color.FromArgb(30, 30, 30);
                _foregroundColor = Color.White;
                _borderColor = Color.FromArgb(60, 60, 60);
                _titleBarBackColor = Color.FromArgb(20, 20, 20);
                _titleBarForeColor = Color.White;
            }
            else
            {
                _backgroundColor = Color.FromArgb(245, 245, 245);
                _foregroundColor = Color.Black;
                _borderColor = Color.FromArgb(200, 200, 200);
                _titleBarBackColor = _primaryColor;
                _titleBarForeColor = Color.White;
            }

            if (_form != null)
            {
                _form.BackColor = _backgroundColor;
                _form.ForeColor = _foregroundColor;
                _form.Invalidate();
            }
        }

        private void ApplyModernStyle()
        {
            if (_form == null) return;

            _form.FormBorderStyle = FormBorderStyle.None;
            _form.BackColor = _backgroundColor;
            _form.ForeColor = _foregroundColor;

            // Hook into form events
            _form.Paint += Form_Paint;
            _form.MouseDown += Form_MouseDown;
            _form.MouseMove += Form_MouseMove;
            _form.MouseUp += Form_MouseUp;
            _form.Resize += Form_Resize;
            _form.DoubleClick += Form_DoubleClick;

            // Set form properties
            _form.AllowTransparency = _enableTransparency;
            if (_enableTransparency)
                _form.Opacity = _transparency;
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            if (_form == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // Draw shadow
            if (_enableShadow)
                DrawShadow(e.Graphics);

            // Draw background
            DrawBackground(e.Graphics);

            // Draw title bar
            if (_enableCustomTitleBar)
                DrawTitleBar(e.Graphics);

            // Draw border
            if (_showFormBorder)
                DrawBorder(e.Graphics);
        }

        private void DrawShadow(Graphics g)
        {
            using (var shadowPath = GetRoundedPath(new Rectangle(_shadowSize, _shadowSize, _form.Width - _shadowSize * 2, _form.Height - _shadowSize * 2), _borderRadius))
            using (var shadowBrush = new SolidBrush(Color.FromArgb((int)(_shadowOpacity * 255), _shadowColor.R, _shadowColor.G, _shadowColor.B)))
            {
                g.FillPath(shadowBrush, shadowPath);
            }
        }

        private void DrawBackground(Graphics g)
        {
            if (_enableGradient)
            {
                using (var gradientBrush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point((int)(_form.Width * Math.Cos(_gradientAngle * Math.PI / 180)),
                              (int)(_form.Height * Math.Sin(_gradientAngle * Math.PI / 180))),
                    _backgroundColor,
                    Color.FromArgb(_backgroundColor.A, 
                                 Math.Max(0, _backgroundColor.R - 10),
                                 Math.Max(0, _backgroundColor.G - 10),
                                 Math.Max(0, _backgroundColor.B - 10))))
                {
                    using (var path = GetRoundedPath(new Rectangle(0, 0, _form.Width, _form.Height), _borderRadius))
                    {
                        g.FillPath(gradientBrush, path);
                    }
                }
            }
            else
            {
                using (var backgroundBrush = new SolidBrush(_backgroundColor))
                using (var path = GetRoundedPath(new Rectangle(0, 0, _form.Width, _form.Height), _borderRadius))
                {
                    g.FillPath(backgroundBrush, path);
                }
            }
        }

        private void DrawTitleBar(Graphics g)
        {
            var titleBarRect = new Rectangle(0, 0, _form.Width, _titleBarHeight);

            if (_enableTitleBarGradient)
            {
                using (var titleGradient = new LinearGradientBrush(titleBarRect, _titleBarBackColor, 
                    Color.FromArgb(_titleBarBackColor.A, 
                                 Math.Max(0, _titleBarBackColor.R - 20),
                                 Math.Max(0, _titleBarBackColor.G - 20),
                                 Math.Max(0, _titleBarBackColor.B - 20)), 90f))
                {
                    g.FillRectangle(titleGradient, titleBarRect);
                }
            }
            else
            {
                using (var titleBrush = new SolidBrush(_titleBarBackColor))
                {
                    g.FillRectangle(titleBrush, titleBarRect);
                }
            }

            // Draw title text
            TextRenderer.DrawText(g, _form.Text, new Font("Segoe UI", 10, FontStyle.Bold), 
                titleBarRect, _titleBarForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void DrawBorder(Graphics g)
        {
            using (var borderPen = new Pen(_borderColor, _borderThickness))
            {
                using (var path = GetRoundedPath(new Rectangle(_borderThickness / 2, _borderThickness / 2, 
                    _form.Width - _borderThickness, _form.Height - _borderThickness), _borderRadius))
                {
                    g.DrawPath(borderPen, path);
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            if (d > bounds.Width) d = bounds.Width;
            if (d > bounds.Height) d = bounds.Height;

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (_enableDragWindowMove && e.Y < _titleBarHeight)
            {
                _isDragging = true;
                _dragStartPoint = e.Location;
            }

            if (_enableDoubleClickMaximize && e.Clicks == 2 && e.Y < _titleBarHeight)
            {
                _form.WindowState = _form.WindowState == FormWindowState.Maximized ? 
                    FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _form.WindowState == FormWindowState.Normal)
            {
                _form.Left += e.X - _dragStartPoint.X;
                _form.Top += e.Y - _dragStartPoint.Y;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            _form?.Invalidate();
        }

        private void Form_DoubleClick(object sender, EventArgs e)
        {
            if (_enableDoubleClickMaximize)
            {
                _form.WindowState = _form.WindowState == FormWindowState.Maximized ? 
                    FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (_isAnimating && _enableAnimation)
            {
                _animationProgress = Math.Min(1f, _animationProgress + 0.05f);
                _form?.Invalidate();
            }
        }
        #endregion

        #region Public Methods
        public void ApplyLightTheme()
        {
            _isDarkTheme = false;
            ApplyTheme();
        }

        public void ApplyDarkTheme()
        {
            _isDarkTheme = true;
            ApplyTheme();
        }

        public void ApplyBlueTheme()
        {
            _primaryColor = Color.FromArgb(45, 118, 232);
            _secondaryColor = Color.FromArgb(54, 100, 150);
            _accentColor = Color.FromArgb(100, 150, 255);
            _backgroundColor = Color.FromArgb(240, 245, 250);
            _titleBarBackColor = _primaryColor;
        }

        public void ApplyGreenTheme()
        {
            _primaryColor = Color.FromArgb(52, 168, 83);
            _secondaryColor = Color.FromArgb(46, 125, 50);
            _accentColor = Color.FromArgb(76, 175, 80);
            _backgroundColor = Color.FromArgb(240, 250, 243);
            _titleBarBackColor = _primaryColor;
        }

        public void ApplyRedTheme()
        {
            _primaryColor = Color.FromArgb(233, 30, 99);
            _secondaryColor = Color.FromArgb(194, 24, 91);
            _accentColor = Color.FromArgb(255, 87, 34);
            _backgroundColor = Color.FromArgb(252, 240, 245);
            _titleBarBackColor = _primaryColor;
        }

        public void ApplyPurpleTheme()
        {
            _primaryColor = Color.FromArgb(156, 39, 176);
            _secondaryColor = Color.FromArgb(103, 58, 183);
            _accentColor = Color.FromArgb(187, 134, 252);
            _backgroundColor = Color.FromArgb(243, 237, 250);
            _titleBarBackColor = _primaryColor;
        }

        public void SetCustomTheme(Color primary, Color secondary, Color accent, Color background)
        {
            _primaryColor = primary;
            _secondaryColor = secondary;
            _accentColor = accent;
            _backgroundColor = background;
            _titleBarBackColor = primary;
            _form?.Invalidate();
        }

        public void ResetToDefault()
        {
            InitializeTheme();
            _borderRadius = 8;
            _borderThickness = 1;
            _shadowSize = 8;
            _enableShadow = true;
            _enableBorderRadius = true;
            _enableGradient = true;
            _isDarkTheme = false;
            _form?.Invalidate();
        }

        public void StartAnimation()
        {
            if (_enableAnimation)
            {
                _isAnimating = true;
                _animationTimer.Start();
            }
        }

        public void StopAnimation()
        {
            _isAnimating = false;
            _animationTimer.Stop();
            _animationProgress = 0f;
        }
        #endregion

        #region Cleanup
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_form != null)
                {
                    _form.Paint -= Form_Paint;
                    _form.MouseDown -= Form_MouseDown;
                    _form.MouseMove -= Form_MouseMove;
                    _form.MouseUp -= Form_MouseUp;
                    _form.Resize -= Form_Resize;
                    _form.DoubleClick -= Form_DoubleClick;
                }
                _animationTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
