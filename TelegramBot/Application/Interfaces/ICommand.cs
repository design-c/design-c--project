namespace Application.Interfaces;

public interface ICommand
{
    string Command { get; }
    string Description { get; }
    string Execute(long userId);
}