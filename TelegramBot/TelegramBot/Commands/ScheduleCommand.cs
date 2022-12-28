using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands;

public class ScheduleCommand : ICommand
{
    public string Description => "/schedule - Расписание дня";
    public async Task Execute(TelegramBotClient client, Message message)
    {
        var schedule = "1 пара - 8:30 - Математика\n3 пара - 12:00 - Физика";
        await client.SendTextMessageAsync(message.Chat.Id, $"Ваше расписание:\n{schedule}");
    }
}