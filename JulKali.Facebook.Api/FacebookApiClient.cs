using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JulKali.Facebook.Api
{
    /// <summary>
    /// Represents a client to communicate with the Facebook Graph API.
    /// </summary>
    public class FacebookApiClient
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new <see cref="FacebookApiClient"/> instance.
        /// </summary>
        public FacebookApiClient()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Initializes a new <see cref="FacebookApiClient"/> instance using an exisiting <see cref="HttpClient"/> instance.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> instance.</param>
        public FacebookApiClient(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Posts data to the api.
        /// </summary>
        /// <typeparam name="TSuccess">Type of the JSON encoded response content if request was successful.</typeparam>
        /// <typeparam name="TError">Type of the JSON encoded response content if request was not successful.</typeparam>
        /// <param name="url">The absolute Facebook API endpoint.</param>
        /// <param name="data">Data to be sent to the endpoint.</param>
        /// <returns>A <see cref="ResponseObject{TSuccess,TError}"/> instance. Either the <see cref="TSuccess"/> or the <see cref="TError"/> field is null.</returns>
        public async Task<ResponseObject<TSuccess, TError>> Post<TSuccess, TError>(string url, object data) 
            where TSuccess : IEntity 
            where TError : IEntity
        {
            var serializedData = JsonConvert.SerializeObject(data);

            var response = await _client.PostAsync(url, new StringContent(serializedData, Encoding.UTF8, "application/json"));

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
