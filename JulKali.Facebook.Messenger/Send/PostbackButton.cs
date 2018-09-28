using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Postback button that can be used inside a message template.
    /// </summary>
    public class PostbackButton : Button
    {
        private readonly string _title;
        private readonly string _payload;

        /// <summary>
        /// Initializes a new <see cref="PostbackButton"/> object.
        /// </summary>
        /// <param name="title">The text displayed on the button. Limited to 20 characters.</param>
        /// <param name="payload">The payload returned if the user clicks on the button. Limited to 1000 characters.</param>
        public PostbackButton(string title, string payload)
        {
            if (title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (payload == null)
            {
                throw new ValueException("Payload must be set.");
            }

            if (title.Length > 20)
            {
                throw new ValueException("Title must not exceed 20 characters.");
            }

            if (payload.Length > 1000)
            {
                throw new ValueException("Payload must not exceed 1000 characters.");
            }

            _title = title;
            _payload = payload;
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new PostbackButtonEntity
            {
                Title = _title,
                Payload = _payload
            };
        }
    }
}