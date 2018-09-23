using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class MediaPayloadEntity : IPayloadEntity
    {
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaUrl { get; set; }

        [JsonProperty("is_reusable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsReusable { get; set; }

        [JsonProperty("attachment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentId { get; set; }
    }
}