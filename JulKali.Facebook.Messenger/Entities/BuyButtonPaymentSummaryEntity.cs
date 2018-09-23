namespace JulKali.Facebook.Entities
{
    internal class BuyButtonPaymentSummaryEntity
    {
        public string Currency { get; set; }

        public string PaymentType { get; set; }

        public bool? IsTestPayment { get; set; }

        public string MerchantName { get; set; }

        public string[] RequestedUserInfo { get; set; }

        public PriceEntity[] PriceList { get; set; }

    }
}