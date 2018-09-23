using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class FileAttachmentEntity : IMessageAttachmentEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "file";

        [JsonProperty("payload")]
        public MediaPayloadEntity Payload { get; set; }
    }
}