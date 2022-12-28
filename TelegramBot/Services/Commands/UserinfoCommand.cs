using System.Text;
using Services.Commands.Interfaces;
using Services.InputMethods;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Services.Commands;

public class UserinfoCommand : ICommand
{
    public const string Command = "/userinfo";
    
    public string Description => $"{Command} - Информация о пользователе";
    
    public async Task Execute(TelegramBotClient client, Message message)
    {
        var userEmail = $"{message.Chat.Username}@gmail.com";
        var userFullname = $"{message.Chat.FirstName} {message.Chat.LastName} {message.Chat.Description}";
        var userGroup = $"{message.Chat.Id}";
        var userCard = $"{message.Chat.Bio}";
        
        var msg = new StringBuilder();
        msg.Append("Ваши данные:\n");
        msg.Append($"Электронная почта: {userEmail}\n");
        msg.Append($"ФИО: {userFullname}\n");
        msg.Append($"Академическая группа: {userGroup}\n");
        msg.Append($"Номер студенческого билета: {userCard}");
        
        await client.SendTextMessageAsync(message.Chat.Id, msg.ToString(), replyMarkup: InlineKeyboards.FinalKeyboard);
    }
}