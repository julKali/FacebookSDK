using JulKali.Facebook.Api;
using Newtonsoft.Json;

namespace JulKali.Facebook.Messenger.Entities
{
    public class SendMessageResponse : IEntity
    {
        [JsonProperty("recipient_id")]
        public string RecipientId { get; set; }

        [JsonProperty("message_id")]
        public string MessageId { get; set; }
    }
}
