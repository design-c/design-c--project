using Application.Commands;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.InputMethods.InlineKeyboards;

public static class InlineKeyboards
{
    public static readonly InlineKeyboardMarkup MainKeyboard = InlineKeyboardMaker.MakeInlineKeyboard(CommandLists.MainCommands);
    
    public static readonly InlineKeyboardMarkup StartKeyboard = InlineKeyboardMaker.MakeInlineKeyboard(CommandLists.StartCommands);

    public static readonly InlineKeyboardMarkup LoginKeyboard = Array.Empty<InlineKeyboardButton>();
}