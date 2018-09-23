namespace JulKali.Facebook.Entities
{
    internal class ReceiptTemplateAddressEntity
    {
        public string Street1 { get; set; }

        // optional
        public string Street2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
    }
}