namespace DVLD.PL.Theme
{
    public static class DefaultDark
    {
        public static ThemePalette Colors { get; } = new ThemePalette(
            primary: Color.FromArgb(139, 92, 246),
            primaryHover: Color.FromArgb(167, 139, 250),
            primaryPressed: Color.FromArgb(124, 58, 237),

            background: Color.FromArgb(15, 23, 42),
            surface: Color.FromArgb(30, 41, 59),

            border: Color.FromArgb(51, 65, 85),
            borderHover: Color.FromArgb(71, 85, 105),

            textPrimary: Color.FromArgb(248, 250, 252),
            textSecondary: Color.FromArgb(203, 213, 225),
            textMuted: Color.FromArgb(100, 116, 139),

            success: Color.FromArgb(52, 211, 153),
            danger: Color.FromArgb(248, 113, 113),
            dangerHover: Color.FromArgb(243, 85, 85),
            dangerPressed: Color.FromArgb(225, 52, 52),

            warning: Color.FromArgb(251, 191, 36),
            info: Color.FromArgb(56, 189, 248),

            disabledBackground: Color.FromArgb(30, 41, 59),
            disabledText: Color.FromArgb(71, 85, 105),

            selectionBg: Color.FromArgb(88, 28, 135),
            selectionText: Color.FromArgb(248, 250, 252));
    }
}