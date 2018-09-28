namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents valid types of quick replies.
    /// </summary>
    public enum QuickReplyContentType
    {
        /// <summary>
        /// The quick reply will contain predefined text.
        /// </summary>
        Text,

        /// <summary>
        /// The quick reply will contain the current user location.
        /// </summary>
        Location,

        /// <summary>
        /// The quick reply will contain the phone number of the user.
        /// </summary>
        UserPhoneNumber,

        /// <summary>
        /// The quick reply will contain the email address of the user.
        /// </summary>
        UserEmail
    }
}