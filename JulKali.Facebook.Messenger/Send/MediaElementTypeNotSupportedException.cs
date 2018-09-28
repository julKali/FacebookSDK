using System;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Thrown if the specified <see cref="MediaElementType"/> is not supported.
    /// </summary>
    public class MediaElementTypeNotSupportedException : Exception
    {
        public MediaElementTypeNotSupportedException(MediaElementType type)
            : base($"Invalid media type for media element: {type.ToString()}")
        {
        }
    }
}