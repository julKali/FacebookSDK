using System;
using System.Threading;
using System.Threading.Tasks;
using JulKali.Facebook.Messenger;
using JulKali.Facebook.Messenger.Send;

namespace MessengerTests
{
    class Program
    {
        private static MessengerClient _client;
        private static PsidRecipient _recipient;

        static async Task Main(string[] args)
       {
            // initialize client

            _client = new MessengerClient(Environment.GetEnvironmentVariable("FB_ACCESS_TOKEN"));

            // initialize recipient

            _recipient = new PsidRecipient(Environment.GetEnvironmentVariable("TEST_PSID"));

            // call example method

            await SendTextAndQuickReplies();
            
            // keep window open

            Console.ReadKey();
        }

        static async Task SendText()
        {
            // build message

            var msg = new TextMessage()
                .SetText("This is an example message.")
                .ReturnCompletedMessage();

            // send message

            var mid = await _client.SendMessage(_recipient, msg);

            // pring message id

            Console.WriteLine($"Message [{mid}] sent.");
        }

        static async Task SendUserActionAndText()
        {
            // build message

            var msg = new TextMessage()
                .SetText("This is an example message. Did you see me typing?.")
                .ReturnCompletedMessage();

            // send SenderAction "typing on"

            await _client.SendAction(_recipient, SenderAction.TypingOn);

            // wait a bit.

            Thread.Sleep(1000);

            // send msg. Automatically stops typing.

            var mid = await _client.SendMessage(_recipient, msg);

            // pring message id

            Console.WriteLine($"Message [{mid}] sent.");
        }

        static async Task SendTextAndQuickReplies()
        {
            // build message

            var msg = new TextMessage()
                .SetText("This is an example message. Below, you can see a quick reply.")
                .AddTextQuickReply("Click me!", "RETURN_PAYLOAD")
                .AddTextQuickReply("Click with emoji", "RETURN_PAYLOAD_IMAGE", "https://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/240/microsoft/135/heavy-check-mark_2714.png")
                .ReturnCompletedMessage();

            // send message and print message id

            Console.WriteLine(await _client.SendMessage(_recipient, msg));
        }

        static async Task SendGenericTemplateAndQuickReplies()
        {
            // build image

            var msg = new AttachmentMessage()
                .StartBuildingTemplateAttachment()
                .UseGenericTemplate()
                .AddElement(
                    Element
                        .StartBuilding()
                        .SetTitle("You GOT IT!")
                        .SetDefaultAction(
                            DefaultAction
                                .Create(new Uri("https://duckduckgo.com"))
                                .HideWebviewShareButton()
                        )
                        .SetImageUrl("https://thechangreport.com/img/lightning.png")
                        .AddButton(
                            new ShareButton(
                                "I took the math quiz!",
                                "My result: AWESOME",
                                "https://bot.peters-hats.com/img/hats/fez.jpg",
                                DefaultAction
                                    .Create("http://m.me/petershats?ref=invited_by_24601"),
                                new UrlButton("Test", "https://duckduckgo.com")
                            )
                        )
                        .AddButton(
                            new CallButton(
                                "Call this guy!",
                                "+12347234329"
                            )
                        )
                        .Build()
                )
                .BuildTemplate()
                .AddTextQuickReply("test", "")
                .AddQuickReply(QuickReplyContentType.UserEmail)
                .ReturnCompletedMessage();

            // send message and print message id

            Console.WriteLine(await _client.SendMessage(_recipient, msg));
        }
    }
}
