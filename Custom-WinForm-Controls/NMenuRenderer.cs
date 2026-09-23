using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CustomizeControls;

public class NMenuColorTable : ProfessionalColorTable
{
    public Color CustomBorder { get; set; } = Color.FromArgb(51, 65, 85);
    public Color CustomBackground { get; set; } = Color.FromArgb(30, 41, 59);
    public Color CustomItemSelected { get; set; } = Color.FromArgb(51, 65, 85);
    public Color CustomItemPressed { get; set; } = Color.FromArgb(71, 85, 105);
    public Color CustomSeparator { get; set; } = Color.FromArgb(51, 65, 85);

    public override Color MenuBorder => CustomBorder;
    public override Color ToolStripDropDownBackground => CustomBackground;
    public override Color ImageMarginGradientBegin => CustomBackground;
    public override Color ImageMarginGradientMiddle => CustomBackground;
    public override Color ImageMarginGradientEnd => CustomBackground;
    public override Color MenuItemSelected => CustomItemSelected;
    public override Color MenuItemSelectedGradientBegin => CustomItemSelected;
    public override Color MenuItemSelectedGradientEnd => CustomItemSelected;
    public override Color MenuItemPressedGradientBegin => CustomItemPressed;
    public override Color MenuItemPressedGradientMiddle => CustomItemPressed;
    public override Color MenuItemPressedGradientEnd => CustomItemPressed;
    public override Color MenuItemBorder => Color.Transparent;
    public override Color MenuStripGradientBegin => CustomBackground;
    public override Color MenuStripGradientEnd => CustomBackground;
    public override Color SeparatorDark => CustomSeparator;
    public override Color SeparatorLight => Color.Transparent;
}

public class NMenuRenderer(NMenuColorTable colorTable) : ToolStripProfessionalRenderer(colorTable)
{
    private readonly NMenuColorTable _colorTable = colorTable;

    public NMenuRenderer() : this(new NMenuColorTable())
    {
    }

    public new NMenuColorTable ColorTable => _colorTable;

    public Color ItemTextColor { get; set; } = Color.FromArgb(241, 245, 249);
    public Color ItemHoverTextColor { get; set; } = Color.White;
    public Color ItemPressedTextColor { get; set; } = Color.White;
    public Color DisabledTextColor { get; set; } = Color.FromArgb(100, 116, 139);
    public Color AccentColor { get; set; } = Color.FromArgb(99, 102, 241);
    public Color ArrowColor { get; set; } = Color.FromArgb(148, 163, 184);
    public Color DangerTextColor { get; set; } = Color.FromArgb(248, 113, 113);
    public Color DangerHoverBackground { get; set; } = Color.FromArgb(153, 27, 27);
    public int BorderSize { get; set; } = 1;
    public int ItemHorizontalPadding { get; set; } = 14;
    public int ItemVerticalPadding { get; set; } = 8;
    public int SeparatorHeight { get; set; } = 7;
    public int AccentSize { get; set; } = 3;

    protected override void InitializeItem(ToolStripItem item)
    {
        base.InitializeItem(item);

        if (item is ToolStripMenuItem menuItem)
        {
            menuItem.AutoSize = true;
            menuItem.Padding = new Padding(ItemHorizontalPadding, ItemVerticalPadding, ItemHorizontalPadding + 2, ItemVerticalPadding);
        }
        else if (item is ToolStripSeparator separator)
        {
            separator.AutoSize = false;
            separator.Height = Math.Max(1, SeparatorHeight);
        }
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        if (!e.Item.Selected && !e.Item.Pressed) return;
        if (!e.Item.Enabled) return;

        Graphics g = e.Graphics;
        bool isDanger = e.Item.Tag?.ToString() == "Danger" || e.Item.ForeColor == DangerTextColor;
        Color bg = e.Item.Pressed
            ? _colorTable.CustomItemPressed
            : (isDanger ? DangerHoverBackground : _colorTable.CustomItemSelected);
        Color accent = isDanger ? DangerTextColor : AccentColor;

        Rectangle rect = new(0, 0, e.Item.Width, e.Item.Height);
        using SolidBrush brush = new(bg);
        g.FillRectangle(brush, rect);

        if (AccentSize > 0)
        {
            using SolidBrush accentBrush = new(accent);
            if (e.ToolStrip is MenuStrip)
            {
                g.FillRectangle(accentBrush, 0, e.Item.Height - AccentSize, e.Item.Width, AccentSize);
            }
            else
            {
                g.FillRectangle(accentBrush, 0, 0, AccentSize, e.Item.Height);
            }
        }
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

        bool isDanger = e.Item.Tag?.ToString() == "Danger" || e.Item.ForeColor == DangerTextColor;

        if (!e.Item.Enabled)
        {
            e.TextColor = DisabledTextColor;
        }
        else if (isDanger)
        {
            e.TextColor = DangerTextColor;
        }
        else if (e.Item.Pressed)
        {
            e.TextColor = ItemPressedTextColor;
        }
        else if (e.Item.Selected)
        {
            e.TextColor = ItemHoverTextColor;
        }
        else
        {
            e.TextColor = ItemTextColor;
        }

        base.OnRenderItemText(e);
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        if (e.ToolStrip is MenuStrip || BorderSize <= 0) return;

        Rectangle rect = new(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
        using Pen pen = new(_colorTable.CustomBorder, BorderSize);
        e.Graphics.DrawRectangle(pen, rect);
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        int y = e.Item.Height / 2;
        using Pen pen = new(_colorTable.CustomSeparator, 1);
        e.Graphics.DrawLine(pen, ItemHorizontalPadding, y, e.Item.Width - ItemHorizontalPadding, y);
    }

    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
        Color currentArrowColor = e.Item.Selected ? AccentColor : ArrowColor;
        using SolidBrush brush = new(currentArrowColor);

        Point middle = new(
            e.ArrowRectangle.Left + e.ArrowRectangle.Width / 2,
            e.ArrowRectangle.Top + e.ArrowRectangle.Height / 2
        );

        Point[] arrowPoints =
        [
            new(middle.X - 2, middle.Y - 4),
            new(middle.X + 2, middle.Y),
            new(middle.X - 2, middle.Y + 4)
        ];

        e.Graphics.FillPolygon(brush, arrowPoints);
    }
}