using System;
using System.Threading.Tasks;
using JulKali.Facebook.Messenger;
using JulKali.Facebook.Messenger.Send;

namespace MessengerTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // initialize client

            var client = new MessengerClient(Environment.GetEnvironmentVariable("FB_ACCESS_TOKEN"));

            // initialize recipient

            var rec = new PsidRecipient(Environment.GetEnvironmentVariable("TEST_PSID"));

            // send SenderAction "typing on"

            await client.SendAction(rec, SenderAction.TypingOn);

            // send example text

            await client.SendText(rec, "This is an example message");
        }
    }
}
