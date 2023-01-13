namespace Application.Commands.Interfaces;

public interface ICommand
{
    string Description { get; }
    string Execute();
}