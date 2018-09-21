using System;

namespace JulKali.Facebook.Messenger
{
    public class SenderActionNotSupportedException : Exception
    {
        public SenderActionNotSupportedException(SenderAction action)
            : base($"Invalid sender action: {action.ToString()}")
        {
        }
    }
}