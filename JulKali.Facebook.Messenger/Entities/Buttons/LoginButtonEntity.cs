using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class LoginButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "account_link";

        [JsonProperty("url")]
        public string CallbackUrl { get; set; }
    }
}