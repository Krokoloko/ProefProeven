using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour 
{
    private States _currentState;

    public delegate void enterStateAttacking();
    public event enterStateAttacking EnterStateAttacking;
    public delegate void enterStateWandering();
    public event enterStateWandering EnterStateWandering;
    public delegate void enterStateCharge();
    public event enterStateCharge EnterStateCharge;
    public delegate void exitStateAttacking();
    public event exitStateAttacking ExitStateAttacking;
    public delegate void exitStateWandering();
    public event exitStateWandering ExitStateWandering;
    public delegate void exitStateCharge();
    public event exitStateCharge ExitStateCharge;

    public enum States
    {
        Attacking,
        Wandering,
        Charge,
    }
    private void Start() 
    {
        ChangeState(States.Wandering);
    }
    private void StateEnter() 
    {
        switch(_currentState)
        {
            case States.Attacking:
            EnterStateAttacking?.Invoke();
            break;
            case States.Wandering:
            EnterStateWandering?.Invoke();
            break;
            case States.Charge:
            EnterStateCharge?.Invoke();
            break;
        }
    }
    private void StateExit() 
    {
        switch(_currentState) 
        {
            case States.Attacking:
            ExitStateAttacking?.Invoke();
            break;
            case States.Wandering:
            ExitStateWandering?.Invoke();
            break;
            case States.Charge:
            ExitStateCharge?.Invoke();
            break;
        }
    }
    public void ChangeState(States newState)
    {
        print("state: " + newState);
        StateExit();
        _currentState = newState;
        StateEnter();
    }
    public States GetState()
    {
        return _currentState;
    }
}
