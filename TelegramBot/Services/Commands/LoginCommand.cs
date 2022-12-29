using Services.Commands.Interfaces;
using Services.InputMethods;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Services.Commands;

public class LoginCommand : ICommand
{
    public const string Command = "/login";

    public string Description => $"{Command} - Авторизироваться";
    
    public async Task Execute(TelegramBotClient client, Message message)
    {
        Console.WriteLine($"Авторизировался {message.Chat.Username}");
        await client.SendTextMessageAsync(message.Chat.Id, "Введите логин и пароль от личного кабинета УрФУ, " +
                                                           "начав сообщение с \":\":");
    }
}