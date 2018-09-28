using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class ElementEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SubTitle { get; set; }

        [JsonProperty("image_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageUrl { get; set; }

        [JsonProperty("default_action", NullValueHandling = NullValueHandling.Ignore)]
        public DefaultActionEntity DefaultAction { get; set; }

        [JsonProperty("buttons", NullValueHandling = NullValueHandling.Ignore)]
        public List<IButtonEntity> Buttons { get; set; }
    }
}