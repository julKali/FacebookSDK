using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class LogoutButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "account_unlink";
    }
}