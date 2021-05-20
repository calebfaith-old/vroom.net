using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VROOM.Converters;

namespace VROOM.Tests
{
    [TestClass]
    public class TestStringEnumConverter
    {
        private static readonly Enum[] TestValues = {
            ViolationCause.Load,
            ViolationCause.LeadTime,
            ViolationCause.MissingBreak,
        };

        [TestMethod]
        public void CanSerialize()
        {
            StringEnumConverter<ViolationCause> converter = new StringEnumConverter<ViolationCause>();

            foreach (var value in TestValues)
            {
                using MemoryStream stream = new MemoryStream();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

                converter.Write(writer, (ViolationCause) value, new JsonSerializerOptions());

                writer.Flush();
                stream.Position = 0;

                using TextReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                result.Should().Be('"' + value.GetAttributeFromEnumValue<EnumMemberAttribute>()?.Value + '"');
            }
        }

        [TestMethod]
        public void CanDeserialize()
        {
            StringEnumConverter<ViolationCause> converter = new StringEnumConverter<ViolationCause>();
            foreach (var value in TestValues)
            {
                Utf8JsonReader reader =
                    new Utf8JsonReader(
                        Encoding.UTF8.GetBytes(
                            '"' + value.GetAttributeFromEnumValue<EnumMemberAttribute>()?.Value + '"'));
                reader.Read();
                var result = converter.Read(ref reader, typeof(ViolationCause), new JsonSerializerOptions());

                result.Should().BeEquivalentTo(value);
            }
        }
    }
}