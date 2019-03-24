using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public GameObject loc;
    GameObject oldloc;

    public bool alarmed = false;

    GameObject player;
    NavMeshAgent nav;


    public float wanderRadius = 10f;
    public float wandertimer;

    public Transform target;
    private float timer;

    Camera cam;
    GameObject playercam;

    public static bool DialogueIsFinished = false;

    public Animator anim;

    public GameObject otherenemy;

    private void OnEnable()
    {
        timer = wandertimer;
    }

    // Use this for initialization
    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        nav = GetComponent<NavMeshAgent>();

        playercam = GameObject.FindGameObjectWithTag("MainCamera");
        cam = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {


        if (DialogueIsFinished)
        {
            nav.enabled = true;
        }
        else
        {
            nav.enabled = false;
        }

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1))
        {
            if (hit.transform.tag == "Door")
            {
                Animator door = hit.transform.GetComponent<Animator>();
                door.SetBool("IsOpen", true);
            }
        }

        //FOV
        Vector3 viewpos = cam.WorldToViewportPoint(playercam.transform.position);

        if (viewpos.x >= 0 && viewpos.x <= 1 && viewpos.y >= 0 && viewpos.z > 0)
        {
            if (Physics.Linecast(this.transform.position, playercam.transform.position))
            {
                //Debug.Log("In Vision but blocked by obj");
                alarmed = false;
            }
            else
            {
                Debug.DrawLine(this.transform.position, target.transform.position, Color.red, 10f, true);
                //Debug.Log("Seen");
                alarmed = true;
            }
        }
        else
        {
            //Debug.Log("Not seen");
            alarmed = false;
        }


        if (nav.enabled == true)
        {
            if (alarmed)
            {
                Music.chaseMusic = true;
                if (!anim.GetBool("isAlarmed"))
                {
                    anim.SetBool("isAlarmed", true);
                }
                nav.SetDestination(target.position);
                //SeeYou.text = this.name + " knows where you are";

            }
            else
            {
                if (anim.GetBool("isAlarmed"))
                {
                    anim.SetBool("isAlarmed", false);
                }
                Wander();
                if (!otherenemy.GetComponent<EnemyMovement>().alarmed)
                {
                    Music.chaseMusic = false;
                }
                //SeeYou.text = "Nobody knows where you are";
            }
        }
    }

        void Wander()
    {
        timer += Time.deltaTime; 
        if(timer >= wandertimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            nav.SetDestination(newPos);
            timer = 0;
            Destroy(oldloc);
            oldloc = Instantiate(loc, new Vector3(newPos.x, newPos.y + 2, newPos.z), transform.rotation);
            oldloc.name = "Destination"; 
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
}
