using System.Threading.Tasks;
using JulKali.Facebook.Api;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Entities;
using JulKali.Facebook.Messenger.Send;

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

        public async Task<string> SendText(
            Recipient recipient, 
            string text, 
            MessageType messageType = MessageType.Standard, 
            MessagingType messagingType = MessagingType.Response,
            NotificationType notificationType = NotificationType.Regular,
            string tag = default
            )
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

            string notificationTypeString;

            switch (notificationType)
            {
                case NotificationType.Regular:
                    notificationTypeString = "REGULAR";
                    break;

                case NotificationType.SilentPush:
                    notificationTypeString = "SILENT_PUSH";
                    break;

                case NotificationType.NoPush:
                    notificationTypeString = "NO_PUSH";
                    break;

                default:
                    throw new MessagingTypeNotSupportedException(messagingType);
            }

            dynamic message = new
            {
                messaging_type = messagingTypeString,
                recipient = recipient.ToRecipientJsonObject(),
                notification_type = notificationTypeString,
                message = new
                {
                    text
                }
            };

            if (tag != default)
            {
                message.tag = tag; // doesnt work, will fix later
            }

            var result = await _client.Post<SendMessageResponse, MessengerErrorEntity>(ApiUri, (object) message);

            if (result.Error != null)
            {
                throw new MessengerRequestFailedException("text", ApiUri, result.HttpCode, result.Error.Code, result.Error.Message, result.Error.TraceId, result.Error.SubCode);
            }

            return result.Success.MessageId;
        }

        public async Task SendAction(Recipient recipient, SenderAction action)
        {
            var message = new SenderActionMessage
            {
                Recipient = recipient.ToRecipientJsonObject()
            };

            switch (action)
            {
                case SenderAction.TypingOn:
                    message.SenderAction = "typing_on";
                    break;

                case SenderAction.TypingOff:
                    message.SenderAction = "typing_off";
                    break;

                case SenderAction.MarkAsSeen:
                    message.SenderAction = "mark_seen";
                    break;

                default:
                    throw new SenderActionNotSupportedException(action);
            }

            var result = await _client.Post<SendMessageResponse, MessengerErrorEntity>(ApiUri, message);

            if (result.Error != null)
            {
                throw new MessengerRequestFailedException("text", ApiUri, result.HttpCode, result.Error.Code, result.Error.Message, result.Error.TraceId, result.Error.SubCode);
            }

            return;
        }
    }
}
