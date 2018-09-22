namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents valid message types.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Standard message. Can be sent within 24 hours after the last received message from the recipient. After the deadline there can only be sent one more message.
        /// </summary>
        Standard,

        /// <summary>
        /// Non-promotional subscription message. May be sent outside the 24-hour window.
        /// </summary>
        Subscription
    }
}