using System;
using System.ComponentModel.Design;
using System.IO;
using System.Threading.Tasks;
using NetTelegramBotApi;
using NetTelegramBotApi.Requests;

namespace MusicFeedbackTGBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bot = new TelegramBot(RetrieveAccToken(), null);
            var me = await bot.MakeRequestAsync(new GetMe());
            if (me != null)
            {
                Console.WriteLine("Me: {0} (@{1})", me.FirstName, me.Username);
            }

            var updates = await bot.MakeRequestAsync(new GetUpdates());

            Console.WriteLine(updates.ToString());
        }
        
        private static string RetrieveAccToken()
        {
            if (File.Exists("config\\access token.txt"))
            {
                var sr = new StreamReader("config\\access token.txt");
                var accessToken = sr.ReadLine();
                return accessToken;
            }
            else
            {
                throw new CheckoutException("Please create directory \"config\" and put there a file " +
                                            "\"access token.txt\" with your bot access token");
            }
        }
    }
}