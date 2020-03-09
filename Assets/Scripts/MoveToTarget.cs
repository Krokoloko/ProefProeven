using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour 
{
    private NavMeshAgent navMeshAgent;
    private bool canMove = true;

    [SerializeField]private GameObject Test;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update() 
    {
        if(canMove) 
        {
            MoveToPoint(Test.transform.position);
        }
    }
    private void MoveToPoint(Vector3 TargetPosition) 
    {
        navMeshAgent.SetDestination(TargetPosition);
    }
    
}
