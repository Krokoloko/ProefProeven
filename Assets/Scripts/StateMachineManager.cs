using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private EnemyStateMachine enemyStateMachine;    
    private int layer_mask;
    private Vector3 rayDirection;

    [SerializeField] private int attackRange;
    [SerializeField] private int agroRange;


    private void Start()
    {
        enemyStateMachine = GetComponent<EnemyStateMachine>();
    }
    private void Update()
    {
        if(PlayerInRange(attackRange , false)) 
        {
            enemyStateMachine.ChangeState(EnemyStateMachine.States.Attacking);
            //set stage to attack
        }
        else if(PlayerInRange(agroRange, true)) 
        {
            enemyStateMachine.ChangeState(EnemyStateMachine.States.Charge);
            //set stage to charge
        }
        else
        {
            enemyStateMachine.ChangeState(EnemyStateMachine.States.Wandering);
            //set stage to wander
        }
    }
    private bool PlayerInRange(int range , bool ingnoreObjects)
    {
        if(ingnoreObjects) 
        {
            layer_mask = 1 << 8;
        }
        else
        {
            layer_mask = 1 << 0 | 1 << 8;
        }

        RaycastHit hit;
        rayDirection = _player.transform.position - transform.position;
        if(Physics.Raycast(transform.position, rayDirection, out hit, range, layer_mask)) 
        {
            if(hit.collider.gameObject.tag == "Player") 
            {
                Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.green);
                return true;               
            }
        }
        return false;
    }
}
