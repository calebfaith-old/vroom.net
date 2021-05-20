using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VROOM
{
    public class VroomInput
    {
        [JsonPropertyName("jobs")]
        public Job[] Jobs { get; set; }
        
        [JsonPropertyName("shipments")]
        public Shipment[] Shipments { get; set; }
        
        [JsonPropertyName("vehicles")]
        public Vehicle[] Vehicles { get; set; }
        
        /// <summary>
        /// Key is vehicle profile type.
        /// </summary>
        [JsonPropertyName("matrices")]
        public Dictionary<string, Matrice>? Matrices { get; set; }
    }
}