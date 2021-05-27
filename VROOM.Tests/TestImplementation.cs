using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VROOM.API;

namespace VROOM.Tests
{
    [TestClass]
    public class TestImplementation
    {
        // uncomment to test implementation (needs VROOM instance)
        // [TestMethod]
        public async Task Test()
        {
            VroomApiClient apiClient = new VroomApiClient("http://localhost:3000");
            uint id = 0;
            
            var response = await apiClient.PerformRequest(new VroomInput()
            {
                Jobs = new List<Job>()
                {
                    new Job()
                    {
                        Id = id++,
                        Location = new Coordinate(151.7735849, -32.9337431)
                    },
                    new Job()
                    {
                        Id = id++,
                        Location = new Coordinate(151.7617514, -32.9351314)
                    },
                    new Job()
                    {
                        Id = id++,
                        Location = new Coordinate(151.7105484, -32.9338793)
                    }
                },
                Vehicles = new List<Vehicle>()
                {
                    new Vehicle()
                    {
                        Id = id++,
                        Start = new Coordinate(151.7005484, -32.9331793)
                    }
                }
            });
        }
    }
}