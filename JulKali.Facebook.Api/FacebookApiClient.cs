using System.Net.Http;

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
    }
}
