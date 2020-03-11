using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : MonoBehaviour
{
    private EnemyStateMachine _enemyStateMachine;
    private MoveToTarget _moveToTarget;

    void Start()
    {
        _moveToTarget = GetComponent<MoveToTarget>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _enemyStateMachine.EnterStateCharge += EnterChargeState;
        _enemyStateMachine.ExitStateCharge += ExitChargeState;
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
        _enemyStateMachine.EnterStateCharge -= EnterChargeState;
        _enemyStateMachine.ExitStateCharge -= ExitChargeState;
    }
}
