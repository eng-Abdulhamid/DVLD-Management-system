using System;
using System.Drawing;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DVLD.PL.Theme;

public sealed class ColorJsonConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? hex = reader.GetString();
            if (string.IsNullOrWhiteSpace(hex)) return Color.Empty;

            string cleanHex = hex.TrimStart('#');

            if (cleanHex.Length == 8 && uint.TryParse(cleanHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out uint argb))
            {
                return Color.FromArgb((int)argb);
            }

            if (cleanHex.Length == 6 && int.TryParse(cleanHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int rgb))
            {
                return Color.FromArgb(255, Color.FromArgb(rgb));
            }
        }

        return Color.FromArgb(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"#{value.A:X2}{value.R:X2}{value.G:X2}{value.B:X2}");
    }
}