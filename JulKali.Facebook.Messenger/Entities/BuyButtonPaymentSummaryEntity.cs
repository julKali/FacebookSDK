using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class BuyButtonPaymentSummaryEntity
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("is_test_payment", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsTestPayment { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        [JsonProperty("requested_user_info")]
        public IEnumerable<string> RequestedUserInfo { get; set; }
        
        [JsonProperty("price_list")]
        public IEnumerable<PriceEntity> PriceList { get; set; }

    }
}