namespace DVLD.PL.Theme
{
    public static class ToolStripTheme
    {
        public static void ApplyToolStripStyle(
            this ToolStrip ts,
            bool borderless = false)
        {
            if (ts == null)
                return;

            ThemePalette colors = ThemeManager.Current;

            ts.BackColor = colors.Surface;
            ts.ForeColor = colors.TextPrimary;
            ts.Font = CommonTheme.CreateFont(9F);
            ts.Padding = new Padding(4);

            if (borderless)
                ts.RenderMode = ToolStripRenderMode.System;

            ApplyItemsStyle(ts.Items, colors);
        }

        public static void ApplyContextMenuStyle(
            this ContextMenuStrip cms)
        {
            if (cms == null)
                return;

            ApplyToolStripStyle(
                cms,
                borderless: false);
        }

        private static void ApplyItemsStyle(
            ToolStripItemCollection items,
            ThemePalette colors)
        {
            foreach (ToolStripItem item in items)
            {
                item.ForeColor = colors.TextPrimary;
                item.BackColor = colors.Surface;
                item.Font = CommonTheme.CreateFont(9F);

                if (item is ToolStripMenuItem menuItem)
                {
                    ApplyItemsStyle(
                        menuItem.DropDownItems,
                        colors);
                }
            }
        }
    }
}