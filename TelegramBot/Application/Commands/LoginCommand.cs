using Application.Commands.Interfaces;

namespace Application.Commands;

public class LoginCommand : ICommand
{
    private string[] loginInfo;
    private long userId;
    
    public string Command => "";
    
    public string Description => "";
    
    public LoginCommand() { }

    public LoginCommand(string[] loginInfo, long userId)
    {
        this.loginInfo = loginInfo;
        this.userId = userId;
    }
    
    public string Execute()
    {
        // TODO: domain login
        return "Успешный вход\nДля получения списка команд, воспользуйтесь командой /help";
    }
}