using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GenericHealth _genericHealth;

    private void Start() 
    {
        _genericHealth = GetComponent<GenericHealth>();
        _genericHealth.onDeath.AddListener(EnemyDied);
    }
    private void EnemyDied() 
    {
        Destroy(this.gameObject);
        print("enemy died");
    }
    private void OnDestroy() 
    {
        _genericHealth.onDeath.RemoveListener(EnemyDied);
    }
}
