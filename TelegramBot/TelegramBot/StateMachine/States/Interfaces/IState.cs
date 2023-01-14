using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.StateMachine.States.Interfaces;

public interface IState
{
    Task HandleMessage(ITelegramBotClient botClient, 
        Message msg, 
        CancellationToken cancellationToken, 
        StateMachine stateMachine);
    
    Task HandleCallbackQuery(ITelegramBotClient botClient, 
        CallbackQuery callbackQuery, 
        CancellationToken cancellationToken, 
        StateMachine stateMachine);
}