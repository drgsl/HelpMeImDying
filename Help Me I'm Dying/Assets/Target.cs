using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject player;
    public TargetManager targetmanager;

    public int targetScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        targetmanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TargetManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            targetmanager.targetIndex++;
            Destroy(this.gameObject);
            Changeable.level += targetScore;
        }
    }
}
