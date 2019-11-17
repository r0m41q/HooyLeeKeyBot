using System;
using Telegram.Bot;
using Telegram.Bot.Args;


namespace TelegramBotHooyLeeKey
{
    class Program
    {
        public static ITelegramBotClient botclient;
        static void Main(string[] args)
        {
            botclient = new TelegramBotClient("946377878:AAEGAoWALvdnLDtQobbbh80l-JlemR-F8Rs");

            var me = botclient.GetMeAsync().Result;
            Console.WriteLine($"bot id: { me.Id } bot name: { me.FirstName } ");

            botclient.OnMessage += message;
            botclient.StartReceiving();
            Console.ReadLine();
            
        }
            private static async void message(object sender, MessageEventArgs e)
        {
            var text = e?.Message?.Text;
            if (text == null) return;
            if (text.Contains("Тьома підар"))
            {
                await botclient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        $"Мельник більший підар!",
                        replyToMessageId: e.Message.MessageId
                    ).ConfigureAwait(false);
            }
            else
            if (text.Contains("Тьома"))
            {
                await botclient.SendTextMessageAsync(
                        chatId: e.Message.Chat.Id,
                        $"Ти хотів сказати Тьома підар?",
                        replyToMessageId: e.Message.MessageId
                    ).ConfigureAwait(false);
            }

        }
        
    }
}
