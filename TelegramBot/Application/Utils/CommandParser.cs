using Application.Interfaces;

namespace Application.Commands.Utils;

public static class CommandParser
{
    public static ICommand ParseCommand(IEnumerable<ICommand> commands, string text)
    {
        foreach (var command in commands)
        {
            if (text == command.Command)
                return command;
        }

        return new WrongCommand(text);
    }
}