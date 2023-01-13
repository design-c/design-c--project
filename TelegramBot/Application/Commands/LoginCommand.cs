using Application.Commands.Interfaces;

namespace Application.Commands;

public class LoginCommand : ICommand
{
    public const string Command = "/login";

    public string Description => $"{Command} - Авторизироваться";
    
    public string Execute()
    {
        var msg = "Введите логин и пароль от личного кабинета УрФУ, начав сообщение с \":\":";
        
        return msg;
    }
}