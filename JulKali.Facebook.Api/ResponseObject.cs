using System.Net;

namespace JulKali.Facebook.Api
{
    /// <summary>
    /// Used to return information about an API request.
    /// </summary>
    /// <typeparam name="TSuccess">Type of the JSON encoded response content if request was successful.</typeparam>
    /// <typeparam name="TError">Type of the JSON encoded response content if request was not successful.</typeparam>
    public struct ResponseObject <TSuccess, TError>
        where TSuccess : IEntity
        where TError : IEntity
    {
        /// <summary>
        /// The HTTP status code of the response.
        /// </summary>
        public HttpStatusCode HttpCode { get; set; }

        /// <summary>
        /// Filled if the request was successful.
        /// </summary>
        public TSuccess Success { get; set; }

        /// <summary>
        /// Filled if the request was not successful.
        /// </summary>
        public TError Error { get; set; }
    }
}
