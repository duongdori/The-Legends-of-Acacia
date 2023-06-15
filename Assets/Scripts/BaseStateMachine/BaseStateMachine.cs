using UnityEngine;

public class BaseStateMachine
{
    private BaseState currentState;
    public BaseState CurrentState => currentState;

    public void Initialize(BaseState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}