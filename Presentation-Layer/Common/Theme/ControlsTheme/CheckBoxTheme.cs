using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class CheckBoxTheme
    {
        public static void ApplyCheckBoxStyle(this NCheckBox chk)
        {
            if (chk == null)
                return;

            var colors = ThemeManager.Current;

            chk.CheckedColor = colors.Primary;
            chk.HoverBorderColor = colors.Primary;

            chk.BoxBorderColor = colors.Border;
            chk.BoxBackColor = colors.Surface;

            chk.CheckMarkColor = Color.White;

            chk.ForeColor = colors.TextPrimary;
            chk.Cursor = Cursors.Hand;

            chk.EnableAnimation = CommonTheme.EnableSystemAnimations;
        }
    }
}