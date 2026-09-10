using System.Text.Json.Serialization;
namespace XXX.Net.Core.MongoDb
{
    public class MongoJsonDateTimeAttribute : JsonConverterAttribute
    {
        private readonly string _format;

        public MongoJsonDateTimeAttribute(
            string format = "yyyy-MM-dd HH:mm:ss")
            : base(typeof(MongoDateTimeFormatConverter))
        {
            _format = format;
        }

        public override JsonConverter CreateConverter(Type typeToConvert)
        {
            return new MongoDateTimeFormatConverter(_format);
        }
    }
}
