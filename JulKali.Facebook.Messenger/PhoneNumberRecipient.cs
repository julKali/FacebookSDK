namespace JulKali.Facebook.Messenger
{
    public class PhoneNumberRecipient : Recipient
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly bool _nameSupplied;

        public PhoneNumberRecipient(string phoneNumber) 
            : base(phoneNumber)
        {
        }

        public PhoneNumberRecipient(string phoneNumber, string firstName, string lastName)
            : base(phoneNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _nameSupplied = true;
        }

        public override object ToRecipientJsonObject()
        {
            if (_nameSupplied)
            {
                return new
                {
                    phone_number = Identifier,
                    name = new
                    {
                        first_name = _firstName,
                        last_name = _lastName
                    }
                };
            }

            return new
            {
                phone_number = Identifier
            };
        }
    }
}