using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class GamePlayButtonEntity : IButtonEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "game_play";

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("payload", NullValueHandling = NullValueHandling.Ignore)]
        public string Payload { get; set; }

        [JsonProperty("game_metadata", NullValueHandling = NullValueHandling.Ignore)]
        public IGameMetadataEntity GameMetadata { get; set; }
    }
}