using System.Text;
using Application.Commands.Interfaces;
using Domain;
using Infrastructure.Repositories;

namespace Application.Commands;

public class SubjectsCommand : ICommand
{
    public string Command => "/subjects";
    
    public string Description => "Список оценок по предметам";
    
    public string Execute(long userId)
    {
        var token = UserRepository.GetUserToken(userId);
        var subjects = SubjectsRequest.GetSubjects(userId);

        var builder = new StringBuilder();
        foreach (var subject in subjects)
            builder.Append($"{subject.Name} - {subject.Grade}\n");
        
        return builder.ToString();
    }
}