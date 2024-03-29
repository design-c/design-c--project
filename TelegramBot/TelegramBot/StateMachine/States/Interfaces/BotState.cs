using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.StateMachine.States.Interfaces;

public abstract class BotState
{
    protected readonly long userId;
    protected readonly ITelegramBotClient botClient;
    protected readonly CancellationToken cancellationToken;
    protected readonly StateMachine stateMachine;

    protected BotState(long userId, ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine)
    {
        this.userId = userId;
        this.botClient = botClient;
        this.cancellationToken = cancellationToken;
        this.stateMachine = stateMachine;
    }

    public abstract Task HandleMessage(Message message);
    public abstract Task HandleCallbackQuery(CallbackQuery callbackQuery);
    
    protected Task TypeMessage(string text, IReplyMarkup replyMarkup)
    {
        return botClient.SendTextMessageAsync(chatId: userId, 
            text: text, 
            replyMarkup: replyMarkup, 
            cancellationToken: cancellationToken);
    }
}