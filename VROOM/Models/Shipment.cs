using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VROOM
{
    public class Shipment
    {
        /// <summary>
        /// A ShipmentStep object describing pickup.
        /// </summary>
        [JsonPropertyName("pickup")]
        public ShipmentStep Pickup { get; set; }
        
        /// <summary>
        /// A ShipmentStep object describing delivery.
        /// </summary>
        [JsonPropertyName("delivery")]
        public ShipmentStep Delivery { get; set; }
        
        /// <summary>
        /// List of ints describing multidimensional quantities for delivery.
        /// </summary>
        [JsonPropertyName("amount")]
        public List<int>? Amount { get; set; }
        
        /// <summary>
        /// A List of ints defining mandatory skills.
        /// </summary>
        [JsonPropertyName("skills")]
        public List<int>? Skills { get; set; }
        
        /// <summary>
        /// An integer in the [0, 100] range describing priority level.
        /// </summary>
        [JsonPropertyName("priority")]
        public Priority? Priority { get; set; }
    }
}