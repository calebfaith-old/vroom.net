using System.Text.Json.Serialization;

namespace VROOM
{
    public class Matrice
    {
        [JsonPropertyName("durations")]
        public int[][] Durations { get; set; } 
    }
}