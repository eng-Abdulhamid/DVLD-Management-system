namespace DVLD.PL.Theme
{
    public static class ComboBoxTheme
    {
        public static float FontSize { get; set; } = 9.5F;

        public static void ApplyComboBoxStyle(this ComboBox cb)
        {
            if (cb == null)
                return;

            cb.FlatStyle = FlatStyle.Flat;
            cb.Font = CommonTheme.CreateFont(FontSize);
            cb.ForeColor = ThemeManager.Current.TextPrimary;
            cb.BackColor = ThemeManager.Current.Surface;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}