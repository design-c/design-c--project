using System.Collections.Concurrent;

namespace Infrastructure.Repositories;

public class UserRepository
{
    private readonly ConcurrentDictionary<long, string> users = new();

    public void AddUser(long num, string token)
    {
        users.TryAdd(num, token);
    }
}