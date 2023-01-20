using Telegram.Bot;
using TelegramBot.StateMachine.States;
using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine;

public class StateMachine
{
    public BotState CurrentState { get; private set; }

    public StateMachine(long userId, ITelegramBotClient botClient, CancellationToken cancellationToken)
    {
        CurrentState = new StartState(userId, botClient, cancellationToken, this);
    }
    
    public StateMachine()
    {
        CurrentState = null!;
    }
    
    public StateMachine(BotState currentState)
    {
        CurrentState = currentState;
    }

    public void ChangeState(BotState state)
    {
        CurrentState = state;
    }
}