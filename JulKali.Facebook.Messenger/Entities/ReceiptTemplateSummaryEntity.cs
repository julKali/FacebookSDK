namespace JulKali.Facebook.Entities
{
    internal class ReceiptTemplateSummaryEntity
    {
        // optional
        public decimal SubTotal { get; set; }

        // optional
        public decimal ShippingCost { get; set; }

        // optional
        public decimal TotalTax { get; set; }

        public decimal TotalCost { get; set; }
    }
}