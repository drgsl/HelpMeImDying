using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changeable : MonoBehaviour
{

    public GameObject changed;
    public int value;
    public int neededlvl;
    public static int level = -1;
    Text scoretext;
    public string changetext = "Press E to help the planet";

    FPS fps;

    Animator CharAnim;

    public GameObject[] particles;


    private void Awake()
    {
        scoretext = GameObject.Find("ScoreText").GetComponentInChildren<Text>();
        fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FPS>();

        CharAnim = fps.gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        scoretext.text = "" + level +" Eco - Points";
    }

    public void Change()
    {
        if (level >= neededlvl)
        {
            CharAnim.SetTrigger("PickUp");
            level += value;
            //GameObject newobj = 
            Instantiate(changed, transform.position, transform.rotation);
            fps.SavePlayer();
            //newobj.transform.localScale = gameObject.transform.localScale;
            Destroy(gameObject);
        }
    }
}
