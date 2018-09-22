namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a recipient that is identified by user reference.
    /// </summary>
    public class UserReferenceRecipient : Recipient
    {
        /// <summary>
        /// Initializes a new recipient using the PSID.
        /// </summary>
        /// <param name="userRef">The user reference</param>
        public UserReferenceRecipient(string userRef) 
            : base(userRef)
        {
        }

        public override object ToRecipientJsonObject()
        {
            return new
            {
                user_ref = Identifier
            };
        }
    }
}