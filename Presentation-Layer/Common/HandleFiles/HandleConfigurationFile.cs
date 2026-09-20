using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DVLD.PL.Configuration
{
    public static class HandleConfigurationFile
    {
        private const string AppSettingsSection = "appSettings";
        private static readonly object _configLock = new();

        private static System.Configuration.Configuration OpenConfiguration() =>
            ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        #region Standard String Operations (Backward Compatible)

        public static bool AppSettingExists(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;
            return ConfigurationManager.AppSettings[key] != null;
        }

        public static string GetValueByKey(string key, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(key)) return defaultValue;

            try
            {
                return ConfigurationManager.AppSettings[key] ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool SetKeyAndValue(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            lock (_configLock)
            {
                try
                {
                    var config = OpenConfiguration();
                    var settings = config.AppSettings.Settings;

                    if (settings[key] != null)
                    {
                        settings[key].Value = value;
                    }
                    else
                    {
                        settings.Add(key, value);
                    }

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(AppSettingsSection);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool DeleteKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            lock (_configLock)
            {
                try
                {
                    var config = OpenConfiguration();
                    if (config.AppSettings.Settings[key] == null) return false;

                    config.AppSettings.Settings.Remove(key);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(AppSettingsSection);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion

        #region Strongly-Typed Generic Operations

        // Reads values automatically converted to target type (int, bool, double, etc.)
        public static T GetValue<T>(string key, T defaultValue)
        {
            string rawValue = GetValueByKey(key, string.Empty);
            if (string.IsNullOrWhiteSpace(rawValue)) return defaultValue;

            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter.CanConvertFrom(typeof(string)))
                {
                    object? converted = converter.ConvertFromString(rawValue);
                    return converted is T value ? value : defaultValue;
                }

                return (T)Convert.ChangeType(rawValue, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool SetValue<T>(string key, T value)
        {
            string strValue = value?.ToString() ?? string.Empty;
            return SetKeyAndValue(key, strValue);
        }

        // Dedicated helper for enums (such as enMode for Light/Dark theme)
        public static TEnum GetEnum<TEnum>(string key, TEnum defaultValue) where TEnum : struct, Enum
        {
            string rawValue = GetValueByKey(key, string.Empty);
            if (string.IsNullOrWhiteSpace(rawValue)) return defaultValue;

            return Enum.TryParse(rawValue, true, out TEnum result) ? result : defaultValue;
        }

        // Saves multiple configuration pairs in a single disk I/O operation
        public static bool SetMultiple(IEnumerable<KeyValuePair<string, string>> settingsPairs)
        {
            ArgumentNullException.ThrowIfNull(settingsPairs);

            lock (_configLock)
            {
                try
                {
                    var config = OpenConfiguration();
                    var settings = config.AppSettings.Settings;

                    foreach (var pair in settingsPairs)
                    {
                        if (string.IsNullOrWhiteSpace(pair.Key)) continue;

                        if (settings[pair.Key] != null)
                        {
                            settings[pair.Key].Value = pair.Value;
                        }
                        else
                        {
                            settings.Add(pair.Key, pair.Value);
                        }
                    }

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(AppSettingsSection);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion

        #region Secure DPAPI Storage (For Remember-Me Passwords/Tokens)

        // Encrypts sensitive string using Windows current-user DPAPI
        public static bool SetSecureValue(string key, string sensitiveValue)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            try
            {
                if (string.IsNullOrEmpty(sensitiveValue))
                {
                    return DeleteKey(key);
                }

                byte[] plainBytes = Encoding.UTF8.GetBytes(sensitiveValue);
                byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
                string base64Encrypted = Convert.ToBase64String(encryptedBytes);

                return SetKeyAndValue(key, base64Encrypted);
            }
            catch
            {
                return false;
            }
        }

        // Decrypts sensitive string stored via DPAPI
        public static string GetSecureValue(string key, string defaultValue = "")
        {
            string encryptedBase64 = GetValueByKey(key, string.Empty);
            if (string.IsNullOrWhiteSpace(encryptedBase64)) return defaultValue;

            try
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedBase64);
                byte[] plainBytes = ProtectedData.Unprotect(encryptedBytes, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plainBytes);
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion
    }
}