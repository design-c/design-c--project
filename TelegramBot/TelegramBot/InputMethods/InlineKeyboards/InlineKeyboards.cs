using Application.Commands;
using Application.Commands.Interfaces;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.InputMethods.InlineKeyboards;

public static class InlineKeyboards
{
    public static readonly InlineKeyboardMarkup FinalKeyboard = InlineKeyboardMaker.MakeInlineKeyboard(CommandLists.FinalCommands);
    
    public static readonly InlineKeyboardMarkup StartKeyboard = InlineKeyboardMaker.MakeInlineKeyboard(CommandLists.StartCommands);
}