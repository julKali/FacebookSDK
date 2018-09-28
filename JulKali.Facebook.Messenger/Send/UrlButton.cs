using System;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a URL button that can be used inside a message template.
    /// </summary>
    public class UrlButton : Button
    {
        private readonly string _title;
        private readonly Uri _url;
        private readonly WebviewHeightRatio _heightRatio;
        private readonly bool _useMessengerExtensions;
        private readonly Uri _fallbackUrl;
        private readonly bool _hideShareButton;

        /// <summary>
        /// Initializes a new <see cref="UrlButton"/> object.
        /// </summary>
        /// <param name="title">The text displayed on the button. Limited to 20 characters.</param>
        /// <param name="url">The URL the user is sent to on click.</param>
        /// <param name="fallBackUrl">The fallback URL if Messenger Extensions is not supported by the client. Settings this automatically enables Messenger Extensions.</param>
        /// <param name="webviewHeightRatio">The height of the webview. Only has effect if Messenger Extensions is enabled.</param>
        /// <param name="hideShareButton">True to disable the share button in the webview.</param>
        public UrlButton(
            string title,
            string url,
            string fallBackUrl = null,
            WebviewHeightRatio webviewHeightRatio = WebviewHeightRatio.Full,
            bool hideShareButton = false
        )
        {
            if (title == null)
            {
                throw new ValueException("Title must be set.");
            }

            if (title.Length > 20)
            {
                throw new ValueException("Title must not exceed 20 characters.");
            }

            if (!Uri.TryCreate(url, UriKind.Absolute, out _url))
            {
                throw new ValueException("URL must be a valid absolute URI.");
            }

            if (fallBackUrl != null)
            {
                if (_url.Scheme != Uri.UriSchemeHttps)
                {
                    throw new ValueException("URL must be using the HTTPS protocol if using Messenger Extensions.");
                }


                if (!Uri.TryCreate(fallBackUrl, UriKind.Absolute, out _fallbackUrl))
                {
                    throw new ValueException("Fallback URL must be a valid absolute URI.");
                }

                _useMessengerExtensions = true;
            }

            _title = title;
            _heightRatio = webviewHeightRatio;

            _hideShareButton = hideShareButton;
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            var entity = new UrlButtonEntity
            {
                Title = _title,
                Url = _url.ToString(),
                WebviewShareButton = _hideShareButton ? "hide" : null
            };

            switch (_heightRatio)
            {
                case WebviewHeightRatio.Full:
                    break;

                case WebviewHeightRatio.Compact:
                    entity.WebviewHeightRatio = "compact";
                    break;

                case WebviewHeightRatio.Tall:
                    entity.WebviewHeightRatio = "tall";
                    break;

                default:
                    throw new WebviewHeightRatioNotSupportedException(_heightRatio);
            }

            if (_useMessengerExtensions)
            {
                entity.MessengerExtensions = true;
                entity.FallbackUrl = _fallbackUrl.ToString();
            }

            return entity;
        }
    }
}