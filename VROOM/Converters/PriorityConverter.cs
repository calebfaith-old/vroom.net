using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VROOM.Converters
{
    public class PriorityConverter : JsonConverter<Priority>
    {
        public override Priority Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, Priority value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }
    }
}