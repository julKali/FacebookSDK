namespace JulKali.Facebook.Entities
{
    internal class ShareButtonEntity : IButtonEntity
    {
        public string Type { get; } = "element_share";

        public MessageEntity ShareContents { get; set; }
    }
}