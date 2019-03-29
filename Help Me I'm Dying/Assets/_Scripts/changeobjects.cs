using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class changeobjects : MonoBehaviour
{

    public float range = 5f;
    public GameObject cam;
    public Text Changeabletext;
    public string doortextOpen = "Press E to open the door!";
    public string doortextClose = "Press E to close the door!";
    public string Handletext = "Press E to celebrate Earh Day!";

    AudioSource audiosource;
    public AudioClip woosh;

    FPS fps;

    private void Awake()
    {
        audiosource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FPS>();
    }

    void Update()
    {
        RaycastHit hit;
        Changeabletext.text = "";
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Door")
            {
                Animator door = hit.transform.GetComponent<Animator>();
                if (door.GetBool("IsOpen"))
                {
                    Changeabletext.text = doortextClose;
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        door.SetBool("IsOpen", false);
                    }
                }
                else
                {
                    Changeabletext.text = doortextOpen;
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        door.SetBool("IsOpen", true);
                    }
                }
            }
        }
        if (hit.transform != null)
        {
            if (hit.transform.tag == "Changeable")
            {
                Changeable target = hit.transform.GetComponent<Changeable>();

                if (Changeable.level >= target.neededlvl)
                    Changeabletext.text = target.changetext;
                else
                    Changeabletext.text = "You must have at least " + target.neededlvl + " points to change this";

                if (Input.GetKeyUp(KeyCode.E))
                {
                    audiosource.PlayOneShot(woosh);
                    target.Change();
                    Changeabletext.text = "";
                }
            }

            if (hit.transform.tag == "Handle")
            {
                if (Input.GetKeyUp(KeyCode.E))
                {

                    Animator handle;

                    if (hit.transform.childCount == 0)
                    {
                        handle = hit.transform.GetComponentInParent<Animator>();
                    }
                    else
                    {
                        handle = hit.transform.GetComponentInChildren<Animator>();
                    }
                    handle.SetBool("IsDown", true);
                }
                Changeabletext.text = Handletext;
            }

            if (hit.transform.tag == "KeycardReader")
            {
                Animator keycardanim = hit.transform.GetComponent<Animator>();
                if (TargetManager.HasKeycard)
                {
                    Changeabletext.text = "Press E to use your Keycard";
                    if (Input.GetKeyUp(KeyCode.E))
                    {
                        keycardanim.SetBool("IsOpen", true);
                    }
                }
                else
                {
                    Changeabletext.text = "You have to find a keycard";
                }
            }

        }
    }
}
