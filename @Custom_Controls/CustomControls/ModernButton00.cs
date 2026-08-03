//using System;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Windows.Forms;

//namespace CustomControls
//{
//    public class ModernButton : Button
//    {
//        private Color _baseColor = Color.FromArgb(45, 118, 232);
//        private Color _hoverColor = Color.FromArgb(60, 130, 250);
//        private Color _pressedColor = Color.FromArgb(30, 90, 200);
//        private Color _borderColor = Color.FromArgb(30, 100, 200);
//        private int _borderRadius = 6;

//        public ModernButton()
//        {
//            SetStyle(ControlStyles.AllPaintingInWmPaint |
//                     ControlStyles.UserPaint |
//                     ControlStyles.DoubleBuffer |
//                     ControlStyles.ResizeRedraw, true);

//            FlatStyle = FlatStyle.Flat;
//            FlatAppearance.BorderSize = 0;
//            ForeColor = Color.White;
//            Font = new Font("Segoe UI", 9F, FontStyle.Regular);
//            Cursor = Cursors.Hand;
//            Size = new Size(100, 36);
//            BackColor = _baseColor;
//        }

//        public Color BaseColor
//        {
//            get => _baseColor;
//            set { _baseColor = value; Invalidate(); }
//        }

//        public Color HoverColor
//        {
//            get => _hoverColor;
//            set { _hoverColor = value; }
//        }

//        public Color PressedColor
//        {
//            get => _pressedColor;
//            set { _pressedColor = value; }
//        }

//        public Color BorderColor
//        {
//            get => _borderColor;
//            set { _borderColor = value; Invalidate(); }
//        }

//        public int BorderRadius
//        {
//            get => _borderRadius;
//            set { _borderRadius = Math.Max(0, value); Invalidate(); }
//        }

//        protected override void OnPaint(PaintEventArgs e)
//        {
//            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
//            e.Graphics.Clear(Parent?.BackColor ?? Color.White);

//            // Determine current color based on state
//            Color currentColor = _baseColor;
//            if (!Enabled)
//                currentColor = Color.FromArgb(150, 150, 150);

//            // Draw rounded background
//            using (var path = GetRoundedPath(new Rectangle(0, 0, Width - 1, Height - 1), _borderRadius))
//            using (var brush = new SolidBrush(currentColor))
//            using (var pen = new Pen(_borderColor, 1))
//            {
//                e.Graphics.FillPath(brush, path);
//                e.Graphics.DrawPath(pen, path);
//            }

//            // Draw text centered
//            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle,
//                ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
//        }

//        protected override void OnMouseEnter(EventArgs e)
//        {
//            if (!Enabled) return;
//            BackColor = _hoverColor;
//            Invalidate();
//            base.OnMouseEnter(e);
//        }

//        protected override void OnMouseLeave(EventArgs e)
//        {
//            if (!Enabled) return;
//            BackColor = _baseColor;
//            Invalidate();
//            base.OnMouseLeave(e);
//        }

//        protected override void OnMouseDown(MouseEventArgs mevent)
//        {
//            if (!Enabled) return;
//            BackColor = _pressedColor;
//            Invalidate();
//            base.OnMouseDown(mevent);
//        }

//        protected override void OnMouseUp(MouseEventArgs mevent)
//        {
//            if (!Enabled) return;
//            BackColor = _hoverColor;
//            Invalidate();
//            base.OnMouseUp(mevent);
//        }

//        private GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
//        {
//            var path = new GraphicsPath();
//            int d = radius * 2;

//            if (radius == 0)
//            {
//                path.AddRectangle(bounds);
//                return path;
//            }

//            path.StartFigure();
//            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
//            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
//            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
//            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
//            path.CloseFigure();

//            return path;
//        }
//    }
//}
