using System.Threading.Tasks;
using JulKali.Facebook.Api;

namespace JulKali.Facebook.Messenger
{
    public class MessengerClient
    {
        private const string ApiEndpoint = "https://graph.facebook.com/me/messages";


        private readonly string _accessToken;
        private readonly FacebookApiClient _client;

        private string ApiUri => $"{ApiEndpoint}?access_token={_accessToken}";


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

        public async Task SendText(Recipient recipient, string text, MessageType messageType = MessageType.Standard, MessagingType messagingType = MessagingType.Response)
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

            await _client.Post<object>(ApiUri, message);
        }

        public async Task SendAction(Recipient recipient, SenderAction action)
        {
            dynamic message = new
            {
                recipient = recipient.ToRecipientJsonObject()
            };

            switch (action)
            {
                case SenderAction.TypingOn:
                    message.sender_action = "typing_on";
                    break;

                case SenderAction.TypingOff:
                    message.sender_action = "typing_off";
                    break;

                case SenderAction.MarkAsSeen:
                    message.sender_action = "mark_seen";
                    break;

                default:
                    throw new SenderActionNotSupportedException(action);
            }

            await _client.Post<object>(ApiUri, message);
        }
    }
}
