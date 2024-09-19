using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace FIrstBotASP.Controllers
{
    public class HomeController : Controller
    {
        // TelegramBotClient sinfidan obyekt hosil qilamiz
        // va unga Botfather orqali olgan tokenni
        // bog'laymiz
        private TelegramBotClient client = new TelegramBotClient("1531755050:AAEpi-2sgSeqoP8E_DVEe0Csx0H8L1zBi2c");

        // HomePage
        public string Index()
        {
            // yangi event_handler yasaldi
            client.OnMessage += Xabar_Kelganda;

            // xabar kelishini tasdiqlash
            client.StartReceiving();
            
            // string qaytaradi  
            return "Bot hozr ishlamoqda";
        }

        // foydalanuvchu xabar yuborganda ishlaydi
        private async void Xabar_Kelganda(object sender, MessageEventArgs e)
        {
            // foydalanuvchi idsi
            long userId = e.Message.Chat.Id;
            
            // kelgan xabar idsi
            int msgId = e.Message.MessageId;

            if(e.Message.Text == "/start")
            {
                // xabar yuborish
                await client.SendTextMessageAsync(userId, "Assalomu alaykum", replyToMessageId: msgId);
            }
        }
    }
}
