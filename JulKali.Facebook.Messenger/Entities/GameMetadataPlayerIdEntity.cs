using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class GameMetadataPlayerIdEntity : IGameMetadataEntity
    {
        [JsonProperty("player_id")]
        public string PlayerId { get; set; }
    }
}