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
    public string doortext = "Press E to open the door";

    void Update()
    {
        RaycastHit hit;
        Changeabletext.text = "";
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Door")
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Animator door = hit.transform.GetComponent<Animator>();
                    if (door.GetBool("IsOpen"))
                    {
                        door.SetBool("IsOpen", false);
                    }
                    else
                    {
                        door.SetBool("IsOpen", true);
                    }
                }
                Changeabletext.text = doortext;
            }


            if (hit.transform.tag == "Changeable")
            {
                Changeable target = hit.transform.GetComponent<Changeable>();

                if(Changeable.level >= target.neededlvl)
                    Changeabletext.text = target.changetext;
                else
                    Changeabletext.text = "You must have at least " + target.neededlvl + " points to change this";

                if (Input.GetKeyUp(KeyCode.E))
                {
                    target.Change();
                    Changeabletext.text = "";
                }
            }

        }
    }
}
