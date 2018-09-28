using System;

namespace JulKali.Facebook.Messenger.Send.Exceptions
{
    /// <summary>
    /// Thrown if the specified <see cref="PaymentType"/> is not supported.
    /// </summary>
    public class PaymentTypeNotSupportedException : Exception
    {
        public PaymentTypeNotSupportedException(PaymentType type)
            : base($"Invalid payment type: {type.ToString()}")
        {
        }
    }
}