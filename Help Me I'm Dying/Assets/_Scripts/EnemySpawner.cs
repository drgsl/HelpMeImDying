using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    PlayerHealth playerHealth;
    public GameObject[] enemies;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    int i = 0;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        int index = Random.Range(0, enemies.Length);

        GameObject obj = Instantiate(enemies[index], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        i++;
        obj.name = i + ". " + enemies[index].name;
        obj.transform.parent = this.transform;
    }
}
