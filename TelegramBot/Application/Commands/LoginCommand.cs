using Application.Commands.Interfaces;
using Domain;

namespace Application.Commands;

public class LoginCommand : ICommand
{
    private string[] loginInfo;
    
    public string Command => "";
    
    public string Description => "";
    
    public LoginCommand() { }

    public LoginCommand(string[] loginInfo)
    {
        this.loginInfo = loginInfo;
    }
    
    public string Execute(long userId)
    {
        LoginRequest.LoginUser(loginInfo, userId);
        
        return "Успешный вход\nДля получения списка команд, воспользуйтесь командой /help";
    }
}