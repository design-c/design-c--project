using Application.Interfaces;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.InputMethods.InlineKeyboards;

public static class InlineKeyboardMaker
{
    public static InlineKeyboardMarkup MakeInlineKeyboard(IEnumerable<ICommand> commands)
    {
        var buttons = commands
            .Select(command => MakeInlineButton(command));

        return new InlineKeyboardMarkup(buttons);
    }
    
    private static InlineKeyboardButton[] MakeInlineButton(ICommand command)
    {
        var text = command.Description;
        var callbackData = command.Command;

        var button = InlineKeyboardButton.WithCallbackData(text, callbackData);
        return new[] { button };
    }
}