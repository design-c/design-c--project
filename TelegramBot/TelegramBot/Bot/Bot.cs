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
    private readonly CancellationTokenSource cancellationToken;

    private ConcurrentDictionary<long, StateMachine.StateMachine> userStateMachines;

    public Bot(
        TelegramBotClient client,
        CancellationTokenSource cancellationToken,
        ReceiverOptions receiverOptions
    )
    {
        this.cancellationToken = cancellationToken;
        userStateMachines = new ConcurrentDictionary<long, StateMachine.StateMachine>();
        client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions, cancellationToken.Token);
    }

    public void StopBot() => cancellationToken.Cancel();

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        switch (update)
        {
            case { Type: UpdateType.Message, Message: { } }:
                CheckUser(update.Message.Chat.Id, botClient, cancellationToken);
                Console.WriteLine(
                    $"{update.Message.Date} - {update.Message.Chat.Username} - {update.Message.Text} - {userStateMachines[update.Message.Chat.Id].CurrentState.GetType()}");
                await userStateMachines[update.Message.Chat.Id].CurrentState.HandleMessage(update.Message);
                return;

            case { Type: UpdateType.CallbackQuery, CallbackQuery: { }, CallbackQuery.Message: { } }:
                CheckUser(update.CallbackQuery.Message.Chat.Id, botClient, cancellationToken);
                Console.WriteLine(
                    $"{update.CallbackQuery.Message.Date} - {update.CallbackQuery.Message.Chat.Username} - Кнопка - {update.CallbackQuery.Data} - {userStateMachines[update.CallbackQuery.Message.Chat.Id].CurrentState.GetType()}");
                await userStateMachines[update.CallbackQuery.Message.Chat.Id].CurrentState
                    .HandleCallbackQuery(update.CallbackQuery);
                return;
        }
    }

    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken token)
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

    private void CheckUser(long userId, ITelegramBotClient botClient, CancellationToken cancellationToken)
    {
        if (!userStateMachines.ContainsKey(userId))
        {
            userStateMachines.TryAdd(userId, new StateMachine.StateMachine(userId, botClient, cancellationToken));
            Console.WriteLine($"{userId} - {userStateMachines[userId].CurrentState.GetType()}");
        }
    }
}