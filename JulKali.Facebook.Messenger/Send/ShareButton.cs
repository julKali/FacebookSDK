using System.Collections.Generic;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Share button that can be used inside a message template.
    /// </summary>
    public class ShareButton : Button
    {
        private readonly MessageEntity _content;

        /// <summary>
        /// Initializes a new <see cref="ShareButton"/> object.
        /// </summary>
        /// <param name="title">The shared element title. Limited to 80 characters.</param>
        /// <param name="subtitle">The shared element subtitle. Limited to 80 characters.</param>
        /// <param name="imageUrl">The URL of an optional iamge that may be included by the shared element.</param>
        /// <param name="defaultAction">An optional shared element default onclick behavior.</param>
        /// <param name="button">An optional button added to the shared element.</param>
        /// <param name="isShareable">Sets whether the native share button in Messenger is enabled for the shared element.</param>
        /// <param name="imageAspectRatio">Sets the image aspect ratio of the image in the shared element if it is set.</param>
        public ShareButton(
            string title,
            string subtitle = null,
            string imageUrl = null,
            DefaultAction defaultAction = null,
            UrlButton button = null,
            bool isShareable = false,
            ImageAspectRatio imageAspectRatio = ImageAspectRatio.Horizontal
            )
        {
            if (title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (title.Length > 80)
            {
                throw new ValueException("Title must not exceed 80 characters.");
            }

            if (subtitle != null && subtitle.Length > 80)
            {
                throw new ValueException("Subtitle must not exceed 80 characters.");
            }

            var payload = new GenericTemplatePayloadEntity
            {
                Shareable = isShareable ? (bool?) true : null,
                Elements = new List<ElementEntity>()
            };

            switch (imageAspectRatio)
            {
                case ImageAspectRatio.Horizontal:
                    break;

                case ImageAspectRatio.Square:
                    payload.ImageAspectRatio = "square";
                    break;

                default:
                    throw new ImageAspectRatioNotSupportedException(imageAspectRatio);
            }

            payload.Elements.Add(new ElementEntity
            {
                Title = title, 
                SubTitle = subtitle,
                ImageUrl = imageUrl,
                DefaultAction = defaultAction?.ToEntity(),
                Buttons = button != null ? new List<IButtonEntity>
                {
                    button.ToEntity()
                } : new List<IButtonEntity>()
            });

            var attachment = new TemplateAttachmentEntity
            {
                Payload = payload
            };

            _content = new MessageEntity
            {
                Attachment = attachment
            };
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new ShareButtonEntity
            {
                ShareContents = _content
            };
        }
    }
}