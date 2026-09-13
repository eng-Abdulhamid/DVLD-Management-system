using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using CustomizeControls;

namespace DVLD.PL.Global
{
    public static class UIUtility
    {
        private static readonly bool _isDesignMode = CheckIsDesignMode();

        public static bool IsDesignMode => _isDesignMode;

        private static bool CheckIsDesignMode()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;

            try
            {
                using var process = Process.GetCurrentProcess();
                string processName = process.ProcessName;

                return processName.Contains("devenv", StringComparison.OrdinalIgnoreCase) ||
                       processName.Contains("DesignToolsServer", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        // Resolves Windows file locking issues caused by standard Image.FromFile
        public static Image? LoadImageWithoutLock(string? filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return null;

            try
            {
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var sourceImage = Image.FromStream(stream);
                return new Bitmap(sourceImage);
            }
            catch
            {
                return null;
            }
        }

        public static Image? RecolorIcon(Image? source, Color color)
        {
            if (source == null || source.Width <= 0 || source.Height <= 0)
                return null;

            Bitmap bitmap = new Bitmap(source.Width, source.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;

                float a = color.A / 255f;
                float r = color.R / 255f;
                float gr = color.G / 255f;
                float b = color.B / 255f;

                ColorMatrix matrix = new ColorMatrix(new float[][]
                {
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, 0, 0 },
                    new float[] { 0, 0, 0, a, 0 },
                    new float[] { r, gr, b, 0, 1 }
                });

                using ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height), 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
            }
            return bitmap;
        }

        // Toggles password mask and swaps only the dedicated right eye icon without clearing other icons
        public static void TogglePasswordVisibility(NTextBox txt, Image eyeOnIcon, Image eyeOffIcon)
        {
            ArgumentNullException.ThrowIfNull(txt);

            txt.UseSystemPasswordChar = !txt.UseSystemPasswordChar;
            txt.RightIcon = txt.UseSystemPasswordChar ? eyeOnIcon : eyeOffIcon;
            txt.RightIconClickable = true;

            txt.RightIconClick -= PasswordEye_Click;
            txt.RightIconClick += PasswordEye_Click;

            void PasswordEye_Click(object? sender, EventArgs e)
            {
                if (sender is NTextBox target)
                {
                    TogglePasswordVisibility(target, eyeOnIcon, eyeOffIcon);
                }
            }
        }

        public static void SetupPasswordToggle(NTextBox txt, Image eyeOnIcon, Image eyeOffIcon)
        {
            ArgumentNullException.ThrowIfNull(txt);

            txt.UseSystemPasswordChar = true;
            txt.RightIcon = eyeOnIcon;
            txt.RightIconClickable = true;

            txt.RightIconClick += (s, e) =>
            {
                if (s is NTextBox target)
                {
                    TogglePasswordVisibility(target, eyeOnIcon, eyeOffIcon);
                }
            };
        }
    }
}