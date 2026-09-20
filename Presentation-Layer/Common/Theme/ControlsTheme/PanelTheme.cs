namespace DVLD.PL.Theme
{
    public static class PannelTheme
    {
        public static int PaddingSize { get; set; } = 0;

        public static void ApplyPanelStyle(this Panel pnl)
        {
            if (pnl == null)
                return;

            pnl.BackColor = ThemeManager.Current.Surface;
            pnl.Padding = new Padding(PaddingSize);
        }
    }
}