using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace DVLD.PL.AppConfigration
{
    /// <summary>
    /// Provides fast, reusable and thread-safe access to application
    /// configuration values stored in the executable .config file.
    ///
    /// Features:
    /// - Cached reads
    /// - Generic typed values
    /// - Enum support
    /// - JSON object support
    /// - Batch writes
    /// - Async writes
    /// - DPAPI protected values
    /// - Thread-safe write operations
    /// </summary>
    public static class HandleConfigurationFile
    {
        #region Constants

        private const string AppSettingsSection = "appSettings";

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<string, string?> _cache =
            new(StringComparer.OrdinalIgnoreCase);

        private static readonly SemaphoreSlim _writeSemaphore = new(1, 1);

        private static readonly object _cacheInitializationLock = new();

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = false
        };

        private static bool _cacheInitialized;

        #endregion

        #region Configuration Access

        private static Configuration OpenConfiguration()
        {
            return ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
        }

        #endregion

        #region Cache

        private static void EnsureCacheInitialized()
        {
            if (Volatile.Read(ref _cacheInitialized))
                return;

            lock (_cacheInitializationLock)
            {
                if (_cacheInitialized)
                    return;

                foreach (string? key in ConfigurationManager.AppSettings.AllKeys)
                {
                    if (string.IsNullOrWhiteSpace(key))
                        continue;

                    _cache[key] = ConfigurationManager.AppSettings[key];
                }

                Volatile.Write(ref _cacheInitialized, true);
            }
        }

        /// <summary>
        /// Reloads all application settings from the actual configuration file.
        /// Useful when the configuration may have been modified externally.
        /// </summary>
        public static void Reload()
        {
            _writeSemaphore.Wait();

            try
            {
                ConfigurationManager.RefreshSection(AppSettingsSection);

                lock (_cacheInitializationLock)
                {
                    _cache.Clear();

                    foreach (string? key in ConfigurationManager.AppSettings.AllKeys)
                    {
                        if (string.IsNullOrWhiteSpace(key))
                            continue;

                        _cache[key] = ConfigurationManager.AppSettings[key];
                    }

                    Volatile.Write(ref _cacheInitialized, true);
                }
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        #endregion

        #region Standard String Operations

        public static bool AppSettingExists(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            EnsureCacheInitialized();

            return _cache.ContainsKey(key);
        }

        public static bool TryGetValue(
            string key,
            out string? value)
        {
            value = null;

            if (string.IsNullOrWhiteSpace(key))
                return false;

            EnsureCacheInitialized();

            return _cache.TryGetValue(key, out value);
        }

        public static string GetValueByKey(
            string key,
            string defaultValue = "")
        {
            return TryGetValue(key, out string? value)
                ? value ?? defaultValue
                : defaultValue;
        }

        public static IReadOnlyDictionary<string, string?> GetAll()
        {
            EnsureCacheInitialized();

            return new Dictionary<string, string?>(
                _cache,
                StringComparer.OrdinalIgnoreCase);
        }

        #endregion

        #region Standard Write Operations

        public static bool SetKeyAndValue(
            string key,
            string? value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            var pair = new KeyValuePair<string, string?>(
                key,
                value ?? string.Empty);

            return SetMultiple(new[] { pair });
        }

        public static async Task<bool> SetKeyAndValueAsync(
            string key,
            string? value,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            var pair = new KeyValuePair<string, string?>(
                key,
                value ?? string.Empty);

            return await SetMultipleAsync(
                new[] { pair },
                cancellationToken);
        }

        public static bool DeleteKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            _writeSemaphore.Wait();

            try
            {
                return DeleteKeyCore(key);
            }
            catch (Exception ex)
            {
                LogException(nameof(DeleteKey), ex);
                return false;
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        public static async Task<bool> DeleteKeyAsync(
            string key,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            await _writeSemaphore.WaitAsync(cancellationToken)
                                 .ConfigureAwait(false);

            try
            {
                return await Task.Run(
                    () => DeleteKeyCore(key),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                LogException(nameof(DeleteKeyAsync), ex);
                return false;
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        private static bool DeleteKeyCore(string key)
        {
            Configuration config = OpenConfiguration();

            if (config.AppSettings.Settings[key] is null)
                return false;

            config.AppSettings.Settings.Remove(key);

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(AppSettingsSection);

            _cache.TryRemove(key, out _);

            return true;
        }

        #endregion

        #region Batch Operations

        public static bool SetMultiple(
            IEnumerable<KeyValuePair<string, string?>> settingsPairs)
        {
            ArgumentNullException.ThrowIfNull(settingsPairs);

            var pairs = settingsPairs
                .Where(x => !string.IsNullOrWhiteSpace(x.Key))
                .ToList();

            if (pairs.Count == 0)
                return false;

            _writeSemaphore.Wait();

            try
            {
                return SetMultipleCore(pairs);
            }
            catch (Exception ex)
            {
                LogException(nameof(SetMultiple), ex);
                return false;
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        public static async Task<bool> SetMultipleAsync(
            IEnumerable<KeyValuePair<string, string?>> settingsPairs,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(settingsPairs);

            var pairs = settingsPairs
                .Where(x => !string.IsNullOrWhiteSpace(x.Key))
                .ToList();

            if (pairs.Count == 0)
                return false;

            await _writeSemaphore.WaitAsync(cancellationToken)
                                 .ConfigureAwait(false);

            try
            {
                return await Task.Run(
                    () => SetMultipleCore(pairs),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                LogException(nameof(SetMultipleAsync), ex);
                return false;
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        private static bool SetMultipleCore(
            IReadOnlyCollection<KeyValuePair<string, string?>> pairs)
        {
            Configuration config = OpenConfiguration();

            var settings = config.AppSettings.Settings;

            foreach (KeyValuePair<string, string?> pair in pairs)
            {
                string value = pair.Value ?? string.Empty;

                if (settings[pair.Key] is null)
                {
                    settings.Add(pair.Key, value);
                }
                else
                {
                    settings[pair.Key].Value = value;
                }
            }

            /*
             * One Save only.
             *
             * This is much faster than calling SetKeyAndValue()
             * multiple times.
             */
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection(AppSettingsSection);

            foreach (KeyValuePair<string, string?> pair in pairs)
            {
                _cache[pair.Key] = pair.Value ?? string.Empty;
            }

            return true;
        }

        #endregion

        #region Strongly Typed Operations

        public static T GetValue<T>(
            string key,
            T defaultValue)
        {
            string rawValue = GetValueByKey(key, string.Empty);

            if (string.IsNullOrWhiteSpace(rawValue))
                return defaultValue;

            try
            {
                Type targetType =
                    Nullable.GetUnderlyingType(typeof(T))
                    ?? typeof(T);

                if (targetType == typeof(string))
                {
                    return (T)(object)rawValue;
                }

                if (targetType.IsEnum)
                {
                    return Enum.TryParse(
                        targetType,
                        rawValue,
                        true,
                        out object? enumValue)
                        ? (T)enumValue
                        : defaultValue;
                }

                TypeConverter converter =
                    TypeDescriptor.GetConverter(targetType);

                if (converter.CanConvertFrom(typeof(string)))
                {
                    object? converted =
                        converter.ConvertFromInvariantString(rawValue);

                    if (converted is not null)
                        return (T)converted;
                }

                object changedValue =
                    Convert.ChangeType(
                        rawValue,
                        targetType,
                        CultureInfo.InvariantCulture);

                return (T)changedValue;
            }
            catch (Exception ex)
            {
                LogException(
                    $"GetValue<{typeof(T).Name}>",
                    ex);

                return defaultValue;
            }
        }

        public static bool SetValue<T>(
            string key,
            T value)
        {
            string serializedValue = ConvertToString(value);

            return SetKeyAndValue(
                key,
                serializedValue);
        }

        public static Task<bool> SetValueAsync<T>(
            string key,
            T value,
            CancellationToken cancellationToken = default)
        {
            string serializedValue = ConvertToString(value);

            return SetKeyAndValueAsync(
                key,
                serializedValue,
                cancellationToken);
        }

        private static string ConvertToString<T>(T value)
        {
            if (value is null)
                return string.Empty;

            if (value is IFormattable formattable)
            {
                return formattable.ToString(
                    null,
                    CultureInfo.InvariantCulture)
                    ?? string.Empty;
            }

            return value.ToString() ?? string.Empty;
        }

        #endregion

        #region Enum Operations

        public static TEnum GetEnum<TEnum>(
            string key,
            TEnum defaultValue)
            where TEnum : struct, Enum
        {
            string rawValue =
                GetValueByKey(key, string.Empty);

            if (string.IsNullOrWhiteSpace(rawValue))
                return defaultValue;

            return Enum.TryParse(
                rawValue,
                ignoreCase: true,
                out TEnum result)
                ? result
                : defaultValue;
        }

        public static bool SetEnum<TEnum>(
            string key,
            TEnum value)
            where TEnum : struct, Enum
        {
            return SetKeyAndValue(
                key,
                value.ToString());
        }

        public static Task<bool> SetEnumAsync<TEnum>(
            string key,
            TEnum value,
            CancellationToken cancellationToken = default)
            where TEnum : struct, Enum
        {
            return SetKeyAndValueAsync(
                key,
                value.ToString(),
                cancellationToken);
        }

        #endregion

        #region JSON Object Operations

        /// <summary>
        /// Stores any serializable object as JSON.
        /// </summary>
        public static bool SetObject<T>(
            string key,
            T value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            try
            {
                string json =
                    JsonSerializer.Serialize(
                        value,
                        _jsonOptions);

                return SetKeyAndValue(
                    key,
                    json);
            }
            catch (Exception ex)
            {
                LogException(nameof(SetObject), ex);
                return false;
            }
        }

        public static async Task<bool> SetObjectAsync<T>(
            string key,
            T value,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            try
            {
                string json =
                    JsonSerializer.Serialize(
                        value,
                        _jsonOptions);

                return await SetKeyAndValueAsync(
                    key,
                    json,
                    cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                LogException(nameof(SetObjectAsync), ex);
                return false;
            }
        }

        public static T? GetObject<T>(
            string key,
            T? defaultValue = default)
        {
            string json =
                GetValueByKey(key, string.Empty);

            if (string.IsNullOrWhiteSpace(json))
                return defaultValue;

            try
            {
                return JsonSerializer.Deserialize<T>(
                    json,
                    _jsonOptions);
            }
            catch (Exception ex)
            {
                LogException(nameof(GetObject), ex);
                return defaultValue;
            }
        }

        #endregion

        #region Secure DPAPI Storage

        /// <summary>
        /// Stores a sensitive string encrypted using Windows DPAPI
        /// with the current Windows user scope.
        /// </summary>
        public static bool SetSecureValue(
            string key,
            string? sensitiveValue)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            if (string.IsNullOrEmpty(sensitiveValue))
                return DeleteKey(key);

            byte[]? plainBytes = null;
            byte[]? encryptedBytes = null;

            try
            {
                plainBytes =
                    Encoding.UTF8.GetBytes(sensitiveValue);

                encryptedBytes =
                    ProtectedData.Protect(
                        plainBytes,
                        optionalEntropy: null,
                        scope: DataProtectionScope.CurrentUser);

                string encryptedBase64 =
                    Convert.ToBase64String(
                        encryptedBytes);

                return SetKeyAndValue(
                    key,
                    encryptedBase64);
            }
            catch (Exception ex)
            {
                LogException(
                    nameof(SetSecureValue),
                    ex);

                return false;
            }
            finally
            {
                if (plainBytes is not null)
                {
                    CryptographicOperations.ZeroMemory(
                        plainBytes);
                }

                if (encryptedBytes is not null)
                {
                    CryptographicOperations.ZeroMemory(
                        encryptedBytes);
                }
            }
        }

        public static async Task<bool> SetSecureValueAsync(
            string key,
            string? sensitiveValue,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(key))
                return false;

            if (string.IsNullOrEmpty(sensitiveValue))
            {
                return await DeleteKeyAsync(
                    key,
                    cancellationToken);
            }

            byte[]? plainBytes = null;
            byte[]? encryptedBytes = null;

            try
            {
                plainBytes =
                    Encoding.UTF8.GetBytes(sensitiveValue);

                encryptedBytes =
                    ProtectedData.Protect(
                        plainBytes,
                        optionalEntropy: null,
                        scope: DataProtectionScope.CurrentUser);

                string encryptedBase64 =
                    Convert.ToBase64String(
                        encryptedBytes);

                return await SetKeyAndValueAsync(
                    key,
                    encryptedBase64,
                    cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                LogException(
                    nameof(SetSecureValueAsync),
                    ex);

                return false;
            }
            finally
            {
                if (plainBytes is not null)
                {
                    CryptographicOperations.ZeroMemory(
                        plainBytes);
                }

                if (encryptedBytes is not null)
                {
                    CryptographicOperations.ZeroMemory(
                        encryptedBytes);
                }
            }
        }

        public static bool TryGetSecureValue(
            string key,
            out string? value)
        {
            value = null;

            string encryptedBase64 =
                GetValueByKey(
                    key,
                    string.Empty);

            if (string.IsNullOrWhiteSpace(encryptedBase64))
                return false;

            byte[]? encryptedBytes = null;
            byte[]? plainBytes = null;

            try
            {
                encryptedBytes =
                    Convert.FromBase64String(
                        encryptedBase64);

                plainBytes =
                    ProtectedData.Unprotect(
                        encryptedBytes,
                        optionalEntropy: null,
                        scope: DataProtectionScope.CurrentUser);

                value =
                    Encoding.UTF8.GetString(
                        plainBytes);

                return true;
            }
            catch (Exception ex)
            {
                LogException(
                    nameof(TryGetSecureValue),
                    ex);

                value = null;
                return false;
            }
            finally
            {
                if (encryptedBytes is not null)
                {
                    CryptographicOperations.ZeroMemory(
                        encryptedBytes);
                }

                if (plainBytes is not null)
                {
                    CryptographicOperations.ZeroMemory(
                        plainBytes);
                }
            }
        }

        public static string GetSecureValue(
            string key,
            string defaultValue = "")
        {
            return TryGetSecureValue(
                key,
                out string? value)
                ? value ?? defaultValue
                : defaultValue;
        }

        #endregion

        #region Utility Operations

        public static bool DeleteKeys(
            IEnumerable<string> keys)
        {
            ArgumentNullException.ThrowIfNull(keys);

            var validKeys = keys
                .Where(key => !string.IsNullOrWhiteSpace(key))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (validKeys.Count == 0)
                return false;

            _writeSemaphore.Wait();

            try
            {
                Configuration config =
                    OpenConfiguration();

                var settings =
                    config.AppSettings.Settings;

                bool changed = false;

                foreach (string key in validKeys)
                {
                    if (settings[key] is null)
                        continue;

                    settings.Remove(key);
                    changed = true;
                }

                if (!changed)
                    return false;

                config.Save(
                    ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(
                    AppSettingsSection);

                foreach (string key in validKeys)
                {
                    _cache.TryRemove(
                        key,
                        out _);
                }

                return true;
            }
            catch (Exception ex)
            {
                LogException(
                    nameof(DeleteKeys),
                    ex);

                return false;
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        public static bool Clear()
        {
            _writeSemaphore.Wait();

            try
            {
                Configuration config =
                    OpenConfiguration();

                var settings =
                    config.AppSettings.Settings;

                if (settings.Count == 0)
                    return false;

                settings.Clear();

                config.Save(
                    ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection(
                    AppSettingsSection);

                _cache.Clear();

                return true;
            }
            catch (Exception ex)
            {
                LogException(nameof(Clear), ex);
                return false;
            }
            finally
            {
                _writeSemaphore.Release();
            }
        }

        #endregion

        #region Diagnostics

        private static void LogException(
            string operation,
            Exception exception)
        {
            Debug.WriteLine(
                $"[{nameof(HandleConfigurationFile)}] " +
                $"{operation} failed: " +
                $"{exception}");
        }

        #endregion
    }
}