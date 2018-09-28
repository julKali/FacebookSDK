using System.Text.RegularExpressions;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Call button that can be used inside a message template.
    /// </summary>
    public class CallButton : Button
    {
        private readonly string _title;
        private readonly string _payload;

        /// <summary>
        /// Initializes a new <see cref="CallButton"/> object.
        /// </summary>
        /// <param name="title">The text that is displayed to the user.</param>
        /// <param name="phoneNumber">The phone number that is called when the user clicks on the button.</param>
        public CallButton(string title, string phoneNumber)
        {
            if (title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (phoneNumber == null)
            {
                throw new ValueException("Phone number must be set.");
            }

            if (title.Length > 20)
            {
                throw new ValueException("Title must not exceed 20 characters.");
            }

            if (phoneNumber.Length > 1000)
            {
                throw new ValueException("Phone number must not exceed 1000 characters.");
            }

            var rgx = new Regex(@"^\+(\d)*$");

            if (!rgx.IsMatch(phoneNumber))
            {
                throw new ValueException("Phone number must have valid format: '+' prefix followed by country code, area code and local number.");
            }

            _title = title;
            _payload = phoneNumber;
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new CallButtonEntity
            {
                Title = _title,
                PhoneNumber = _payload
            };
        }
    }
}