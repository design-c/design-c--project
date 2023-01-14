using System.Text;
using Application.Commands.Interfaces;
using Domain;
using Infrastructure.Repositories;

namespace Application.Commands;

public class UserinfoCommand : ICommand
{
    public string Command => "/userinfo";
    
    public string Description => "Информация о пользователе";
    
    public string Execute(long userId)
    {
        var userinfo = UsersInfoRequest.GetUserInfo(userId);
        
        var msg = new StringBuilder();
        msg.Append("Ваши данные:\n");
        msg.Append($"Электронная почта: {userinfo.Email}\n");
        msg.Append($"ФИО: {userinfo.FullName}\n");
        msg.Append($"Академическая группа: {userinfo.AcademGroup}\n");
        msg.Append($"Номер студенческого билета: {userinfo.StudentId}");
        return msg.ToString();
    }
}