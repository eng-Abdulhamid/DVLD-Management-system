using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DVLD.PL.Global
{
    public class ModernMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder => UITheme.NeutralBorder;
        public override Color ToolStripDropDownBackground => UITheme.SurfaceWhite;
        public override Color ImageMarginGradientBegin => UITheme.SurfaceWhite;
        public override Color ImageMarginGradientMiddle => UITheme.SurfaceWhite;
        public override Color ImageMarginGradientEnd => UITheme.SurfaceWhite;
        public override Color MenuItemSelected => Color.FromArgb(243, 232, 255);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(243, 232, 255);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(243, 232, 255);
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuStripGradientBegin => UITheme.SurfaceWhite;
        public override Color MenuStripGradientEnd => UITheme.SurfaceWhite;
        public override Color SeparatorDark => UITheme.NeutralBorder;
        public override Color SeparatorLight => Color.Transparent;
    }

    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernMenuColorTable())
        {
            RoundedEdges = true;
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected)
            {
                base.OnRenderMenuItemBackground(e);
                return;
            }

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(2, 1, e.Item.Width - 4, e.Item.Height - 2);
            using GraphicsPath path = CreateRoundedRectangle(rect, 6);
            using SolidBrush brush = new SolidBrush(Color.FromArgb(243, 232, 255));
            g.FillPath(brush, path);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Selected ? UITheme.PrimaryPressed : UITheme.TextPrimary;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using Pen pen = new Pen(UITheme.NeutralBorder, 1);
            g.DrawRectangle(pen, rect);
        }

        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
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