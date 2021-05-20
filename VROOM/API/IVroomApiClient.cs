using System;
using System.Threading.Tasks;

namespace VROOM.API
{
    public interface IVroomApiClient : IDisposable
    {
        Task<Output> PerformRequest(Input input);
        Task<bool> IsHealthy();
    }
}