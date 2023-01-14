using Application.Commands.Interfaces;

namespace Application.Commands;

public static class CommandLists
{
    public static readonly IEnumerable<ICommand> AllCommands = GetAllCommands();
    
    private static IEnumerable<ICommand> GetAllCommands()
    {
        var allCommands = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ICommand).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false })
            .Select(x => (ICommand)Activator.CreateInstance(x)!);

        return allCommands;
    }
}