namespace JulKali.Facebook.Messenger
{
    public class UserReferenceRecipient : Recipient
    {
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