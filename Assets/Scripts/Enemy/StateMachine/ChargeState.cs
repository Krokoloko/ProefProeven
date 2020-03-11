using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    private MoveToTarget _moveToTarget;

    void Start()
    {
        _moveToTarget = GetComponent<MoveToTarget>();
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyStateMachine.EnterStateCharge += EnterChargeState;
        enemyStateMachine.ExitStateCharge += ExitChargeState;
    }
    private void EnterChargeState()
    {
        _moveToTarget.StartMoving();
    }
    private void ExitChargeState() 
    {
        _moveToTarget.StopMoving();
    }
    private void OnDestroy() 
    {
        enemyStateMachine.EnterStateCharge -= EnterChargeState;
        enemyStateMachine.ExitStateCharge -= ExitChargeState;
    }
}
