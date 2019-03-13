using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public float health = 400f;
    public GameObject destroyedVersion;

    public static float killcount;
    public static bool isDead = false;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            killcount++;
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(destroyedVersion, transform.position, transform.rotation);
    }
}
