namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents the root class for all kinds of message recipients. Cannot be used in any other way but as a parent class.
    /// </summary>
    public abstract class Recipient
    {
        protected readonly string Identifier;

        protected Recipient(string identifier)
        {
            Identifier = identifier;
        }

        public abstract object ToRecipientJsonObject();
    }
}
