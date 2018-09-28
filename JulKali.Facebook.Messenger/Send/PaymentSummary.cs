using System.Collections.Generic;
using System.Linq;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents payment details for <see cref="BuyButton"/> objects.
    /// </summary>
    public class PaymentSummary
    {
        private readonly string _currency;
        private readonly PaymentType _type;
        private readonly string _merchantName;
        private readonly IEnumerable<RequestableUserInfo> _userInfo;
        private readonly IEnumerable<ProductItem> _products;
        private readonly bool _isTestPayment;

        /// <summary>
        /// Initalizes a new <see cref="PaymentSummary"/> object.
        /// </summary>
        /// <param name="currency">The price currency.</param>
        /// <param name="paymentType">The payment type.</param>
        /// <param name="merchantName">The name of the merchant.</param>
        /// <param name="requestedUserInfo">Information requested from person that will render in the dialog</param>
        /// <param name="products">List of products. Is used to calculate total price.</param>
        /// <param name="isTestPayment">Whether this is a test payment. If true, the charge will be a dummy charge.</param>
        public PaymentSummary(
            string currency,
            PaymentType paymentType,
            string merchantName,
            IEnumerable<RequestableUserInfo> requestedUserInfo,
            IEnumerable<ProductItem> products,
            bool isTestPayment = false
        )
        {
            _currency = currency ?? throw new ValueException("Currency must be set");

            _type = paymentType;

            _merchantName = merchantName ?? throw new ValueException("Merchant name must be set");

            _userInfo = requestedUserInfo ?? throw new ValueException("Requested user info must be at least an empty instance.");

            _products = products ?? throw new ValueException("Products must be at least an empty instance.");

            _isTestPayment = isTestPayment;
        }

        /// <summary>
        /// Returns the payment summary as an <see cref="BuyButtonPaymentSummaryEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal BuyButtonPaymentSummaryEntity ToEntity()
        {
            var entity = new BuyButtonPaymentSummaryEntity
            {
                Currency = _currency,
                MerchantName = _merchantName,
                PriceList = _products.Select(_ => _.ToEntity()).ToList(),
                IsTestPayment = _isTestPayment ? (bool?) true : null,
                RequestedUserInfo = _userInfo.Select(_ =>
                {
                    switch (_)
                    {
                        case RequestableUserInfo.ShippingAddress:
                            return "shipping_address";

                        case RequestableUserInfo.ContactName:
                            return "contact_name";

                        case RequestableUserInfo.ContactPhone:
                            return "contact_phone";

                        case RequestableUserInfo.ContactEmail:
                            return "contact_email";

                        default:
                            throw new RequestableUserInfoNotSupportedException(_);
                    }
                })
            };

            switch (_type)
            {
                case PaymentType.FixedAmount:
                    entity.PaymentType = "FIXED_AMOUNT";
                    break;

                case PaymentType.FlexibleAmount:
                    entity.PaymentType = "FLEXIBLE_AMOUNT";
                    break;

                default:
                    throw new PaymentTypeNotSupportedException(_type);
            }

            return entity;
        }
    }
}