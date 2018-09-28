using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Send.Exceptions;

namespace JulKali.Facebook.Messenger.Send
{
    /// <summary>
    /// Represents a quick reply that is displayed below the message.
    /// </summary>
    public class QuickReply
    {
        public QuickReplyContentType? ContentType { get; set; }

        public string Title { get; set; }

        public string Payload { get; set; }

        public string ImageUrl { get; set; }

        internal QuickReplyEntity ToQuickReplyEntity()
        {
            if (ContentType == default)
            {
                throw new ValueException("Field 'ContentType' must set.");
            }

            if (ContentType == QuickReplyContentType.Text)
            {
                if (string.IsNullOrEmpty(Title))
                {
                    throw new ValueException("Field 'Title' must not be empty if 'ContentType' is set to 'Text'.");
                }

                if (string.IsNullOrEmpty(Payload))
                {
                    throw new ValueException("Field 'Payload' must not be empty if 'ContentType' is set to 'Text'.");
                }
            }

            if (Title?.Length > 20)
            {
                throw new ValueException("Field 'Title' must not exceed 20 characters.");
            }

            if (Payload?.Length > 1000)
            {
                throw new ValueException("Field 'Payload' must not exceed 1000 characters.");
            }

            if (string.IsNullOrEmpty(Title) && string.IsNullOrEmpty(ImageUrl))
            {
                throw new ValueException("Field 'ImageUrl' must not be empty if 'Title' is empty.");
            }

            string contentTypeString;

            switch (ContentType)
            {
                case QuickReplyContentType.Text:
                    contentTypeString = "text";
                    break;

                case QuickReplyContentType.Location:
                    contentTypeString = "location";
                    break;

                case QuickReplyContentType.UserPhoneNumber:
                    contentTypeString = "user_phone_number";
                    break;

                case QuickReplyContentType.UserEmail:
                    contentTypeString = "user_email";
                    break;

                default:
                    throw new QuickReplyContentTypeNotSupportedException((QuickReplyContentType) ContentType);
            }

            return new QuickReplyEntity
            {
                ContentType = contentTypeString,
                Title = Title,
                ImageUrl = ImageUrl,
                Payload = Payload
            };
        }
    }
}
