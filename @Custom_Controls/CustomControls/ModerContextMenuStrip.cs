using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ModernUI
{
    
    public class ModernContextMenuStrip : ContextMenuStrip
    {
        public ModernContextMenuStrip()
        {
            // إعدادات الريندر والألوان
            this.Renderer = new ModernMenuRenderer();
            
            // تحسينات بصرية
            this.ShowImageMargin = true;
            this.ImageScalingSize = new Size(24, 24); // حجم عرض الأيقونة لتبدو واضحة
            this.BackColor = Color.FromArgb(40, 40, 40); // لون الخلفية
            this.ForeColor = Color.WhiteSmoke; // لون النص
            this.Font = new Font("Segoe UI", 10f, FontStyle.Regular); // خط عصري
            this.DropShadowEnabled = true; // تفعيل الظل (ويندوز سيقوم بمعالجته)
        }

        // تجاوز حدث Paint لإضافة حدود ناعمة
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // رسم إطار خارجي بلون عصري
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(60, 60, 60), ButtonBorderStyle.Solid);
        }
    }

    // ==========================================
    // الرسام المخصص: ModernMenuRenderer
    // ==========================================
    public class ModernMenuRenderer : ToolStripProfessionalRenderer
    {
        public ModernMenuRenderer() : base(new ModernColorTable()) { }

        // تخصيص رسم خلفية العنصر (Item)
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                
                // رسم مستطيل التحديد بحواف دائرية (Rounded Selection)
                using (GraphicsPath path = GetRoundedPath(rc, 4))
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(60, 60, 60))) // لون التحديد
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        // إزالة الخط الفاصل القبيح بجانب الصور
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            // لا تفعل شيئاً (يمنع رسم الخط الافتراضي)
        }

        // تخصيص رسم الفواصل (Separators)
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            // رسم خط فاصل أنيق ورفيع
            using (Pen pen = new Pen(Color.FromArgb(80, 80, 80), 1))
            {
                int y = e.Item.ContentRectangle.Height / 2;
                e.Graphics.DrawLine(pen, 10, y, e.Item.Width - 10, y);
            }
        }

        // تخصيص رسم الأسهم للقوائم الفرعية
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.White; // سهم أبيض دائماً
            base.OnRenderArrow(e);
        }

        // تخصيص رسم النص لضمان الوضوح
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Selected ? Color.White : Color.LightGray;
            base.OnRenderItemText(e);
        }

        // دالة مساعدة لإنشاء مسار بحواف دائرية
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    // ==========================================
    // جدول الألوان المخصص: ColorTable
    // ==========================================
    public class ModernColorTable : ProfessionalColorTable
    {
        // ألوان الخلفيات
        public override Color ToolStripDropDownBackground => Color.FromArgb(40, 40, 40); // خلفية القائمة
        public override Color MenuBorder => Color.FromArgb(60, 60, 60); // الإطار الخارجي

        // ألوان العناصر عند التحديد (نخفي الافتراضي لأننا رسمنا خاص بنا في OnRenderMenuItemBackground)
        public override Color MenuItemSelected => Color.Transparent;
        public override Color MenuItemBorder => Color.Transparent;

        // ألوان القوائم الفرعية
        public override Color MenuItemSelectedGradientBegin => Color.Transparent;
        public override Color MenuItemSelectedGradientEnd => Color.Transparent;

        // منطقة الصور (يسار القائمة)
        public override Color ImageMarginGradientBegin => Color.FromArgb(40, 40, 40);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(40, 40, 40);
        public override Color ImageMarginGradientEnd => Color.FromArgb(40, 40, 40);
    }
}