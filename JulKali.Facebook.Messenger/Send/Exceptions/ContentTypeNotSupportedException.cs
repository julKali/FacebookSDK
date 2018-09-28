using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="QuickReplyContentType"/> is not supported.
    /// </summary>
    public class QuickReplyContentTypeNotSupportedException : Exception
    {
        public QuickReplyContentTypeNotSupportedException(QuickReplyContentType type)
            : base($"Invalid quick reply content type: {type.ToString()}")
        {
        }
    }
}