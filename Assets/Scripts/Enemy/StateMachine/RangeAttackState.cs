using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : MonoBehaviour
{
    private EnemyStateMachine _enemyStateMachine;
    private RangeAttack _rangeAttack;

    void Start() 
    {
        _rangeAttack = GetComponent<RangeAttack>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _enemyStateMachine.EnterStateAttacking += EnterAttackState;
        _enemyStateMachine.ExitStateAttacking += ExitAttackState;
    }
    private void EnterAttackState()
    {
        _rangeAttack.StartShooting();
    }
    private void ExitAttackState()
    {
        _rangeAttack.StopShooting();
    }
    private void OnDestroy() 
    {
        _enemyStateMachine.EnterStateAttacking -= EnterAttackState;
        _enemyStateMachine.ExitStateAttacking -= ExitAttackState;
    }
}
