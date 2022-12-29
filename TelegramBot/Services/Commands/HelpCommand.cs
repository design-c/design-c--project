using System.Text;
using Services.Commands.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Services.InputMethods;

namespace Services.Commands;

public class HelpCommand : ICommand
{
    private static readonly List<ICommand> Commands = new() { new StartCommand(), new UserinfoCommand(), 
                                                            new ScheduleCommand(), new HelpCommand()};

    public const string Command = "/help";
    
    public string Description => $"{Command} - Список и описание всех команд";
    
    public async Task Execute(TelegramBotClient client, Message message)
    {
        var msg = new StringBuilder();
        
        msg.Append("Список команд:\n");
        foreach (var command in Commands)
            msg.Append($"{command.Description}\n");
        
        await client.SendTextMessageAsync(message.Chat.Id, msg.ToString(), replyMarkup:  InlineKeyboards.FinalKeyboard);
    }
}