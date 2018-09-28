using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class GenericTemplatePayloadEntity : ITemplatePayloadEntity
    {
        [JsonProperty("template_type")]
        public string TemplateType { get; } = "generic";

        [JsonProperty("sharable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Shareable { get; set; }

        [JsonProperty("image_aspect_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageAspectRatio { get; set; }

        [JsonProperty("elements")]
        public IList<ElementEntity> Elements { get; set; }
    }
}