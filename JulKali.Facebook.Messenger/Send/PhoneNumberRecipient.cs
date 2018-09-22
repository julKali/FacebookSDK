namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a recipient that is identified by phone number.
    /// </summary>
    public class PhoneNumberRecipient : Recipient
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly bool _nameSupplied;

        /// <summary>
        /// Initializes a new recipient using the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number</param>
        public PhoneNumberRecipient(string phoneNumber) 
            : base(phoneNumber)
        {
        }

        /// <summary>
        /// Initializes a new recipient using the phone number and first and last name.
        /// </summary>
        /// <param name="phoneNumber">The phone number</param>
        /// <param name="firstName">The first name</param>
        /// <param name="lastName">The last name</param>
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