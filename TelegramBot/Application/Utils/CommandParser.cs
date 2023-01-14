using Application.Commands.Interfaces;

namespace Application.Commands.Utils;

public static class CommandParser
{
    public static ICommand ParseCommand(string text)
    {
        var commands = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => t.GetInterfaces().Contains(typeof(ICommand)));
        
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
            .Where(x => typeof(ICommand).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
            .Select(x => x.Name).ToList();
        
        return text switch
        {
            StartCommand.Command => new StartCommand(),
            UserinfoCommand.Command => new UserinfoCommand(),
            ScheduleCommand.Command => new ScheduleCommand(),
            HelpCommand.Command => new HelpCommand(),
            LoginCommand.Command => new LoginCommand(),
            SubjectsCommand.Command => new SubjectsCommand(),
            _ => new HelpCommand()//throw new Exception("Wrong command")
        };
    }
}