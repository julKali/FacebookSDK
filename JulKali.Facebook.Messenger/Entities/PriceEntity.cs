using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class PriceEntity
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}