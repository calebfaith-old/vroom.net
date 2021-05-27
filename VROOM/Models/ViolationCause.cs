using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    [JsonConverter(typeof(StringEnumConverter<ViolationCause>))]
    public enum ViolationCause : uint
    {
        Invalid = 0,

        /// <summary>
        /// If actual service start does not meet a task time window and is late on a time window end.
        /// </summary>
        [EnumMember(Value = "delay")]
        Delay,

        /// <summary>
        /// If actual service start does not meet a task time window and is early on a time window start.
        /// </summary>
        [EnumMember(Value = "lead_time")]
        LeadTime,

        /// <summary>
        /// If the vehicle load goes over its capacity.
        /// </summary>
        [EnumMember(Value = "load")]
        Load,

        /// <summary>
        /// If the vehicle does not hold all required skills for a task.
        /// </summary>
        [EnumMember(Value = "skills")]
        Skills,

        /// <summary>
        /// If a shipment precedence constraint is not met (pickup without matching delivery, delivery before/without matching pickup).
        /// </summary>
        [EnumMember(Value = "precedence")]
        Precedence,

        /// <summary>
        /// If a vehicle break has been omitted in its custom route.
        /// </summary>
        [EnumMember(Value = "missing_break")]
        MissingBreak
    }
}