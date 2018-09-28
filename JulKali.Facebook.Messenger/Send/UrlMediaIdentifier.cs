using System;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a URL to identify media inside a media template.
    /// </summary>
    public class UrlMediaIdentifier : MediaIdentifier
    {
        private readonly Uri _url;
        private readonly bool _isReusable;

        /// <summary>
        /// </summary>
        /// <param name="mediaUrl">The media URL.</param>
        /// <param name="isReusable">If true, media can be reused through an attachment ID returned by the API when sending the message.</param>
        public UrlMediaIdentifier(string mediaUrl, bool isReusable = false)
        {
            if (!Uri.TryCreate(mediaUrl, UriKind.Absolute, out _url))
            {
                throw new ValueException("Media URL must be a valid absolute URI.");
            }

            _isReusable = isReusable;
        }

        /// <summary>
        /// Adds URL and IsReusable value to the payload.
        /// </summary>
        /// <param name="payload">The media payload.</param>
        internal override void AddValuesToPayloadEntity(MediaPayloadEntity payload)
        {
            payload.MediaUrl = _url.ToString();
            payload.IsReusable = _isReusable;
        }
    }
}