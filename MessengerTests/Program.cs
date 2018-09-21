using System;
using System.Threading.Tasks;
using JulKali.Facebook.Messenger;

namespace MessengerTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MessengerClient(Environment.GetEnvironmentVariable("FB_ACCESS_TOKEN"));

            Console.WriteLine("Hello World!");
        }
    }
}
