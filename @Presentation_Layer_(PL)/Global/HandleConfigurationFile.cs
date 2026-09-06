using System;
using System.Configuration;

namespace DVLD.PL.Configuration
{
    public static class HandleConfigurationFile
    {
        private const string AppSettingsSection = "appSettings";

        private static System.Configuration.Configuration OpenConfiguration()
        {
            return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        #region AppSettings Read Operations

        public static bool AppSettingExists(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            return ConfigurationManager.AppSettings[key] != null;
        }

        public static string GetValueByKey(string key, string defaultValue = "")
        {
            if (string.IsNullOrWhiteSpace(key))
                return defaultValue;

            try
            {
                string value = ConfigurationManager.AppSettings[key];
                return value ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        #endregion

        #region AppSettings Write Operations

        public static bool SetKeyAndValue(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            try
            {
                System.Configuration.Configuration config = OpenConfiguration();
                KeyValueConfigurationElement setting = config.AppSettings.Settings[key];

                if (setting != null)
                {
                    setting.Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add(key, value);
                }

                config.Save(System.Configuration.ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(AppSettingsSection);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveKeySetting(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            try
            {
                System.Configuration.Configuration config = OpenConfiguration();

                if (config.AppSettings.Settings[key] == null)
                    return false;

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

        #endregion
    }
}