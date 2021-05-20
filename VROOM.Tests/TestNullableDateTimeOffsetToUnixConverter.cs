using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VROOM.Converters;

namespace VROOM.Tests
{
    [TestClass]
    public class TestDateTimeOffsetToUnixConverter
    {
        private static readonly DateTimeOffset[] TestValues = new[]
        {
            new DateTimeOffset(2020, 9, 11, 10, 1, 45, 0, new TimeSpan()),
            new DateTimeOffset(2020, 1, 1, 0, 0, 0, 0, new TimeSpan()),
            new DateTimeOffset(1980, 1, 11, 20, 59, 0, 0, new TimeSpan()),
        };
        
        [TestMethod]
        public void CanSerialize()
        {
            DateTimeOffsetToUnixConverter converter = new DateTimeOffsetToUnixConverter();

            foreach (var value in TestValues)
            {
                using MemoryStream stream = new MemoryStream();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

                converter.Write(writer, value, new JsonSerializerOptions());

                writer.Flush();
                stream.Position = 0;

                using TextReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                result.Should().Be(value.ToUnixTimeSeconds().ToString());
            }
        }
        
        [TestMethod]
        public void CanDeserialize()
        {
            DateTimeOffsetToUnixConverter converter = new DateTimeOffsetToUnixConverter();
            foreach (var value in TestValues)
            {
                Utf8JsonReader reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(value.ToUnixTimeSeconds().ToString()));
                reader.Read();
                var result = converter.Read(ref reader, typeof(DateTimeOffset), new JsonSerializerOptions());

                result.Should().Be(value);
            }
        }
    }
}