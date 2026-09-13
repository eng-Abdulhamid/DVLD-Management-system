using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CustomizeControls
{
    public class NMenuColorTable : ProfessionalColorTable
    {
        public Color CustomBorder { get; set; } = Color.FromArgb(226, 232, 240);
        public Color CustomBackground { get; set; } = Color.White;
        public Color CustomItemSelected { get; set; } = Color.FromArgb(241, 245, 249); // رمادي ويندوز الهادئ والمسطح
        public Color CustomSeparator { get; set; } = Color.FromArgb(226, 232, 240);

        public override Color MenuBorder => CustomBorder;
        public override Color ToolStripDropDownBackground => CustomBackground;
        public override Color ImageMarginGradientBegin => CustomBackground;
        public override Color ImageMarginGradientMiddle => CustomBackground;
        public override Color ImageMarginGradientEnd => CustomBackground;
        public override Color MenuItemSelected => CustomItemSelected;
        public override Color MenuItemSelectedGradientBegin => CustomItemSelected;
        public override Color MenuItemSelectedGradientEnd => CustomItemSelected;
        public override Color MenuItemBorder => Color.Transparent; // بدون إطار خارجي حول الهوفر
        public override Color MenuStripGradientBegin => CustomBackground;
        public override Color MenuStripGradientEnd => CustomBackground;
        public override Color SeparatorDark => CustomSeparator;
        public override Color SeparatorLight => Color.Transparent;
    }

    public class NMenuRenderer : ToolStripProfessionalRenderer
    {
        private readonly NMenuColorTable _colorTable;

        public Color ItemTextColor { get; set; } = Color.FromArgb(30, 41, 59);       // رمادي داكن مقروء ومريح
        public Color ItemHoverTextColor { get; set; } = Color.FromArgb(15, 23, 42);    // نص أغمق عند التمرير
        public Color AccentColor { get; set; } = Color.FromArgb(124, 58, 237);       // لمسة التحديد الأنيقة
        public Color DangerTextColor { get; set; } = Color.FromArgb(220, 38, 38);      // لون أحمر عند تسجيل الخروج
        public Color DangerHoverBackground { get; set; } = Color.FromArgb(254, 242, 242);

        public NMenuRenderer() : this(new NMenuColorTable())
        {
        }

        public NMenuRenderer(NMenuColorTable colorTable) : base(colorTable)
        {
            _colorTable = colorTable;
            RoundedEdges = false; // حواف مربعة مسطحة كلياً مثل الويندوز
        }

        protected override void InitializeItem(ToolStripItem item)
        {
            base.InitializeItem(item);

            if (item is ToolStripMenuItem menuItem)
            {
                menuItem.AutoSize = true;
                // مسافة مريحة وكافية بين الكلام والحدود
                menuItem.Padding = new Padding(14, 8, 16, 8);
            }
            else if (item is ToolStripSeparator separator)
            {
                separator.AutoSize = false;
                separator.Height = 7;
            }
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected || !e.Item.Enabled) return;

            Graphics g = e.Graphics;
            bool isDanger = e.Item.Tag?.ToString() == "Danger" || e.Item.ForeColor == DangerTextColor;
            Color hoverBg = isDanger ? DangerHoverBackground : _colorTable.CustomItemSelected;
            Color accent = isDanger ? DangerTextColor : AccentColor;

            // 1. رسم خلفية مستطيلة مربعة بدون أي زوايا دائرية
            Rectangle rect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
            using (SolidBrush brush = new SolidBrush(hoverBg))
            {
                g.FillRectangle(brush, rect);
            }

            // 2. اللمسة الفنية (شريط تفاعلي نحيف مربع 3px):
            // في القائمة الرئيسية يظهر في الأسفل، وفي المنسدلة يظهر على اليسار
            using (SolidBrush accentBrush = new SolidBrush(accent))
            {
                if (e.ToolStrip is MenuStrip)
                {
                    g.FillRectangle(accentBrush, 0, e.Item.Height - 3, e.Item.Width, 3);
                }
                else
                {
                    g.FillRectangle(accentBrush, 0, 0, 3, e.Item.Height);
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            bool isDanger = e.Item.Tag?.ToString() == "Danger" || e.Item.ForeColor == DangerTextColor;

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
            // إبقاء شريط الـ MenuStrip العلوي بدون إطار ليكون مدمجاً
            if (e.ToolStrip is MenuStrip) return;

            // إطار مربع نظيف ومسطح للقائمة المنسدلة فقط
            Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            using Pen pen = new Pen(_colorTable.CustomBorder, 1);
            e.Graphics.DrawRectangle(pen, rect);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            int y = e.Item.Height / 2;
            using Pen pen = new Pen(_colorTable.CustomSeparator, 1);
            // خط فاصل أفقي بسيط ومستقيم
            e.Graphics.DrawLine(pen, 12, y, e.Item.Width - 12, y);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            // سهم توجيه مربع وبسيط
            Color arrowColor = e.Item.Selected ? AccentColor : Color.FromArgb(100, 116, 139);
            using SolidBrush brush = new SolidBrush(arrowColor);

            Point middle = new Point(
                e.ArrowRectangle.Left + e.ArrowRectangle.Width / 2,
                e.ArrowRectangle.Top + e.ArrowRectangle.Height / 2
            );

            Point[] arrowPoints = new Point[]
            {
                new Point(middle.X - 2, middle.Y - 4),
                new Point(middle.X + 2, middle.Y),
                new Point(middle.X - 2, middle.Y + 4)
            };

            e.Graphics.FillPolygon(brush, arrowPoints);
        }
    }
}