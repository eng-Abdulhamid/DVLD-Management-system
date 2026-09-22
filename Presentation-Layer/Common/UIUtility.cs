using CustomizeControls;
using DVLD.PL.Properties;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
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
        public static void SetupPasswordVisibility(NTextBox txtBox)
        {
            txtBox.UseSystemPasswordChar = true;
            txtBox.RightIcon = Resources.visibilityOff;
            txtBox.RightIconClickable = true;

            txtBox.RightIconClick += (s, e) =>
            {
                txtBox.UseSystemPasswordChar = !txtBox.UseSystemPasswordChar;
                txtBox.RightIcon = txtBox.UseSystemPasswordChar
                    ? Resources.visibilityOff
                    : Resources.visibilityOn;
            };
        }


        public static string GenerateRandomPassword()
    {
        const int defaultLength = 20;

        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        const string numbers = "0123456789";
        const string special = "!@#$%^&*()-_=+";

        string allCharacters = uppercase + lowercase + numbers + special;

        char[] password = new char[defaultLength];

        // Guarantee all required criteria
        password[0] = uppercase[RandomNumberGenerator.GetInt32(uppercase.Length)];
        password[1] = lowercase[RandomNumberGenerator.GetInt32(lowercase.Length)];
        password[2] = numbers[RandomNumberGenerator.GetInt32(numbers.Length)];
        password[3] = special[RandomNumberGenerator.GetInt32(special.Length)];

        // Fill the remaining characters
        for (int i = 4; i < password.Length; i++)
        {
            password[i] = allCharacters[
                RandomNumberGenerator.GetInt32(allCharacters.Length)
            ];
        }

        // Cryptographically secure Fisher-Yates shuffle
        for (int i = password.Length - 1; i > 0; i--)
        {
            int j = RandomNumberGenerator.GetInt32(i + 1);

            (password[i], password[j]) = (password[j], password[i]);
        }

        return new string(password);
    }
}
}