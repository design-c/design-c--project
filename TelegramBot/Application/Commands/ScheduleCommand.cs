using System.Text;
using Application.Commands.Interfaces;

namespace Application.Commands;

public class ScheduleCommand //: ICommand
{
    public string Command => "/schedule";
    
    public string Description => $"{Command} - Расписание дня";
    
    public string Execute()
    {
        var msg = new StringBuilder();
        msg.Append("Ваше расписание:\n");
        msg.Append("1 пара - 8:30 - Математика\n");
        msg.Append("3 пара - 12:00 - Физика\n");

        return msg.ToString();
    }
}