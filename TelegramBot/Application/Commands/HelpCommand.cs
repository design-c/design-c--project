using System.Text;
using Application.Commands.Interfaces;

namespace Application.Commands;

public class HelpCommand : ICommand
{
    private static readonly List<ICommand> Commands = new() { new StartCommand(), new UserinfoCommand(), 
                                                            new ScheduleCommand(), new HelpCommand()};

    public const string Command = "/help";
    
    public string Description => $"{Command} - Список и описание всех команд";
    
    public string Execute()
    {
        var msg = new StringBuilder();
        
        msg.Append("Список команд:\n");
        foreach (var command in Commands)
            msg.Append($"{command.Description}\n");

        return msg.ToString();
    }
}