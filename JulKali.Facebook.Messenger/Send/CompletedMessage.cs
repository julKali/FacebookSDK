using JulKali.Facebook.Entities;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a completed message that can be sent to the API.
    /// </summary>
    public class CompletedMessage
    {
        private readonly Message _message;

        internal CompletedMessage(Message message)
        {
            _message = message;
        }

        /// <summary>
        /// Returns a copy of the message entity.
        /// </summary>
        /// <returns></returns>
        internal MessageEntity GetMessageEntity()
        {
            // returns copy

            return _message.MessageEntity;
        }
    }
}