# VROOM .NET

VROOM .NET is a simple API client for [vroom-express](https://github.com/VROOM-Project/vroom-express) which covers 100% of the API. 

It provides models and an API designed following standard C# coding conventions. For example, instead of coordinates being an array of 2 numbers they are encapsulated as a type-safe Coordinate object with Latitude and Longitude properties.

# Usage

1. Requires a reachable VROOM server. [vroom-docker](https://github.com/VROOM-Project/vroom-docker) is a good place to get started. No support will be provided relating to deploying a VROOM server, please raise issues relating to that on the [vroom-docker](https://github.com/VROOM-Project/vroom-docker) repo.
2. Install via NuGet [`VROOM.NET`](https://www.nuget.org/packages/VROOM.NET/1.0.0).
3. Use the `VROOM.API.VroomApiClient` to make requests to a VROOM server.

# Example

```C#
public async Task Run()
{
    VroomApiClient apiClient = new VroomApiClient("http://localhost:3000");
    uint id = 0;

    var input = new VroomInput()
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
    };
    
    var result = await apiClient.PerformRequest(input);
    
    // do something with the result...
}
```

# Contributors

Contributions are welcome, please feel free to open new issues or submit pull requests.

Main contributors:
* [Caleb Faith](https://github.com/calebfaith)

# License

MIT

# Thanks

Thanks to [VROOM](https://github.com/VROOM-Project) for providing an awesome implementation.
