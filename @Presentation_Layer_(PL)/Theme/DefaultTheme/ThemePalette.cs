namespace DVLD.PL.Theme
{
    public sealed class ThemePalette
    {
        public Color Primary { get; }
        public Color PrimaryHover { get; }
        public Color PrimaryPressed { get; }

        public Color Background { get; }
        public Color Surface { get; }

        public Color Border { get; }
        public Color BorderHover { get; }

        public Color TextPrimary { get; }
        public Color TextSecondary { get; }
        public Color TextMuted { get; }

        public Color Success { get; }
        public Color Danger { get; }
        public Color DangerHover { get; }
        public Color DangerPressed { get; }

        public Color Warning { get; }
        public Color Info { get; }

        public Color DisabledBackground { get; }
        public Color DisabledText { get; }

        public Color SelectionBg { get; }
        public Color SelectionText { get; }

        public ThemePalette(
            Color primary,
            Color primaryHover,
            Color primaryPressed,
            Color background,
            Color surface,
            Color border,
            Color borderHover,
            Color textPrimary,
            Color textSecondary,
            Color textMuted,
            Color success,
            Color danger,
            Color dangerHover,
            Color dangerPressed,
            Color warning,
            Color info,
            Color disabledBackground,
            Color disabledText,
            Color selectionBg,
            Color selectionText)
        {
            Primary = primary;
            PrimaryHover = primaryHover;
            PrimaryPressed = primaryPressed;

            Background = background;
            Surface = surface;

            Border = border;
            BorderHover = borderHover;

            TextPrimary = textPrimary;
            TextSecondary = textSecondary;
            TextMuted = textMuted;

            Success = success;
            Danger = danger;
            DangerHover = dangerHover;
            DangerPressed = dangerPressed;

            Warning = warning;
            Info = info;

            DisabledBackground = disabledBackground;
            DisabledText = disabledText;

            SelectionBg = selectionBg;
            SelectionText = selectionText;
        }
    }
}