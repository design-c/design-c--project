using System.Collections.Concurrent;
using Services.Commands.Utils;
using Services.InputMethods;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Services.Bot;

public class Bot
{
    private const string Token = "5887050935:AAGlzQPcrF923D7FKpWphX5yNck8erdPFhI";
    private static readonly TelegramBotClient Client = new(Token);
    private static ConcurrentDictionary<long, string> users = new();
    
    public Bot()
    {
        Client.StartReceiving();
        Client.OnMessage += OnMessageHandler;
        Client.OnCallbackQuery += OnCallbackHandler;
    }

    private async void OnCallbackHandler(object? sender, CallbackQueryEventArgs e)
    {
        var msg = e.CallbackQuery.Message;
        
        Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - Кнопка - {e.CallbackQuery.Data}");
        
        var command = CommandParser.ParseCommand(e.CallbackQuery.Data);
        await command.Execute(Client, msg);
    }

    private async void OnMessageHandler(object? sender, MessageEventArgs e)
    {
        var msg = e.Message;
        var text = msg.Text;
        
        if (text == null)
        {
            await Client.SendTextMessageAsync(msg.Chat.Id, "пиши текстом мужик", replyMarkup: InputMethods.InlineKeyboards.FinalKeyboard);

            return;
        }
        
        Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - {text}");

        switch (text[0])
        {
            case ':':
                var loginInfo = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var token = "AdajnfuasfmAUIfaufm3244";

                users.TryAdd(msg.Chat.Id, token);
                await Client.SetMyCommandsAsync(MenuCommands.FinalCommands);
                await Client.SendTextMessageAsync(msg.Chat.Id, "Авторизация произошла успешно!\nМеню:",
                    replyMarkup: InlineKeyboards.FinalKeyboard);
                
                return;
            case '/':
                var command = CommandParser.ParseCommand(text);
                    
                await command.Execute(Client, msg);
                    
                return;
            default:
                await Client.SendTextMessageAsync(msg.Chat.Id, "заткнись и напиши команду", replyMarkup: InlineKeyboards.FinalKeyboard);
                    
                return;
        }
    }
}