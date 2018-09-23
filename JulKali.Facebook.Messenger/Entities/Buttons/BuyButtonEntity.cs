namespace JulKali.Facebook.Entities
{
    internal class BuyButtonEntity : IButtonEntity
    {
        public string Type { get; } = "payment";

        public string Title { get; } = "Buy";

        public string Payload { get; set; }

        public BuyButtonPaymentSummaryEntity BuyButtonPaymentSummary { get; set; }
    }
}