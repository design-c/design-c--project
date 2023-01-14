using Application.Commands.Interfaces;

namespace Application.Commands;

public class SubjectsCommand : ICommand
{
    public string Command => "/subjects";
    
    public string Description => "Список оценок по предметам";
    
    public string Execute()
    {
        // TODO: domain get subjects 
        return "Матика - 60\nПрога - 80";
    }
}