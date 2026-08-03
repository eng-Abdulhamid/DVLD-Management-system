using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CustomControls
{
    [ToolboxItem(true)]
    [Description("إصدار فائق الأداء مع محرك رسوم متحركة وتأثيرات بصرية متقدمة.")]
    public class ModernFormStylerAdvanced : Component, IDisposable
    {
        #region Win32 API & Constants
        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        #endregion

        #region Fields & Animation Logic
        private Form _targetForm;
        private FormAdapter _adapter;
        private bool _isDisposed;
        private GraphicsPath _cachedRegionPath;
        private Rectangle _closeRect, _maxRect, _minRect;

        // Animation Helpers
        private Timer _animTimer;
        private float _glowAngle = 0;
        private int _hoverBtn = -1; // 0: None, 1: Min, 2: Max, 3: Close
        private float _closeBtnAlpha = 0, _maxBtnAlpha = 0, _minBtnAlpha = 0;
        #endregion

        #region Properties - Appearance
        private bool _showHeader = true;
        [Category("Design - Header")] public bool ShowHeader { get => _showHeader; set { _showHeader = value; FullRefresh(); } }

        private int _headerHeight = 45;
        [Category("Design - Header")] public int HeaderHeight { get => _headerHeight; set { _headerHeight = value; FullRefresh(); } }

        [Category("Design - Header")] public Color HeaderBackColor { get; set; } = Color.FromArgb(28, 28, 28);
        [Category("Design - Header")] public string TitleText { get; set; } = "Modern Interface";
        [Category("Design - Header")] public Color TitleColor { get; set; } = Color.White;
        [Category("Design - Header")] public Font TitleFont { get; set; } = new Font("Segoe UI", 10f, FontStyle.Bold);
        [Category("Design - Header")] public bool CenterTitle { get; set; } = false;

        private int _borderRadius = 18;
        [Category("Design - Main")] public int BorderRadius { get => _borderRadius; set { _borderRadius = value; FullRefresh(); } }
        [Category("Design - Main")] public Color BorderColor { get; set; } = Color.FromArgb(50, 50, 50);
        [Category("Design - Main")] public int BorderSize { get; set; } = 1;

        [Category("Design - Animation")] public bool EnableGlowAnimation { get; set; } = true;
        [Category("Design - Animation")] public Color GlowColor { get; set; } = Color.Cyan;
        [Category("Design - Animation")] public bool EnableFadeIn { get; set; } = true;

        [Category("Behavior")] public bool AllowResize { get; set; } = true;
        #endregion

        [Category("Target")]
        public Form TargetForm
        {
            get => _targetForm;
            set
            {
                if (_targetForm != value)
                {
                    _targetForm = value;
                    if (_targetForm != null)
                    {
                        if (_targetForm.IsHandleCreated) InitializeForm();
                        else _targetForm.HandleCreated += (s, e) => InitializeForm();
                    }
                }
            }
        }

        public ModernFormStylerAdvanced()
        {
            _animTimer = new Timer { Interval = 15 }; // ~60 FPS
            _animTimer.Tick += AnimationTick;
        }

        private void InitializeForm()
        {
            if (_targetForm == null) return;

            _targetForm.FormBorderStyle = FormBorderStyle.None;

            // تحسين الأداء عبر الـ Reflection
            typeof(Form).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(_targetForm, true);

            _targetForm.Paint += OnFormPaint;
            _targetForm.MouseDown += OnFormMouseDown;
            _targetForm.MouseMove += OnFormMouseMove;
            _targetForm.MouseLeave += (s, e) => { _hoverBtn = -1; };
            _targetForm.Resize += (s, e) => { _cachedRegionPath?.Dispose(); _cachedRegionPath = null; ApplyRegion(); };

            if (EnableFadeIn)
            {
                _targetForm.Opacity = 0;
                Timer t = new Timer { Interval = 15 };
                t.Tick += (s, e) => {
                    if (_targetForm.Opacity < 1) _targetForm.Opacity += 0.05;
                    else { t.Stop(); t.Dispose(); }
                };
                t.Start();
            }

            if (_adapter != null) _adapter.ReleaseHandle();
            _adapter = new FormAdapter(_targetForm, this);

            ApplyRegion();
            _animTimer.Start();
        }

        private void AnimationTick(object sender, EventArgs e)
        {
            if (_targetForm == null || _targetForm.IsDisposed) return;

            // 1. تحريك توهج الحدود
            if (EnableGlowAnimation)
            {
                _glowAngle += 4f;
                if (_glowAngle >= 360) _glowAngle = 0;
            }

            // 2. تحريك شفافية الأزرار (Smooth Hover) باستخدام Lerp
            _closeBtnAlpha = Lerp(_closeBtnAlpha, (_hoverBtn == 3 ? 255 : 0), 0.15f);
            _maxBtnAlpha = Lerp(_maxBtnAlpha, (_hoverBtn == 2 ? 60 : 0), 0.15f);
            _minBtnAlpha = Lerp(_minBtnAlpha, (_hoverBtn == 1 ? 60 : 0), 0.15f);

            // نحدث فقط منطقة الهيدر لتقليل استهلاك المعالج
            _targetForm.Invalidate(new Rectangle(0, 0, _targetForm.Width, HeaderHeight + 2));
        }

        private float Lerp(float start, float end, float amount) => start + (end - start) * amount;

        private void FullRefresh() { if (_targetForm == null) return; _cachedRegionPath?.Dispose(); _cachedRegionPath = null; ApplyRegion(); _targetForm.Invalidate(); }

        private void ApplyRegion()
        {
            if (_targetForm == null || _targetForm.IsDisposed) return;
            if (_targetForm.WindowState == FormWindowState.Maximized) { _targetForm.Region = null; return; }

            if (_cachedRegionPath == null)
                _cachedRegionPath = GetRoundedPath(new Rectangle(0, 0, _targetForm.Width, _targetForm.Height), BorderRadius);

            _targetForm.Region = new Region(_cachedRegionPath);
        }

        private void OnFormPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.Low; // لتحسين الأداء
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;

            // 1. رسم الهيدر
            if (ShowHeader)
            {
                using (var brush = new SolidBrush(HeaderBackColor))
                    g.FillRectangle(brush, 0, 0, _targetForm.Width, HeaderHeight);

                // رسم العنوان
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                using (var titleBrush = new SolidBrush(TitleColor))
                {
                    var size = g.MeasureString(TitleText, TitleFont);
                    float x = CenterTitle ? (_targetForm.Width - size.Width) / 2 : 15;
                    g.DrawString(TitleText, TitleFont, titleBrush, x, (HeaderHeight - size.Height) / 2);
                }

                DrawControlBox(g);
            }

            // 2. رسم الحدود والتوهج (AntiAlias فقط هنا لجمالية الخطوط)
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (EnableGlowAnimation && _targetForm.WindowState != FormWindowState.Maximized && _cachedRegionPath != null)
            {
                using (LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(0, 0, _targetForm.Width, _targetForm.Height), GlowColor, Color.Transparent, _glowAngle))
                using (Pen glowPen = new Pen(lgb, 2f))
                    g.DrawPath(glowPen, _cachedRegionPath);
            }

            if (BorderSize > 0 && _targetForm.WindowState != FormWindowState.Maximized && _cachedRegionPath != null)
            {
                using (var pen = new Pen(BorderColor, BorderSize))
                    g.DrawPath(pen, _cachedRegionPath);
            }
        }

        private void DrawControlBox(Graphics g)
        {
            int btnWidth = 46;
            _closeRect = new Rectangle(_targetForm.Width - btnWidth, 0, btnWidth, HeaderHeight);
            _maxRect = new Rectangle(_targetForm.Width - (btnWidth * 2), 0, btnWidth, HeaderHeight);
            _minRect = new Rectangle(_targetForm.Width - (btnWidth * 3), 0, btnWidth, HeaderHeight);

            // تأثيرات الألوان المتحركة
            if (_closeBtnAlpha > 1)
                using (var bClose = new SolidBrush(Color.FromArgb((int)_closeBtnAlpha, Color.Crimson)))
                    g.FillRectangle(bClose, _closeRect);

            if (_maxBtnAlpha > 1)
                using (var bMax = new SolidBrush(Color.FromArgb((int)_maxBtnAlpha, Color.White)))
                    g.FillRectangle(bMax, _maxRect);

            if (_minBtnAlpha > 1)
                using (var bMin = new SolidBrush(Color.FromArgb((int)_minBtnAlpha, Color.White)))
                    g.FillRectangle(bMin, _minRect);

            // رسم الأيقونات
            using (var pen = new Pen(TitleColor, 1.5f))
            {
                int cy = HeaderHeight / 2;
                // إغلاق
                g.DrawLine(pen, _closeRect.X + 18, cy - 5, _closeRect.Right - 18, cy + 5);
                g.DrawLine(pen, _closeRect.Right - 18, cy - 5, _closeRect.X + 18, cy + 5);
                // تكبير
                g.DrawRectangle(pen, _maxRect.X + 18, cy - 5, 10, 10);
                // تصغير
                g.DrawLine(pen, _minRect.X + 18, cy + 5, _minRect.X + 28, cy + 5);
            }
        }

        private void OnFormMouseMove(object sender, MouseEventArgs e)
        {
            if (_closeRect.Contains(e.Location)) _hoverBtn = 3;
            else if (_maxRect.Contains(e.Location)) _hoverBtn = 2;
            else if (_minRect.Contains(e.Location)) _hoverBtn = 1;
            else _hoverBtn = -1;
        }

        private void OnFormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_closeRect.Contains(e.Location)) _targetForm.Close();
                else if (_maxRect.Contains(e.Location))
                    _targetForm.WindowState = _targetForm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                else if (_minRect.Contains(e.Location)) _targetForm.WindowState = FormWindowState.Minimized;
                else if (e.Y <= HeaderHeight)
                {
                    ReleaseCapture();
                    SendMessage(_targetForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            if (d <= 0) { path.AddRectangle(r); return path; }
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        #region FormAdapter
        private class FormAdapter : NativeWindow
        {
            private Form _form;
            private ModernFormStylerAdvanced _styler;
            public FormAdapter(Form form, ModernFormStylerAdvanced styler) { _form = form; _styler = styler; AssignHandle(form.Handle); }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x84 && _styler.AllowResize && _form.WindowState != FormWindowState.Maximized)
                {
                    base.WndProc(ref m);
                    if (m.Result.ToInt32() == 1) // HTCLIENT
                    {
                        Point p = _form.PointToClient(new Point(m.LParam.ToInt32()));
                        int g = 8;
                        if (p.X <= g && p.Y <= g) m.Result = (IntPtr)13;
                        else if (p.X >= _form.Width - g && p.Y <= g) m.Result = (IntPtr)14;
                        else if (p.X <= g && p.Y >= _form.Height - g) m.Result = (IntPtr)16;
                        else if (p.X >= _form.Width - g && p.Y >= _form.Height - g) m.Result = (IntPtr)17;
                        else if (p.X <= g) m.Result = (IntPtr)10;
                        else if (p.X >= _form.Width - g) m.Result = (IntPtr)11;
                        else if (p.Y <= g) m.Result = (IntPtr)12;
                        else if (p.Y >= _form.Height - g) m.Result = (IntPtr)15;
                    }
                    return;
                }
                base.WndProc(ref m);
            }
        }
        #endregion

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                _animTimer?.Stop();
                _animTimer?.Dispose();
                _cachedRegionPath?.Dispose();
                _adapter?.ReleaseHandle();
            }
        }
    }
}