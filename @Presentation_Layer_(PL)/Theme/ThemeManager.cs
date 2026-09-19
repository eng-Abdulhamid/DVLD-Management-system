namespace DVLD.PL.Theme
{
    public static class ThemeManager
    {
        public static enMode Mode { get; private set; } = enMode.DefaultLight;

        public static ThemePalette Current => Mode switch
        {
            enMode.DefaultDark => DefaultDark.Colors,
            enMode.CustomLight => CustomLight.Colors,
            enMode.CustomDark => CustomDark.Colors,
            _ => DefaultDark.Colors
        };
        /// <summary>
        /// Raised after the current theme mode changes.
        /// Subscribers should apply the provided theme palette to their controls.
        /// </summary>
        public static event EventHandler<ModeEventsArgs>? ThemeChanged;

        public class ModeEventsArgs : EventArgs
        {
            public ThemePalette CurrentThemePalette { get; }
            public enMode Mode { get; }

            public ModeEventsArgs(
                ThemePalette currentThemePalette,
                enMode mode)
            {
                CurrentThemePalette = currentThemePalette;
                Mode = mode;
            }
        }

        /// <summary>
        /// Changes the current theme mode and raises ThemeChanged when the mode changes.
        /// Controls should get the updated theme from ThemeManager.Current
        /// and apply it to themselves through frmBase.
        /// </summary>
        public static void SetMode(enMode mode)
        {
            if (Mode == mode)
                return;

            Mode = mode;

            ThemeChanged?.Invoke(
                null,
                new ModeEventsArgs(Current, Mode));
        }
    }
}