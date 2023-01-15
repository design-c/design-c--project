using Dal;
using Dal.Contracts.Interfaces;
using Dal.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.DependencyRegistration;

public static class AddRepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<DbContext, DataContext>();
        services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(connectionString, o => o.MigrationsAssembly("Dal")), ServiceLifetime.Transient);
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserInfoRepository, UserInfoRepository>();
        services.AddTransient<IUserMarksRepository, UserMarksRepository>();
    }
}