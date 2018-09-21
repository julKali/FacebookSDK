using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JulKali.Facebook.Api
{
    public class FacebookApiClient
    {
        private readonly HttpClient _client;

        public FacebookApiClient()
        {
            _client = new HttpClient();
        }

        public FacebookApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> Post<T>(string url, object data)
        {
            var response = await _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }

            return default;
        } 
    }
}
