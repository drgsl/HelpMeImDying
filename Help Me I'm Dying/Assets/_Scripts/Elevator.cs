using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject player;
    public Transform teleportGoal;

    private void OnCollisionEnter(Collision collision)
    {
            collision.gameObject.transform.position = teleportGoal.position;
    }
}
