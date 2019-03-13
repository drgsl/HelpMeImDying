using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : MonoBehaviour
{

    public int NeededLevelToFinish;

    public GameObject winmenu;
    [HideInInspector]
    public bool Finished = false;

    void Update()
    {
        if (Changeable.level >= NeededLevelToFinish && !Finished)
        {
            winmenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Finished = true;
        }
    }
}
