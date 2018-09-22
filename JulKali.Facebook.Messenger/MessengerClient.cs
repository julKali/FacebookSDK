using System.Threading.Tasks;
using JulKali.Facebook.Api;
using JulKali.Facebook.Entities;
using JulKali.Facebook.Messenger.Entities;
using JulKali.Facebook.Messenger.Send;

namespace JulKali.Facebook.Messenger
{
    /// <summary>
    /// Represents a client to send messages via the Facebook Send API.
    /// </summary>
    public class MessengerClient
    {
        #region Constants

        private const string ApiEndpoint = "https://graph.facebook.com/me/messages"; 

        #endregion

        private readonly string _accessToken;
        private readonly FacebookApiClient _client;

        private string ApiUri => $"{ApiEndpoint}?access_token={_accessToken}";

        /// <summary>
        /// Initializes a new <see cref="MessengerClient"/> instance.
        /// </summary>
        /// <param name="accessToken">The Messenger Platform access token.</param>
        public MessengerClient(string accessToken)
        {
            _accessToken = accessToken;
            _client = new FacebookApiClient();
        }

        /// <summary>
        /// Initializes a new <see cref="MessengerClient"/> instance using an existing <see cref="FacebookApiClient"/> instance.
        /// </summary>
        /// <param name="accessToken">The Messenger Platform access token.</param>
        /// <param name="client">The <see cref="FacebookApiClient"/> instance.</param>
        public MessengerClient(string accessToken, FacebookApiClient client)
        {
            _accessToken = accessToken;
            _client = client;
        }

        /// <summary>
        /// Sends a text message to a recipient via Facebook Messenger.
        /// </summary>
        /// <param name="recipient">The message recipient. Must be a valid <see cref="Recipient"/> subclass.</param>
        /// <param name="text">The message text.</param>
        /// <param name="messageType">The message type. Defaults to <see cref="MessageType.Standard"/>.</param>
        /// <param name="messagingType">The messaging type. Defaults to <see cref="MessagingType.Response"/>.</param>
        /// <param name="notificationType">The notification type. Defaults to <see cref="NotificationType.Regular"/>.</param>
        /// <param name="tag">An optional message reference tag.</param>
        /// <returns>The id of the sent message.</returns>
        /// <exception cref="MessengerRequestFailedException">Thrown if the API request returned an error.</exception>
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

            if (messageType == MessageType.Subscription)
            {
                message.tag = "NON_PROMOTIONAL_SUBSCRIPTION";
            }

            var result = await _client.Post<SendMessageResponse, MessengerErrorEntity>(ApiUri, (object) message);

            if (result.Error != null)
            {
                throw new MessengerRequestFailedException("text", ApiUri, result.HttpCode, result.Error.Code, result.Error.Message, result.Error.TraceId, result.Error.SubCode);
            }

            return result.Success.MessageId;
        }

        /// <summary>
        /// Sends a sender action to a recipient via Facebook Messenger.
        /// </summary>
        /// <param name="recipient">The recipient in form of a valid <see cref="Recipient"/> subclass.</param>
        /// <param name="action">The sender action.</param>
        /// <returns></returns>
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
                throw new MessengerRequestFailedException("text", ApiUri, result.HttpCode, result.Error.Code,
                    result.Error.Message, result.Error.TraceId, result.Error.SubCode);
            }
        }
    }
}
