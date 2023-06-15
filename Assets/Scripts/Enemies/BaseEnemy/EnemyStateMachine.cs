using UnityEngine;

public class EnemyStateMachine
{
    private EnemyState currentState;
    public EnemyState CurrentState => currentState;

    public void Initialize(EnemyState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }
    public void ChangeState(EnemyState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}