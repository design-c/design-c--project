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
        await DbSet.FirstOrDefaultAsync(userModel => userModel.UserKey == userKey);
}