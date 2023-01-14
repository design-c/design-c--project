namespace Application.Commands.Interfaces;

public interface ICommand
{
    string Command { get; }
    string Description { get; }
    string Execute();
}