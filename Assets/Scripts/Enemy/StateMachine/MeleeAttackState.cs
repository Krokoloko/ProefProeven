using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MonoBehaviour
{
    private EnemyStateMachine _enemyStateMachine;
    private MeleeAttack _meleeAttack;

    void Start() 
    {
        _meleeAttack = GetComponent<MeleeAttack>();
        _enemyStateMachine = GetComponent<EnemyStateMachine>();
        _enemyStateMachine.EnterStateAttacking += EnterAttackState;
        _enemyStateMachine.ExitStateAttacking += ExitAttackState;
    }
    private void EnterAttackState()
    {
        _meleeAttack.StartAttack();
    }
    private void ExitAttackState()
    {
        _meleeAttack.StopAttack();
    }
    private void OnDestroy() 
    {
        _enemyStateMachine.EnterStateAttacking -= EnterAttackState;
        _enemyStateMachine.ExitStateAttacking -= ExitAttackState;
    }
}
