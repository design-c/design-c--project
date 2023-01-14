using Application.Commands.Interfaces;

namespace Application.Commands;

public class WrongCommand : ICommand
{
    private readonly string wrongText;
    public string Command => "";
    public string Description => "Вызывается при неопознанной команде";
    
    public WrongCommand() {}
    
    public WrongCommand(string wrongText)
    {
        this.wrongText = wrongText;
    }
    
    public string Execute(long userId)
    {
        return
            $"Неопознанная команда \"{wrongText}\".\n";//Воспользуйтесь /help для получения списка всех доступных команд";
    }
}