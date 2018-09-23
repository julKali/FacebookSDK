using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class SendRequestContainerEntity
    {
        [JsonProperty("recipient")]
        public RecipientEntity Recipient { get; set; }

        [JsonProperty("messaging_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MessagingType { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public MessageEntity Message { get; set; }

        [JsonProperty("sender_action", NullValueHandling = NullValueHandling.Ignore)]
        public string SenderAction { get; set; }

        [JsonProperty("notification_type", NullValueHandling = NullValueHandling.Ignore)]
        public string NotificationType { get; set; }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }
    }
}
