using TelegramBot.StateMachine.States.Interfaces;

namespace TelegramBot.StateMachine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public StateMachine(IState currentState)
    {
        CurrentState = currentState;
    }

    public void ChangeState(IState state) => CurrentState = state;
}