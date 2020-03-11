using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;

    void Start() 
    {
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyStateMachine.EnterStateWandering += EnterWanderState;
        enemyStateMachine.ExitStateWandering += ExitWanderState;
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
        enemyStateMachine.EnterStateWandering -= EnterWanderState;
        enemyStateMachine.ExitStateWandering -= ExitWanderState;
    }
}
