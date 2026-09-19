using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class TextBoxTheme
    {
        public static float FontSize { get; set; } = 10F;

        public static void ApplyTextBoxStyle(this NTextBox txt)
        {
            if (txt == null)
                return;

            var colors = ThemeManager.Current;

            txt.BorderRadius = CommonTheme.DefaultBorderRadius;
            txt.BorderSize = 1;

            txt.BorderColor = colors.Border;
            txt.BorderFocusColor = colors.Primary;

            txt.FillColor = colors.Surface;

            txt.Font = CommonTheme.CreateFont(FontSize);
            txt.ForeColor = colors.TextPrimary;
            txt.PlaceholderColor = colors.TextMuted;

            txt.ErrorBorderColor = colors.Danger;

            txt.ShowClearButton = true;

            txt.EnableIconTinting = true;
            txt.IconColor = colors.TextMuted;
            txt.HoverIconColor = colors.TextPrimary;
        }
    }
}