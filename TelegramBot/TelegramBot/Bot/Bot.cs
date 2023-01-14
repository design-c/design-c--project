using System.Collections.Concurrent;
using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.InputMethods;

namespace TelegramBot.Bot;

public class Bot
{
    private const string Token = "5887050935:AAGlzQPcrF923D7FKpWphX5yNck8erdPFhI";
    private static readonly TelegramBotClient Client = new(Token);
    private static readonly ConcurrentDictionary<long, string> users = new();
    
    private readonly CancellationTokenSource cts = new ();
    private readonly  ReceiverOptions receiverOptions = new () { AllowedUpdates = Array.Empty<UpdateType>() };
    
    public Bot()
    {
        Client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions, cts.Token);
        //Client.SetWebhookAsync();
        //Client.DeleteWebhookAsync();
        //Client.OnMessage += OnMessageHandler;
        //Client.OnCallbackQuery += OnCallbackHandler;
    }

    public void StopBot()
    {
        cts.Cancel();
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update)
        {
            case { Type: UpdateType.Message, Message: { } }:
            {
                var msg = update.Message;
                var text = msg.Text;
        
                if (text == null)
                {
                    await Client.SendTextMessageAsync(msg.Chat.Id, "пиши текстом мужик", replyMarkup: InlineKeyboards.FinalKeyboard);

                    return;
                }
        
                Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - {text}");

                switch (text[0])
                {
                    case ':':
                        var loginInfo = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var token = "AdajnfuasfmAUIfaufm3244";

                        users.TryAdd(msg.Chat.Id, token);
                        await Client.SendTextMessageAsync(msg.Chat.Id, "Авторизация произошла успешно!\nМеню:",
                            replyMarkup: InlineKeyboards.FinalKeyboard);
                
                        return;
                    case '/':
                        var command = CommandParser.ParseCommand(text);
                        var commandOutput = command.Execute();
                        await Client.SendTextMessageAsync(msg.Chat.Id, commandOutput,replyMarkup: InlineKeyboards.FinalKeyboard);
                        //await command.Execute(Client, msg);
                    
                        return;
                    default:
                        await Client.SendTextMessageAsync(msg.Chat.Id, "заткнись и напиши команду", replyMarkup: InlineKeyboards.FinalKeyboard);
                    
                        return;
                }

                break;
            }
            case { Type: UpdateType.CallbackQuery, CallbackQuery: { } }:
            {
                var msg = update.CallbackQuery.Message;
            
                Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - Кнопка - {update.CallbackQuery.Data}");

                var command = CommandParser.ParseCommand(update.CallbackQuery.Data);
                var commandOutput = command.Execute();
                await Client.SendTextMessageAsync(msg.Chat.Id, commandOutput, replyMarkup: InlineKeyboards.FinalKeyboard, cancellationToken: cancellationToken);
                break;
            }
        }
    }
    
    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }
    /*
    private async void OnCallbackHandler(object? sender, CallbackQueryEventArgs e)
    {
        var msg = e.CallbackQuery.Message;
        
        Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - Кнопка - {e.CallbackQuery.Data}");
        
        var command = CommandParser.ParseCommand(e.CallbackQuery.Data);
        var commandOutput = command.Execute();
        await Client.SendTextMessageAsync(msg.Chat.Id, commandOutput,replyMarkup: InlineKeyboards.FinalKeyboard);
        //await command.Execute(Client, msg);
    }

    private async void OnMessageHandler(object? sender, MessageEventArgs e)
    {
        Console.WriteLine("got a msg");
        var msg = e.Message;
        var text = msg.Text;
        
        if (text == null)
        {
            await Client.SendTextMessageAsync(msg.Chat.Id, "пиши текстом мужик", replyMarkup: InlineKeyboards.FinalKeyboard);

            return;
        }
        
        Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - {text}");

        switch (text[0])
        {
            case ':':
                var loginInfo = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var token = "AdajnfuasfmAUIfaufm3244";

                users.TryAdd(msg.Chat.Id, token);
                await Client.SendTextMessageAsync(msg.Chat.Id, "Авторизация произошла успешно!\nМеню:",
                    replyMarkup: InlineKeyboards.FinalKeyboard);
                
                return;
            case '/':
                var command = CommandParser.ParseCommand(text);
                var commandOutput = command.Execute();
                await Client.SendTextMessageAsync(msg.Chat.Id, commandOutput,replyMarkup: InlineKeyboards.FinalKeyboard);
                //await command.Execute(Client, msg);
                    
                return;
            default:
                await Client.SendTextMessageAsync(msg.Chat.Id, "заткнись и напиши команду", replyMarkup: InlineKeyboards.FinalKeyboard);
                    
                return;
        }
    }*/
}