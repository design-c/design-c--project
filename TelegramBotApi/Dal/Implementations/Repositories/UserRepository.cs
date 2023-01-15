using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Implementations.Repositories;

public class UserRepository : BaseRepository<UserModel, int>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public async Task<UserModel?> GetUserByKey(string userKey) =>
        await GetUserByKey(userKey, null);
    
    public async Task<UserModel?> GetUserByKeyWithMarks(string userKey) =>
        await GetUserByKey(userKey, new[] { "Marks" });

    public async Task<UserModel?> GetUserByKeyWithInfo(string userKey) =>
        await GetUserByKey(userKey, new[] { "Info" });
    
    public async Task<UserModel?> GetUserByKeyWithAll(string userKey) =>
        await GetUserByKey(userKey, new[] { "Info", "Marks" });
    
    private async Task<UserModel?> GetUserByKey(string userKey, IEnumerable<string>? properties)
    {
        var expression = DbSet.AsQueryable();
        if (properties != null)
            foreach (var property in properties)
                expression = DbSet.Include(property);
        
        return await expression.FirstOrDefaultAsync(userModel => userModel.UserKey == userKey);
    }
}