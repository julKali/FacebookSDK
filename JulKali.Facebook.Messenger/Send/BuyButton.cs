using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Buy button that can be used inside a message template.
    /// </summary>
    public class BuyButton : Button
    {
        private readonly string _payload;
        private readonly PaymentSummary _summary;

        /// <summary>
        /// Initializes a new <see cref="BuyButton"/> object.
        /// </summary>
        /// <param name="payload">The payload returned if the user clicks on the button. Limited to 1000 characters.</param>
        /// <param name="paymentSummary">The payment summary of the purchase.</param>
        public BuyButton(string payload, PaymentSummary paymentSummary)
        {
            if (payload == null)
            {
                throw new ValueException("Payload must be set.");
            }

            if (payload.Length > 1000)
            {
                throw new ValueException("Payload must not exceed 1000 characters.");
            }

            _summary = paymentSummary ?? throw new ValueException("Payment summary must be set.");
            
            _payload = payload;
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new BuyButtonEntity
            {
                Payload = _payload,
                BuyButtonPaymentSummary = _summary.ToEntity()
            };
        }
    }
}