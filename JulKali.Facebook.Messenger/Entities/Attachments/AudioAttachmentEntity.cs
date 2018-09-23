using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class AudioAttachmentEntity : IMessageAttachmentEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "audio";

        [JsonProperty("payload")]
        public MediaPayloadEntity Payload { get; set; }
    }
}