using Application.Commands.Interfaces;

namespace Application.Commands;

public class StartCommand : ICommand
{
    public const string Command = "/start";
    
    public string Description => $"{Command} - Старт";
    
    public string Execute()
    {
        return $"Здравствуйте!\nДля начала работы авторизируйтесь с помощью команды /login";
    }
}