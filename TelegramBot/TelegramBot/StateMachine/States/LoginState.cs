using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class LoginState : IState
{
    public async Task HandleMessage(ITelegramBotClient botClient, 
        Message msg, 
        CancellationToken cancellationToken, 
        StateMachine stateMachine)
    {
        if (msg.Text == "сам завались")
        {
            stateMachine.ChangeState(new MainState());
            return;
        }
        
        await botClient.SendTextMessageAsync(chatId: msg.Chat.Id, 
                    text: "завались", 
                    replyMarkup: InlineKeyboards.StartKeyboard, 
                    cancellationToken: cancellationToken);
         
    }

    public async Task HandleCallbackQuery(ITelegramBotClient botClient, 
        CallbackQuery callbackQuery,
        CancellationToken cancellationToken, 
        StateMachine stateMachine)
    {
        var msg = callbackQuery.Message;
        await botClient.SendTextMessageAsync(chatId: msg.Chat.Id, 
            text: "да не кликай", 
            replyMarkup: InlineKeyboards.StartKeyboard, 
            cancellationToken: cancellationToken);
    }
}