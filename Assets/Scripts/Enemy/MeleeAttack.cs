using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float _attackRate;
    [SerializeField] private float _attackRange;
    [SerializeField] private int _hitDamage;
    [SerializeField] private Vector3 _pivotPointOffset;
    [SerializeField] private bool _hitEnemys;
    [SerializeField] private bool _hitPlayer;
    private int _hitLayers;
    private float _attackTimer;
    private bool _canAttack = false;

    private void Start()
    {
        if(_hitEnemys) 
        {
            _hitLayers = _hitLayers | 1 << 8;
        }
        if(_hitPlayer) 
        {
            _hitLayers = _hitLayers | 1 << 9;
        }
    }
    private void Update() 
    {
        _attackTimer += Time.deltaTime;
        if(_canAttack && _attackRate <= _attackTimer)
        {
            _attackTimer = 0;
            Attack();
        }
    }
    private void Attack() 
    {
        print("meleeAttack");        
        Vector3 _attackPosition = transform.position + _pivotPointOffset + transform.forward.normalized;
        Collider[] hitTargets = Physics.OverlapSphere(_attackPosition, _attackRange, _hitLayers);

        foreach(Collider hit in hitTargets) 
        {
            hit.GetComponent<GenericHealth>().TakeDamage(_hitDamage);
        }
    }
    private void OnDrawGizmosSelected() 
    {
        Vector3 _attackPosition = transform.position + _pivotPointOffset + transform.forward.normalized;
        Gizmos.DrawWireSphere(_attackPosition, _attackRange);
    }
    public void StartAttack() 
    {
        _canAttack = true;
    }
    public void StopAttack() 
    {
        _canAttack = false;
    }
}
