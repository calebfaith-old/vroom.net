using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public class Job
    {
        /// <summary>
        /// The job ID.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }
        
        /// <summary>
        /// A description of this job.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        /// <summary>
        /// The location of this job.
        /// </summary>
        [JsonPropertyName("location")]
        public Coordinate? Location { get; set; }
        
        /// <summary>
        /// Index of relevant row and column in custom matrices. Only needed if supplying custom matrix.
        /// </summary>
        [JsonPropertyName("location_index")]
        public MatrixIndex? LocationIndex { get; set; }
        
        /// <summary>
        /// Job service duration. In VROOM this is the "service" property.
        /// </summary>
        [JsonPropertyName("service")]
        [JsonConverter(typeof(NullableTimeSpanSecondsToIntConverter))]
        public TimeSpan? Duration { get; set; }
        
        /// <summary>
        /// List of ints describing multidimensional quantities for delivery.
        /// </summary>
        [JsonPropertyName("delivery")]
        public List<int>? Delivery { get; set; }
        
        /// <summary>
        /// List of ints describing multidimensional quantities for pickup.
        /// </summary>
        [JsonPropertyName("pickup")]
        public List<int>? Pickup { get; set; }
        
        /// <summary>
        /// List of ints defining mandatory skills.
        /// </summary>
        [JsonPropertyName("skills")]
        public List<int>? Skills { get; set; }
        
        /// <summary>
        /// An integer in the [0, 100] range describing priority level.
        /// </summary>
        [JsonPropertyName("priority")]
        public Priority? Priority { get; set; }
        
        /// <summary>
        /// List of timewindows describing valid slots for job service start.
        /// </summary>
        [JsonPropertyName("time_windows")]
        public List<TimeWindow>? TimeWindows { get; set; }
    }
}