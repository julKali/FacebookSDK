namespace JulKali.Facebook.Entities
{
    internal class PostbackButtonEntity : IButtonEntity
    {
        public string Type { get; } = "postback";

        public string Title { get; set; }

        public string Payload { get; set; }
    }
}