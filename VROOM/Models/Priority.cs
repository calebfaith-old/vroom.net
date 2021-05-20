using System;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    [JsonConverter(typeof(PriorityConverter))]
    public readonly struct Priority
    {
        /// <summary>
        /// Must be within [0, 100]
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Creates a priority value. Must be within [0, 100].
        /// </summary>
        /// <param name="value">Must be within [0, 100].</param>
        public Priority(int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Must be within [0, 100].", nameof(value));
            }
            
            Value = value;
        }
        
        public static implicit operator Priority(int i) => new Priority(i); 
    }
}