using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class MainState : IState
{
    public async Task HandleMessage(ITelegramBotClient botClient, 
        Message msg, 
        CancellationToken cancellationToken, 
        StateMachine stateMachine)
    {
        var text = msg.Text;

        if (text == null)
        {
            await botClient.SendTextMessageAsync(msg.Chat.Id, "пиши текстом мужик",
                replyMarkup: InlineKeyboards.FinalKeyboard, cancellationToken: cancellationToken);

            return;
        }

        Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - {text}");

        switch (text[0])
        {
            case ':':
                var loginInfo = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var token = "AdajnfuasfmAUIfaufm3244";

                //users.TryAdd(msg.Chat.Id, token);
                await botClient.SendTextMessageAsync(msg.Chat.Id, "Авторизация произошла успешно!\nМеню:",
                    replyMarkup: InlineKeyboards.FinalKeyboard);

                return;
            case '/':
                var command = CommandParser.ParseCommand(text);
                var commandOutput = command.Execute();
                await botClient.SendTextMessageAsync(chatId: msg.Chat.Id,
                    text: commandOutput,
                    replyMarkup: InlineKeyboards.FinalKeyboard,
                    cancellationToken: cancellationToken);

                return;
            default:
                await botClient.SendTextMessageAsync(msg.Chat.Id,
                    "заткнись и напиши команду",
                    replyMarkup: InlineKeyboards.FinalKeyboard,
                    cancellationToken: cancellationToken);

                return;
        }
    }

    public async Task HandleCallbackQuery(ITelegramBotClient botClient, 
        CallbackQuery callbackQuery,
        CancellationToken cancellationToken, 
        StateMachine stateMachine)
    {
        var msg = callbackQuery.Message;
                
        Console.WriteLine($"{msg.Date} - {msg.Chat.Username} - Кнопка - {callbackQuery.Data}");
        var command = CommandParser.ParseCommand(callbackQuery.Data);
        var commandOutput = command.Execute();
        await botClient.SendTextMessageAsync(msg.Chat.Id, commandOutput, replyMarkup: InlineKeyboards.FinalKeyboard, cancellationToken: cancellationToken);
    }
}