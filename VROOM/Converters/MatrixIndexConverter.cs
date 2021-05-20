using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace VROOM.Converters
{
    public class MatrixIndexConverter : JsonConverter<MatrixIndex>
    {
        public override MatrixIndex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException("Failed converting MatrixIndex.");
            }

            reader.Read();
            int row = reader.GetInt32();
            reader.Read();
            int col = reader.GetInt32();

            reader.Read();
            if (reader.TokenType != JsonTokenType.EndArray)
            {
                throw new JsonException("Failed converting MatrixIndex.");
            }

            return new MatrixIndex(row, col);
        }

        public override void Write(Utf8JsonWriter writer, MatrixIndex value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Row);
            writer.WriteNumberValue(value.Column);
            writer.WriteEndArray();
        }
    }
}