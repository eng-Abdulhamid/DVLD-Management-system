using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CustomizeControls
{
    public class NMenuColorTable : ProfessionalColorTable
    {
        public Color CustomMenuBorder { get; set; } = Color.FromArgb(226, 232, 240);
        public Color CustomBackground { get; set; } = Color.White;
        public Color CustomItemSelected { get; set; } = Color.FromArgb(243, 232, 255);
        public Color CustomSeparator { get; set; } = Color.FromArgb(241, 245, 249);

        public override Color MenuBorder => CustomMenuBorder;
        public override Color ToolStripDropDownBackground => CustomBackground;
        public override Color ImageMarginGradientBegin => CustomBackground;
        public override Color ImageMarginGradientMiddle => CustomBackground;
        public override Color ImageMarginGradientEnd => CustomBackground;
        public override Color MenuItemSelected => CustomItemSelected;
        public override Color MenuItemSelectedGradientBegin => CustomItemSelected;
        public override Color MenuItemSelectedGradientEnd => CustomItemSelected;
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuStripGradientBegin => CustomBackground;
        public override Color MenuStripGradientEnd => CustomBackground;
        public override Color SeparatorDark => CustomSeparator;
        public override Color SeparatorLight => Color.Transparent;
    }

    public class NMenuRenderer : ToolStripProfessionalRenderer
    {
        private readonly NMenuColorTable _colorTable;

        public Color ItemTextColor { get; set; } = Color.FromArgb(15, 23, 42);
        public Color ItemHoverTextColor { get; set; } = Color.FromArgb(124, 58, 237);
        public Color DangerTextColor { get; set; } = Color.FromArgb(239, 68, 68);
        public Color DangerHoverBackground { get; set; } = Color.FromArgb(254, 242, 242);
        public int ItemBorderRadius { get; set; } = 6;

        public NMenuRenderer() : this(new NMenuColorTable())
        {
        }

        public NMenuRenderer(NMenuColorTable colorTable) : base(colorTable)
        {
            _colorTable = colorTable;
            RoundedEdges = true;
        }

        protected override void InitializeItem(ToolStripItem item)
        {
            base.InitializeItem(item);

            if (item is ToolStripMenuItem menuItem)
            {
                menuItem.AutoSize = true;
                menuItem.Padding = new Padding(8, 6, 16, 6);
            }
            else if (item is ToolStripSeparator separator)
            {
                separator.AutoSize = false;
                separator.Height = 6;
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected || !e.Item.Enabled) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            bool isDanger = e.Item.Tag?.ToString() == "Danger" ||
                            e.Item.ForeColor == DangerTextColor;

            Color hoverBg = isDanger ? DangerHoverBackground : _colorTable.CustomItemSelected;
            Rectangle rect = new Rectangle(4, 2, e.Item.Width - 8, e.Item.Height - 4);

            using GraphicsPath path = GetRoundedRectangle(rect, ItemBorderRadius);
            using SolidBrush brush = new SolidBrush(hoverBg);
            g.FillPath(brush, path);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            bool isDanger = e.Item.Tag?.ToString() == "Danger" ||
                            e.Item.ForeColor == DangerTextColor;

            if (!e.Item.Enabled)
            {
                e.TextColor = Color.FromArgb(148, 163, 184);
            }
            else if (isDanger)
            {
                e.TextColor = DangerTextColor;
            }
            else
            {
                e.TextColor = e.Item.Selected ? ItemHoverTextColor : ItemTextColor;
            }

            base.OnRenderItemText(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using Pen pen = new Pen(_colorTable.CustomMenuBorder, 1);
            g.DrawRectangle(pen, rect);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            int y = e.Item.Height / 2;
            using Pen pen = new Pen(_colorTable.CustomSeparator, 1);
            e.Graphics.DrawLine(pen, 32, y, e.Item.Width - 8, y);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color arrowColor = e.Item.Selected ? ItemHoverTextColor : Color.FromArgb(148, 163, 184);
            using Pen pen = new Pen(arrowColor, 1.8f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            int x = e.ArrowRectangle.X + (e.ArrowRectangle.Width - 6) / 2;
            int y = e.ArrowRectangle.Y + (e.ArrowRectangle.Height - 8) / 2;

            e.Graphics.DrawLine(pen, x, y, x + 4, y + 4);
            e.Graphics.DrawLine(pen, x + 4, y + 4, x, y + 8);
        }

        private static GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}