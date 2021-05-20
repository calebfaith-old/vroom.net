using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VROOM.Converters
{
    public class TimeWindowConverter : JsonConverter<TimeWindow>
    {
        public override TimeWindow Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Failed converting TimeWindow.");
            }

            reader.Read();
            long start = reader.GetInt64();
            reader.Read();
            long end = reader.GetInt64();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException("Failed converting TimeWindow.");
            }

            return new TimeWindow(DateTimeOffset.FromUnixTimeSeconds(start), DateTimeOffset.FromUnixTimeSeconds(end));
        }

        public override void Write(Utf8JsonWriter writer, TimeWindow value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Start.ToUnixTimeSeconds());
            writer.WriteNumberValue(value.End.ToUnixTimeSeconds());
            writer.WriteEndArray();
        }
    }
}