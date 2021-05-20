using System;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public class Route
    {
        /// <summary>
        /// Id of the vehicle assigned to this route.
        /// </summary>
        [JsonPropertyName("vehicle")]
        public uint VehicleId { get; set; }

        /// <summary>
        /// Array of step objects.
        /// </summary>
        [JsonPropertyName("steps")]
        public Step[] Steps { get; set; }

        /// <summary>
        /// Cost for this route.
        /// </summary>
        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        /// <summary>
        /// Total service time for this route.
        /// </summary>
        [JsonPropertyName("service")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan Service { get; set; }

        /// <summary>
        /// Total travel time for this route.
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Total waiting time for this route.
        /// </summary>
        [JsonPropertyName("waiting_time")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan WaitingTime { get; set; }

        /// <summary>
        /// Total priority sum for tasks in this route.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Array of violation objects for this route.
        /// </summary>
        [JsonPropertyName("violations")]
        public Violation[] Violations { get; set; }

        /// <summary>
        /// Total delivery for tasks in this route.
        /// </summary>
        [JsonPropertyName("delivery")]
        public int[]? Delivery { get; set; }

        /// <summary>
        /// Total pickup for tasks in this route.
        /// </summary>
        [JsonPropertyName("pickup")]
        public int[]? Pickup { get; set; }

        /// <summary>
        /// Vehicle description, if provided in input.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Polyline encoded route geometry. Provided when using the -g flag.
        /// </summary>
        [JsonPropertyName("geometry")]
        public string? Geometry { get; set; }

        /// <summary>
        /// Total route distance. Provided when using the -g flag.
        /// </summary>
        [JsonPropertyName("distance")]
        public int? Distance { get; set; }
    }
}