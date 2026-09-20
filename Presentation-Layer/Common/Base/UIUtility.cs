using System.ComponentModel;
using System.Diagnostics;
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
    }
}