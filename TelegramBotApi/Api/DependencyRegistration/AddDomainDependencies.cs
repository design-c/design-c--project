using Logic.Services;
using Logic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Api.DependencyRegistration;

public static class AddDomainServices
{
    public static void AddLogicServices(this IServiceCollection services)
    {
        services
            .AddTransient<IAuthService, AuthService>()
            .TryAddScoped<HttpClient>();
    }
}