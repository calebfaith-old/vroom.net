using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    [JsonConverter(typeof(StringEnumConverter<StepType>))]
    public enum StepType
    {
        [EnumMember(Value = "start")]
        Start,
        
        [EnumMember(Value = "job")]
        Job,
        
        [EnumMember(Value = "pickup")]
        Pickup,
        
        [EnumMember(Value = "delivery")]
        Delivery,
        
        [EnumMember(Value = "break")]
        Break,
        
        [EnumMember(Value = "end")]
        End
    }
}