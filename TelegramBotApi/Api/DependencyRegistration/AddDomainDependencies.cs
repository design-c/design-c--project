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
            .AddTransient<IUrfuUserServerDataService, UrfuUserServerDataService>()
            .AddTransient<IUserDataService, UrfuUserDataService>();
        services.AddHttpClient<HttpClient>()
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => true
            });
        services.TryAddScoped<WebClient>();
        services.TryAddScoped<HtmlParser>();
    }
}