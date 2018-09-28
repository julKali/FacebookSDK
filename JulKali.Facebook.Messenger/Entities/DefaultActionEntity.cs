using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class DefaultActionEntity
    {
        [JsonProperty("type")]
        public string Type { get; } = "web_url";

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("webview_height_ratio", NullValueHandling = NullValueHandling.Ignore)]
        public string WebviewHeightRatio { get; set; }

        [JsonProperty("messenger_extensions", NullValueHandling = NullValueHandling.Ignore)]
        public bool MessengerExtensions { get; set; }

        [JsonProperty("fallback_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FallbackUrl { get; set; }

        [JsonProperty("webview_share_button", NullValueHandling = NullValueHandling.Ignore)]
        public string WebviewShareButton { get; set; }
    }
}