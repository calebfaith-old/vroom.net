using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VROOM.API
{
    public class VroomApiClient : IVroomApiClient
    {
        private readonly string _host;
        private readonly HttpClient _client;

        public VroomApiClient(string host)
        {
            if (string.IsNullOrEmpty(host))
            {
                throw new ArgumentNullException(nameof(host));
            }

            if (!host.EndsWith("/"))
            {
                host += "/";
            }

            _host = host;

            _client = new HttpClient();
        }

        public async Task<VroomOutput> PerformRequest(VroomInput vroomInput)
        {
            var response = await _client.PostAsync(_host,
                new StringContent(JsonSerializer.Serialize(vroomInput), Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Server responded with status code {response.StatusCode}. Content: " +
                                    await response.Content.ReadAsStringAsync());
            }

            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<VroomOutput>(content);
        }

        public async Task<bool> IsHealthy()
        {
            var result = await _client.GetAsync(_host + "health");
            return result.StatusCode == HttpStatusCode.OK;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}