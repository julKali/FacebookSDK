using System;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a Login button that can be used inside a message template.
    /// </summary>
    public class LoginButton : Button
    {
        private readonly Uri _url;

        /// <summary>
        /// Initialzes a new <see cref="LoginButton"/> object.
        /// </summary>
        /// <param name="url">The authentication callback URL. Must be using HTTPS.</param>
        public LoginButton(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
            {
                throw new ValueException("URL must be a valid absolute URI.");
            }

            if (uri.Scheme != Uri.UriSchemeHttps)
            {
                throw new ValueException("URL must using HTTPS protocol.");
            }

            _url = uri;
        }

        /// <inheritdoc />
        internal override IButtonEntity ToEntity()
        {
            return new LoginButtonEntity
            {
                CallbackUrl = _url.ToString()
            };
        }
    }
}