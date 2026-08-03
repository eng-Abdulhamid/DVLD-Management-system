using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace CustomControls
{
    public class ModernComboBox : ComboBox
    {
        #region Fields
        private Color _borderColor = Color.FromArgb(45, 118, 232);
        private Color _focusBorderColor = Color.FromArgb(70, 140, 230);
        private Color _backgroundColor = Color.White;
        private Color _textColor = Color.FromArgb(34, 47, 62);
        private Color _itemsBackColor = Color.White;
        private Color _itemsHoverColor = Color.FromArgb(242, 245, 252);
        private Color _itemsSelectedColor = Color.FromArgb(230, 240, 255);
        private Color _accentColor = Color.FromArgb(45, 118, 232);

        private int _borderRadius = 8;
        private int _borderWidth = 1;
        #endregion

        public ModernComboBox()
        {
            InitializeStyle();
            ApplyModernTheme();
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        private void InitializeStyle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable, true);

            DoubleBuffered = true;
        }

        private void ApplyModernTheme()
        {
            FlatStyle = FlatStyle.Flat;
            DropDownStyle = ComboBoxStyle.DropDownList;
            Font = new Font("Segoe UI", 10F);

            BackColor = _backgroundColor;
            ForeColor = _textColor;

            Height = 38;
            ItemHeight = 32;
            MaxDropDownItems = 10;
        }

        #region Properties
        [Category("Modern Appearance")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color FocusBorderColor
        {
            get => _focusBorderColor;
            set { _focusBorderColor = value; }
        }

        [Category("Modern Appearance")]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("Modern Appearance")]
        public int BorderWidth
        {
            get => _borderWidth;
            set { _borderWidth = Math.Max(1, value); Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color ItemsBackgroundColor
        {
            get => _itemsBackColor;
            set { _itemsBackColor = value; Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color ItemsHoverColor
        {
            get => _itemsHoverColor;
            set { _itemsHoverColor = value; Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color ItemsSelectedColor
        {
            get => _itemsSelectedColor;
            set { _itemsSelectedColor = value; Invalidate(); }
        }

        [Category("Modern Appearance")]
        public Color AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; Invalidate(); }
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            graph.Clear(Parent?.BackColor ?? Color.White);

            Color currentBorderColor = Focused ? _focusBorderColor : _borderColor;

            // Draw Background
            using (var path = GetRoundedPath(new Rectangle(0, 0, Width - 1, Height - 1), _borderRadius))
            using (var bgBrush = new SolidBrush(_backgroundColor))
            {
                graph.FillPath(bgBrush, path);

                // Draw Border
                using (var borderPen = new Pen(currentBorderColor, _borderWidth))
                {
                    graph.DrawPath(borderPen, path);
                }
            }

            // Draw Selected Item Text
            if (SelectedItem != null || Text != "")
            {
                string displayText = SelectedItem != null ? SelectedItem.ToString() : Text;
                var textRect = new Rectangle(12, 0, Width - 45, Height);
                TextRenderer.DrawText(graph, displayText, Font, textRect,
                    _textColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
            }

            DrawDropdownArrow(graph);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.AntiAlias;
            graph.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            // Background Color Logic
            Color itemBackColor = isSelected ? _itemsSelectedColor : _itemsBackColor;
            Color itemTextColor = _textColor;

            // Draw Item Background
            using (var brush = new SolidBrush(itemBackColor))
            {
                graph.FillRectangle(brush, e.Bounds);
            }

            // Draw Selection Indicator (The vertical line on the left)
            if (isSelected)
            {
                using (var accentBrush = new SolidBrush(_accentColor))
                {
                    graph.FillRectangle(accentBrush, e.Bounds.X, e.Bounds.Y + 4, 4, e.Bounds.Height - 8);
                }
            }

            // Text Padding & Rect
            int paddingLeft = 15;
            var textRect = new Rectangle(
                e.Bounds.X + paddingLeft,
                e.Bounds.Y,
                e.Bounds.Width - paddingLeft - 5,
                e.Bounds.Height);

            // Draw Text
            TextRenderer.DrawText(graph, Items[e.Index].ToString(),
                Font,
                textRect,
                itemTextColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            e.ItemHeight = ItemHeight;
            base.OnMeasureItem(e);
        }

        private void DrawDropdownArrow(Graphics g)
        {
            int arrowWidth = 10;
            int arrowHeight = 6;
            int arrowX = Width - 20;
            int arrowY = (Height - arrowHeight) / 2 + 1;

            using (var pen = new Pen(_borderColor, 2))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                Point[] points = new Point[]
                {
                    new Point(arrowX - arrowWidth/2, arrowY),
                    new Point(arrowX, arrowY + arrowHeight),
                    new Point(arrowX + arrowWidth/2, arrowY)
                };
                g.DrawLines(pen, points);
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            if (radius <= 0) { path.AddRectangle(bounds); return path; }

            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        #region Event Overrides
        protected override void OnDropDown(EventArgs e) { base.OnDropDown(e); Invalidate(); }
        protected override void OnDropDownClosed(EventArgs e) { base.OnDropDownClosed(e); Invalidate(); }
        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }
        protected override void OnMouseEnter(EventArgs e) { base.OnMouseEnter(e); Invalidate(); }
        protected override void OnMouseLeave(EventArgs e) { base.OnMouseLeave(e); Invalidate(); }
        #endregion
    }
}