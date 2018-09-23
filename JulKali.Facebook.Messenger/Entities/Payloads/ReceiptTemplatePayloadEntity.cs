namespace JulKali.Facebook.Entities
{
    internal class ReceiptTemplatePayloadEntity : ITemplatePayloadEntity
    {
        public string TemplateType { get; } = "receipt";

        // optional
        public bool Shareable { get; set; }

        public string RecipientName { get; set; }

        // optional
        public string MerchantName { get; set; }

        public string OrderNumber { get; set; }

        public string Currency { get; set; }

        public string PaymentMethod { get; set; }

        // optional, in secs
        public string Timestamp { get; set; }

        // optional, max 100, no sort order
        public ReceiptTemplateElementEntity[] Elements { get; set; }

        // optional
        public ReceiptTemplateAddressEntity ReceiptTemplateAddress { get; set; }

        public ReceiptTemplateSummaryEntity Summary { get; set; }

        // optional
        public ReceiptTemplateAdjustmentEntity[] Adjustments { get; set; }
    }
}