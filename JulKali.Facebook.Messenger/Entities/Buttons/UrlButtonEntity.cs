namespace JulKali.Facebook.Entities
{
    internal class UrlButtonEntity : IButtonEntity
    {
        public string Type { get; } = "web_url";

        public string Title { get; set; }

        public string Url { get; set; }

        public string WebviewHeightRatio { get; set; }

        public bool MessengerExtensions { get; set; }

        public string FallbackUrl { get; set; }

        public string WebviewShareButton { get; set; }
    }
}