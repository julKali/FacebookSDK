using System;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents the default behavior when the user clicks on an element.
    /// </summary>
    public class DefaultAction
    {
        private readonly Uri _url;
        private WebviewHeightRatio _heightRatio = WebviewHeightRatio.Full;
        private bool _useMessengerExtensions;
        private Uri _fallbackUrl;
        private bool _hideShareButton;

        internal DefaultAction(Uri url)
        {
            _url = url;
        }

        /// <summary>
        /// Creates a new empty default action object by providing the URL as a <see cref="String"/>.
        /// </summary>
        /// <param name="url">The URL as <see cref="String"/>.</param>
        /// <returns></returns>
        public static DefaultAction Create(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                return new DefaultAction(uri);
            }

            throw new ValueException("URL must be a valid absolute URI.");
        }

        /// <summary>
        /// Creates a new empty default action object by providing the URL as a <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">The URL as a <see cref="Uri"/></param>
        /// <returns></returns>
        public static DefaultAction Create(Uri uri)
        {
            return new DefaultAction(uri);
        }

        /// <summary>
        /// Enables Messenger Extensions.
        /// </summary>
        /// <param name="fallbackUrl">Fallback URL if client doesn't support Messenger Extensions.</param>
        /// <param name="webviewHeightRatio">The height of the opened webview.</param>
        /// <returns></returns>
        public DefaultAction UseMessengerExtensions(string fallbackUrl, WebviewHeightRatio webviewHeightRatio)
        {
            if (_url.Scheme != Uri.UriSchemeHttps)
            {
                throw new ValueException("URL must be using the HTTPS protocol if using Messenger Extensions.");
            }

            if (Uri.TryCreate(fallbackUrl, UriKind.Absolute, out _fallbackUrl))
            {
                throw new ValueException("Fallback URL must be set and valid.");
            }

            _heightRatio = webviewHeightRatio;
            _useMessengerExtensions = true;

            return this;
        }

        /// <summary>
        /// Disables the share button in the webview.
        /// </summary>
        /// <returns></returns>
        public DefaultAction HideWebviewShareButton()
        {
            _hideShareButton = true;

            return this;
        }

        /// <summary>
        /// Returns the default action as a <see cref="DefaultActionEntity"/> object.
        /// </summary>
        /// <returns></returns>
        internal DefaultActionEntity ToEntity()
        {
            var entity = new DefaultActionEntity
            {
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
                entity.FallbackUrl = _fallbackUrl?.ToString() ?? throw new ValueException("Fallback URL must be set if using Messenger Extension.");
            }

            return entity;
        }
    }
}