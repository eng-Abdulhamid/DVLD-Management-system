namespace DVLD.PL.Theme
{
    public static class LabelTheme
    {
        public static void ApplyLabelStyle(this Label lbl)
        {
            if (lbl == null)
                return;

            lbl.BackColor = Color.Transparent;

            if (IsDangerColor(lbl.ForeColor))
            {
                lbl.ForeColor = ThemeManager.Current.Danger;
            }
            else
            {
                lbl.ForeColor = ThemeManager.Current.TextPrimary;
            }
        }

        private static bool IsDangerColor(Color color)
        {
            return color == Color.Red ||
                   color == Color.DarkRed ||
                   color == Color.Crimson ||
                   (color.R > 180 && color.G < 80 && color.B < 80);
        }
    }
}