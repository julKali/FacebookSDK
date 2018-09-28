using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class MediaElementEntity
    {
        // [image, video]
        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        // either url or attachment
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaUrl { get; set; }

        [JsonProperty("attachment_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AttachmentId { get; set; }

        // optional, max 1 button
        [JsonProperty("buttons", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<IButtonEntity> Buttons { get; set; }
    }
}