using System;
using System.Drawing;

namespace DVLD.PL.Theme;

internal static class ColorMathHelper
{
    public static Color Lighten(Color color, float factor)
    {
        factor = Math.Clamp(factor, 0f, 1f);
        int r = (int)(color.R + (255 - color.R) * factor);
        int g = (int)(color.G + (255 - color.G) * factor);
        int b = (int)(color.B + (255 - color.B) * factor);
        return Color.FromArgb(color.A, Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255));
    }

    public static Color Darken(Color color, float factor)
    {
        factor = Math.Clamp(factor, 0f, 1f);
        int r = (int)(color.R * (1f - factor));
        int g = (int)(color.G * (1f - factor));
        int b = (int)(color.B * (1f - factor));
        return Color.FromArgb(color.A, Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255));
    }

    public static Color WithAlpha(Color color, int alpha) =>
        Color.FromArgb(Math.Clamp(alpha, 0, 255), color.R, color.G, color.B);
}