using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TeleBot.Controllers
{
    public class TextMessageController
    {
            private readonly ITelegramBotClient _telegramClient;

            public TextMessageController(ITelegramBotClient telegramBotClient)
            {
                _telegramClient = telegramBotClient;
            }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" текст" , $"str"),
                        InlineKeyboardButton.WithCallbackData($" цифры" , $"num")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Наш бот считает символы в тексте или складывает цифры.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Выберите действие.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Получено сообщение", cancellationToken: ct);
                    break;
            }
        }
        //Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
        //await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"Получено текстовое сообщение", cancellationToken: ct);
    }
    
}
