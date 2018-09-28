namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents valid parts of user information that can be requested using <see cref="PaymentSummary"/> objects.
    /// </summary>
    public enum RequestableUserInfo
    {
        /// <summary>
        /// The user address for shipping.
        /// </summary>
        ShippingAddress,

        /// <summary>
        /// The user full name for contacting.
        /// </summary>
        ContactName,

        /// <summary>
        /// The user phone number for contacting.
        /// </summary>
        ContactPhone,

        /// <summary>
        /// The user email address for contacting.
        /// </summary>
        ContactEmail
    }
}