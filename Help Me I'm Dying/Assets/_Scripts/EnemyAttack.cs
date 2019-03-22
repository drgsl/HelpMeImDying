using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = .5f;
    public int attackDamage = 10;


    GameObject player;
    PlayerHealth playerHealth;
    private bool playerInRange;
    private float timer;
    LuckyManager luckymanager;

    GameObject[] enemies;


    GameObject[] spawnpoints;



    // Use this for initialization
    void Awake () {
        luckymanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LuckyManager>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();

        spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }

        if(playerHealth.currentHealth <= 0)
        {
            //tell the anim the player is dead
        }

	}


    void Attack()
    {
        timer = 0f; 
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
            if (luckymanager.TimerStart == false)
            {
                player.gameObject.transform.position = new Vector3(0, 1, 0);
                for (int i = 0; i < enemies.Length; i++)
                {
                    EnemyMovement enemymovement = enemies[i].GetComponent<EnemyMovement>();
                    enemymovement.alarmed = false;
                    enemies[i].transform.position = spawnpoints[i].transform.position;
                }
            }
        }
    }
}
