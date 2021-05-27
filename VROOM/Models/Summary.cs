using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public class Summary
    {
        /// <summary>
        /// Total cost for all routes.
        /// </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        
        /// <summary>
        /// Number of tasks that could not be served.
        /// </summary>
        [JsonPropertyName("unassigned")]
        public int Unassigned { get; set; }
        
        /// <summary>
        /// Total service time for all routes.
        /// </summary>
        [JsonPropertyName("service")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan Service { get; set; }
        
        /// <summary>
        /// Total travel time for all routes.
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// Total waiting time for all routes.
        /// </summary>
        [JsonPropertyName("waiting_time")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan WaitingTime { get; set; }
        
        /// <summary>
        /// Total priority sum for all assigned tasks.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }
        
        /// <summary>
        /// List of violation objects for all routes.
        /// </summary>
        [JsonPropertyName("violations")]
        public List<Violation> Violations { get; set; } = null!;
        
        /// <summary>
        /// Total delivery for all routes.
        /// </summary>
        [JsonPropertyName("delivery")]
        public List<int>? Delivery { get; set; }
        
        /// <summary>
        /// Total pickup for all routes.
        /// </summary>
        [JsonPropertyName("pickup")]
        public int[]? Pickup { get; set; }
        
        /// <summary>
        /// Total distance for all routes.
        /// </summary>
        [JsonPropertyName("distance")]
        public int? Distance { get; set; }
    }
}