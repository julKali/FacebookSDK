using JulKali.Facebook.Api;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    class SenderActionMessage : IEntity
    {
        [JsonProperty("recipient")]
        public object Recipient { get; set; }

        [JsonProperty("sender_action")]
        public string SenderAction { get; set; }
    }
}
