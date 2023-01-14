using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Implementations.Repositories;

public class UserScheduleRepository: BaseRepository<UserScheduleModel, int>, IUserScheduleRepository
{
    public UserScheduleRepository(DbContext context) : base(context)
    {
    }
}