using System;
using System.Text.Json.Serialization;

namespace VROOM
{
    public class Violation
    {
        /// <summary>
        /// The cause of the violation.
        /// </summary>
        [JsonPropertyName("cause")]
        public ViolationCause Cause { get; set; }
        
        [JsonPropertyName("duration")]
        public double Duration { get; set; }
    }
}