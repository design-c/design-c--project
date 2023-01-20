using System.Collections.Concurrent;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.interfaces;

namespace TelegramBot.Bot;

public class Bot : IBot
{
    private readonly CancellationTokenSource cancelTokenSource;

    private readonly ConcurrentDictionary<long, StateMachine.StateMachine> userStateMachines;

    public Bot(
        TelegramBotClient client,
        CancellationTokenSource cancelTokenSource,
        ReceiverOptions receiverOptions
    )
    {
        this.cancelTokenSource = cancelTokenSource;
        userStateMachines = new ConcurrentDictionary<long, StateMachine.StateMachine>();
        client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions, cancelTokenSource.Token);
    }

    public void StopBot() => cancelTokenSource.Cancel();

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancelToken)
    {
        switch (update)
        {
            case { Type: UpdateType.Message, Message: { } message }:
                var messageUserId = message.Chat.Id;
                CheckUser(messageUserId, botClient, cancelToken);
                
                Console.WriteLine(
                    $"{message.Date} - {message.Chat.Username} - {message.Text} - {userStateMachines[messageUserId].CurrentState.GetType()}");
                
                await userStateMachines[messageUserId].CurrentState.HandleMessage(message);
                return;

            case
            {
                Type: UpdateType.CallbackQuery, 
                CallbackQuery: { } query, 
                CallbackQuery.Message: { } message,
                CallbackQuery.Data: { } queryData
            }:
                var queryUserId = message.Chat.Id;
                CheckUser(queryUserId, botClient, cancelToken);
                
                Console.WriteLine(
                    $"{message.Date} - {message.Chat.Username} - Кнопка - {queryData} - {userStateMachines[queryUserId].CurrentState.GetType()}");
                
                await userStateMachines[queryUserId].CurrentState.HandleCallbackQuery(query);
                return;
            
            default:
                return;
        }
    }

    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancelToken)
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

    private void CheckUser(long userId, ITelegramBotClient botClient, CancellationToken cancelToken)
    {
        if (!userStateMachines.ContainsKey(userId))
            userStateMachines.TryAdd(userId, new StateMachine.StateMachine(userId, botClient, cancelToken));
    }
}