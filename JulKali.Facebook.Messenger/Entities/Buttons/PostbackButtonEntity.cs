using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class PostbackButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "postback";

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}