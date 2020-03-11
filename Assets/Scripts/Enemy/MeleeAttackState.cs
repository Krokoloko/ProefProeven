using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    private MeleeAttack meleeAttack;

    void Start() 
    {
        meleeAttack = GetComponent<MeleeAttack>();
        enemyStateMachine = GetComponent<EnemyStateMachine>();
        enemyStateMachine.EnterStateAttacking += EnterAttackState;
        enemyStateMachine.ExitStateAttacking += ExitAttackState;
    }
    private void EnterAttackState()
    {
        meleeAttack.StartAttack();
    }
    private void ExitAttackState()
    {
        meleeAttack.StopAttack();
    }
    private void OnDestroy() 
    {
        enemyStateMachine.EnterStateAttacking -= EnterAttackState;
        enemyStateMachine.ExitStateAttacking -= ExitAttackState;
    }
}
