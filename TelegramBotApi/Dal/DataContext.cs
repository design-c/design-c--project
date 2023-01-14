using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class DataContext: DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<UserInfoModel> UsersInfo { get; set; }
    public DbSet<UserScheduleModel> UsersSchedule { get; set; }
    
    
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }
}