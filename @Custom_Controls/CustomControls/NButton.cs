using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ModernUI.Controls
{
    [DefaultEvent("Click")]
    public class NButton : Control
    {
        private Timer _hoverTimer;
        private Timer _rippleTimer;
        private float _hoverAlpha = 0f;
        private bool _isHovered = false;
        private bool _isPressed = false;
        private StringFormat _textFormat;

        private float _rippleRadius = 0f;
        private float _rippleAlpha = 0f;
        private Point _rippleLocation;

        [Category("1. Background")]
        [Description("The starting color of the background gradient. Same as EndColor for a solid background.")]
        public Color BackgroundStartColor { get; set; } = SystemColors.Control;

        [Category("1. Background")]
        [Description("The ending color of the background gradient.")]
        public Color BackgroundEndColor { get; set; } = SystemColors.Control;

        [Category("1. Background")]
        [Description("The starting color of the background gradient when the mouse is over the button.")]
        public Color HoverStartColor { get; set; } = Color.FromArgb(229, 241, 251);

        [Category("1. Background")]
        [Description("The ending color of the background gradient when the mouse is over the button.")]
        public Color HoverEndColor { get; set; } = Color.FromArgb(229, 241, 251);

        [Category("1. Background")]
        [Description("The starting color of the background gradient when the button is clicked.")]
        public Color PressedStartColor { get; set; } = Color.FromArgb(204, 228, 247);

        [Category("1. Background")]
        [Description("The ending color of the background gradient when the button is clicked.")]
        public Color PressedEndColor { get; set; } = Color.FromArgb(204, 228, 247);

        [Category("1. Background")]
        [Description("The angle of the background gradient (in degrees).")]
        public float GradientAngle { get; set; } = 90f;

        [Category("2. Text")]
        [Description("The normal color of the text.")]
        public Color TextColor { get; set; } = SystemColors.ControlText;

        [Category("2. Text")]
        [Description("The color of the text when the mouse is over the button or it is clicked.")]
        public Color HoverTextColor { get; set; } = SystemColors.ControlText;

        [Category("2. Text")]
        [Description("Shifts the text position by X and Y pixels. Useful for manual centering.")]
        public Point TextOffset { get; set; } = new Point(0, 0);

        [Category("3. Borders")]
        [Description("The radius of the rounded corners. Set to 0 for a sharp rectangular button.")]
        public int BorderRadius { get; set; } = 0;

        [Category("3. Borders")]
        [Description("The thickness of the border in pixels. Set to 0 to remove the border.")]
        public int BorderSize { get; set; } = 1;

        [Category("3. Borders")]
        [Description("The color of the border.")]
        public Color BorderColor { get; set; } = Color.DarkGray;

        [Category("3. Borders")]
        [Description("The color of the border when the mouse is over the button.")]
        public Color HoverBorderColor { get; set; } = Color.FromArgb(0, 120, 215);

        [Category("4. Icons")]
        [Description("The image to display on the left side of the text.")]
        public Image LeftIcon { get; set; } = null;

        [Category("4. Icons")]
        [Description("The image to display on the right side of the text.")]
        public Image RightIcon { get; set; } = null;

        [Category("4. Icons")]
        [Description("The custom size to render the icons.")]
        public Size IconSize { get; set; } = new Size(16, 16);

        [Category("4. Icons")]
        [Description("If true, the icon is centered together with the text. If false, the icon is anchored to the side.")]
        public bool CenterIconWithText { get; set; } = false;

        [Category("4. Icons")]
        [Description("The distance in pixels from the icon to the edge of the button (used when CenterIconWithText is false).")]
        public int IconMargin { get; set; } = 10;

        [Category("4. Icons")]
        [Description("The spacing in pixels between the icon and the text.")]
        public int IconSpacing { get; set; } = 5;

        [Category("4. Icons")]
        [Description("Shifts the icons position by X and Y pixels.")]
        public Point IconOffset { get; set; } = new Point(0, 0);

        [Category("4. Icons")]
        [Description("If true, the original colors of the icon are replaced by IconColor.")]
        public bool EnableIconTinting { get; set; } = false;

        [Category("4. Icons")]
        [Description("The custom color applied to the icons if Icon Tinting is enabled.")]
        public Color IconColor { get; set; } = Color.White;

        [Category("4. Icons")]
        [Description("The custom color applied to the icons on hover if Icon Tinting is enabled.")]
        public Color HoverIconColor { get; set; } = Color.White;

        [Category("5. Shadow")]
        [Description("Enable or disable a drop shadow behind the button.")]
        public bool EnableShadow { get; set; } = false;

        [Category("5. Shadow")]
        [Description("The spread and blur size of the shadow.")]
        public int ShadowSize { get; set; } = 3;

        [Category("5. Shadow")]
        [Description("The offset of the shadow on the X and Y axes.")]
        public Point ShadowOffset { get; set; } = new Point(1, 1);

        [Category("5. Shadow")]
        [Description("The base color of the shadow (Alpha channel handles opacity automatically).")]
        public Color ShadowColor { get; set; } = Color.FromArgb(60, 0, 0, 0);

        [Category("6. Behavior")]
        [Description("Enable smooth fading transitions for hover colors.")]
        public bool EnableHoverAnimation { get; set; } = false;

        [Category("6. Behavior")]
        [Description("The speed of the hover fade animation (higher is faster).")]
        public int HoverAnimationSpeed { get; set; } = 20;

        [Category("6. Behavior")]
        [Description("Slightly shift the content down when the button is clicked to simulate physical pressing.")]
        public bool ShiftOnPress { get; set; } = false;

        [Category("6. Behavior")]
        [Description("Enable a ripple effect animation originating from the cursor click position.")]
        public bool EnableRippleEffect { get; set; } = false;

        [Category("6. Behavior")]
        [Description("The color of the ripple effect.")]
        public Color RippleColor { get; set; } = Color.FromArgb(70, 0, 0, 0);

        [Category("6. Behavior")]
        [Description("The speed of the ripple expanding animation.")]
        public int RippleSpeed { get; set; } = 15;

        public NButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor | ControlStyles.Selectable, true);

            DoubleBuffered = true;
            BackColor = Color.Transparent;
            ForeColor = SystemColors.ControlText;
            Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            Size = new Size(100, 30);
            Cursor = Cursors.Default;

            _textFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.EllipsisCharacter
            };

            _hoverTimer = new Timer { Interval = 10 };
            _hoverTimer.Tick += HoverTimer_Tick;

            _rippleTimer = new Timer { Interval = 10 };
            _rippleTimer.Tick += RippleTimer_Tick;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _hoverTimer?.Dispose();
                _rippleTimer?.Dispose();
                _textFormat?.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovered = true;
            if (EnableHoverAnimation && !DesignMode) _hoverTimer.Start();
            else { _hoverAlpha = 255; Invalidate(); }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovered = false;
            if (EnableHoverAnimation && !DesignMode) _hoverTimer.Start();
            else { _hoverAlpha = 0; Invalidate(); }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                _isPressed = true;
                if (EnableRippleEffect)
                {
                    _rippleLocation = e.Location;
                    _rippleRadius = 0;
                    _rippleAlpha = RippleColor.A;
                    _rippleTimer.Start();
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

        private void HoverTimer_Tick(object sender, EventArgs e)
        {
            bool stopTimer = false;
            if (_isHovered)
            {
                _hoverAlpha += HoverAnimationSpeed;
                if (_hoverAlpha >= 255) { _hoverAlpha = 255; stopTimer = true; }
            }
            else
            {
                _hoverAlpha -= HoverAnimationSpeed;
                if (_hoverAlpha <= 0) { _hoverAlpha = 0; stopTimer = true; }
            }
            Invalidate();
            if (stopTimer) _hoverTimer.Stop();
        }

        private void RippleTimer_Tick(object sender, EventArgs e)
        {
            _rippleRadius += RippleSpeed;
            _rippleAlpha -= (RippleSpeed * 0.4f);

            if (_rippleAlpha <= 0)
            {
                _rippleAlpha = 0;
                _rippleTimer.Stop();
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Width <= 0 || Height <= 0) return;

            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int shadowMargin = EnableShadow ? ShadowSize + Math.Max(Math.Abs(ShadowOffset.X), Math.Abs(ShadowOffset.Y)) : 0;
            RectangleF btnRect = new RectangleF(shadowMargin, shadowMargin, Width - (shadowMargin * 2) - 1, Height - (shadowMargin * 2) - 1);

            if (btnRect.Width <= 0 || btnRect.Height <= 0) return;

            if (EnableShadow && !_isPressed)
                DrawShadow(g, btnRect);

            DrawBackgroundAndBorder(g, btnRect);

            if (EnableRippleEffect && _rippleAlpha > 0)
                DrawRipple(g, btnRect);

            int pressShift = (_isPressed && ShiftOnPress) ? 1 : 0;
            DrawContent(g, btnRect, pressShift);
        }

        private void DrawShadow(Graphics g, RectangleF rect)
        {
            RectangleF shadowRect = new RectangleF(rect.X + ShadowOffset.X, rect.Y + ShadowOffset.Y, rect.Width, rect.Height);
            using (GraphicsPath path = GetRoundedPath(shadowRect, BorderRadius))
            {
                for (int i = 0; i < ShadowSize; i++)
                {
                    int alpha = (int)(ShadowColor.A * (1f - ((float)i / ShadowSize)));
                    using (Pen pen = new Pen(Color.FromArgb(alpha, ShadowColor), i + 1))
                    {
                        pen.LineJoin = LineJoin.Round;
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        private void DrawBackgroundAndBorder(Graphics g, RectangleF rect)
        {
            Color cStart = BackgroundStartColor;
            Color cEnd = BackgroundEndColor;
            Color cBorder = BorderColor;

            if (_isPressed)
            {
                cStart = PressedStartColor;
                cEnd = PressedEndColor;
                cBorder = HoverBorderColor;
            }
            else if (_hoverAlpha > 0)
            {
                cStart = BlendColors(HoverStartColor, BackgroundStartColor, _hoverAlpha / 255f);
                cEnd = BlendColors(HoverEndColor, BackgroundEndColor, _hoverAlpha / 255f);
                cBorder = BlendColors(HoverBorderColor, BorderColor, _hoverAlpha / 255f);
            }

            using (GraphicsPath path = GetRoundedPath(rect, BorderRadius))
            {
                if (cStart == cEnd)
                {
                    using (SolidBrush brush = new SolidBrush(cStart))
                        g.FillPath(brush, path);
                }
                else
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, cStart, cEnd, GradientAngle))
                        g.FillPath(brush, path);
                }

                if (BorderSize > 0)
                {
                    using (Pen pen = new Pen(cBorder, BorderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        private void DrawRipple(Graphics g, RectangleF rect)
        {
            using (GraphicsPath path = GetRoundedPath(rect, BorderRadius))
            {
                Region oldClip = g.Clip;
                g.SetClip(path);

                int safeAlpha = Math.Max(0, Math.Min(255, (int)_rippleAlpha));
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(safeAlpha, RippleColor)))
                {
                    RectangleF rippleRect = new RectangleF(
                        _rippleLocation.X - _rippleRadius,
                        _rippleLocation.Y - _rippleRadius,
                        _rippleRadius * 2,
                        _rippleRadius * 2);
                    g.FillEllipse(brush, rippleRect);
                }

                g.Clip = oldClip;
            }
        }

        private void DrawContent(Graphics g, RectangleF rect, int shiftY)
        {
            Color currentTextColor = _isPressed ? HoverTextColor : BlendColors(HoverTextColor, TextColor, _hoverAlpha / 255f);
            Color currentIconColor = _isPressed ? HoverIconColor : BlendColors(HoverIconColor, IconColor, _hoverAlpha / 255f);

            float centerY = rect.Y + (rect.Height - IconSize.Height) / 2f + shiftY + IconOffset.Y;

            if (CenterIconWithText)
            {
                int totalWidth = 0;
                int textWidth = TextRenderer.MeasureText(Text, Font).Width;
                totalWidth += textWidth;

                if (LeftIcon != null) totalWidth += IconSize.Width + IconSpacing;
                if (RightIcon != null) totalWidth += IconSize.Width + IconSpacing;

                float startX = rect.X + (rect.Width - totalWidth) / 2f + TextOffset.X;

                if (LeftIcon != null)
                {
                    RectangleF iconRect = new RectangleF(startX + IconOffset.X, centerY, IconSize.Width, IconSize.Height);
                    DrawIcon(g, LeftIcon, iconRect, currentIconColor);
                    startX += IconSize.Width + IconSpacing;
                }

                using (SolidBrush brush = new SolidBrush(currentTextColor))
                {
                    RectangleF textRect = new RectangleF(startX, rect.Y + shiftY + TextOffset.Y, textWidth, rect.Height);
                    g.DrawString(Text, Font, brush, textRect, _textFormat);
                    startX += textWidth + IconSpacing;
                }

                if (RightIcon != null)
                {
                    RectangleF iconRect = new RectangleF(startX + IconOffset.X, centerY, IconSize.Width, IconSize.Height);
                    DrawIcon(g, RightIcon, iconRect, currentIconColor);
                }
            }
            else
            {
                float leftBound = rect.X;
                float rightBound = rect.Right;

                if (LeftIcon != null)
                {
                    RectangleF iconRect = new RectangleF(rect.X + IconMargin + IconOffset.X, centerY, IconSize.Width, IconSize.Height);
                    DrawIcon(g, LeftIcon, iconRect, currentIconColor);
                    leftBound = iconRect.Right + IconSpacing;
                }

                if (RightIcon != null)
                {
                    RectangleF iconRect = new RectangleF(rect.Right - IconSize.Width - IconMargin + IconOffset.X, centerY, IconSize.Width, IconSize.Height);
                    DrawIcon(g, RightIcon, iconRect, currentIconColor);
                    rightBound = iconRect.Left - IconSpacing;
                }

                using (SolidBrush brush = new SolidBrush(currentTextColor))
                {
                    RectangleF textRect = new RectangleF(leftBound + TextOffset.X, rect.Y + shiftY + TextOffset.Y, rightBound - leftBound, rect.Height);
                    g.DrawString(Text, Font, brush, textRect, _textFormat);
                }
            }
        }

        private void DrawIcon(Graphics g, Image img, RectangleF rect, Color tint)
        {
            if (!EnableIconTinting || tint == Color.Transparent || tint == Color.Empty)
            {
                g.DrawImage(img, rect);
                return;
            }

            float r = tint.R / 255f;
            float gr = tint.G / 255f;
            float b = tint.B / 255f;

            ColorMatrix cm = new ColorMatrix(new float[][]
            {
                new float[] {r, 0, 0, 0, 0},
                new float[] {0, gr, 0, 0, 0},
                new float[] {0, 0, b, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
            });

            using (ImageAttributes ia = new ImageAttributes())
            {
                ia.SetColorMatrix(cm);
                g.DrawImage(img, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
            }
        }

        private GraphicsPath GetRoundedPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            float r2 = Math.Min(radius * 2, Math.Min(rect.Width, rect.Height));
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, r2, r2, 180, 90);
            path.AddArc(rect.Right - r2, rect.Y, r2, r2, 270, 90);
            path.AddArc(rect.Right - r2, rect.Bottom - r2, r2, r2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r2, r2, r2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Color BlendColors(Color c1, Color c2, float ratio)
        {
            ratio = Math.Max(0f, Math.Min(1f, ratio));
            int r = (int)(c1.R * ratio + c2.R * (1 - ratio));
            int g = (int)(c1.G * ratio + c2.G * (1 - ratio));
            int b = (int)(c1.B * ratio + c2.B * (1 - ratio));
            int a = (int)(c1.A * ratio + c2.A * (1 - ratio));
            return Color.FromArgb(a, r, g, b);
        }
    }
}