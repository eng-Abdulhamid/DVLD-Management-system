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

            var foreColor = GetForeColor(state);

            lbl.Text = text;
            lbl.ForeColor = foreColor;

            lbl.Font = CommonTheme.CreateFont(
                FontSize,
                FontStyle.Bold);

            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Padding = Padding;
        }
        public static void ApplyStatusBadge(
            this Label lbl,
            StatusLabelStyler state)
        {
            if (lbl == null)
                return;

            var foreColor = GetForeColor(state);

            lbl.ForeColor = foreColor;

            lbl.Font = CommonTheme.CreateFont(
                FontSize,
                FontStyle.Bold);

            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Padding = Padding;
        }
        private static Color GetForeColor(
            StatusLabelStyler state)
        {
            var colors = ThemeManager.Current;

            return state switch
            {
                StatusLabelStyler.Success => colors.Success,
                StatusLabelStyler.Danger => colors.Danger,
                StatusLabelStyler.Warning => colors.Warning,
                StatusLabelStyler.Info => colors.Info,
                _ => colors.TextMuted
            };
        }
    }
}