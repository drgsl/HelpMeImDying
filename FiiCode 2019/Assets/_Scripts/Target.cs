using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject player;
    public TargetManager targetmanager;

    public int targetScore;
    FPS fps;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        targetmanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TargetManager>();

        fps = player.GetComponent<FPS>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            targetmanager.targetIndex++;
            Destroy(this.gameObject);
            Changeable.level += targetScore;
            fps.SavePlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            targetmanager.targetIndex++;
            Changeable.level += targetScore;
            fps.SavePlayer();
            if (transform.name != "Ending Of The Maze")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
