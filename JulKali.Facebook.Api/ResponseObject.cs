using System.Net;

namespace JulKali.Facebook.Api
{
    public class ResponseObject <TSuccess, TError>
        where TSuccess : IEntity
        where TError : IEntity
    {
        public HttpStatusCode HttpCode { get; set; }

        public TSuccess Success { get; set; }

        public TError Error { get; set; }
    }
}
