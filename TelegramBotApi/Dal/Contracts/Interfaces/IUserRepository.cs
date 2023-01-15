using Dal.Contracts.Models;

namespace Dal.Contracts.Interfaces;

public interface IUserRepository : IRepository<UserModel, int>
{
    public Task<UserModel?> GetUserByKey(string userKey);

    public Task<UserModel?> GetUserByKeyWithMarks(string userKey);

    public Task<UserModel?> GetUserByKeyWithInfo(string userKey);

    public Task<UserModel?> GetUserByKeyWithAll(string userKey);
}