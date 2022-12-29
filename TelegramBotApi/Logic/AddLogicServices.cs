using AngleSharp.Html.Parser;
using Logic.Services;
using Logic.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Logic;

public static class ForStartup
{
    public static IServiceCollection AddLogicServices(this IServiceCollection services)
    {
        services
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IUserUrfuService, UserUrfuService>()
            .AddTransient<IUrfuHtmlParserService, UrfuHtmlParserService>()
            .AddTransient<IUrfuUtilsService, UrfuUtilsService>();

        services.TryAddScoped<HttpClient>();
        services.TryAddScoped<HtmlParser>();

        return services;
    }
}