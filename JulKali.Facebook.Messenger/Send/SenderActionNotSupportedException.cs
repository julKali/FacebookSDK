using System;

namespace JulKali.Facebook.Messenger.Send
{
    public class SenderActionNotSupportedException : Exception
    {
        public SenderActionNotSupportedException(SenderAction action)
            : base($"Invalid sender action: {action.ToString()}")
        {
        }
    }
}