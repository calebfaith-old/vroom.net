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
    public class TestPriorityConverter
    {

        [TestMethod]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(0)]
        public void CanSerialize(int val)
        {
            PriorityConverter converter = new PriorityConverter();

            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            
            converter.Write(writer, new Priority(val), new JsonSerializerOptions());
            
            writer.Flush();
            stream.Position = 0;
            
            using TextReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            
            result.Should().Be(val.ToString(CultureInfo.InvariantCulture));
        }
        
        [TestMethod]
        [DataRow(10)]
        [DataRow(100)]
        [DataRow(0)]
        public void CanDeserialize(int val)
        {
            PriorityConverter converter = new PriorityConverter();

            Utf8JsonReader reader = new Utf8JsonReader(Encoding.UTF8.GetBytes(val.ToString()));
            reader.Read();
            var result = converter.Read(ref reader, typeof(Priority), new JsonSerializerOptions());

            result.Value.Should().Be(val);
        }
    }
}