using System.Text;
using Application.Commands.Interfaces;

namespace Application.Commands;

public class HelpCommand : ICommand
{
    public string Command => "/help";
    
    public string Description => $"{Command} - Список и описание всех команд";

    public string Execute()
    {
        var showedCommands = CommandLists.FinalCommands;
        var msg = new StringBuilder();
        
        msg.Append("Список команд:\n");
        foreach (var command in showedCommands)
            msg.Append($"{command.Description}\n");

        return msg.ToString();
    }
}