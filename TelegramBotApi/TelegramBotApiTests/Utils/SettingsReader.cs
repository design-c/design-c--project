using Logic.Settings;
using Microsoft.Extensions.Configuration;
using TelegramBotApiTests.Models;

namespace TelegramBotApiTests.Utils;

public static class SettingsReader
{
    public static AuthLoginTestSettings GetAuthLoginSettings() =>
        new AuthLoginTestSettings().GetSettings(AuthLoginTestSettings.AuthLoginSettings);

    public static AuthJwtSettings GetAuthJwtSettings() =>
        new AuthJwtSettings().GetSettings(AuthJwtSettings.JwtAuth);

    public static AuthUrfuSettings GetAuthUrfuSettings() =>
        new AuthUrfuSettings().GetSettings(AuthUrfuSettings.UrfuAuth);

    public static UrfuUserDataSettings GetUrfuUserDataSettings() =>
        new UrfuUserDataSettings().GetSettings(UrfuUserDataSettings.UrfuUser);

    private static T GetSettings<T>(this T settings, string key)
    {
        GetConfig()
            .GetSection(key)
            .Bind(settings);

        return settings;
    }

    private static IConfigurationRoot GetConfig() => new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.test.json", optional: true)
        .AddEnvironmentVariables()
        .Build();
}