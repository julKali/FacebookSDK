using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a message that contains text.
    /// </summary>
    public class TextMessage : Message
    {
        /// <summary>
        /// Sets the message text.
        /// </summary>
        /// <param name="text">The message text. Limited to 2000 characters.</param>
        /// <returns></returns>
        public MessageOptionalElementSetter SetText(string text)
        {
            if (text.Length > 2000)
            {
                throw new ValueException("Text must not exceed 2000 characters.");
            }

            MessageEntity.Text = text;

            return new MessageOptionalElementSetter(this);
        }
    }
}