using Services.Commands.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Services.InputMethods;

namespace Services.Commands;

public class StartCommand : ICommand
{
    public const string Command = "/start";
    
    public string Description => $"{Command} - Старт";

    public async Task Execute(TelegramBotClient client, Message message)
    {
        await client.SetMyCommandsAsync(MenuCommands.StartCommands);
        await client.SendTextMessageAsync(message.Chat.Id,
            $"Здравствуйте, {message.Chat.Username}!\nДля начала работы авторизируйтесь с помощью команды /login", replyMarkup: InlineKeyboards.StartKeyboard);
    }
}