namespace JulKali.Facebook.Messenger.Send
{
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
