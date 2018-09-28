namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents valid payment types. 
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// The purchase amount is fixed.
        /// </summary>
        FixedAmount,

        /// <summary>
        /// The purchase amount is flexible.
        /// </summary>
        FlexibleAmount
    }
}