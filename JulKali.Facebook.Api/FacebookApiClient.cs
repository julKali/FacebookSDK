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

        public async Task<ResponseObject<TSuccess, TError>> Post<TSuccess, TError>(string url, object data) 
            where TSuccess : IEntity 
            where TError : IEntity
        {
            var response = await _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));

            var responseObj = new ResponseObject<TSuccess, TError>
            {
                HttpCode = response.StatusCode
            };

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                responseObj.Success = JsonConvert.DeserializeObject<TSuccess>(responseContent);
            }
            else
            {
                responseObj.Error = JsonConvert.DeserializeObject<TError>(responseContent);
            }

            return responseObj;
        } 
    }
}
