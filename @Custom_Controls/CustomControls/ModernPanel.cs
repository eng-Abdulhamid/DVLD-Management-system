using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomControls
{
    /// <summary>
    /// لوحة عصرية متقدمة وشاملة تدعم الحواف المستديرة، التدرجات اللونية، الإطارات المتحركة، والتجاوب الكامل.
    /// </summary>
    [ToolboxItem(true)]
    [Description("لوحة عصرية احترافية مع ميزات تصميم متقدمة وتجاوب كامل")]
    public class ModernPanel : Panel
    {
        // --- حقول التصميم الأساسي ---
        private int _borderRadius = 20;
        private Color _accentColor = Color.DodgerBlue;
        private int _borderSize = 2;
        private DashStyle _borderStyle = DashStyle.Solid;

        // --- حقول الخلفية المتقدمة ---
        private bool _enableGradientBackground = false;
        private Color _gradientColor1 = Color.White;
        private Color _gradientColor2 = Color.FromArgb(240, 240, 240);
        private float _gradientAngle = 90f;

        // --- حقول الأكريليك والشفافية ---
        private bool _enableAcrylicEffect = false;
        private Color _acrylicTintColor = Color.White;
        private int _acrylicOpacity = 128;

        // --- حقول الإطار المتحرك (Neon Effect) ---
        private bool _enableBorderAnimation = false;
        private Color _borderAnimationColor1 = Color.Cyan;
        private Color _borderAnimationColor2 = Color.Purple;
        private float _borderAnimationAngle = 0;
        private int _borderAnimationSpeed = 5;
        private Timer _animationTimer;

        // --- حقول الشارة (Badge) ---
        private string _badgeValue = "";
        private Color _badgeBackColor = Color.Red;
        private Color _badgeForeColor = Color.White;

        // --- حقول الزوايا الفردية ---
        private int _cornerRadiusTopLeft = 20;
        private int _cornerRadiusTopRight = 20;
        private int _cornerRadiusBottomLeft = 20;
        private int _cornerRadiusBottomRight = 20;

        public ModernPanel()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(250, 150);
            this.BackColor = Color.White;
            this.ResizeRedraw = true; // لضمان التجاوب الفوري عند تغيير الحجم

            // إعداد محرك الحركة
            _animationTimer = new Timer();
            _animationTimer.Interval = 20;
            _animationTimer.Tick += (s, e) => {
                _borderAnimationAngle = (_borderAnimationAngle + _borderAnimationSpeed) % 360;
                this.Invalidate();
            };
        }

        #region "Properties - Appearance"

        [Category("Modern Appearance")]
        [Description("نصف قطر الحواف الكلي")]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = value;
                UpdateAllCorners(value);
                UpdateRegion(); // تحديث المنطقة فوراً عند تغيير القيمة
                Invalidate();
            }
        }

        [Category("Modern Appearance")]
        [Description("لون الإطار الثابت")]
        public Color AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("سمك الإطار")]
        public int BorderSize
        {
            get => _borderSize;
            set { _borderSize = Math.Max(0, value); Invalidate(); }
        }

        [Category("Modern Appearance")]
        [Description("نمط خط الإطار (متصل، منقط، إلخ)")]
        public DashStyle BorderStyle
        {
            get => _borderStyle;
            set { _borderStyle = value; Invalidate(); }
        }

        #endregion

        #region "Properties - Gradient Background"

        [Category("Modern Background")]
        [Description("تفعيل التدرج اللوني للخلفية")]
        public bool EnableGradientBackground
        {
            get => _enableGradientBackground;
            set { _enableGradientBackground = value; Invalidate(); }
        }

        [Category("Modern Background")]
        public Color GradientColor1
        {
            get => _gradientColor1;
            set { _gradientColor1 = value; Invalidate(); }
        }

        [Category("Modern Background")]
        public Color GradientColor2
        {
            get => _gradientColor2;
            set { _gradientColor2 = value; Invalidate(); }
        }

        [Category("Modern Background")]
        public float GradientAngle
        {
            get => _gradientAngle;
            set { _gradientAngle = value; Invalidate(); }
        }

        #endregion

        #region "Properties - Border Animation"

        [Category("Modern Border Animation")]
        [Description("تفعيل دوران الألوان حول الإطار")]
        public bool EnableBorderAnimation
        {
            get => _enableBorderAnimation;
            set
            {
                _enableBorderAnimation = value;
                if (value && !DesignMode) _animationTimer.Start();
                else _animationTimer.Stop();
                Invalidate();
            }
        }

        [Category("Modern Border Animation")]
        public Color BorderAnimationColor1
        {
            get => _borderAnimationColor1;
            set { _borderAnimationColor1 = value; Invalidate(); }
        }

        [Category("Modern Border Animation")]
        public Color BorderAnimationColor2
        {
            get => _borderAnimationColor2;
            set { _borderAnimationColor2 = value; Invalidate(); }
        }

        [Category("Modern Border Animation")]
        public int BorderAnimationSpeed
        {
            get => _borderAnimationSpeed;
            set { _borderAnimationSpeed = Math.Max(1, value); }
        }

        #endregion

        #region "Properties - Badge & Corners"

        [Category("Modern Badge")]
        public string BadgeValue
        {
            get => _badgeValue;
            set { _badgeValue = value; Invalidate(); }
        }

        [Category("Modern Badge")]
        public Color BadgeBackColor { get => _badgeBackColor; set { _badgeBackColor = value; Invalidate(); } }

        [Category("Modern Badge")]
        public Color BadgeForeColor { get => _badgeForeColor; set { _badgeForeColor = value; Invalidate(); } }

        [Category("Modern Corners")]
        public int CornerRadiusTopLeft { get => _cornerRadiusTopLeft; set { _cornerRadiusTopLeft = value; UpdateRegion(); Invalidate(); } }
        [Category("Modern Corners")]
        public int CornerRadiusTopRight { get => _cornerRadiusTopRight; set { _cornerRadiusTopRight = value; UpdateRegion(); Invalidate(); } }
        [Category("Modern Corners")]
        public int CornerRadiusBottomLeft { get => _cornerRadiusBottomLeft; set { _cornerRadiusBottomLeft = value; UpdateRegion(); Invalidate(); } }
        [Category("Modern Corners")]
        public int CornerRadiusBottomRight { get => _cornerRadiusBottomRight; set { _cornerRadiusBottomRight = value; UpdateRegion(); Invalidate(); } }

        #endregion

        // --- وظائف الرسم والتجاوب ---

        private void UpdateAllCorners(int value)
        {
            _cornerRadiusTopLeft = _cornerRadiusTopRight = _cornerRadiusBottomLeft = _cornerRadiusBottomRight = value;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            UpdateRegion(); // تحديث القص (Region) فوراً عند تغيير الحجم
        }

        private void UpdateRegion()
        {
            if (this.Width <= 0 || this.Height <= 0) return;

            // هذا الجزء هو المسؤول عن جعل الـ Panel نفسها مستديرة
            using (GraphicsPath path = GetFigurePath(new Rectangle(0, 0, this.Width, this.Height)))
            {
                this.Region = new Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Rectangle rect = ClientRectangle;
            if (rect.Width <= 0 || rect.Height <= 0) return;

            using (GraphicsPath path = GetFigurePath(rect))
            {
                // 1. رسم الخلفية
                if (EnableGradientBackground)
                {
                    using (LinearGradientBrush lgb = new LinearGradientBrush(rect, _gradientColor1, _gradientColor2, _gradientAngle))
                    {
                        g.FillPath(lgb, path);
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(this.BackColor))
                    {
                        g.FillPath(brush, path);
                    }
                }

                // 2. تأثير الأكريليك
                if (_enableAcrylicEffect)
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(_acrylicOpacity, _acrylicTintColor)))
                        g.FillPath(brush, path);
                }

                // 3. رسم الإطار
                if (BorderSize > 0)
                {
                    float penOffset = (float)BorderSize / 2;
                    RectangleF rectF = new RectangleF(penOffset, penOffset, rect.Width - BorderSize, rect.Height - BorderSize);
                    using (GraphicsPath pathFrame = GetFigurePath(rectF))
                    {
                        if (EnableBorderAnimation)
                        {
                            using (LinearGradientBrush lgb = new LinearGradientBrush(rect, _borderAnimationColor1, _borderAnimationColor2, _borderAnimationAngle))
                            {
                                using (Pen pen = new Pen(lgb, BorderSize))
                                {
                                    pen.DashStyle = _borderStyle;
                                    g.DrawPath(pen, pathFrame);
                                }
                            }
                        }
                        else
                        {
                            using (Pen pen = new Pen(AccentColor, BorderSize))
                            {
                                pen.DashStyle = _borderStyle;
                                g.DrawPath(pen, pathFrame);
                            }
                        }
                    }
                }
            }

            // 4. رسم الشارة
            if (!string.IsNullOrEmpty(BadgeValue)) DrawBadge(g);
        }

        // دالة إنشاء المسار المنحني (تدعم RectangleF لدقة الرسم)
        private GraphicsPath GetFigurePath(RectangleF rect)
        {
            GraphicsPath path = new GraphicsPath();
            float tl = Math.Max(1, _cornerRadiusTopLeft * 2);
            float tr = Math.Max(1, _cornerRadiusTopRight * 2);
            float br = Math.Max(1, _cornerRadiusBottomRight * 2);
            float bl = Math.Max(1, _cornerRadiusBottomLeft * 2);

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, tl, tl, 180, 90);
            path.AddArc(rect.Right - tr, rect.Y, tr, tr, 270, 90);
            path.AddArc(rect.Right - br, rect.Bottom - br, br, br, 0, 90);
            path.AddArc(rect.X, rect.Bottom - bl, bl, bl, 90, 90);
            path.CloseFigure();
            return path;
        }

        private GraphicsPath GetFigurePath(Rectangle rect)
        {
            return GetFigurePath((RectangleF)rect);
        }

        private void DrawBadge(Graphics g)
        {
            Font badgeFont = new Font(this.Font.FontFamily, 8.5f, FontStyle.Bold);
            Size badgeSize = TextRenderer.MeasureText(BadgeValue, badgeFont);
            int padding = 8;
            Rectangle badgeRect = new Rectangle(this.Width - badgeSize.Width - 22, 10, badgeSize.Width + padding, badgeSize.Height + 2);

            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 10;
                int diameter = radius * 2;
                path.AddArc(badgeRect.X, badgeRect.Y, diameter, diameter, 180, 90);
                path.AddArc(badgeRect.Right - diameter, badgeRect.Y, diameter, diameter, 270, 90);
                path.AddArc(badgeRect.Right - diameter, badgeRect.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(badgeRect.X, badgeRect.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                using (SolidBrush brush = new SolidBrush(_badgeBackColor)) g.FillPath(brush, path);
                TextRenderer.DrawText(g, BadgeValue, badgeFont, badgeRect, _badgeForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _animationTimer?.Dispose();
            base.Dispose(disposing);
        }
    }
}