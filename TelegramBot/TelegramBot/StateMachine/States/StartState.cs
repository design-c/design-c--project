using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.InputMethods.InlineKeyboards;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine.States;

public class StartState : IState
{
    public async Task HandleMessage(ITelegramBotClient botClient, 
        Message msg, 
        CancellationToken cancellationToken, 
        StateMachine stateMachine)
    {
        if (msg.Text == "дарова")
        {
            stateMachine.ChangeState(new LoginState());
            return;
        }
        
        await botClient.SendTextMessageAsync(chatId: msg.Chat.Id, 
            text: "дарова епта", 
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
            text: "и чо", 
            replyMarkup: InlineKeyboards.StartKeyboard, 
            cancellationToken: cancellationToken);
    }
}