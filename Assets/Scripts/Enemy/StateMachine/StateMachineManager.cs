using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _agroRange;
    private EnemyStateMachine enemyStateMachine;
    private Vector3 _rayDirection;
    private int _layer_mask;

    private void Start()
    {
        enemyStateMachine = GetComponent<EnemyStateMachine>();
    }
    private void Update()
    {
        if(PlayerInRange(_attackRange, false)) 
        {
            enemyStateMachine.ChangeState(EnemyStateMachine.States.Attacking);
            //set stage to attack
        }
        else if(PlayerInRange(_agroRange, true)) 
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
    private bool PlayerInRange(float range , bool ingnoreObjects)
    {
        if(ingnoreObjects) 
        {
            _layer_mask = 1 << 8;
        }
        else
        {
            _layer_mask = 1 << 0 | 1 << 8;
        }

        RaycastHit hit;
        _rayDirection = _player.transform.position - transform.position;
        if(Physics.Raycast(transform.position, _rayDirection, out hit, range, _layer_mask)) 
        {
            if(hit.collider.gameObject.tag == "Player") 
            {
                Debug.DrawRay(transform.position, _rayDirection * hit.distance, Color.green);
                return true;               
            }
        }
        return false;
    }
}
