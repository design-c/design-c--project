using Application.Commands;
using Application.Commands.Interfaces;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.InputMethods;

public static class InlineKeyboards
{
    public static readonly InlineKeyboardMarkup FinalKeyboard1 = new(new[]
    {
        new[] { InlineKeyboardButton.WithCallbackData("Список и описание команд", "/help") },
        new[] { InlineKeyboardButton.WithCallbackData("Информация о пользователе", "/userinfo") },
        new[] { InlineKeyboardButton.WithCallbackData("Расписание дня", "/schedule") },
        new[] { InlineKeyboardButton.WithCallbackData("Оценки за предметы", "/subjects") }
    });
    
    public static readonly InlineKeyboardMarkup StartKeyboard1 = new(new[]
    {
        new[] { InlineKeyboardButton.WithCallbackData("Авторизироваться", "/login") }
    });
    
    public static readonly InlineKeyboardMarkup FinalKeyboard = new(new[]
    {
        MakeInlineButton(new HelpCommand()),
        MakeInlineButton(new UserinfoCommand()),
        MakeInlineButton(new ScheduleCommand()),
        MakeInlineButton(new SubjectsCommand())
    });
    
    public static readonly InlineKeyboardMarkup StartKeyboard = new(new[]
    {
        MakeInlineButton(new LoginCommand())
    });
    
    private static InlineKeyboardButton[] MakeInlineButton(ICommand command)
    {
        var cmdDescription = command.Description.Split(" - ");
        var text = cmdDescription[1];
        var callbackData = cmdDescription[0];

        var button = InlineKeyboardButton.WithCallbackData(text, callbackData);
        return new[] { button };
    }
}