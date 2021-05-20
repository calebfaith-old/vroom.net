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
    public class TestMatrixIndexConverter
    {
        private static readonly MatrixIndex[] TestValues = new[]
        {
            new MatrixIndex(0, 0),
            new MatrixIndex(1, 100),
            new MatrixIndex(1000, 1000000),
        };
        
        [TestMethod]
        public void CanSerialize()
        {
            MatrixIndexConverter converter = new MatrixIndexConverter();

            foreach (var value in TestValues)
            {
                using MemoryStream stream = new MemoryStream();
                using Utf8JsonWriter writer = new Utf8JsonWriter(stream);

                converter.Write(writer, value, new JsonSerializerOptions());

                writer.Flush();
                stream.Position = 0;

                using TextReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();

                result.Should().Be($"[{value.Row},{value.Column}]");
            }
        }
        
        [TestMethod]
        public void CanDeserialize()
        {
            MatrixIndexConverter converter = new MatrixIndexConverter();
            foreach (var value in TestValues)
            {
                Utf8JsonReader reader = new Utf8JsonReader(Encoding.UTF8.GetBytes($"[{value.Row},{value.Column}]"));
                reader.Read();
                var result = converter.Read(ref reader, typeof(Priority), new JsonSerializerOptions());

                result.Should().BeEquivalentTo(value);
            }
        }
    }
}