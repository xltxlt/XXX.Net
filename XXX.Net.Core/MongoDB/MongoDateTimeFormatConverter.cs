using System.Text.Json;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.MongoDb
{
    public class MongoDateTimeFormatConverter
    : JsonConverter<DateTime>
    {

        private readonly string _format;


        public MongoDateTimeFormatConverter(
            string format)
        {
            _format = format;
        }


        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(
                value.AddHours(8).ToString(_format)
            );
        }


        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return DateTime.Parse(
                reader.GetString()
            );
        }
    }
}