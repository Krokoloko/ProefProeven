using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectileDamage;
    public float projectileLifeTime;

    void Update() 
    {
        projectileLifeTime -= Time.deltaTime;
        if(projectileLifeTime <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision) 
    {
        if(collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<GenericHealth>().TakeDamage(projectileDamage);
        }
        Destroy(this.gameObject);
    }
}
