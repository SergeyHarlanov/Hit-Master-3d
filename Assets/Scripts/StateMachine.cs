using UnityEngine;


public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    public void UpdateState()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
