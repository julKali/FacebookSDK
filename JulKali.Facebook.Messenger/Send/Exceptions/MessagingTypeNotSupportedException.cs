using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="MessagingType"/> is not supported.
    /// </summary>
    public class MessagingTypeNotSupportedException : Exception
    {
        public MessagingTypeNotSupportedException(MessagingType type) 
            : base($"Invalid messaging type: {type.ToString()}")
        {
        }
    }
}