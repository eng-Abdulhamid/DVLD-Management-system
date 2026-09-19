using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class DangerButtonTheme
    {
        public static Color Background => ThemeManager.Current.Danger;

        public static Color HoverBackground => ThemeManager.Current.DangerHover;

        public static Color PressedBackground => ThemeManager.Current.DangerPressed;

        public static Color TextColor => Color.White;

        public static void ApplyDangerStyle(this NButton btn)
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