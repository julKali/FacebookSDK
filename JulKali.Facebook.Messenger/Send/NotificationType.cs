namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents valid message notification types. Specifies what type of push notification is used for the message.
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Sound and vibration.
        /// </summary>
        Regular,

        /// <summary>
        /// On-screen notification only.
        /// </summary>
        SilentPush,

        /// <summary>
        /// No notification.
        /// </summary>
        NoPush
    }
}