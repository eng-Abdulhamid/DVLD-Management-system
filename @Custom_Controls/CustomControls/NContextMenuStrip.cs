using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ModernUI.Controls
{
    public class NContextMenuStrip : ContextMenuStrip
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(IntPtr hObject);

        private int _borderRadius = 10;
        private int _itemHeight = 38;
        private Size _iconSize = new Size(18, 18);
        private bool _enableIconTinting = true;

        private Color _menuBackColor = Color.White;
        private Color _menuBorderColor = Color.FromArgb(203, 213, 225);
        private Color _itemTextColor = Color.FromArgb(30, 41, 59);
        private Color _itemHoverColor = Color.FromArgb(243, 232, 255);
        private Color _itemHoverTextColor = Color.FromArgb(124, 58, 237);
        private Color _iconColor = Color.FromArgb(100, 116, 139);
        private Color _iconHoverColor = Color.FromArgb(124, 58, 237);
        private Color _separatorColor = Color.FromArgb(241, 245, 249);
        private Color _shortcutTextColor = Color.FromArgb(148, 163, 184);

        private Color _dangerItemHoverColor = Color.FromArgb(254, 242, 242);
        private Color _dangerItemTextColor = Color.FromArgb(239, 68, 68);
        private Color _dangerIconColor = Color.FromArgb(239, 68, 68);

        public NContextMenuStrip()
        {
            this.DoubleBuffered = true;
            this.ShowImageMargin = true;
            this.ShowCheckMargin = false;
            this.DropShadowEnabled = true;
            this.AutoSize = true;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.Renderer = new NMenuRenderer(this);
        }

        public NContextMenuStrip(IContainer container) : this()
        {
            container?.Add(this);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return cp;
            }
        }

        [Category("Appearance - Layout")]
        [DefaultValue(10)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get => _borderRadius;
            set
            {
                _borderRadius = Math.Max(0, value);
                UpdateRegion();
            }
        }

        [Category("Appearance - Layout")]
        [DefaultValue(38)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ItemHeight
        {
            get => _itemHeight;
            set
            {
                _itemHeight = Math.Max(28, value);
                this.Invalidate();
            }
        }

        [Category("Appearance - Icons")]
        [DefaultValue(typeof(Size), "18, 18")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Size IconSize
        {
            get => _iconSize;
            set
            {
                _iconSize = value;
                this.Invalidate();
            }
        }

        [Category("Appearance - Icons")]
        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EnableIconTinting
        {
            get => _enableIconTinting;
            set
            {
                _enableIconTinting = value;
                this.Invalidate();
            }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color MenuBackColor
        {
            get => _menuBackColor;
            set { _menuBackColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color MenuBorderColor
        {
            get => _menuBorderColor;
            set { _menuBorderColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ItemTextColor
        {
            get => _itemTextColor;
            set { _itemTextColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ItemHoverColor
        {
            get => _itemHoverColor;
            set { _itemHoverColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ItemHoverTextColor
        {
            get => _itemHoverTextColor;
            set { _itemHoverTextColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color IconColor
        {
            get => _iconColor;
            set { _iconColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color IconHoverColor
        {
            get => _iconHoverColor;
            set { _iconHoverColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SeparatorColor
        {
            get => _separatorColor;
            set { _separatorColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Colors")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ShortcutTextColor
        {
            get => _shortcutTextColor;
            set { _shortcutTextColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Danger Item")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DangerItemHoverColor
        {
            get => _dangerItemHoverColor;
            set { _dangerItemHoverColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Danger Item")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DangerItemTextColor
        {
            get => _dangerItemTextColor;
            set { _dangerItemTextColor = value; this.Invalidate(); }
        }

        [Category("Appearance - Danger Item")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color DangerIconColor
        {
            get => _dangerIconColor;
            set { _dangerIconColor = value; this.Invalidate(); }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateRegion();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateRegion();
        }

        private void UpdateRegion()
        {
            if (this.Width <= 0 || this.Height <= 0) return;

            if (_borderRadius > 0)
            {
                IntPtr hRgn = CreateRoundRectRgn(0, 0, this.Width + 1, this.Height + 1, _borderRadius * 2, _borderRadius * 2);
                Region? oldRegion = this.Region;
                this.Region = Region.FromHrgn(hRgn);
                DeleteObject(hRgn);
                oldRegion?.Dispose();
            }
            else
            {
                this.Region = null;
            }
        }

        public ToolStripMenuItem AddItem(string text, Image? icon, EventHandler? onClick, Keys shortcut = Keys.None, bool isDanger = false)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text, icon, onClick);

            if (shortcut != Keys.None)
            {
                item.ShortcutKeys = shortcut;
                item.ShowShortcutKeys = true;
            }

            if (isDanger)
            {
                item.Tag = "Danger";
            }

            this.Items.Add(item);
            return item;
        }

        public void AddCustomSeparator()
        {
            this.Items.Add(new ToolStripSeparator());
        }

        private class NMenuRenderer : ToolStripRenderer
        {
            private readonly NContextMenuStrip _owner;

            public NMenuRenderer(NContextMenuStrip owner)
            {
                _owner = owner;
            }

            protected override void InitializeItem(ToolStripItem item)
            {
                base.InitializeItem(item);

                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.AutoSize = true;
                    menuItem.Padding = new Padding(12, 6, 20, 6);
                }
                else if (item is ToolStripSeparator separator)
                {
                    separator.AutoSize = false;
                    separator.Height = 8;
                }
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using (SolidBrush bgBrush = new SolidBrush(_owner.MenuBackColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.AffectedBounds);
                }
            }

            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                using (SolidBrush marginBrush = new SolidBrush(_owner.MenuBackColor))
                {
                    e.Graphics.FillRectangle(marginBrush, e.AffectedBounds);
                }
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                Rectangle rect = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);

                if (_owner.BorderRadius > 0)
                {
                    using (GraphicsPath path = GetRoundedPath(new RectangleF(rect.X, rect.Y, rect.Width, rect.Height), _owner.BorderRadius))
                    using (Pen borderPen = new Pen(_owner.MenuBorderColor, 1.2f))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
                else
                {
                    using (Pen borderPen = new Pen(_owner.MenuBorderColor, 1.2f))
                    {
                        e.Graphics.DrawRectangle(borderPen, rect);
                    }
                }
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                bool isDanger = e.Item.Tag?.ToString() == "Danger";
                bool isSelected = e.Item.Selected && e.Item.Enabled;

                if (isSelected)
                {
                    Rectangle capsuleRect = new Rectangle(6, 3, e.Item.Width - 12, e.Item.Height - 6);
                    Color hoverColor = isDanger ? _owner.DangerItemHoverColor : _owner.ItemHoverColor;

                    using (GraphicsPath path = GetRoundedPath(new RectangleF(capsuleRect.X, capsuleRect.Y, capsuleRect.Width, capsuleRect.Height), 6))
                    using (SolidBrush hoverBrush = new SolidBrush(hoverColor))
                    {
                        e.Graphics.FillPath(hoverBrush, path);
                    }
                }
            }

            protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
            {
                if (e.Image == null) return;

                bool isDanger = e.Item.Tag?.ToString() == "Danger";
                bool isSelected = e.Item.Selected && e.Item.Enabled;

                Color tintColor;
                if (!e.Item.Enabled)
                {
                    tintColor = Color.FromArgb(203, 213, 225);
                }
                else if (isDanger)
                {
                    tintColor = _owner.DangerIconColor;
                }
                else if (isSelected)
                {
                    tintColor = _owner.IconHoverColor;
                }
                else
                {
                    tintColor = _owner.IconColor;
                }

                int centerX = e.ImageRectangle.X + (e.ImageRectangle.Width / 2);
                int centerY = e.Item.ContentRectangle.Y + (e.Item.Height / 2);
                Rectangle iconRect = new Rectangle(
                    centerX - (_owner.IconSize.Width / 2),
                    centerY - (_owner.IconSize.Height / 2),
                    _owner.IconSize.Width,
                    _owner.IconSize.Height);

                DrawCrispImage(e.Graphics, e.Image, iconRect, tintColor, _owner.EnableIconTinting);
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                bool isDanger = e.Item.Tag?.ToString() == "Danger";
                bool isSelected = e.Item.Selected && e.Item.Enabled;

                if (!e.Item.Enabled)
                {
                    e.TextColor = Color.FromArgb(160, 166, 175);
                }
                else if (isDanger)
                {
                    e.TextColor = _owner.DangerItemTextColor;
                }
                else if (isSelected)
                {
                    e.TextColor = _owner.ItemHoverTextColor;
                }
                else
                {
                    e.TextColor = _owner.ItemTextColor;
                }

                base.OnRenderItemText(e);
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                int y = e.Item.Height / 2;
                int startX = 40;
                int endX = e.Item.Width - 14;

                using (Pen pen = new Pen(_owner.SeparatorColor, 1))
                {
                    e.Graphics.DrawLine(pen, startX, y, endX, y);
                }
            }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                bool isSelected = e.Item.Selected && e.Item.Enabled;
                Color arrowColor = isSelected ? _owner.ItemHoverTextColor : _owner.IconColor;

                using (Pen pen = new Pen(arrowColor, 1.8f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;

                    int x = e.ArrowRectangle.X + (e.ArrowRectangle.Width - 5) / 2;
                    int y = e.ArrowRectangle.Y + (e.ArrowRectangle.Height - 8) / 2;

                    e.Graphics.DrawLine(pen, x, y, x + 4, y + 4);
                    e.Graphics.DrawLine(pen, x + 4, y + 4, x, y + 8);
                }
            }

            private static void DrawCrispImage(Graphics g, Image img, Rectangle bounds, Color tint, bool enableTint)
            {
                InterpolationMode prevInterp = g.InterpolationMode;
                PixelOffsetMode prevOffset = g.PixelOffsetMode;
                SmoothingMode prevSmooth = g.SmoothingMode;
                CompositingQuality prevComp = g.CompositingQuality;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;

                if (!enableTint || tint == Color.Transparent || tint == Color.Empty)
                {
                    g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                }
                else
                {
                    float r = tint.R / 255f;
                    float gr = tint.G / 255f;
                    float b = tint.B / 255f;
                    float a = tint.A / 255f;

                    ColorMatrix cm = new ColorMatrix(new float[][]
                    {
                        new float[] { 0, 0, 0, 0, 0 },
                        new float[] { 0, 0, 0, 0, 0 },
                        new float[] { 0, 0, 0, 0, 0 },
                        new float[] { 0, 0, 0, a, 0 },
                        new float[] { r, gr, b, 0, 1 }
                    });

                    using (ImageAttributes ia = new ImageAttributes())
                    {
                        ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        g.DrawImage(img, bounds, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                    }
                }

                g.InterpolationMode = prevInterp;
                g.PixelOffsetMode = prevOffset;
                g.SmoothingMode = prevSmooth;
                g.CompositingQuality = prevComp;
            }

            private static GraphicsPath GetRoundedPath(RectangleF rect, float radius)
            {
                GraphicsPath path = new GraphicsPath();
                if (radius <= 0)
                {
                    path.AddRectangle(rect);
                    return path;
                }

                float diameter = radius * 2f;
                SizeF size = new SizeF(diameter, diameter);
                RectangleF arc = new RectangleF(rect.Location, size);

                path.StartFigure();
                path.AddArc(arc, 180, 90);

                arc.X = rect.Right - diameter;
                path.AddArc(arc, 270, 90);

                arc.Y = rect.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                arc.X = rect.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();
                return path;
            }
        }
    }
}