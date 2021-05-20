using System.Text.Json.Serialization;

namespace VROOM
{
    public class Vehicle
    {
        /// <summary>
        /// Vehicle ID.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The routing profile to use. Defaults to car.
        /// </summary>
        [JsonPropertyName("profile")]
        public string? Profile { get; set; }

        /// <summary>
        /// A description of this vehicle.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// The start coordinate of the vehicle.
        /// </summary>
        [JsonPropertyName("start")] 
        public Coordinate? Start { get; set; }

        /// <summary>
        /// The start index of the vehicle in custom matrices. Only needed if supplying custom matrix.
        /// </summary>
        [JsonPropertyName("start_index")]
        public MatrixIndex? StartIndex { get; set; }

        /// <summary>
        /// The end coordinate of the vehicle.
        /// </summary>
        [JsonPropertyName("end")]
        public Coordinate? End { get; set; }

        /// <summary>
        /// The end index of the vehicle in custom matrices. Only needed if supplying custom matrix.
        /// </summary>
        [JsonPropertyName("end_index")]
        public MatrixIndex? EndIndex { get; set; }

        /// <summary>
        /// Array of integers describing multidimensional qualities.
        /// </summary>
        [JsonPropertyName("capacity")]
        public int[]? Capacity { get; set; }

        /// <summary>
        /// Array of ints defining skills.
        /// </summary>
        [JsonPropertyName("skills")]
        public int[]? Skills { get; set; }

        /// <summary>
        /// The possible working hours of the vehicle.
        /// </summary>
        [JsonPropertyName("time_window")]
        public TimeWindow? TimeWindow { get; set; }

        /// <summary>
        /// An array of break objects.
        /// </summary>
        [JsonPropertyName("breaks")]
        public Break[]? Breaks { get; set; }

        /// <summary>
        /// A value used to scale all vehicle travel times.
        /// The respected precision is limited to two digits after the decimal point.
        /// </summary>
        [JsonPropertyName("speed_factor")]
        public double? SpeedFactor { get; set; }

        /// <summary>
        /// An array of VehicleStep objects describing a custom route for this vehicle (only makes sense when using -c)
        /// </summary>
        [JsonPropertyName("steps")]
        public VehicleStep[]? Steps { get; set; }
    }
}