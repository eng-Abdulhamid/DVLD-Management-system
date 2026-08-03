using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ModernUI.Components
{
    /// <summary>
    /// Advanced Professional Error Provider with smooth rendering, custom icons,
    /// high-fidelity tooltips, and interactive animations.
    /// </summary>
    [ProvideProperty("ErrorText", typeof(Control))]
    public class ModernErrorProvider : Component, IExtenderProvider
    {
        #region Internal Classes
        private class ErrorInfo
        {
            public string Text { get; set; }
            public bool IsVisible { get; set; } = false;
            public Control Control { get; set; }
        }

        private class ErrorPopup : Form
        {
            public string ErrorMessage { get; set; }
            public Color ThemeColor { get; set; } = Color.FromArgb(231, 76, 60);
            public int CornerRadius { get; set; } = 12;

            public ErrorPopup()
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
                BackColor = Color.White;
                TransparencyKey = Color.Magenta;
                DoubleBuffered = true;
                Size = new Size(220, 50);
                TopMost = true;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

                using (GraphicsPath path = GetRoundedPath(rect, CornerRadius))
                {
                    // Gradient background for a premium look
                    using (LinearGradientBrush b = new LinearGradientBrush(rect, ThemeColor, ControlPaint.Dark(ThemeColor, 0.2f), 45f))
                        g.FillPath(b, path);

                    // Soft inner glow/border
                    using (Pen p = new Pen(Color.FromArgb(100, Color.White), 1.5f))
                        g.DrawPath(p, path);
                }

                using (StringFormat sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center })
                using (SolidBrush b = new SolidBrush(Color.White))
                {
                    g.DrawString(ErrorMessage, new Font("Segoe UI", 9, FontStyle.Bold), b, rect, sf);
                }
            }

            private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
            {
                GraphicsPath path = new GraphicsPath();
                int d = radius * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                return path;
            }
        }

        // طبقة شفافة تضمن رسم الأيقونات فوق كل شيء
        private class DrawingOverlay : Control
        {
            private ModernErrorProvider _provider;
            public DrawingOverlay(ModernErrorProvider provider)
            {
                _provider = provider;
                SetStyle(ControlStyles.SupportsTransparentBackColor  | ControlStyles.Opaque, true);
                BackColor = Color.Transparent;
                Dock = DockStyle.Fill;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                _provider.RenderAllErrors(e.Graphics);
            }

            protected override void OnMouseMove(MouseEventArgs e)
            {
                _provider.CheckHover(e.Location);
                base.OnMouseMove(e);
            }
        }
        #endregion

        #region Fields
        private Dictionary<Control, ErrorInfo> _errors = new Dictionary<Control, ErrorInfo>();
        private ErrorPopup _activePopup = new ErrorPopup();
        private Timer _animationTimer = new Timer { Interval = 30 };
        private float _pulseFactor = 1.0f;
        private bool _pulseExpanding = true;
        #endregion

        #region Properties
        [Category("Appearance")] public Color ErrorColor { get; set; } = Color.FromArgb(231, 76, 60);
        [Category("Appearance")] public Size IconSize { get; set; } = new Size(22, 22);
        [Category("Appearance")] public int IconPadding { get; set; } = 10;
        [Category("Behavior")] public bool EnableShake { get; set; } = true;
        #endregion

        public ModernErrorProvider()
        {
            _animationTimer.Tick += (s, e) => {
                if (_pulseExpanding) { _pulseFactor += 0.05f; if (_pulseFactor >= 1.3f) _pulseExpanding = false; }
                else { _pulseFactor -= 0.05f; if (_pulseFactor <= 1.0f) _pulseExpanding = true; }
                RefreshAll();
            };
            _animationTimer.Start();
        }

        public bool CanExtend(object extendee) => extendee is Control && !(extendee is Form);

        [DefaultValue("")]
        public string GetErrorText(Control control) => _errors.ContainsKey(control) ? _errors[control].Text : "";

        public void SetErrorText(Control control, string value)
        {
            if (control == null) return;

            if (string.IsNullOrEmpty(value))
            {
                if (_errors.ContainsKey(control)) _errors[control].IsVisible = false;
            }
            else
            {
                if (!_errors.ContainsKey(control))
                    _errors[control] = new ErrorInfo { Control = control };

                _errors[control].Text = value;
                _errors[control].IsVisible = true;

                if (EnableShake) PerformShake(control);
            }
            RefreshAll();
        }

        private void RefreshAll()
        {
            foreach (var err in _errors.Values)
                err.Control.Parent?.Invalidate();
        }

        public void RenderAllErrors(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var err in _errors.Values)
            {
                if (!err.IsVisible || err.Control.Parent == null) continue;
                DrawProfessionalIcon(g, err.Control);
            }
        }

        private void DrawProfessionalIcon(Graphics g, Control ctrl)
        {
            Rectangle rect = new Rectangle(ctrl.Right + IconPadding, ctrl.Top + (ctrl.Height - IconSize.Height) / 2, IconSize.Width, IconSize.Height);

            // 1. Draw animated glow shadow
            using (GraphicsPath glowPath = new GraphicsPath())
            {
                int inflate = (int)(6 * _pulseFactor);
                Rectangle glowRect = Rectangle.Inflate(rect, inflate, inflate);
                glowPath.AddEllipse(glowRect);
                using (PathGradientBrush pgb = new PathGradientBrush(glowPath))
                {
                    pgb.CenterColor = Color.FromArgb((int)(100 / _pulseFactor), ErrorColor);
                    pgb.SurroundColors = new Color[] { Color.Transparent };
                    g.FillPath(pgb, glowPath);
                }
            }

            // 2. Draw Main Circle
            using (LinearGradientBrush b = new LinearGradientBrush(rect, ErrorColor, ControlPaint.Dark(ErrorColor), 45f))
            {
                g.FillEllipse(b, rect);
            }

            // 3. Draw high-fidelity "!"
            using (Pen p = new Pen(Color.White, 2.5f))
            {
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;
                float midX = rect.X + rect.Width / 2f;
                g.DrawLine(p, midX, rect.Y + 6, midX, rect.Bottom - 10);
                g.FillEllipse(Brushes.White, midX - 1.25f, rect.Bottom - 7, 2.5f, 2.5f);
            }
        }

        public void CheckHover(Point mousePos)
        {
            bool found = false;
            foreach (var err in _errors.Values)
            {
                if (!err.IsVisible) continue;
                Rectangle iconRect = new Rectangle(err.Control.Right + IconPadding, err.Control.Top + (err.Control.Height - IconSize.Height) / 2, IconSize.Width, IconSize.Height);
                if (iconRect.Contains(mousePos))
                {
                    ShowPopup(err);
                    found = true;
                    break;
                }
            }
            if (!found) _activePopup.Hide();
        }

        private void ShowPopup(ErrorInfo err)
        {
            _activePopup.ErrorMessage = err.Text;
            _activePopup.ThemeColor = ErrorColor;
            Point screenPos = err.Control.Parent.PointToScreen(new Point(err.Control.Right + IconPadding + IconSize.Width + 5, err.Control.Top));
            _activePopup.Location = screenPos;
            if (!_activePopup.Visible) _activePopup.Show();
        }

        private void PerformShake(Control ctrl)
        {
            Point orig = ctrl.Location;
            Timer t = new Timer { Interval = 20 };
            int count = 0;
            t.Tick += (s, e) => {
                ctrl.Location = new Point(orig.X + (count % 2 == 0 ? 5 : -5), orig.Y);
                if (++count > 10) { t.Stop(); ctrl.Location = orig; t.Dispose(); }
            };
            t.Start();
        }

        private void HidePopup() => _activePopup.Hide();
    }
}