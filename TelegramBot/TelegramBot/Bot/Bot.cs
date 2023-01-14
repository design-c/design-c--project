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
    private readonly CancellationTokenSource cts;
    private readonly ReceiverOptions receiverOptions;

    private StateMachine.StateMachine stateMachine;
    
    public Bot(BotSettings botSettings)
    {
        client = new TelegramBotClient(botSettings.Token);
        cts = new CancellationTokenSource();
        receiverOptions = new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() };
        stateMachine = new StateMachine.StateMachine();
        stateMachine.ChangeState(new StartState(client, cts.Token, stateMachine));
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
                await stateMachine.CurrentState.HandleMessage(update.Message);
                return;

                //await stateMachine.CurrentState.HandleMessage(botClient, update.Message, cancellationToken, stateMachine);
            
            case { Type: UpdateType.CallbackQuery, CallbackQuery: { }, CallbackQuery.Message: { }}:
                await stateMachine.CurrentState.HandleCallbackQuery(update.CallbackQuery);
                return;
            
                //await stateMachine.CurrentState.HandleCallbackQuery(botClient, update.CallbackQuery, cancellationToken, stateMachine);
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