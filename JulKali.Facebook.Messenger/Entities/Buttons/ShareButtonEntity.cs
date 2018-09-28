using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class ShareButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "element_share";

        [JsonProperty("share_contents")]
        public MessageEntity ShareContents { get; set; }
    }
}