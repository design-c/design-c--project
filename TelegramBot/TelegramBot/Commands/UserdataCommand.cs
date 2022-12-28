using System.Security.Cryptography;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands;

public class UserdataCommand : ICommand
{
    public string Description => "/userdata - Данные пользователя";
    public async Task Execute(TelegramBotClient client, Message message)
    {
        var msg = new StringBuilder();
        msg.Append("Ваши данные:\n");
        msg.Append($"Электронная почта: {message.Chat.Username}@gmail.com\n");
        msg.Append($"ФИО: {message.Chat.FirstName} {message.Chat.LastName} {message.Chat.Description}\n");
        msg.Append($"Академическая группа: {message.Chat.Id}\n");
        
        await client.SendTextMessageAsync(message.Chat.Id, msg.ToString());
    }
}