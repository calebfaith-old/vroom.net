using System;
using System.Linq;
using System.Reflection;

namespace VROOM
{
    internal static class Extensions
    {
        public static T GetAttributeFromEnumValue<T>(this Enum enumValue)
            where T : Attribute
        {
            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attribute = memInfo.FirstOrDefault()?.GetCustomAttribute(typeof(T), false);
            return (T) attribute;
        }

        public static DateTimeOffset ToSecondsAccuracy(this DateTimeOffset dateTimeOffset)
        {
            return DateTimeOffset.FromUnixTimeSeconds(dateTimeOffset.ToUnixTimeSeconds());
        }
    }
}