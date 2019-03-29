using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SecondTargetManager : MonoBehaviour
{
    LineRenderer lineRenderer;

    public bool easymode = true;
    GameObject[] targets;
    Transform[] transArray;


    public Text TargetText;

    public GameObject player;


    private void Awake()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.05f;

        lineRenderer = GetComponent<LineRenderer>();

        TargetText = GameObject.FindGameObjectWithTag("TargetText").GetComponent<Text>();

        player = GameObject.FindGameObjectWithTag("Player");

        targets = GameObject.FindGameObjectsWithTag("Changeable");

        transArray = new Transform[targets.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            transArray[i] = targets[i].transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GetClosestEnemy(transArray) == null)
        {
            Time.timeScale = 1f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            MenuButton.LevelSelectorActive = true;

            SceneManager.LoadScene("Menu");
        }
        else
        {
            string LayerIndex = LayerMask.LayerToName(GetClosestEnemy(transArray).gameObject.layer);
            TargetText.text = "You can " + LayerIndex;
        }

        if (easymode)
        {
            if (lineRenderer.positionCount != 2)
            {
                lineRenderer.positionCount = 2;
            }

            lineRenderer.SetPosition(0, player.transform.position);
            lineRenderer.SetPosition(1, GetClosestEnemy(transArray).transform.position);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }

    }

    public Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = player.transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (potentialTarget !=null)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    if (potentialTarget.GetComponent<Changeable>().neededlvl <= Changeable.level)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        bestTarget = potentialTarget;
                    }

                }
            }

        }

        return bestTarget;
    }

    public void ChangeMode(bool mode)
    {
        easymode = mode;
    }
}
