using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.Converts
{
    public class LongJsonConverter : JsonConverter<long>
    {
        public override long Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default(long);

            if (reader.TokenType == JsonTokenType.String)
            {
                
                return string.IsNullOrEmpty(reader.GetString())?default(long): long.Parse(reader.GetString()!);
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt64();
            }

            throw new JsonException($"无法将 {reader.TokenType} 转换为 long");
        }

        public override void Write(
            Utf8JsonWriter writer,
            long value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
