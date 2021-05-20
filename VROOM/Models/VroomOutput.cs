using System.Text.Json.Serialization;

namespace VROOM
{
    public class VroomOutput
    {
        [JsonIgnore]
        public bool WasSuccessful => Code == OutputCode.NoError;
        
        [JsonPropertyName("code")]
        public OutputCode Code { get; set; }
        
        [JsonPropertyName("error")]
        public string? Error { get; set; }
        
        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }
        
        [JsonPropertyName("unassigned")]
        public Unassigned[]? Unassigned { get; set; }
        
    }
}