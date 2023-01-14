using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine;

public class StateMachine
{
    public BotState CurrentState { get; private set; }

    public StateMachine()
    {
        CurrentState = null!;
    }
    
    public StateMachine(BotState currentState)
    {
        CurrentState = currentState;
    }

    public void ChangeState(BotState state) => CurrentState = state;
}