using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Implementations.Repositories;

public class UserInfoRepository: BaseRepository<UserInfoModel, int>, IUserInfoRepository
{
    public UserInfoRepository(DbContext context) : base(context)
    {
    }
}