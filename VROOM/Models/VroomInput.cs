using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VROOM
{
    public class VroomInput
    {
        /// <summary>
        /// List of job objects describing the places to visit.
        /// </summary>
        [JsonPropertyName("jobs")]
        public List<Job> Jobs { get; set; }
        
        /// <summary>
        /// List of shipment objects describing pickup and delivery tasks.
        /// </summary>
        [JsonPropertyName("shipments")]
        public List<Shipment> Shipments { get; set; }
        
        /// <summary>
        /// List of vehicle objects describing the available vehicles.
        /// </summary>
        [JsonPropertyName("vehicles")]
        public List<Vehicle> Vehicles { get; set; }
        
        /// <summary>
        /// Optional description of per-profile custom matrices. Key is vehicle profile type.
        /// </summary>
        [JsonPropertyName("matrices")]
        public Dictionary<string, Matrice>? Matrices { get; set; }
    }
}