using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StationEnemy : MonoBehaviour
{

    GameObject oldloc;

    NavMeshAgent nav;

    public float wanderRadius = 10f;
    public float wandertimer;

    private float timer;

     GameObject winmenu;



    GameObject player;
    PlayerHealth playerHealth;
    public int attackDamage = 10;

    AudioSource audiosource;
    public AudioClip attack;

    // Start is called before the first frame update
    void Start()
    {
        winmenu = GameObject.FindGameObjectWithTag("WinMenu");
        audiosource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        //for (int i = 0; i < 10; i++)
        //{
        //    {
        //        float x = Random.Range(-50, 100);
        //        float y = 0;
        //        float z = Random.Range(-60, -300);
        //        Vector3 pos = new Vector3(x, y, z);
        //        GameObject obj = Instantiate(enemy, pos, Quaternion.);
        //    }
        //}

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= wandertimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            nav.SetDestination(newPos);
            timer = 0;
        }

    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            audiosource.PlayOneShot(attack);
            playerHealth.TakeDamage(attackDamage);
            player.gameObject.transform.position = new Vector3(0, 1, 0);
        }
    }
}
