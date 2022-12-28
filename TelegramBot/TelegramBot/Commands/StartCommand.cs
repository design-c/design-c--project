using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands;

public class StartCommand : ICommand
{
    public string Description => "/start - Старт";

    public async Task Execute(TelegramBotClient client, Message message)
    {
        await client.SendTextMessageAsync(message.Chat.Id,
            "Здравствуйте!\nВведите логин и пороль к личному кабинету УрФУ");
    }
}