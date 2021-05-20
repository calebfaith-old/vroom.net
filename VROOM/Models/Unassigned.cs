using System.Text.Json.Serialization;

namespace VROOM
{
    public class Unassigned
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }
        
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        
        [JsonPropertyName("location")]
        public Coordinate? Location { get; set; }
    }
}