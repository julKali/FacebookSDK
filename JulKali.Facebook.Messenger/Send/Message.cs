using System;
using System.Collections.Generic;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a message that can contain text or an attachment and can be send to the Facebook Graph API.
    /// </summary>
    public abstract class Message
    {
        internal MessageEntity MessageEntity = new MessageEntity();
        internal bool TemplateBuilding;

        /// <summary>
        /// Makes sure that the quick reply array inside the message entity has been intialized.
        /// </summary>
        private void AssureQuickReplyCreated()
        {
            if (MessageEntity.QuickReplies == null)
            {
                MessageEntity.QuickReplies = new List<QuickReplyEntity>();
            }
        }

        /// <summary>
        /// Adds a quick reply of type <see cref="QuickReplyContentType.Text"/> to the message entity.
        /// </summary>
        /// <param name="title">The text displayed on the quick reply. Limited to 20 characters.</param>
        /// <param name="payload">The payload returned if the user clicks on the quick reply. Limited to 1000 characters.</param>
        /// <param name="imageUrl">An optional image visible to the user.</param>
        internal void AddTextQuickReply(string title, string payload, string imageUrl = null)
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

            if (title == string.Empty && imageUrl != null)
            {
                throw new ValueException("Image URL must be set if title is an empty string.");
            }

            if (imageUrl != null && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            {
                throw new ValueException("Image URL must be a valid URI");
            }

            AssureQuickReplyCreated();

            MessageEntity.QuickReplies.Add(new QuickReplyEntity
            {
                ContentType = "text",
                Title = title,
                Payload = payload,
                ImageUrl = imageUrl
            });
        }

        /// <summary>
        /// Adds a quick reply of type <see cref="QuickReplyContentType.Location"/>, <see cref="QuickReplyContentType.UserEmail"/> or <see cref="QuickReplyContentType.UserPhoneNumber"/>.
        /// </summary>
        /// <param name="type">The quick reply type. Must not be Text.</param>
        internal void AddQuickReply(QuickReplyContentType type)
        {
            //todo check if postback is also sent if type is not Text

            switch (type)
            {
                case QuickReplyContentType.Text:
                    throw new ArgumentException("Type must not be 'Text'. Call method AddTextQuickReply.");

                case QuickReplyContentType.Location:
                    AssureQuickReplyCreated();
                    MessageEntity.QuickReplies.Add(new QuickReplyEntity
                    {
                        ContentType = "location"
                    });
                    break;

                case QuickReplyContentType.UserPhoneNumber:
                    AssureQuickReplyCreated();
                    MessageEntity.QuickReplies.Add(new QuickReplyEntity
                    {
                        ContentType = "user_phone_number"
                    });
                    break;

                case QuickReplyContentType.UserEmail:
                    AssureQuickReplyCreated();
                    MessageEntity.QuickReplies.Add(new QuickReplyEntity
                    {
                        ContentType = "user_email"
                    });
                    break;

                default:
                    throw new QuickReplyContentTypeNotSupportedException(type);
            }
        }

        /// <summary>
        /// Sets a metadata string for the message.
        /// </summary>
        /// <param name="metadata">The metadata string.</param>
        internal void SetMetadata(string metadata)
        {
            MessageEntity.Metadata = metadata;
        }
    }
}
