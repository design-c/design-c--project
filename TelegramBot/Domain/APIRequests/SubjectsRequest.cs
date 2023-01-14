using Infrastructure.Repositories;

namespace Domain;

public static class SubjectsRequest
{
    public static List<Subject> GetSubjects(long userId)
    {
        var token = UserRepository.GetUserToken(userId);
        // API get subjects from token
        return new List<Subject> { new ("Математика", 80.1), 
            new ("Программирование", 99.1) };
    }
}