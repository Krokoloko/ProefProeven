using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    private RangeAttack rangeAttack;

    void Start() 
    {
        rangeAttack = GetComponent<RangeAttack>();
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyStateMachine.EnterStateAttacking += EnterAttackState;
        enemyStateMachine.ExitStateAttacking += ExitAttackState;
    }
    private void EnterAttackState()
    {
        rangeAttack.StartShooting();
    }
    private void ExitAttackState()
    {
        rangeAttack.StopShooting();
    }
    private void OnDestroy() 
    {
        enemyStateMachine.EnterStateAttacking -= EnterAttackState;
        enemyStateMachine.ExitStateAttacking -= ExitAttackState;
    }
}
