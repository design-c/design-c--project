using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.InputMethods;

public static class InlineKeyboards
{
    public static readonly InlineKeyboardMarkup FinalKeyboard = new(new[]
    {
        new[] { InlineKeyboardButton.WithCallbackData("Список и описание команд", "/help") },
        new[] { InlineKeyboardButton.WithCallbackData("Информация о пользователе", "/userinfo") },
        new[] { InlineKeyboardButton.WithCallbackData("Расписание дня", "/schedule") }
    });
    
    public static readonly InlineKeyboardMarkup StartKeyboard = new(new[]
    {
        new[] { InlineKeyboardButton.WithCallbackData("Авторизироваться", "/login") }
    });
}