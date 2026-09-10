using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.Converts
{
    public class BooleanJsonConverter : JsonConverter<Boolean>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.True) return true;
            if (reader.TokenType == JsonTokenType.False) return false;

            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt32() switch
                {
                    1 => true,
                    0 => false,
                    _ => throw new JsonException("Boolean number must be 0 or 1")
                };
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetString() switch
                {
                    "1" or "true" => true,
                    "0" or "false" => false,
                    _ => throw new JsonException("Invalid boolean string")
                };
            }

            throw new JsonException("Invalid boolean value");
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value ? 1 : 0);
        }
    }
}
