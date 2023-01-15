using Logic.Models;

namespace Logic.Services.Interfaces;

public interface IUserDataService
{
    Task<UserInfo> GetUserInfo(string userKey, bool needUpdate);

    Task<IEnumerable<UserMark>> GetUserMarks(string userKey, bool needUpdate);
}