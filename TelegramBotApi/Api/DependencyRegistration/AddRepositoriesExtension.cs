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
        using (var provider = services.BuildServiceProvider())
        {
            var service = provider.GetRequiredService<DbContext>();
            if (service.Database.GetPendingMigrations().Any())
                service.Database.Migrate();
        }
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IUserInfoRepository, UserInfoRepository>();
        services.AddTransient<IUserMarksRepository, UserMarksRepository>();
    }
}