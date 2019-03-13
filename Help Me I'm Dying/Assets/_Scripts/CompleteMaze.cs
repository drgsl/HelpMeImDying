using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMaze : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public LuckyManager luckymanager;

    [Space]
    public GameObject weapon;
    public GameObject enemyspawner;
    Buttons buttons;

    private void Awake()
    {
        luckymanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LuckyManager>();
        buttons = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Buttons>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.gameObject.transform.position = new Vector3(0, 0, 0);
            playerHealth.isLucky = false;
            playerHealth.currentHealth = playerHealth.startingHealth;
            playerHealth.healthslider.value = playerHealth.currentHealth;

            luckymanager.TimerStart = false;

            weapon.SetActive(false);
            Destroy(enemyspawner);

            buttons.house.SetActive(true);
            buttons.maze.SetActive(false);
        }

    }
}
