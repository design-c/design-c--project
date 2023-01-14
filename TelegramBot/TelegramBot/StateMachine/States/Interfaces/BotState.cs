using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.StateMachine.States.Interfaces;

public abstract class BotState
{
    protected ITelegramBotClient botClient;
    protected CancellationToken cancellationToken;
    protected StateMachine stateMachine;

    protected BotState(ITelegramBotClient botClient, CancellationToken cancellationToken, StateMachine stateMachine)
    {
        this.botClient = botClient;
        this.cancellationToken = cancellationToken;
        this.stateMachine = stateMachine;
    }

    public abstract Task HandleMessage(Message message);
    public abstract Task HandleCallbackQuery(CallbackQuery callbackQuery);
    
    protected Task TypeMessage(Message message, string text, IReplyMarkup replyMarkup)
    {
        return botClient.SendTextMessageAsync(chatId: message.Chat.Id, 
            text: text, 
            replyMarkup: replyMarkup, 
            cancellationToken: cancellationToken);
    }
}