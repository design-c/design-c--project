using System.Net;
using AngleSharp.Html.Parser;
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
            .AddTransient<IUrfuUserDataService, UrfuUserDataService>();

        services.TryAddScoped<HttpClient>();
        services.TryAddScoped<WebClient>();
        services.TryAddScoped<HtmlParser>();
    }
}