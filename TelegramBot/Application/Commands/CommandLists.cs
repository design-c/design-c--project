using Application.Commands.Interfaces;
using Infrastructure.Utils;

namespace Application.Commands;

public static class CommandLists
{
    public static readonly IEnumerable<ICommand> AllCommands = InterfaceUtils.GetImplementedClasses<ICommand>();

    public static readonly IEnumerable<ICommand> StartCommands = AllCommands.Where(cmd => cmd is LoginCommand);

    public static readonly IEnumerable<ICommand> FinalCommands = AllCommands.Where(cmd =>
        cmd is not LoginCommand && cmd is not StartCommand);
}