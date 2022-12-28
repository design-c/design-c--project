using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Commands;

public class HelpCommand : ICommand
{
    private static readonly List<ICommand> Commands = new() { new StartCommand(), new UserdataCommand(), 
                                                            new ScheduleCommand(), new HelpCommand()};
    public string Description => "/help - Список всех команд";
    public async Task Execute(TelegramBotClient client, Message message)
    {
        var builder = new StringBuilder();
        builder.Append("Список команд:\n");
        foreach (var command in Commands)
            builder.Append($"{command.Description}\n");

        await client.SendTextMessageAsync(message.Chat.Id, builder.ToString());
    }
}