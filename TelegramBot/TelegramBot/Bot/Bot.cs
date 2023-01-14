using Application.Commands.Utils;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.interfaces;
using TelegramBot.Settings;
using TelegramBot.StateMachine.States;

namespace TelegramBot.Bot;

public class Bot : IBot
{
    private readonly TelegramBotClient client;
    private readonly CancellationTokenSource cts = new();
    private readonly ReceiverOptions receiverOptions = new() { AllowedUpdates = Array.Empty<UpdateType>() };

    private StateMachine.StateMachine stateMachine = new (new StartState());
    
    public Bot(BotSettings botSettings)
    {
        client = new TelegramBotClient(botSettings.Token);
        client.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync, receiverOptions, cts.Token);
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
                await stateMachine.CurrentState.HandleMessage(botClient, update.Message, cancellationToken, stateMachine);
                return;
            }
            case { Type: UpdateType.CallbackQuery, CallbackQuery: { } }:
            {
                await stateMachine.CurrentState.HandleCallbackQuery(botClient, update.CallbackQuery, cancellationToken, stateMachine);
                return;
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
}