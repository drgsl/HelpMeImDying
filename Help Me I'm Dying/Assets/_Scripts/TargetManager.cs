using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{

    LineRenderer lineRenderer;

    public bool easymode = true;
    public GameObject[] targets;

    [HideInInspector] public int targetIndex = 0;

    public Text TargetText;

    public GameObject player;

    public static bool HasKeycard = false;

    public GameObject Handle;

    public bool mazelevel;

    void Start()
    {

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.05f;

        lineRenderer = GetComponent<LineRenderer>();

        TargetText = GameObject.FindGameObjectWithTag("TargetText").GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");

        targets = GameObject.FindGameObjectsWithTag("Target");

        Handle = GameObject.FindGameObjectWithTag("Handle");

            for (int i = 1; i < targets.Length; i++)
            {
                targets[i].SetActive(false);
            }

        HasKeycard = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (easymode)
        {
            if (lineRenderer.positionCount != 2)
            {
                lineRenderer.positionCount = 2;
            }

            if (targetIndex == targets.Length)
            {
                lineRenderer.positionCount = 0;
            }
            else
            {
                if (!targets[targetIndex].activeSelf)
                {
                    targets[targetIndex].SetActive(true);
                }
                lineRenderer.SetPosition(0, player.transform.position);
                lineRenderer.SetPosition(1, targets[targetIndex].transform.position);
            }
        }
        else
        {
            if (lineRenderer.positionCount != 0)
            {
                lineRenderer.positionCount = 0;
            }
        }



        if (targetIndex != targets.Length)
        {
            if (!targets[targetIndex].activeSelf)
            {
                targets[targetIndex].SetActive(true);
            }

            if (targetIndex == 0)
            {
                TargetText.text = " You should find " + targets[targetIndex].name;
            }
            else
            {
                TargetText.text = " You should find " + targets[targetIndex].name + " now ";
            }
        }
        else
        {
            TargetText.text = " Congrats! You found everything, now go and save the planet! ";
            HasKeycard = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, Handle.transform.position);
        }

    }

    public void ChangeMode(bool mode)
    {
        easymode = mode;
    }

}
