using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VROOM.Converters
{
    public class NullableTimeSpanSecondsToIntConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if(reader.TryGetInt32(out int parsed))
            {
                return new TimeSpan(0, 0, parsed);
            }
            else
            {
                throw new JsonException("Unsupported JSON type.");
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteNumberValue((int) Math.Round(value.Value.TotalSeconds));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}