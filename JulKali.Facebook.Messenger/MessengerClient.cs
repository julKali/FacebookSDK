using System.Threading.Tasks;
using JulKali.Facebook.Api;

namespace JulKali.Facebook.Messenger
{
    public class MessengerClient
    {
        private readonly string _accessToken;
        private readonly FacebookApiClient _client;

        private const string ApiEndpoint = "https://graph.facebook.com/me/messages";

        public MessengerClient(string accessToken)
        {
            _accessToken = accessToken;
            _client = new FacebookApiClient();
        }

        public MessengerClient(string accessToken, FacebookApiClient client)
        {
            _accessToken = accessToken;
            _client = client;
        }

        public async Task<bool> SendText(Recipient recipient, string text, MessageType messageType = MessageType.Standard, MessagingType messagingType = MessagingType.Response)
        {
            string messagingTypeString;

            switch (messagingType)
            {
                case MessagingType.Response:
                    messagingTypeString = "RESPONSE";
                    break;

                case MessagingType.MessageTag:
                    messagingTypeString = "MESSAGE_TAG";
                    break;

                case MessagingType.Update:
                    messagingTypeString = "UPDATE";
                    break;

                default:
                    throw new MessagingTypeNotSupportedException(messagingType);
            }

            var message = new
            {
                messaging_type = messagingTypeString,
                recipient = recipient.ToRecipientJsonObject(),
                message = new
                {
                    text
                }
            };

            return await PostToEndpoint(message);
        }
    }
}
