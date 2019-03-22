using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteMazeLevel : MonoBehaviour
{
    GameObject player;

    public LevelSelectorButton levelselectorbutton;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            
        }
    }
}
