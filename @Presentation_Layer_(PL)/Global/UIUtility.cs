using ModernUI.Controls;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace DVLD.PL.Global
{
    public static class UIUtility
    {
        public static Image RecolorIcon(Image source, Color color)
        {
            Bitmap bitmap = new Bitmap(source.Width, source.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                ColorMatrix matrix = new ColorMatrix(new float[][]
                {
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 1, 0 },
                    new float[] { color.R / 255f, color.G / 255f, color.B / 255f, 0, 1 }
                });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(matrix);
                    g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height), 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return bitmap;
        }

        public static void TogglePasswordVisibility(NControls.NTextBox txt, Image eyeOnIcon, Image eyeOffIcon)
        {
            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;
            txt.ClearIcons();

            Image iconToSet = txt.UseSystemPasswordChar ? eyeOnIcon : eyeOffIcon;

            txt.AddIcon(
                iconToSet,
                NControls.IconPosition.Right,
                20, 20,
                true,
                (t) => TogglePasswordVisibility(t, eyeOnIcon, eyeOffIcon));
        }
        private static readonly bool _isDesignMode = CheckIsDesignMode();

        public static bool IsDesignMode => _isDesignMode;

        private static bool CheckIsDesignMode()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;

            string processName = Process.GetCurrentProcess().ProcessName;

            return processName.Contains("devenv", StringComparison.OrdinalIgnoreCase) ||
                   processName.Contains("DesignToolsServer", StringComparison.OrdinalIgnoreCase);
        }
    }
}