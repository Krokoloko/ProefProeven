using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour 
{
    private NavMeshAgent _navMeshAgent;
    public bool canMove = true;
    [SerializeField]private GameObject _target;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update() 
    {
        if(canMove) 
        {
            MoveToPoint(_target.transform.position);
        }
    }
    private void MoveToPoint(Vector3 targetPosition) 
    {
        _navMeshAgent.SetDestination(targetPosition);
    }
    
}
