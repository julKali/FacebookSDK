namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents valid messaging types.
    /// </summary>
    public enum MessagingType
    {
        /// <summary>
        /// Message is in response to a received message.
        /// </summary>
        Response,

        /// <summary>
        /// Message is being sent proactively and is not in response to a received message.
        /// </summary>
        Update,

        /// <summary>
        /// Message is non-promotional and is being sent with a message tag.
        /// </summary>
        MessageTag
    }
}