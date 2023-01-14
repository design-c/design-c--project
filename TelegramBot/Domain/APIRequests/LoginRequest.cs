using Infrastructure.Repositories;

namespace Domain;

public static class LoginRequest
{
    public static void LoginUser(string[] loginInfo, long userId)
    {
        // API get token from login info
        var token = loginInfo[0] + loginInfo[1];
        UserRepository.AddUser(userId, token);
    }
}