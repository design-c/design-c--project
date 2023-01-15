using Infrastructure.Repositories;

namespace Domain;

public static class LoginRequest
{
    public static void LoginUser(string[] loginInfo, long userId)
    {
        var token = loginInfo[0] + loginInfo[1];
        UserRepository.AddUser(userId, token);
    }
}