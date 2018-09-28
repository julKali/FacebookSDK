using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class GameMetadataContextIdEntity : IGameMetadataEntity
    {
        [JsonProperty("context_id")]
        public string ContextId { get; set; }
    }
}