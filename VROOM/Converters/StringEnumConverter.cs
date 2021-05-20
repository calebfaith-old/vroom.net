using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VROOM.Converters
{
    public class StringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string s = reader.GetString();
            if (Enum.TryParse(s, out T parsedVal))
            {
                return parsedVal;
            }
            
            var values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                var enumMemberAttribute = ((T)value).GetAttributeFromEnumValue<EnumMemberAttribute>();
                if (enumMemberAttribute != null)
                {
                    if (s == enumMemberAttribute.Value)
                    {
                        return (T) value;
                    }
                }
            }

            throw new JsonException($"Could not find enum value {s} in {typeof(T)}");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var enumMemberAttribute = value.GetAttributeFromEnumValue<EnumMemberAttribute>();
            writer.WriteStringValue(enumMemberAttribute != null ? enumMemberAttribute.Value : value.ToString());
        }
    }
}