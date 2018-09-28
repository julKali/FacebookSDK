using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class ButtonTemplatePayloadEntity : ITemplatePayloadEntity
    {
        [JsonProperty("template_type")]
        public string TemplateType { get; } = "button";

        //max 640 characters
        [JsonProperty("text")]
        public string Text { get; set; }

        // 1-3 buttons
        [JsonProperty("buttons")]
        public IEnumerable<IButtonEntity> Buttons { get; set; }

        [JsonProperty("sharable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Shareable { get; set; }
    }
}