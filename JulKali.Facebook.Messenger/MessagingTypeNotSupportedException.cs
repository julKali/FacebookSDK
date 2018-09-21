using System;

namespace JulKali.Facebook.Messenger
{
    public class MessagingTypeNotSupportedException : Exception
    {
        public MessagingTypeNotSupportedException(MessagingType type) 
            : base($"Invalid messaging type: {type.ToString()}")
        {
        }
    }
}