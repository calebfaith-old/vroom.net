using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public class Break
    {
        /// <summary>
        /// The break Id.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// A description of the break.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// A list of TimeWindows describing valid slots for break start.
        /// </summary>
        [JsonPropertyName("time_windows")]
        public List<TimeWindow>? TimeWindows { get; set; }
        
        /// <summary>
        /// The break duration (in VROOM this is "service").
        /// </summary>
        [JsonPropertyName("service")]
        [JsonConverter(typeof(NullableTimeSpanSecondsToIntConverter))]
        public TimeSpan? Duration { get; set; }
    }
}