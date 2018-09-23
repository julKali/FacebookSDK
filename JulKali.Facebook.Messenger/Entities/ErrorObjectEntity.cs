using JulKali.Facebook.Api;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class MessengerErrorWrapperEntity : IEntity
    {
        [JsonProperty("error")]
        public MessengerErrorEntity MessengerError { get; set; }
    }
}
