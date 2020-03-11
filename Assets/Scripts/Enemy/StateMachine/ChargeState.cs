using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    private MoveToTarget moveToTarget;

    void Start()
    {
        moveToTarget = GetComponent<MoveToTarget>();
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyStateMachine.EnterStateCharge += EnterChargeState;
        enemyStateMachine.ExitStateCharge += ExitChargeState;
    }
    private void EnterChargeState()
    {
        moveToTarget.StartMoving();
    }
    private void ExitChargeState() 
    {
        moveToTarget.StopMoving();
    }
    private void OnDestroy() 
    {
        enemyStateMachine.EnterStateCharge -= EnterChargeState;
        enemyStateMachine.ExitStateCharge -= ExitChargeState;
    }
}
