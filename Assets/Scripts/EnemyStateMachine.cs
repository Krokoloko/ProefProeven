using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour 
{
    //enemy aanvallen kan dan niet lopen 
    //hij loopt naar je toe als je binnen zijn vision range bent
    //hij shiet pas als je in shiet range ben
    //wander = idle

    private States currentState;

    public delegate void stateAttacking();
    public event stateAttacking StateAttacking;
    public delegate void stateWandering();
    public event stateWandering StateWandering;
    public delegate void stateCharge();
    public event stateCharge StateCharge;

    public enum States
    {
        Attacking,
        Wandering,
        Charge,
    }
    private void Start() 
    {
        currentState = States.Wandering;
    }
    private void Update() 
    {   
        switch(currentState) 
        {
            case States.Attacking:
            StateAttacking?.Invoke();
            break;
            case States.Wandering:
            StateWandering?.Invoke();
            break;
            case States.Charge:
            StateCharge?.Invoke();
            break;
        }
    }
    public void ChangeState(States newState)
    {
        print("state: " + newState);
        currentState = newState;
    }
    public States GetState()
    {
        return currentState;
    }
}
