using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUp : MonoBehaviour
{

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            player.gameObject.transform.position = new Vector3(0, 1, 0);
        }
    }
}
