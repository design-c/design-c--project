using System.Collections.Concurrent;

namespace Infrastructure.Repositories;

public static class UserRepository
{
    private static readonly ConcurrentDictionary<long, string> users = new();

    public static void AddUser(long userId, string token)
    {
        users.TryAdd(userId, token);
    }

    public static string GetUserToken(long userId)
    {
        return users[userId];
    }
}