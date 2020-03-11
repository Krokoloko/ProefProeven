using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : MonoBehaviour
{
    private EnemyStateMachine _enemyStateMachine;

    void Start() 
    {
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _enemyStateMachine.EnterStateWandering += EnterWanderState;
        _enemyStateMachine.ExitStateWandering += ExitWanderState;
    }
    private void EnterWanderState() 
    {
        //move back to spawnpoint???
    }
    private void ExitWanderState() 
    {
        
    }
    private void OnDestroy() 
    {
        _enemyStateMachine.EnterStateWandering -= EnterWanderState;
        _enemyStateMachine.ExitStateWandering -= ExitWanderState;
    }
}
