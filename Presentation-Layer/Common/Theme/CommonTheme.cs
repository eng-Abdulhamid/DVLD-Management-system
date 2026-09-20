namespace DVLD.PL.Theme
{
    public static class CommonTheme
    {
        public static int DefaultBorderRadius { get; set; } = 0;

        public static bool EnableSystemAnimations { get; set; } = true;

        public static string SystemFontFamily { get; set; } = "Segoe UI";

        public static Font CreateFont(float size, FontStyle style = FontStyle.Regular)
        {
            return new Font(SystemFontFamily, size, style);
        }
    }
}