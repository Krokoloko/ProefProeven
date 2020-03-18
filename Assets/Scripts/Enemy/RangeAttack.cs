using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _projectileDamage;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileLifeTime; 
    [SerializeField] private Vector3 _pivotPointOffset;
    private float _shootTimer;
    private bool _canShoot = false;

    public delegate void onAttack();
    public event onAttack OnAttack;

    private void Update() 
    {
        _shootTimer += Time.deltaTime;
        if(_canShoot && _fireRate <= _shootTimer) 
        {
            _shootTimer = 0;
            Shoot();
        }
    }
    private void Shoot()
    {
        OnAttack?.Invoke();
        Vector3 _shootDirection = _target.transform.position - (transform.position + _pivotPointOffset);
        GameObject _spawnedObject = Instantiate(_projectile, (transform.position + _pivotPointOffset), Quaternion.EulerAngles(0, 0, 0));
        Physics.IgnoreCollision(_spawnedObject.GetComponent<Collider>(), GetComponent<Collider>());
        _spawnedObject.transform.parent = transform;
        _spawnedObject.GetComponent<Rigidbody>().velocity = _shootDirection.normalized * _projectileSpeed;
        _spawnedObject.GetComponent<Projectile>().projectileDamage = _projectileDamage;
        _spawnedObject.GetComponent<Projectile>().projectileLifeTime = _projectileLifeTime;
    }
    public void StartShooting() 
    {
        _canShoot = true;
    }
    public void StopShooting() 
    {
        _canShoot = false;
    }
    public void ChangeTarget(GameObject _newTarget) 
    {
        _target = _newTarget;
    }
}
