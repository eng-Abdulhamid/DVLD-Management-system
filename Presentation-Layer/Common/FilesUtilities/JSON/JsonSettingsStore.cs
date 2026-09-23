using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD.PL.Theme;

public class JsonSettingsStore<T> where T : class, new()
{
    private readonly string _filePath;
    private readonly JsonSerializerOptions _serializerOptions;

    public JsonSettingsStore(string filePath)
    {
        _filePath = !string.IsNullOrWhiteSpace(filePath)
            ? filePath
            : throw new ArgumentNullException(nameof(filePath));

        _serializerOptions = CreateDefaultOptions();
    }

    public async ValueTask SaveAsync(T data, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(data);

        EnsureDirectoryExists(_filePath);
        await WriteToFileAtomicallyAsync(_filePath, data, cancellationToken).ConfigureAwait(false);
    }

    private static void EnsureDirectoryExists(string filePath)
    {
        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    private async Task WriteToFileAtomicallyAsync(string destinationPath, T data, CancellationToken cancellationToken)
    {
        string tempPath = destinationPath + ".tmp";

        await using (FileStream stream = CreateWriteStream(tempPath))
        {
            await JsonSerializer.SerializeAsync(stream, data, _serializerOptions, cancellationToken).ConfigureAwait(false);
            await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }

        File.Move(tempPath, destinationPath, overwrite: true);
    }

    private static FileStream CreateWriteStream(string path) =>
        new(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);

    public async ValueTask<T> LoadAsync(CancellationToken cancellationToken = default)
    {
        if (!File.Exists(_filePath))
        {
            return new T();
        }

        return await ReadFromFileAsync(_filePath, cancellationToken).ConfigureAwait(false);
    }

    private async Task<T> ReadFromFileAsync(string path, CancellationToken cancellationToken)
    {
        try
        {
            await using FileStream stream = CreateReadStream(path);
            T? result = await JsonSerializer.DeserializeAsync<T>(stream, _serializerOptions, cancellationToken).ConfigureAwait(false);

            return result ?? new T();
        }
        catch (JsonException)
        {
            return new T();
        }
    }

    private static FileStream CreateReadStream(string path) =>
        new(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, FileOptions.SequentialScan | FileOptions.Asynchronous);

    private static JsonSerializerOptions CreateDefaultOptions()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(),
                new ColorJsonConverter()
            }
        };

        return options;
    }
}