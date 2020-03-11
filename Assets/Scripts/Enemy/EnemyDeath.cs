using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private GenericHealth genericHealth;

    private void Start() 
    {
        genericHealth = GetComponent<GenericHealth>();
        genericHealth.onDeath.AddListener(EnemyDied);
    }
    private void EnemyDied() 
    {
        Destroy(this.gameObject);
        print("enemy died");
    }
    private void OnDestroy() 
    {
        genericHealth.onDeath.RemoveListener(EnemyDied);
    }
}
