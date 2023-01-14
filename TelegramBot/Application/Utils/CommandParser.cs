using Application.Commands.Interfaces;

namespace Application.Commands.Utils;

public static class CommandParser
{
    public static ICommand ParseCommand(string text)
    {
        return text switch
        {
            StartCommand.Command => new StartCommand(),
            UserinfoCommand.Command => new UserinfoCommand(),
            ScheduleCommand.Command => new ScheduleCommand(),
            HelpCommand.Command => new HelpCommand(),
            LoginCommand.Command => new LoginCommand(),
            _ => new HelpCommand()//throw new Exception("Wrong command")
        };
    }
}