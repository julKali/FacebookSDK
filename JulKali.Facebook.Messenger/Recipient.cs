namespace JulKali.Facebook.Messenger
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
