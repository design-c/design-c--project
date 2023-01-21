using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;

namespace TelegramBotApiTests.Models;

public class UserTestRepository : IUserRepository
{
    private List<UserModel> dataBase = new();

    public async Task<IEnumerable<UserModel>> GetAllAsync() => dataBase;

    public async Task<UserModel?> FindAsync(int id) => dataBase.FirstOrDefault(u => u.Id == id);

    public async Task CreateAsync(UserModel item) => dataBase.Add(item);

    public async Task<UserModel> UpdateAsync(UserModel item)
    {
        var tuple = dataBase
            .Select((u, index) => (user: u, index))
            .FirstOrDefault(x => x.user.Id == item.Id);

        if (tuple.user != null)
            dataBase[tuple.index] = item;

        return item;
    }

    public async Task<UserModel?> GetUserByKey(string userKey) =>
        dataBase.FirstOrDefault(u => u.UserKey == userKey);

    public async Task DeleteAsync(int id)
    {
        dataBase = dataBase.Where(u => u.Id != id).ToList();
    }

    public Task<UserModel?> GetUserByKeyWithMarks(string userKey) => throw new NotImplementedException();

    public Task<UserModel?> GetUserByKeyWithInfo(string userKey) => throw new NotImplementedException();

    public Task<UserModel?> GetUserByKeyWithAll(string userKey) => throw new NotImplementedException();
}