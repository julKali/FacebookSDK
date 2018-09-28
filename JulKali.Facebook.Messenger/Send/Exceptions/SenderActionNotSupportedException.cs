using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="SenderAction"/> is not supported.
    /// </summary>
    public class SenderActionNotSupportedException : Exception
    {
        public SenderActionNotSupportedException(SenderAction action)
            : base($"Invalid sender action: {action.ToString()}")
        {
        }
    }
}