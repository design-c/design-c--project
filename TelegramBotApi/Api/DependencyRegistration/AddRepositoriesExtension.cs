using Dal;
using Dal.Contracts.Interfaces;
using Dal.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.DependencyRegistration;

public static class AddRepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<DbContext, DataContext>();
        services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(connectionString, o => o.MigrationsAssembly("Dal")));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserInfoRepository, UserInfoRepository>();
        services.AddScoped<IUserScheduleRepository, UserScheduleRepository>();

        return services;
    }
}