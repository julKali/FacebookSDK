using System.Net.Mime;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class QuickReplyEntity
    {
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string Payload { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }
    }
}