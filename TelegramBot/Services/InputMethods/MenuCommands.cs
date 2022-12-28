using Telegram.Bot.Types;

namespace Services.InputMethods;

public static class MenuCommands
{
    public static readonly BotCommand[] StartCommands = Array.Empty<BotCommand>();

    public static readonly BotCommand[] FinalCommands =
    {
        new() { Command = "userinfo", Description = "Информация о пользователе" },
        new() { Command = "schedule", Description = "Расписание дня" },
        new() { Command = "help", Description = "Список всех команд" }
    };
}