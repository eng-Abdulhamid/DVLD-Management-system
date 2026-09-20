using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class DisabledButtonTheme
    {
        public static Color Background => ThemeManager.Current.DisabledBackground;

        public static Color TextColor => ThemeManager.Current.DisabledText;

        public static void ApplyDisabledStyle(this NButton btn)
        {
            if (btn == null)
                return;

            ButtonTheme.ApplyColors(
                btn,
                Background,
                Background,
                Background,
                Color.Transparent,
                TextColor,
                false);

            DisableInteraction(btn);
        }

        private static void DisableInteraction(NButton btn)
        {
            btn.EnableHoverAnimation = false;
            btn.EnableRippleEffect = false;
            btn.Cursor = Cursors.Default;
        }
    }
}