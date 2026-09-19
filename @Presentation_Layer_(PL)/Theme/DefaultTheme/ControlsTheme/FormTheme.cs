namespace DVLD.PL.Theme
{
    public static class FormTheme
    {
        public static void ApplyStandardFormTheme(this Form frm)
        {
            if (frm == null)
                return;

            frm.BackColor = ThemeManager.Current.Background;
            frm.ForeColor = ThemeManager.Current.TextPrimary;
        }
    }
}