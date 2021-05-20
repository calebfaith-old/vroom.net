using System;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public class Step
    {
        /// <summary>
        /// The step type.
        /// </summary>
        [JsonPropertyName("type")]
        public StepType StepType { get; set; }
        
        /// <summary>
        /// Estimated time of arrival at this step.
        /// </summary>
        [JsonPropertyName("arrival")]
        [JsonConverter(typeof(DateTimeOffsetToUnixConverter))]
        public DateTimeOffset Arrival { get; set; }
        
        /// <summary>
        /// Cumulated travel time upon arrival at this step.
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan Duration { get; set; }
        
        /// <summary>
        /// Service time at this step.
        /// </summary>
        [JsonPropertyName("service")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan Service { get; set; }
        
        /// <summary>
        /// Waiting time upon arrival at this step.
        /// </summary>
        [JsonPropertyName("waiting_time")]
        [JsonConverter(typeof(TimeSpanSecondsToIntConverter))]
        public TimeSpan WaitingTime { get; set; }
        
        /// <summary>
        /// Array of violation objects for this step.
        /// </summary>
        [JsonPropertyName("violations")]
        public Violation[] Violations { get; set; }
        
        /// <summary>
        /// Step description, if provided in input.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        /// <summary>
        /// Coordinates for this step, if provided in input.
        /// </summary>
        [JsonPropertyName("location")]
        public Coordinate? Location { get; set; }
        
        /// <summary>
        /// Id of the task performed at this step.
        /// Only provided if type value is job, pickup, delivery or break.
        /// </summary>
        [JsonPropertyName("id")]
        public uint? Id { get; set; }
        
        /// <summary>
        /// Vehicle load after step completion (with capacity constraints).
        /// </summary>
        [JsonPropertyName("load")]
        public int[]? Load { get; set; }
        
        /// <summary>
        /// Traveled distance upon arrival at this step. Provided when using the -g flag.
        /// </summary>
        [JsonPropertyName("distance")]
        public int Distance { get; set; }
    }
}