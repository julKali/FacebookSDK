using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    public class CallButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "phone_number";

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("payload")]
        public string PhoneNumber { get; set; }
    }
}