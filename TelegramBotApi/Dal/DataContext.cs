using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal;

public class DataContext: DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<UserInfoModel> UsersInfo { get; set; }
    public DbSet<UserScheduleModel> UsersSchedule { get; set; }
    public DbSet<UserMarksModel> UsersMarks { get; set; }
    
    
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasOne(u => u.Info)
            .WithOne(i => i.User)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Marks)
            .WithOne(m => m.User)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<UserModel>()
            .HasOne(u => u.Schedule)
            .WithOne(m => m.User)
            .OnDelete(DeleteBehavior.Cascade);
    }
}