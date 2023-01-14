using Logic.Models;

namespace Logic.Services.Interfaces;

public interface IUserDataService
{
    Task<UserInfo> GetUserInfo(string userKey);

    Task<IEnumerable<UserMark>> GetUserMarks(string userKey);
}