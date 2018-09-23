using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class ImageAttachmentEntity : IMessageAttachmentEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "image";

        [JsonProperty("payload")]
        public MediaPayloadEntity Payload { get; set; }
    }
}