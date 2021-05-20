using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VROOM.Converters
{
    public class NullableDateTimeOffsetToUnixConverter : JsonConverter<DateTimeOffset?>
    {
        public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetInt64(out long parsed))
            {
                return DateTimeOffset.FromUnixTimeSeconds(parsed);
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteNumberValue(value.Value.ToUnixTimeSeconds());
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}