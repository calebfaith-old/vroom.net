using System;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public class ShipmentStep
    {
        /// <summary>
        /// The shipment step ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// A description of this shipment step.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        /// <summary>
        /// The location of this shipment step.
        /// </summary>
        [JsonPropertyName("location")]
        public Coordinate? Location { get; set; }
        
        /// <summary>
        /// Index of relevant row and column in custom matrices. Only needed if supplying custom matrix.
        /// </summary>
        [JsonPropertyName("location_index")]
        public MatrixIndex? LocationIndex { get; set; }
        
        /// <summary>
        /// Shipment step service duration.
        /// </summary>
        [JsonPropertyName("service")]
        [JsonConverter(typeof(NullableTimeSpanSecondsToIntConverter))]
        public TimeSpan? Service { get; set; }
        
        /// <summary>
        /// Array of timewindows describing valid slots for job service start.
        /// </summary>
        [JsonPropertyName("time_windows")]
        public TimeWindow[]? TimeWindows { get; set; }
    }
}