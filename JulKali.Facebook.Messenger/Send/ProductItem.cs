using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a product as listed in <see cref="PaymentSummary"/> objects.
    /// </summary>
    public class ProductItem
    {
        private readonly string _label;
        private readonly string _price;

        /// <summary>
        /// Initializes a new <see cref="ProductItem"/> object.
        /// </summary>
        /// <param name="label">The product name.</param>
        /// <param name="price">The product price without the currency symbol.</param>
        public ProductItem(string label, string price)
        {
            _label = label ?? throw new ValueException("Label must be set.");

            _price = price ?? throw new ValueException("Price must be set.");
        }

        /// <summary>
        /// Returns the product item as a <see cref="PriceEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal PriceEntity ToEntity()
        {
            return new PriceEntity
            {
                Label = _label,
                Amount = _price
            };
        }
    }
}