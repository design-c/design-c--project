using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Implementations.Repositories;

public class UserMarksRepository : BaseRepository<UserScheduleModel, int>, IUserMarksRepository
{
    public UserMarksRepository(DbContext context) : base(context)
    {
    }
}