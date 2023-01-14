using Application.Commands.Interfaces;

namespace Application.Commands;

public class StartLoginCommand : ICommand
{
    public const string LoginInfoSeparator = " ";
    public const string LoginFormat = $"login{LoginInfoSeparator}password";
    
    public string Command => "/login";

    public string Description => "Авторизироваться";
    
    public string Execute(long userId)
    {
        return $"Введите логин и пароль от личного кабинета УрФУ в формате {LoginFormat}";
    }
}