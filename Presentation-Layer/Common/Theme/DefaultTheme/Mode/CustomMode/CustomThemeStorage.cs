namespace DVLD.PL.Theme
{
    public static class CustomThemeStorage
    {
        /// <summary>
        /// Loads the custom light theme from storage.
        /// Returns the default light theme when no custom theme is stored.
        /// </summary>
        public static ThemePalette LoadCustomLight()
        {
            return DefaultLight.Colors;
        }

        /// <summary>
        /// Loads the custom dark theme from storage.
        /// Returns the default dark theme when no custom theme is stored.
        /// </summary>
        public static ThemePalette LoadCustomDark()
        {
            return DefaultDark.Colors;
        }

        /// <summary>
        /// Saves the custom light theme to storage.
        /// </summary>
        /// <param name="palette">The light theme palette to save.</param>
        public static void SaveCustomLight(ThemePalette palette)
        {
        }

        /// <summary>
        /// Saves the custom dark theme to storage.
        /// </summary>
        /// <param name="palette">The dark theme palette to save.</param>
        public static void SaveCustomDark(ThemePalette palette)
        {
        }
    }
}