using System;
using System.IO;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VROOM.Converters;

namespace VROOM.Tests
{
    [TestClass]
    public class TestTimeWindowConverter
    {
        private static readonly TimeWindow[] TestValues = new[]
        {
            new TimeWindow(DateTimeOffset.UtcNow.ToSecondsAccuracy(), DateTimeOffset.UtcNow.ToSecondsAccuracy() + TimeSpan.FromSeconds(100)),
            new TimeWindow(DateTimeOffset.UtcNow.ToSecondsAccuracy(), DateTimeOffset.UtcNow.ToSecondsAccuracy() + TimeSpan.FromSeconds(1)),
            new TimeWindow(DateTimeOffset.UtcNow.ToSecondsAccuracy(), DateTimeOffset.UtcNow.ToSecondsAccuracy() + TimeSpan.FromDays(100)),
        };

        [TestMethod]
        public void CanSerialize()
        {
            TimeWindowConverter converter = new TimeWindowConverter();

            foreach (var value in TestValues)
            {
                using MemoryStream stream = new MemoryStream();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

                converter.Write(writer, value, new JsonSerializerOptions());

                writer.Flush();
                stream.Position = 0;

                using TextReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                result.Should().Be($"[{value.Start.ToUnixTimeSeconds()},{value.End.ToUnixTimeSeconds()}]");
            }
        }

        [TestMethod]
        public void CanDeserialize()
        {
            TimeWindowConverter converter = new TimeWindowConverter();
            foreach (var value in TestValues)
            {
                Utf8JsonReader reader =
                    new Utf8JsonReader(Encoding.UTF8.GetBytes($"[{value.Start.ToUnixTimeSeconds()},{value.End.ToUnixTimeSeconds()}]"));
                reader.Read();
                var result = converter.Read(ref reader, typeof(TimeSpan), new JsonSerializerOptions());

                result.Should().Be(value);
            }
        }
    }
}