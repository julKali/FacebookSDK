using System;
using System.Collections.Generic;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents an element containing media that is used by media templates.
    /// </summary>
    public class MediaElement
    {
        private readonly string _type;
        private readonly string _attachmentId;
        private readonly Uri _mediaUrl;
        private readonly Button _button;

        private MediaElement(string type, string attachmentId, Uri mediaUrl, Button button)
        {
            if ((attachmentId == null) == (mediaUrl == null))
            {
                throw new ValueException("Either attachment ID or media URL must be set.");
            }

            _type = type ?? throw new ValueException("Type must be set.");

            _attachmentId = attachmentId;
            _mediaUrl = mediaUrl;
            _button = button;
        }

        /// <summary>
        /// Initiate a new <see cref="MediaElement"/> class using an attachment ID.
        /// </summary>
        /// <param name="mediaType">The media type.</param>
        /// <param name="attachmentId">The attachment ID.</param>
        /// <param name="button">An optional button below the media.</param>
        /// <returns></returns>
        public static MediaElement CreateByAttachmentId(MediaElementType mediaType, string attachmentId, Button button = null)
        {
            if (attachmentId == null)
            {
                throw new ValueException("Attachment ID must be set.");
            }

            return new MediaElement(GetMediaElementTypeString(mediaType), attachmentId, null, button);
        }

        /// <summary>
        /// Initiate a new <see cref="MediaElement"/> class using a URL.
        /// </summary>
        /// <param name="mediaType">The media type.</param>
        /// <param name="mediaUrl">The media URL.</param>
        /// <param name="button">An optional button below the media.</param>
        /// <returns></returns>
        public static MediaElement CreateByMediaUrl(MediaElementType mediaType, string mediaUrl, Button button = null)
        {
            if (!Uri.TryCreate(mediaUrl, UriKind.Absolute, out var validUrl))
            {
                throw new ValueException("Media URL must be set and valid.");
            }

            if (validUrl.Host != "www.facebook.com" && validUrl.Host != "business.facebook.com")
            {
                throw new ValueException("URL must be a Facebook URL.");
            }

            return new MediaElement(GetMediaElementTypeString(mediaType), null, validUrl, button);
        }

        /// <summary>
        /// Returns the string representation of <see cref="MediaElementType"/>.
        /// </summary>
        /// <param name="type">The type as an enum.</param>
        /// <returns></returns>
        private static string GetMediaElementTypeString(MediaElementType type)
        {
            switch (type)
            {
                case MediaElementType.Image:
                    return "image";

                case MediaElementType.Video:
                    return "video";

                default:
                    throw new MediaElementTypeNotSupportedException(type);
            }
        }

        /// <summary>
        /// Returns the media element as a <see cref="MediaElementEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal MediaElementEntity ToEntity()
        {
            var entity = new MediaElementEntity
            {
                MediaType = _type,
                AttachmentId = _attachmentId,
                MediaUrl = _mediaUrl?.ToString(),
                Buttons = _button != null ? new List<IButtonEntity> { _button.ToEntity() } : new List<IButtonEntity>()
            };

            return entity;
        }
    }
}