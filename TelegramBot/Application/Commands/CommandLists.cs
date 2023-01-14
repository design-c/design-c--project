using Application.Commands.Interfaces;
using Infrastructure.Utils;

namespace Application.Commands;

public static class CommandLists
{
    private static readonly IEnumerable<ICommand> AllCommands = InterfaceUtils.GetImplementedClasses<ICommand>();

    public static IEnumerable<ICommand> StartCommands = AllCommands.Where(cmd => cmd is StartCommand or StartLoginCommand);

    public static readonly IEnumerable<ICommand> MainCommands = AllCommands.Where(cmd =>
        cmd is not StartLoginCommand && cmd is not StartCommand && cmd is not WrongCommand && cmd is not LoginCommand);
}