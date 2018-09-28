using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class MediaTemplatePayloadEntity : ITemplatePayloadEntity
    {
        [JsonProperty("template_type")]
        public string TemplateType { get; } = "media";

        // excatly 1 element
        [JsonProperty("elements")]
        public IList<MediaElementEntity> Elements { get; set; }

        [JsonProperty("sharable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Shareable { get; set; }
    }
}