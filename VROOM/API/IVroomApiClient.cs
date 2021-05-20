using System;
using System.Threading.Tasks;

namespace VROOM.API
{
    public interface IVroomApiClient : IDisposable
    {
        Task<VroomOutput> PerformRequest(VroomInput vroomInput);
        Task<bool> IsHealthy();
    }
}