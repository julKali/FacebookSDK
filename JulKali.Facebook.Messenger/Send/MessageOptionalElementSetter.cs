using System;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a message which's attachment or text has been set and accepts quick replies or metadata.
    /// </summary>
    public class MessageOptionalElementSetter
    {
        private readonly Message _message;

        internal MessageOptionalElementSetter(Message message)
        {
            _message = message;
        }

        /// <summary>
        /// Adds a quick reply of type <see cref="QuickReplyContentType.Text"/> to the message entity.
        /// </summary>
        /// <param name="title">The text displayed on the quick reply. Limited to 20 characters.</param>
        /// <param name="payload">The payload returned if the user clicks on the quick reply. Limited to 1000 characters.</param>
        /// <param name="imageUrl">An optional image visible to the user.</param>
        public MessageOptionalElementSetter AddTextQuickReply(string title, string payload, string imageUrl = null)
        {
            _message.AddTextQuickReply(title, payload, imageUrl);
            return this;
        }

        /// <summary>
        /// Adds a quick reply of type <see cref="QuickReplyContentType.Location"/>, <see cref="QuickReplyContentType.UserEmail"/> or <see cref="QuickReplyContentType.UserPhoneNumber"/>.
        /// </summary>
        /// <param name="type">The quick reply type. Must not be Text.</param>
        public MessageOptionalElementSetter AddQuickReply(QuickReplyContentType type)
        {
            _message.AddQuickReply(type);
            return this;
        }

        /// <summary>
        /// Sets a metadata string for the message.
        /// </summary>
        /// <param name="metadata">The metadata string.</param>
        public MessageOptionalElementSetter SetMetadata(string metadata)
        {
            _message.SetMetadata(metadata);
            return this;
        }

        /// <summary>
        /// Returns a completed message that is ready to be sent to the API.
        /// </summary>
        /// <returns></returns>
        public CompletedMessage ReturnCompletedMessage()
        {
            if (_message.TemplateBuilding)
            {
                throw new InvalidOperationException("Message template has not been built. Call method BuildTemplate.");
            }

            return new CompletedMessage(_message);
        }
    }
}