using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="MediaAttachmentType"/> is not supported.
    /// </summary>
    public class MediaAttachmentTypeNotSupportedException : Exception
    {
        public MediaAttachmentTypeNotSupportedException(MediaAttachmentType type)
            : base($"Invalid media attachment type: {type.ToString()}")
        {
        }
    }
}