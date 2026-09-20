using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class ButtonTheme
    {
        public static void ApplyColors(
            NButton btn,
            Color background,
            Color hoverBackground,
            Color pressedBackground,
            Color border,
            Color text,
            bool drawBorder)
        {
            if (btn == null)
                return;

            btn.BackgroundStartColor = background;
            btn.BackgroundEndColor = background;

            btn.HoverStartColor = hoverBackground;
            btn.HoverEndColor = hoverBackground;

            btn.PressedStartColor = pressedBackground;
            btn.PressedEndColor = pressedBackground;

            btn.BorderColor = border;
            btn.HoverBorderColor = border;
            btn.BorderSize = drawBorder ? 1 : 0;

            btn.TextColor = text;
            btn.HoverTextColor = text;

            btn.BorderRadius = CommonTheme.DefaultBorderRadius;
            btn.Cursor = Cursors.Hand;

            btn.EnableHoverAnimation = CommonTheme.EnableSystemAnimations;
            btn.EnableRippleEffect = CommonTheme.EnableSystemAnimations;

            btn.EnableIconTinting = true;
            btn.IconColor = text;
            btn.HoverIconColor = text;

            btn.Invalidate();
        }
    }
}