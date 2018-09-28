using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="RequestableUserInfo"/> is not supported.
    /// </summary>
    public class RequestableUserInfoNotSupportedException : Exception
    {
        public RequestableUserInfoNotSupportedException(RequestableUserInfo ratio)
            : base($"Invalid user information: {ratio.ToString()}")
        {
        }
    }
}
