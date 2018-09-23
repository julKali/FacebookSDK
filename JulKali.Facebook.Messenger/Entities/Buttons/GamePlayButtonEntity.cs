namespace JulKali.Facebook.Entities
{
    internal class GamePlayButtonEntity : IButtonEntity
    {
        public string Type { get; } = "game_play";

        public string Title { get; set; }

        public string Payload { get; set; }

        public IGameMetadataEntity GameMetadata { get; set; }
    }
}