using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class PrimaryButtonTheme
    {
        public static Color Background => ThemeManager.Current.Primary;

        public static Color HoverBackground => ThemeManager.Current.PrimaryHover;

        public static Color PressedBackground => ThemeManager.Current.PrimaryPressed;

        public static Color TextColor => Color.White;

        public static void ApplyPrimaryStyle(this NButton btn)
        {
            ButtonTheme.ApplyColors(
                btn,
                Background,
                HoverBackground,
                PressedBackground,
                Background,
                TextColor,
                false);
        }
    }
}