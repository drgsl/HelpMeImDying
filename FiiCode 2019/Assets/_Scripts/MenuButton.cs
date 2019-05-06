using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuButton : MonoBehaviour
{
    [Space]
    [Header("Just for Options Button ")]
    public GameObject optionsMenu;

    [Space]
    [Header("Level Selector")]
    public GameObject levelselector;
    public GameObject mainmenu;

    public static bool LevelSelectorActive = false;

    private void Awake()
    {
        if (LevelSelectorActive)
            {
                levelselector.SetActive(true);
                LevelSelectorActive = false;
            }
    }

    public void LevelSelector()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        Cursor.visible = true;
        levelselector.SetActive(true);
        optionsMenu.SetActive(false);
        mainmenu.SetActive(false);
    }


    public void Options()
    {

        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            optionsMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }

}
