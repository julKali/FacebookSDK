using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class VideoAttachmentEntity : IMessageAttachmentEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "video";

        [JsonProperty("payload")]
        public MediaPayloadEntity Payload { get; set; }
    }
}