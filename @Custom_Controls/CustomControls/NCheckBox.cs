using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NControls
{
    public enum NCheckBoxStyle
    {
        Rounded,
        Square,
        Circle,
        ToggleSwitch
    }

    public enum NCheckAlign
    {
        Left,
        Right
    }

    [DefaultEvent("CheckedChanged")]
    [DefaultProperty("Checked")]
    public class NCheckBox : Control
    {
        private bool _checked = false;
        private CheckState _checkState = CheckState.Unchecked;
        private bool _threeState = false;
        private bool _autoCheck = true;

        private NCheckBoxStyle _style = NCheckBoxStyle.Rounded;
        private NCheckAlign _checkAlign = NCheckAlign.Left;

        private int _boxSize = 18;
        private int _borderRadius = 4;
        private int _borderSize = 1;
        private int _textSpacing = 8;

        private Color _boxBackColor = Color.White;
        private Color _boxBorderColor = Color.FromArgb(200, 205, 212);
        private Color _checkedColor = Color.FromArgb(0, 120, 215);
        private Color _hoverBorderColor = Color.FromArgb(0, 120, 215);
        private Color _checkMarkColor = Color.White;
        private Color _disabledColor = Color.FromArgb(220, 224, 230);
        private Color _disabledTextColor = Color.FromArgb(160, 166, 175);

        private float _checkThickness = 2.0f;

        private int _switchWidth = 38;
        private Color _switchOffTrackColor = Color.FromArgb(220, 224, 230);
        private Color _switchThumbColor = Color.White;

        private bool _enableAnimation = true;
        private int _animationSpeed = 25;
        private float _checkProgress = 0f;
        private float _hoverAlpha = 0f;
        private bool _isHovered = false;
        private bool _isPressed = false;

        private bool _enableRipple = false;
        private Color _rippleColor = Color.FromArgb(40, 0, 120, 215);
        private float _rippleRadius = 0f;
        private float _rippleAlpha = 0f;
        private Point _rippleCenter;

        private readonly Timer? _animTimer;
        private readonly Timer? _hoverTimer;
        private readonly Timer? _rippleTimer;

        public event EventHandler? CheckedChanged;
        public event EventHandler? CheckStateChanged;

        // --- إصلاح نظام التركيز وزر الـ Tab ---
        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new int TabIndex { get => base.TabIndex; set => base.TabIndex = value; }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool TabStop { get => base.TabStop; set => base.TabStop = value; }
        // ------------------------------------

        public NCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.Selectable, true);

            DoubleBuffered = true;
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(30, 41, 59);
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            Cursor = Cursors.Hand;
            Size = new Size(140, 24);

            _animTimer = new Timer { Interval = 15 };
            _animTimer.Tick += AnimTimer_Tick;

            _hoverTimer = new Timer { Interval = 15 };
            _hoverTimer.Tick += HoverTimer_Tick;

            _rippleTimer = new Timer { Interval = 15 };
            _rippleTimer.Tick += RippleTimer_Tick;
        }

        [Category("1. State")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Checked
        {
            get => _checked;
            set
            {
                CheckState newState = value ? CheckState.Checked : CheckState.Unchecked;
                if (_checkState != newState)
                {
                    SetCheckStateInternal(newState);
                }
            }
        }

        [Category("1. State")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CheckState CheckState
        {
            get => _checkState;
            set
            {
                if (_checkState != value)
                {
                    SetCheckStateInternal(value);
                }
            }
        }

        [Category("1. State")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool ThreeState
        {
            get => _threeState;
            set => _threeState = value;
        }

        [Category("1. State")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AutoCheck
        {
            get => _autoCheck;
            set => _autoCheck = value;
        }

        [Category("2. Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public NCheckBoxStyle Style
        {
            get => _style;
            set
            {
                _style = value;
                Invalidate();
            }
        }

        [Category("2. Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public NCheckAlign CheckAlign
        {
            get => _checkAlign;
            set
            {
                _checkAlign = value;
                Invalidate();
            }
        }

        [Category("2. Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BoxSize
        {
            get => _boxSize;
            set
            {
                _boxSize = Math.Max(12, Math.Min(40, value));
                Invalidate();
            }
        }

        [Category("2. Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("2. Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = Math.Max(1, value);
                Invalidate();
            }
        }

        [Category("2. Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int TextSpacing
        {
            get => _textSpacing;
            set
            {
                _textSpacing = Math.Max(0, value);
                Invalidate();
            }
        }

        [Category("3. Colors - Box")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BoxBackColor
        {
            get => _boxBackColor;
            set
            {
                _boxBackColor = value;
                Invalidate();
            }
        }

        [Category("3. Colors - Box")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BoxBorderColor
        {
            get => _boxBorderColor;
            set
            {
                _boxBorderColor = value;
                Invalidate();
            }
        }

        [Category("3. Colors - Box")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color CheckedColor
        {
            get => _checkedColor;
            set
            {
                _checkedColor = value;
                Invalidate();
            }
        }

        [Category("3. Colors - Box")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HoverBorderColor
        {
            get => _hoverBorderColor;
            set
            {
                _hoverBorderColor = value;
                Invalidate();
            }
        }

        [Category("3. Colors - Box")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DisabledColor
        {
            get => _disabledColor;
            set
            {
                _disabledColor = value;
                Invalidate();
            }
        }

        [Category("4. Colors - Mark & Switch")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color CheckMarkColor
        {
            get => _checkMarkColor;
            set
            {
                _checkMarkColor = value;
                Invalidate();
            }
        }

        [Category("4. Colors - Mark & Switch")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public float CheckThickness
        {
            get => _checkThickness;
            set
            {
                _checkThickness = Math.Max(1.0f, value);
                Invalidate();
            }
        }

        [Category("4. Colors - Mark & Switch")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SwitchWidth
        {
            get => _switchWidth;
            set
            {
                _switchWidth = Math.Max(28, value);
                Invalidate();
            }
        }

        [Category("4. Colors - Mark & Switch")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SwitchOffTrackColor
        {
            get => _switchOffTrackColor;
            set
            {
                _switchOffTrackColor = value;
                Invalidate();
            }
        }

        [Category("4. Colors - Mark & Switch")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SwitchThumbColor
        {
            get => _switchThumbColor;
            set
            {
                _switchThumbColor = value;
                Invalidate();
            }
        }

        [Category("5. Colors - Text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DisabledTextColor
        {
            get => _disabledTextColor;
            set
            {
                _disabledTextColor = value;
                Invalidate();
            }
        }

        [Category("6. Behavior & Animation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EnableAnimation
        {
            get => _enableAnimation;
            set => _enableAnimation = value;
        }

        [Category("6. Behavior & Animation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int AnimationSpeed
        {
            get => _animationSpeed;
            set => _animationSpeed = Math.Max(5, Math.Min(60, value));
        }

        [Category("6. Behavior & Animation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EnableRipple
        {
            get => _enableRipple;
            set => _enableRipple = value;
        }

        [Category("6. Behavior & Animation")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color RippleColor
        {
            get => _rippleColor;
            set => _rippleColor = value;
        }

        private void SetCheckStateInternal(CheckState newState)
        {
            bool wasChecked = _checked;
            _checkState = newState;
            _checked = (_checkState == CheckState.Checked);

            if (_enableAnimation && !DesignMode)
            {
                _animTimer?.Start();
            }
            else
            {
                _checkProgress = _checked ? 1.0f : 0.0f;
                Invalidate();
            }

            if (wasChecked != _checked)
            {
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
            CheckStateChanged?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnClick(EventArgs e)
        {
            if (_autoCheck && Enabled)
            {
                ToggleState();
            }
            base.OnClick(e);
        }

        private void ToggleState()
        {
            if (!_threeState)
            {
                Checked = !Checked;
            }
            else
            {
                switch (_checkState)
                {
                    case CheckState.Unchecked:
                        CheckState = CheckState.Checked;
                        break;
                    case CheckState.Checked:
                        CheckState = CheckState.Indeterminate;
                        break;
                    case CheckState.Indeterminate:
                        CheckState = CheckState.Unchecked;
                        break;
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            if (_enableAnimation && !DesignMode)
            {
                _hoverTimer?.Start();
            }
            else
            {
                _hoverAlpha = 1.0f;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            if (_enableAnimation && !DesignMode)
            {
                _hoverTimer?.Start();
            }
            else
            {
                _hoverAlpha = 0.0f;
                Invalidate();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && Enabled)
            {
                _isPressed = true;
                Focus();
                if (_enableRipple && !DesignMode)
                {
                    Rectangle box = GetBoxRectangle();
                    _rippleCenter = new Point(box.X + box.Width / 2, box.Y + box.Height / 2);
                    _rippleRadius = 0;
                    _rippleAlpha = _rippleColor.A;
                    _rippleTimer?.Start();
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                _isPressed = false;
                Invalidate();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Space && Enabled)
            {
                _isPressed = true;
                Invalidate();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Space && Enabled)
            {
                _isPressed = false;
                if (_autoCheck)
                {
                    ToggleState();
                }
                Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        private void AnimTimer_Tick(object? sender, EventArgs e)
        {
            float target = (_checkState == CheckState.Checked || _checkState == CheckState.Indeterminate) ? 1.0f : 0.0f;
            float step = _animationSpeed / 100f;

            if (Math.Abs(_checkProgress - target) <= step)
            {
                _checkProgress = target;
                _animTimer?.Stop();
            }
            else
            {
                _checkProgress += (_checkProgress < target) ? step : -step;
            }
            Invalidate();
        }

        private void HoverTimer_Tick(object? sender, EventArgs e)
        {
            float target = _isHovered ? 1.0f : 0.0f;
            float step = 0.12f;

            if (Math.Abs(_hoverAlpha - target) <= step)
            {
                _hoverAlpha = target;
                _hoverTimer?.Stop();
            }
            else
            {
                _hoverAlpha += (_hoverAlpha < target) ? step : -step;
            }
            Invalidate();
        }

        private void RippleTimer_Tick(object? sender, EventArgs e)
        {
            _rippleRadius += 2.5f;
            _rippleAlpha -= 12f;

            if (_rippleAlpha <= 0)
            {
                _rippleAlpha = 0;
                _rippleTimer?.Stop();
            }
            Invalidate();
        }

        private Rectangle GetBoxRectangle()
        {
            int w = (_style == NCheckBoxStyle.ToggleSwitch) ? _switchWidth : _boxSize;
            int h = _boxSize;
            int y = (Height - h) / 2;
            int x = (_checkAlign == NCheckAlign.Left) ? 2 : Width - w - 2;

            return new Rectangle(x, y, w, h);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width <= 0 || Height <= 0) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            Rectangle boxRect = GetBoxRectangle();

            if (_enableRipple && _rippleAlpha > 0)
            {
                DrawRippleEffect(g);
            }

            if (_style == NCheckBoxStyle.ToggleSwitch)
            {
                DrawToggleSwitch(g, boxRect);
            }
            else
            {
                DrawStandardBox(g, boxRect);
            }

            DrawLabelText(g, boxRect);

            if (Focused && ShowFocusCues)
            {
                DrawFocusRectangle(g, boxRect);
            }
        }

        private void DrawRippleEffect(Graphics g)
        {
            int alpha = (int)Math.Max(0, Math.Min(255, _rippleAlpha));
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, _rippleColor)))
            {
                g.FillEllipse(brush,
                    _rippleCenter.X - _rippleRadius,
                    _rippleCenter.Y - _rippleRadius,
                    _rippleRadius * 2,
                    _rippleRadius * 2);
            }
        }

        private void DrawStandardBox(Graphics g, Rectangle rect)
        {
            Color currentBorder = Enabled ? BlendColors(_boxBorderColor, _hoverBorderColor, _hoverAlpha) : _disabledColor;
            Color currentFill = Enabled ? BlendColors(_boxBackColor, _checkedColor, _checkProgress) : _disabledColor;

            if (!Enabled)
            {
                currentBorder = _disabledColor;
                currentFill = _checked ? _disabledColor : Color.FromArgb(245, 247, 250);
            }

            using (GraphicsPath path = GetBoxPath(rect))
            {
                using (SolidBrush bgBrush = new SolidBrush(currentFill))
                {
                    g.FillPath(bgBrush, path);
                }

                Color activeBorder = _checkProgress > 0 ? BlendColors(currentBorder, _checkedColor, _checkProgress) : currentBorder;
                using (Pen borderPen = new Pen(activeBorder, _borderSize))
                {
                    borderPen.Alignment = PenAlignment.Inset;
                    g.DrawPath(borderPen, path);
                }
            }

            if (_checkState == CheckState.Indeterminate)
            {
                DrawIndeterminateGlyph(g, rect);
            }
            else if (_checkProgress > 0.05f)
            {
                DrawCheckGlyph(g, rect, _checkProgress);
            }
        }

        private void DrawCheckGlyph(Graphics g, Rectangle rect, float progress)
        {
            Color glyphColor = Enabled ? _checkMarkColor : Color.White;
            using (Pen checkPen = new Pen(glyphColor, _checkThickness))
            {
                checkPen.StartCap = LineCap.Round;
                checkPen.EndCap = LineCap.Round;
                checkPen.LineJoin = LineJoin.Round;

                PointF p1 = new PointF(rect.X + rect.Width * 0.24f, rect.Y + rect.Height * 0.50f);
                PointF p2 = new PointF(rect.X + rect.Width * 0.44f, rect.Y + rect.Height * 0.70f);
                PointF p3 = new PointF(rect.X + rect.Width * 0.76f, rect.Y + rect.Height * 0.30f);

                if (progress <= 0.4f)
                {
                    float segment = progress / 0.4f;
                    PointF currentP2 = new PointF(
                        p1.X + (p2.X - p1.X) * segment,
                        p1.Y + (p2.Y - p1.Y) * segment);
                    g.DrawLine(checkPen, p1, currentP2);
                }
                else
                {
                    g.DrawLine(checkPen, p1, p2);
                    float segment = (progress - 0.4f) / 0.6f;
                    PointF currentP3 = new PointF(
                        p2.X + (p3.X - p2.X) * segment,
                        p2.Y + (p3.Y - p2.Y) * segment);
                    g.DrawLine(checkPen, p2, currentP3);
                }
            }
        }

        private void DrawIndeterminateGlyph(Graphics g, Rectangle rect)
        {
            Color glyphColor = Enabled ? _checkMarkColor : Color.White;
            using (Pen pen = new Pen(glyphColor, _checkThickness))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;

                float midY = rect.Y + rect.Height / 2.0f;
                g.DrawLine(pen,
                    rect.X + rect.Width * 0.25f,
                    midY,
                    rect.X + rect.Width * 0.75f,
                    midY);
            }
        }

        private void DrawToggleSwitch(Graphics g, Rectangle rect)
        {
            Color trackColor = Enabled
                ? BlendColors(_switchOffTrackColor, _checkedColor, _checkProgress)
                : _disabledColor;

            int radius = rect.Height / 2;
            using (GraphicsPath trackPath = CreateRoundedRectangle(rect, radius))
            {
                using (SolidBrush trackBrush = new SolidBrush(trackColor))
                {
                    g.FillPath(trackBrush, trackPath);
                }
            }

            int thumbPadding = 3;
            int thumbDiameter = rect.Height - (thumbPadding * 2);
            float startX = rect.X + thumbPadding;
            float endX = rect.Right - thumbPadding - thumbDiameter;
            float thumbX = startX + (endX - startX) * _checkProgress;
            float thumbY = rect.Y + thumbPadding;

            RectangleF thumbRect = new RectangleF(thumbX, thumbY, thumbDiameter, thumbDiameter);

            using (GraphicsPath thumbPath = new GraphicsPath())
            {
                thumbPath.AddEllipse(thumbRect);
                using (SolidBrush thumbBrush = new SolidBrush(Enabled ? _switchThumbColor : Color.FromArgb(245, 245, 245)))
                {
                    g.FillPath(thumbBrush, thumbPath);
                }
            }
        }

        private void DrawLabelText(Graphics g, Rectangle boxRect)
        {
            if (string.IsNullOrEmpty(Text)) return;

            Rectangle textRect;
            TextFormatFlags flags = TextFormatFlags.VerticalCenter;

            if (_checkAlign == NCheckAlign.Left)
            {
                int startX = boxRect.Right + _textSpacing;
                textRect = new Rectangle(startX, 0, Math.Max(0, Width - startX), Height);
                flags |= TextFormatFlags.Left;
            }
            else
            {
                int endX = boxRect.Left - _textSpacing;
                textRect = new Rectangle(0, 0, Math.Max(0, endX), Height);
                flags |= TextFormatFlags.Right;
            }

            Color currentTextColor = Enabled ? ForeColor : _disabledTextColor;
            TextRenderer.DrawText(g, Text, Font, textRect, currentTextColor, flags);
        }

        private void DrawFocusRectangle(Graphics g, Rectangle boxRect)
        {
            Rectangle focusRect = boxRect;
            focusRect.Inflate(2, 2);

            using (Pen focusPen = new Pen(Color.FromArgb(120, _checkedColor), 1f))
            {
                focusPen.DashStyle = DashStyle.Dot;
                g.DrawRectangle(focusPen, focusRect);
            }
        }

        private GraphicsPath GetBoxPath(Rectangle rect)
        {
            if (_style == NCheckBoxStyle.Square)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(rect);
                return path;
            }

            if (_style == NCheckBoxStyle.Circle)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(rect);
                return path;
            }

            return CreateRoundedRectangle(rect, _borderRadius);
        }

        private GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Color BlendColors(Color c1, Color c2, float ratio)
        {
            ratio = Math.Max(0f, Math.Min(1f, ratio));
            int r = (int)(c1.R * (1 - ratio) + c2.R * ratio);
            int g = (int)(c1.G * (1 - ratio) + c2.G * ratio);
            int b = (int)(c1.B * (1 - ratio) + c2.B * ratio);
            int a = (int)(c1.A * (1 - ratio) + c2.A * ratio);
            return Color.FromArgb(a, r, g, b);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _animTimer?.Dispose();
                _hoverTimer?.Dispose();
                _rippleTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}