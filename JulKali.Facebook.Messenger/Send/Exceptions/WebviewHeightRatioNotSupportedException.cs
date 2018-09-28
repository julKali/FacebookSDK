using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="WebviewHeightRatio"/> is not supported.
    /// </summary>
    public class WebviewHeightRatioNotSupportedException : Exception
    {
        public WebviewHeightRatioNotSupportedException(WebviewHeightRatio ratio)
            : base($"Invalid webview height ratio: {ratio.ToString()}")
        {
        }
    }
}