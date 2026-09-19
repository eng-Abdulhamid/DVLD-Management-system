using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class SecondaryButtonTheme
    {
        public static Color Background => ThemeManager.Current.Surface;

        public static Color HoverBackground => ThemeManager.Current.DisabledBackground;

        public static Color PressedBackground => ThemeManager.Current.Border;

        public static Color Border => ThemeManager.Current.Border;

        public static Color TextColor => ThemeManager.Current.TextSecondary;

        public static void ApplySecondaryStyle(this NButton btn)
        {
            ButtonTheme.ApplyColors(
                btn,
                Background,
                HoverBackground,
                PressedBackground,
                Border,
                TextColor,
                true);
        }
    }
}