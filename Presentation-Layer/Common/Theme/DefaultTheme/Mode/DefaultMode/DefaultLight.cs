namespace DVLD.PL.Theme
{
    public static class DefaultLight
    {
        public static ThemePalette Colors { get; } = new ThemePalette(
            primary: Color.FromArgb(124, 58, 237),
            primaryHover: Color.FromArgb(135, 72, 240),
            primaryPressed: Color.FromArgb(112, 48, 222),

            background: Color.FromArgb(248, 250, 252),
            surface: Color.White,

            border: Color.FromArgb(226, 232, 240),
            borderHover: Color.FromArgb(203, 213, 225),

            textPrimary: Color.FromArgb(15, 23, 42),
            textSecondary: Color.FromArgb(71, 85, 105),
            textMuted: Color.FromArgb(148, 163, 184),

            success: Color.FromArgb(16, 185, 129),
            danger: Color.FromArgb(239, 68, 68),
            dangerHover: Color.FromArgb(243, 85, 85),
            dangerPressed: Color.FromArgb(225, 52, 52),

            warning: Color.FromArgb(245, 158, 11),
            info: Color.FromArgb(14, 165, 233),

            disabledBackground: Color.FromArgb(241, 245, 249),
            disabledText: Color.FromArgb(148, 163, 184),

            selectionBg: Color.FromArgb(243, 232, 255),
            selectionText: Color.FromArgb(112, 48, 222));
    }
}