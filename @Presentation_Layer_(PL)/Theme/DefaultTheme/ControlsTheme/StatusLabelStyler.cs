namespace DVLD.PL.Theme
{
    public enum StatusLabelStyler
    {
        Success,
        Danger,
        Warning,
        Info,
        Neutral
    }

    public static class StatusBadgeTheme
    {
        public static float FontSize { get; set; } = 8.5F;

        public static int BackgroundAlpha { get; set; } = 25;

        public static Padding Padding { get; set; } =
            new Padding(8, 3, 8, 3);

        public static void ApplyStatusBadge(
            this Label lbl,
            StatusLabelStyler state,
            string text)
        {
            if (lbl == null)
                return;

            var (accent, background) = GetColors(state);

            lbl.Text = text;
            lbl.BackColor = background;
            lbl.ForeColor = accent;

            lbl.Font = CommonTheme.CreateFont(
                FontSize,
                FontStyle.Bold);

            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Padding = Padding;
        }

        private static (Color Accent, Color Background) GetColors(
            StatusLabelStyler state)
        {
            var colors = ThemeManager.Current;

            Color accent = state switch
            {
                StatusLabelStyler.Success => colors.Success,
                StatusLabelStyler.Danger => colors.Danger,
                StatusLabelStyler.Warning => colors.Warning,
                StatusLabelStyler.Info => colors.Info,
                _ => colors.TextMuted
            };

            Color background = Color.FromArgb(
                BackgroundAlpha,
                accent);

            return (accent, background);
        }
    }
}