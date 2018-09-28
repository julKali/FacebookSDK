using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if values are set incorrectly.
    /// </summary>
    public class ValueException : Exception
    {
        public ValueException()
        {
        }

        public ValueException(string message)
            : base(message)
        {
        }

        public ValueException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}