using System.Text.Json.Serialization;
using VROOM.Converters;

namespace VROOM
{
    public enum OutputCode : int
    {
        NoError = 0,
        InternalError = 1,
        InputError = 2,
        RoutingError = 3
    }
}