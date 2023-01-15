using Infrastructure.Repositories;

namespace Domain;

public static class UsersInfoRequest
{
    public static UserInfo GetUserInfo(long userId)
    {
        var token = UserRepository.GetUserToken(userId);
        return new UserInfo("дебил@gmail.com", 
            "наверное, Ильнур", 
            "не ИнэУ-2302342", 
            094324892);
    }
}