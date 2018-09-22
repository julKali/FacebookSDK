using JulKali.Facebook.Api;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    public class MessengerErrorEntity : IEntity
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("error_subcode")]
        public int? SubCode { get; set; }

        [JsonProperty("fbtrace_id")]
        public string TraceId { get; set; }
    }
}
