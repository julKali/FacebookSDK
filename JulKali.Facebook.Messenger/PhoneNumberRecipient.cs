namespace JulKali.Facebook.Messenger
{
    public class PhoneNumberRecipient : Recipient
    {
        public PhoneNumberRecipient(string phoneNumber) 
            : base(phoneNumber)
        {
        }

        public override object ToRecipientJsonObject()
        {
            return new
            {
                phone_number = Identifier
            };
        }
    }
}