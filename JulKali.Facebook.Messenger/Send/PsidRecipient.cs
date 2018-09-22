namespace JulKali.Facebook.Messenger.Send
{
    public class PsidRecipient : Recipient
    {
        public PsidRecipient(string psid)
            : base(psid)
        {
        }

        public override object ToRecipientJsonObject()
        {
            return new
            {
                id = Identifier
            };
        }
    }
}