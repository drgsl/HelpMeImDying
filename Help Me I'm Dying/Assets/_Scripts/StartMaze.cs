using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMaze : MonoBehaviour
{

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == player)
        {
            EnemySpawner.levelstarted = true;
        }
    }
}
