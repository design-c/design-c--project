using System.Text;
using Application.Commands.Interfaces;

namespace Application.Commands;

public class UserinfoCommand : ICommand
{
    public string Command => "/userinfo";
    
    public string Description => $"{Command} - Информация о пользователе";
    
    public string Execute()
    {
        var msg = new StringBuilder();
        msg.Append("Ваши данные:\n");
        msg.Append($"Электронная почта: дебил@gmail.com\n");
        msg.Append($"ФИО: наверное, Ильнур\n");
        msg.Append($"Академическая группа: надеюсь, не ИНэУ\n");
        msg.Append($"Номер студенческого билета: *длинное число мб*");
        return msg.ToString();
    }
}