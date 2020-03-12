using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour 
{
    [SerializeField] private GameObject _target;
    private NavMeshAgent _navMeshAgent;
    private bool _canMove = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update() 
    {
        _navMeshAgent.enabled = _canMove;

        if(_canMove)
        {
            MoveToPoint(_target.transform.position);
        }
    }
    private void MoveToPoint(Vector3 targetPosition) 
    {        
        _navMeshAgent.SetDestination(targetPosition);
    }
    public void StartMoving() 
    {
        _canMove = true;
    }
    public void StopMoving() 
    {
        _canMove = false;
    }
}
