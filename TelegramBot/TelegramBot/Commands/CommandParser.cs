using System.Data;
using System.Reflection.Metadata;

namespace TelegramBot.Commands;

public static class CommandParser
{
    private const string StartCommand = "/start";
    private const string UserdataCommand = "/userdata";
    private const string ScheduleCommand = "/schedule";
    private const string HelpCommand = "/help";

    public static ICommand ParseCommand(string text)
    {
        return text switch
        {
            StartCommand => new StartCommand(),
            UserdataCommand => new UserdataCommand(),
            ScheduleCommand => new ScheduleCommand(),
            HelpCommand => new HelpCommand(),
            _ => throw new Exception()
        };
    }
}