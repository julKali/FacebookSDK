using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class MessageEntity
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachment")]
        public IMessageAttachmentEntity Attachment { get; set; }

        [JsonProperty("quick_replies", NullValueHandling = NullValueHandling.Ignore)]
        public QuickReplyEntity[] QuickReplies { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }
    }
}
