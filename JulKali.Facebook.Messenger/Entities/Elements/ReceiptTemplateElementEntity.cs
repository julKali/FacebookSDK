namespace JulKali.Facebook.Entities
{
    internal class ReceiptTemplateElementEntity
    {
        public string Title { get; set; }

        // optional
        public string SubTitle { get; set; }

        // optional
        public decimal Quantity { get; set; }

        // if free: 0
        public decimal Price { get; set; }

        // optional
        public string Currency { get; set; }

        // optional
        public string ImageUrl { get; set; }
    }
}