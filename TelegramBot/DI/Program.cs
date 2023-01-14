using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TelegramBot.Bot;
using TelegramBot.interfaces;
using TelegramBot.Settings;

namespace DI;

static class Program
{
    private static void Main()
    {
        var builder = new ConfigurationBuilder();

        builder
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        IConfiguration config = builder.Build();

        var host = Host
            .CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton(_ => config.GetSection(BotSettings.Telegram).Get<BotSettings>());
                services.AddSingleton<IBot, Bot>();
            })
            .Build();

        var bot = ActivatorUtilities.CreateInstance<Bot>(host.Services);

        Console.ReadKey();

        bot.StopBot();
    }
}