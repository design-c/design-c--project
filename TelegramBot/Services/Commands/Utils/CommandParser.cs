using Services.Commands.Interfaces;

namespace Services.Commands.Utils;

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
            _ => throw new Exception("Wrong command")
        };
    }
}