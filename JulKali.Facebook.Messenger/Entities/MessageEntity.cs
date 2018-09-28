using System.Collections.Generic;
using Newtonsoft.Json;

namespace JulKali.Facebook.Entities
{
    internal class MessageEntity
    {
        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("attachment", NullValueHandling = NullValueHandling.Ignore)]
        public IMessageAttachmentEntity Attachment { get; set; }

        [JsonProperty("quick_replies", NullValueHandling = NullValueHandling.Ignore)]
        public IList<QuickReplyEntity> QuickReplies { get; set; }

        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata { get; set; }
    }
}
