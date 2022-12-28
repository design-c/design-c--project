using System.Text;
using Services.Commands.Interfaces;
using Services.InputMethods;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Services.Commands;

public class ScheduleCommand : ICommand
{
    public const string Command = "/schedule";
    
    public string Description => $"{Command} - Расписание дня";
    
    public async Task Execute(TelegramBotClient client, Message message)
    {
        var msg = new StringBuilder();
        msg.Append("Ваше расписание:\n");
        msg.Append("1 пара - 8:30 - Математика\n");
        msg.Append("3 пара - 12:00 - Физика\n");
        
        await client.SendTextMessageAsync(message.Chat.Id, msg.ToString(), replyMarkup: InlineKeyboards.FinalKeyboard);
    }
}