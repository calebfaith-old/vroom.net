using System.IO;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VROOM.Converters;

namespace VROOM.Tests
{
    [TestClass]
    public class TestCoordinateConverter
    {
        [TestMethod]
        [DataRow(-10, 50.5)]
        [DataRow(100.345, -0.5)]
        [DataRow(-1345.8, 0)]
        [DataRow(10.456456456678, 0.5)]
        public void CanSerialize(double lon, double lat)
        {
            CoordinateConverter converter = new CoordinateConverter();

            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            
            converter.Write(writer, new Coordinate(lon, lat), new JsonSerializerOptions());
            
            writer.Flush();
            stream.Position = 0;
            
            using TextReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            
            result.Should().Be($"[{lon},{lat}]");
        }

        [TestMethod]
        [DataRow("[-10,50.5]", -10, 50.5)]
        [DataRow("[100.345,-0.5]", 100.345, -0.5)]
        [DataRow("[-1345.8,0]", -1345.8, 0)]
        [DataRow("[10.456456456678,0.5]", 10.456456456678, 0.5)]
        public void CanDeserialize(string input, double lon, double lat)
        {
            CoordinateConverter converter = new CoordinateConverter();

            Utf8JsonReader reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(input));
            reader.Read();
            var result = converter.Read(ref reader, typeof(Coordinate), new JsonSerializerOptions());

            result.Longitude.Should().Be(lon);
            result.Latitude.Should().Be(lat);
        }
    }
}