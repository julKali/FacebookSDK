using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class TemplateAttachmentEntity : IMessageAttachmentEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "template";

        [JsonProperty("payload")]
        public ITemplatePayloadEntity Payload { get; set; }
    }
}