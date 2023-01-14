using System.Text;
using Application.Commands.Interfaces;

namespace Application.Commands;

public class HelpCommand : ICommand
{
    public string Command => "/help";
    
    public string Description => "Список и описание всех команд";

    public string Execute()
    {
        var commands = CommandLists.MainCommands;
        var msg = new StringBuilder();
        
        msg.Append("Список команд:\n");
        foreach (var command in commands)
            msg.Append($"{command.Command} - {command.Description}\n");

        return msg.ToString();
    }
}