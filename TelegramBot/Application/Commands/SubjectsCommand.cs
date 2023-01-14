using Application.Commands.Interfaces;

namespace Application.Commands;

public class SubjectsCommand : ICommand
{
    public string Command => "/subjects";
    
    public string Description => $"{Command} - Список оценок по предметам";
    
    public string Execute()
    {
        return "Матика - 60\nПрога - 80";
    }
}