using System;
using System.Net;

namespace JulKali.Facebook.Messenger
{
    /// <summary>
    /// Thrown if the API request returned an error.
    /// </summary>
    public class MessengerRequestFailedException : Exception
    {
        public MessengerRequestFailedException()
        {
        }

        public MessengerRequestFailedException(string messageType, string url, HttpStatusCode httpCode, int errorCode,
            string errorMessage, string trace, int? subCode)
            : base(BuildExceptionMessage(messageType, url, httpCode, errorCode, errorMessage, trace, subCode))
        {
        }

        public MessengerRequestFailedException(string messageType, string url, HttpStatusCode httpCode, int errorCode, 
            string errorMessage, string trace, int? subCode, Exception innerException)
            : base(BuildExceptionMessage(messageType, url, httpCode, errorCode, errorMessage, trace, subCode), innerException)
        {
        }

        private static string BuildExceptionMessage(string messageType, string url, HttpStatusCode httpCode, int errorCode,
            string errorMessage, string trace, int? subCode)
        {
            return
                $"Couldn't send {messageType} message. Call to {url} returned with code {httpCode}.\nError code: {errorCode}.{(subCode != null ? "\nError subcode: " + subCode + "." : "")}\nError message: {errorMessage}.\nTrace: {trace}";
        }
    }
}