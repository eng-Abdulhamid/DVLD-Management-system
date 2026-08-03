using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ModernUI.Controls
{
    /// <summary>
    /// A professional, high-performance modern button with advanced styling, 
    /// animations, and high-fidelity icon rendering.
    /// </summary>
    [DefaultEvent("Click")]
    public class ModernButton : Control
    {
        #region Private Fields
        private Timer _animationTimer;
        private Timer _borderAnimationTimer;
        private float _hoverProgress = 0f;
        private bool _isMouseOver = false;
        private bool _isPressed = false;
        private StringFormat _stringFormat;
        private const float HoverSpeed = 0.15f;

        // Internal storage for grouped properties
        private int _generalRadius = 0;
        private int _generalHoverRadius = 0;
        private Color _generalBorderColor = Color.Black;
        private Color _generalBorderHoverColor = Color.Gray;
        private float _borderAnimationAngle = 0f;
        private float _pulseFactor = 1f;
        private bool _pulseExpanding = true;
        #endregion

        #region Category: 01. Text & Fonts
        [Category("01. Text & Fonts")]
        [Description("The primary color of the button text.")]
        public Color TextColor { get; set; } = Color.Black;

        [Category("01. Text & Fonts")]
        [Description("The color of the text when the mouse hovers over the button.")]
        public Color HoverTextColor { get; set; } = Color.Gray;

        [Category("01. Text & Fonts")]
        [Description("Enable or disable font change during hover.")]
        public bool EnableCustomHoverFont { get; set; } = false;

        [Category("01. Text & Fonts")]
        [Description("The font style applied when the mouse hovers over the button.")]
        public Font HoverFont { get; set; } = new Font("Segoe UI", 10, FontStyle.Bold);
        #endregion

        #region Category: 02. Background
        [Category("02. Background")]
        [Description("Solid background color of the button.")]
        public Color BackgroundColor { get; set; } = Color.White;

        [Category("02. Background")]
        [Description("Background color when the mouse hovers.")]
        public Color HoverBackgroundColor { get; set; } = Color.FromArgb(245, 245, 245);

        [Category("02. Background")]
        [Description("Enable linear gradient for the background.")]
        public bool UseGradientBackground { get; set; } = false;

        [Category("02. Background")]
        [Description("Starting color for the background gradient.")]
        public Color BackgroundGradientStartColor { get; set; } = Color.White;

        [Category("02. Background")]
        [Description("Ending color for the background gradient.")]
        public Color BackgroundGradientEndColor { get; set; } = Color.FromArgb(240, 240, 240);
        #endregion

        #region Category: 03. Border & Animation
        [Category("03. Border & Animation")]
        [Description("The thickness of the button border.")]
        public int BorderThickness { get; set; } = 1;

        [Category("03. Border & Animation")]
        [Description("The angle of the border color gradient.")]
        public float BorderGradientAngle { get; set; } = 45f;

        [Category("03. Border & Animation")]
        [Description("Enable rotating border color animation.")]
        public bool EnableBorderAnimation { get; set; } = false;

        [Category("03. Border & Animation")]
        [Description("Speed of the border rotation or pulse animation.")]
        public float AnimationSpeed { get; set; } = 2.5f;

        [Category("03. Border & Animation")]
        [Description("Quickly set all 4 border colors at once.")]
        public Color GeneralBorderColor
        {
            get => _generalBorderColor;
            set { _generalBorderColor = value; BorderColor1 = value; BorderColor2 = value; BorderColor3 = value; BorderColor4 = value; Invalidate(); }
        }

        [Category("03. Border & Animation")] public Color BorderColor1 { get; set; } = Color.Black;
        [Category("03. Border & Animation")] public Color BorderColor2 { get; set; } = Color.Black;
        [Category("03. Border & Animation")] public Color BorderColor3 { get; set; } = Color.Black;
        [Category("03. Border & Animation")] public Color BorderColor4 { get; set; } = Color.Black;

        [Category("03. Border & Animation")]
        [Description("Quickly set all 4 border hover colors at once.")]
        public Color GeneralBorderHoverColor
        {
            get => _generalBorderHoverColor;
            set { _generalBorderHoverColor = value; BorderHoverColor1 = value; BorderHoverColor2 = value; BorderHoverColor3 = value; BorderHoverColor4 = value; Invalidate(); }
        }

        [Category("03. Border & Animation")] public Color BorderHoverColor1 { get; set; } = Color.Gray;
        [Category("03. Border & Animation")] public Color BorderHoverColor2 { get; set; } = Color.Gray;
        [Category("03. Border & Animation")] public Color BorderHoverColor3 { get; set; } = Color.Gray;
        [Category("03. Border & Animation")] public Color BorderHoverColor4 { get; set; } = Color.Gray;
        #endregion

        #region Category: 04. Corners
        [Category("04. Corners")]
        [Description("Set corner radius for all corners simultaneously.")]
        public int GeneralRadius
        {
            get => _generalRadius;
            set { _generalRadius = value; RadiusTopLeft = value; RadiusTopRight = value; RadiusBottomLeft = value; RadiusBottomRight = value; Invalidate(); }
        }
        [Category("04. Corners")] public int RadiusTopLeft { get; set; } = 0;
        [Category("04. Corners")] public int RadiusTopRight { get; set; } = 0;
        [Category("04. Corners")] public int RadiusBottomLeft { get; set; } = 0;
        [Category("04. Corners")] public int RadiusBottomRight { get; set; } = 0;

        [Category("04. Corners")]
        [Description("Set hover corner radius for all corners simultaneously.")]
        public int GeneralHoverRadius
        {
            get => _generalHoverRadius;
            set { _generalHoverRadius = value; HoverRadiusTopLeft = value; HoverRadiusTopRight = value; HoverRadiusBottomLeft = value; HoverRadiusBottomRight = value; Invalidate(); }
        }
        [Category("04. Corners")] public int HoverRadiusTopLeft { get; set; } = 0;
        [Category("04. Corners")] public int HoverRadiusTopRight { get; set; } = 0;
        [Category("04. Corners")] public int HoverRadiusBottomLeft { get; set; } = 0;
        [Category("04. Corners")] public int HoverRadiusBottomRight { get; set; } = 0;
        #endregion

        #region Category: 05. Shadow
        [Category("05. Shadow")]
        [Description("Enable dropshadow effect.")]
        public bool EnableShadow { get; set; } = false;

        [Category("05. Shadow")]
        public Color ShadowColor { get; set; } = Color.FromArgb(50, 0, 0, 0);

        [Category("05. Shadow")]
        [Description("Blur intensity of the shadow.")]
        public int ShadowBlur { get; set; } = 8;

        [Category("05. Shadow")]
        [Description("Shadow distance from the button center.")]
        public Point ShadowOffset { get; set; } = new Point(3, 3);

        [Category("05. Shadow")]
        [Description("If true, shadow only appears when mouse is over.")]
        public bool ShadowOnlyOnHover { get; set; } = false;
        #endregion

        #region Category: 06. Glow & Pulse
        [Category("06. Glow & Pulse")] public bool ShowGlowOnFocus { get; set; } = true;
        [Category("06. Glow & Pulse")] public bool ShowGlowOnIdle { get; set; } = true;
        [Category("06. Glow & Pulse")] public int GlowSpread { get; set; } = 8;
        [Category("06. Glow & Pulse")] public int GlowOpacity { get; set; } = 180;
        [Category("06. Glow & Pulse")] public bool EnablePulseEffect { get; set; } = false;

        [Category("06. Glow & Pulse")] public Color FocusColor1 { get; set; } = Color.Orange;
        [Category("06. Glow & Pulse")] public Color FocusColor2 { get; set; } = Color.Red;
        [Category("06. Glow & Pulse")] public Color FocusColor3 { get; set; } = Color.Gold;
        [Category("06. Glow & Pulse")] public Color FocusColor4 { get; set; } = Color.DarkOrange;

        [Category("06. Glow & Pulse")] public Color IdleColor1 { get; set; } = Color.FromArgb(60, 60, 60);
        [Category("06. Glow & Pulse")] public Color IdleColor2 { get; set; } = Color.FromArgb(80, 80, 80);
        #endregion

        #region Category: 07. Icons
        [Category("07. Icons")]
        [Description("Image to display on the left side of the text.")]
        public Image LeftIcon { get; set; } = null;

        [Category("07. Icons")]
        [Description("Image to display on the right side of the text.")]
        public Image RightIcon { get; set; } = null;

        [Category("07. Icons")]
        [Description("Size of the icons in pixels.")]
        public Size IconSize { get; set; } = new Size(20, 20);

        [Category("07. Icons")]
        [Description("Space between icons and the text.")]
        public int TextIconSpacing { get; set; } = 8;

        [Category("07. Icons")]
        [Description("Force icons to match a specific color (good for flat icons).")]
        public bool TintIcons { get; set; } = true;

        [Category("07. Icons")] public Color IconTintColor { get; set; } = Color.Black;
        [Category("07. Icons")] public Color HoverIconTintColor { get; set; } = Color.DimGray;

        [Category("07. Icons")]
        [Description("Enables icons to change size on hover.")]
        public bool EnableCustomHoverIconSize { get; set; } = false;
        [Category("07. Icons")] public Size HoverIconSize { get; set; } = new Size(22, 22);
        #endregion

        #region Category: 08. Global Behavior
        [Category("08. Global Behavior")]
        public bool EnableHoverEffects { get; set; } = true;
        #endregion

        public ModernButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.Selectable, true);
            DoubleBuffered = true;
            Size = new Size(180, 50);
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
            BackColor = Color.Transparent;

            _animationTimer = new Timer { Interval = 15 };
            _animationTimer.Tick += (s, e) => {
                if (_isMouseOver && EnableHoverEffects) { _hoverProgress += HoverSpeed; if (_hoverProgress >= 1f) _hoverProgress = 1f; }
                else { _hoverProgress -= HoverSpeed; if (_hoverProgress <= 0f) _hoverProgress = 0f; }
                if (_hoverProgress <= 0 || _hoverProgress >= 1) _animationTimer.Stop();
                Invalidate();
            };

            _borderAnimationTimer = new Timer { Interval = 20 };
            _borderAnimationTimer.Tick += (s, e) => {
                if (EnableBorderAnimation) { _borderAnimationAngle += AnimationSpeed; if (_borderAnimationAngle >= 360) _borderAnimationAngle = 0; }
                if (EnablePulseEffect)
                {
                    if (_pulseExpanding) { _pulseFactor += 0.015f; if (_pulseFactor >= 1.15f) _pulseExpanding = false; }
                    else { _pulseFactor -= 0.015f; if (_pulseFactor <= 1.0f) _pulseExpanding = true; }
                }
                else { _pulseFactor = 1.0f; }
                if (EnableBorderAnimation || EnablePulseEffect) Invalidate();
            };
            _borderAnimationTimer.Start();
        }

        protected override void OnMouseEnter(EventArgs e) { _isMouseOver = true; if (EnableHoverEffects) _animationTimer.Start(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _isMouseOver = false; if (EnableHoverEffects) _animationTimer.Start(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _isPressed = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _isPressed = false; Invalidate(); base.OnMouseUp(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Global Quality Settings
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            int glowArea = (ShowGlowOnFocus || ShowGlowOnIdle) ? (int)(GlowSpread * 1.5) : 0;
            int shadowArea = EnableShadow ? ShadowBlur + Math.Max(Math.Abs(ShadowOffset.X), Math.Abs(ShadowOffset.Y)) + 2 : 0;
            int margin = Math.Max(glowArea, Math.Max(shadowArea, (int)BorderThickness + 4));

            RectangleF bodyRect = new RectangleF(margin, margin, Width - (margin * 2), Height - (margin * 2));
            if (bodyRect.Width <= 2 || bodyRect.Height <= 2) return;

            if (EnableShadow) DrawShadowOutside(g, bodyRect);
            DrawAnimatedGlow(g, bodyRect);
            DrawAdvancedBackground(g, bodyRect);
            DrawAdvancedBorder(g, bodyRect, BorderThickness);
            DrawContent(g, Rectangle.Round(bodyRect));
        }

        private void DrawShadowOutside(Graphics g, RectangleF rect)
        {
            if (ShadowOnlyOnHover && !_isMouseOver && _hoverProgress <= 0) return;
            float opacityFactor = ShadowOnlyOnHover ? _hoverProgress : 1f;
            RectangleF shadowRect = new RectangleF(rect.X + ShadowOffset.X, rect.Y + ShadowOffset.Y, rect.Width, rect.Height);

            using (GraphicsPath shadowPath = GetUltraRoundedPath(shadowRect))
            {
                for (int i = ShadowBlur; i > 1; i--)
                {
                    int alpha = (int)((ShadowColor.A / (float)ShadowBlur) * opacityFactor);
                    if (alpha <= 0) continue;
                    using (Pen shadowPen = new Pen(Color.FromArgb(alpha, ShadowColor), i))
                    {
                        shadowPen.LineJoin = LineJoin.Round;
                        g.DrawPath(shadowPen, shadowPath);
                    }
                }
            }
        }

        private void DrawAnimatedGlow(Graphics g, RectangleF rect)
        {
            bool isFocused = this.Focused || _isMouseOver;
            if (isFocused && !ShowGlowOnFocus) return;
            if (!isFocused && !ShowGlowOnIdle) return;

            Color c1 = isFocused ? FocusColor1 : IdleColor1;
            float currentAngle = EnableBorderAnimation ? _borderAnimationAngle : BorderGradientAngle;
            float currentSpread = EnablePulseEffect ? GlowSpread * _pulseFactor : GlowSpread;

            for (int i = (int)currentSpread; i > 0; i -= 2)
            {
                RectangleF glowRect = new RectangleF(rect.X - i / 2f, rect.Y - i / 2f, rect.Width + i, rect.Height + i);
                using (GraphicsPath path = GetUltraRoundedPath(glowRect))
                {
                    int alpha = (int)((GlowOpacity / (currentSpread / 2f)) * (currentSpread - i) * 0.3f);
                    alpha = Math.Max(0, Math.Min(255, alpha));
                    using (Pen p = new Pen(Color.FromArgb(alpha, c1), 1.5f)) { g.DrawPath(p, path); }
                }
            }
        }

        private void DrawAdvancedBackground(Graphics g, RectangleF rect)
        {
            Color baseColor = BackgroundColor;
            if (EnableHoverEffects && _hoverProgress > 0) baseColor = InterpolateColor(BackgroundColor, HoverBackgroundColor, _hoverProgress);
            if (_isPressed) baseColor = Color.FromArgb(230, 230, 230);

            using (GraphicsPath path = GetUltraRoundedPath(rect))
            {
                if (UseGradientBackground)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, BackgroundGradientStartColor, BackgroundGradientEndColor, 90f))
                        g.FillPath(brush, path);
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(baseColor)) g.FillPath(brush, path);
                }
            }
        }

        private void DrawAdvancedBorder(Graphics g, RectangleF rect, float penWidth)
        {
            if (penWidth <= 0) return;
            Color b1 = InterpolateColor(BorderColor1, BorderHoverColor1, _hoverProgress);
            Color b4 = InterpolateColor(BorderColor4, BorderHoverColor4, _hoverProgress);
            using (GraphicsPath path = GetUltraRoundedPath(rect))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, b1, b4, BorderGradientAngle))
                {
                    using (Pen pen = new Pen(brush, penWidth)) { g.DrawPath(pen, path); }
                }
            }
        }

        private void DrawContent(Graphics g, Rectangle rect)
        {
            Font currentFont = (EnableCustomHoverFont && _hoverProgress > 0.5f) ? HoverFont : Font;
            Color contentColor = InterpolateColor(TextColor, HoverTextColor, _hoverProgress);
            Color iconColor = InterpolateColor(IconTintColor, HoverIconTintColor, _hoverProgress);
            Size currentIconSize = (EnableCustomHoverIconSize && _isMouseOver) ? HoverIconSize : IconSize;

            float leftOffset = rect.X + 10;
            float rightOffset = rect.Right - 10;

            if (LeftIcon != null)
            {
                DrawIcon(g, LeftIcon, new RectangleF(leftOffset, rect.Y + (rect.Height - currentIconSize.Height) / 2f, currentIconSize.Width, currentIconSize.Height), iconColor);
                leftOffset += currentIconSize.Width + TextIconSpacing;
            }
            if (RightIcon != null)
            {
                rightOffset -= currentIconSize.Width;
                DrawIcon(g, RightIcon, new RectangleF(rightOffset, rect.Y + (rect.Height - currentIconSize.Height) / 2f, currentIconSize.Width, currentIconSize.Height), iconColor);
                rightOffset -= TextIconSpacing;
            }

            if (_stringFormat == null) _stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter, FormatFlags = StringFormatFlags.NoWrap };
            using (SolidBrush brush = new SolidBrush(contentColor))
                g.DrawString(Text, currentFont, brush, new RectangleF(leftOffset, rect.Y, rightOffset - leftOffset, rect.Height), _stringFormat);
        }

        private void DrawIcon(Graphics g, Image img, RectangleF rect, Color tint)
        {
            if (img == null) return;
            var state = g.Save();
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (TintIcons)
            {
                using (ImageAttributes attr = new ImageAttributes())
                {
                    float r = tint.R / 255f, gr = tint.G / 255f, b = tint.B / 255f;
                    attr.SetColorMatrix(new ColorMatrix(new float[][] {
                        new float[] {r,0,0,0,0}, new float[] {0,gr,0,0,0}, new float[] {0,0,b,0,0}, new float[] {0,0,0,1,0}, new float[] {0,0,0,0,1}
                    }));
                    g.DrawImage(img, Rectangle.Round(rect), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attr);
                }
            }
            else g.DrawImage(img, rect);
            g.Restore(state);
        }

        private GraphicsPath GetUltraRoundedPath(RectangleF rect)
        {
            GraphicsPath path = new GraphicsPath();
            float cTL = RadiusTopLeft + (HoverRadiusTopLeft - RadiusTopLeft) * _hoverProgress;
            float cTR = RadiusTopRight + (HoverRadiusTopRight - RadiusTopRight) * _hoverProgress;
            float cBR = RadiusBottomRight + (HoverRadiusBottomRight - RadiusBottomRight) * _hoverProgress;
            float cBL = RadiusBottomLeft + (HoverRadiusBottomLeft - RadiusBottomLeft) * _hoverProgress;

            float tl = Math.Max(0.1f, cTL * 2); float tr = Math.Max(0.1f, cTR * 2);
            float br = Math.Max(0.1f, cBR * 2); float bl = Math.Max(0.1f, cBL * 2);

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, tl, tl, 180, 90);
            path.AddArc(rect.Right - tr, rect.Y, tr, tr, 270, 90);
            path.AddArc(rect.Right - br, rect.Bottom - br, br, br, 0, 90);
            path.AddArc(rect.X, rect.Bottom - bl, bl, bl, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Color InterpolateColor(Color c1, Color c2, float amount)
        {
            amount = Math.Max(0, Math.Min(1, amount));
            return Color.FromArgb((int)(c1.A + (c2.A - c1.A) * amount), (int)(c1.R + (c2.R - c1.R) * amount), (int)(c1.G + (c2.G - c1.G) * amount), (int)(c1.B + (c2.B - c1.B) * amount));
        }
    }
}