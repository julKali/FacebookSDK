using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class BuyButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "payment";

        [JsonProperty("title")]
        public string Title { get; } = "Buy";

        [JsonProperty("payload")]
        public string Payload { get; set; }

        [JsonProperty("payment_summary")]
        public BuyButtonPaymentSummaryEntity BuyButtonPaymentSummary { get; set; }
    }
}