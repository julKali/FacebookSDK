using System;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a message that contains an attachment.
    /// </summary>
    public class AttachmentMessage : Message
    {
        /// <summary>
        /// Creates a media attachment.
        /// </summary>
        /// <param name="type">The media type.</param>
        /// <param name="identifier">The media identifier to specify the media source.</param>
        /// <returns></returns>
        public MessageOptionalElementSetter CreateMediaAttachment(MediaAttachmentType type, MediaIdentifier identifier)
        {
            CheckIfAttachmentAlreadyBuilt();

            TemplateBuilding = true;

            var payload = new MediaPayloadEntity();

            identifier.AddValuesToPayloadEntity(payload);

            IMessageAttachmentEntity attachment;

            switch (type)
            {
                case MediaAttachmentType.Audio:
                    attachment = new AudioAttachmentEntity
                    {
                        Payload = payload
                    };
                    break;

                case MediaAttachmentType.Image:
                    attachment = new ImageAttachmentEntity
                    {
                        Payload = payload
                    };
                    break;

                case MediaAttachmentType.Video:
                    attachment = new VideoAttachmentEntity
                    {
                        Payload = payload
                    };
                    break;

                case MediaAttachmentType.File:
                    attachment = new FileAttachmentEntity
                    {
                        Payload = payload
                    };
                    break;

                default:
                    throw new MediaAttachmentTypeNotSupportedException(type);
            }

            MessageEntity.Attachment = attachment;
            TemplateBuilding = false;

            return new MessageOptionalElementSetter(this);
        }

        /// <summary>
        /// Starts building a template attachment.
        /// </summary>
        /// <returns></returns>
        public AttachmentTemplateRouter StartBuildingTemplateAttachment()
        {
            CheckIfAttachmentAlreadyBuilt();

            return new AttachmentTemplateRouter(this);
        }

        /// <summary>
        /// Returns whether the message attachment is set.
        /// </summary>
        private void CheckIfAttachmentAlreadyBuilt()
        {
            if (MessageEntity.Attachment != null)
            {
                throw new InvalidOperationException("An attachment has already been built for this message.");
            }
        }
    }
}