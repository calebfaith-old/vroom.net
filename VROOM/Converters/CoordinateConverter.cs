using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace VROOM.Converters
{
    public class CoordinateConverter : JsonConverter<Coordinate>
    {
        public override Coordinate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Failed converting coordinate.");
            }

            reader.Read();
            double lon = reader.GetDouble();
            reader.Read();
            double lat = reader.GetDouble();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException("Failed converting coordinate.");
            }

            return new Coordinate(lon, lat);
        }

        public override void Write(Utf8JsonWriter writer, Coordinate value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Longitude);
            writer.WriteNumberValue(value.Latitude);
            writer.WriteEndArray();
        }
    }
}