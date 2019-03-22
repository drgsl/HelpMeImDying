using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuButton : MonoBehaviour
{
    [Header("For Every Button ")]

    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    [Space]
    [Header("Just for Options Button ")]
    public GameObject optionsMenu;

    [Space]
    [Header("Just for Play Button ")]
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progresstext;

    [Space]
    [Header("Level Selector")]
    public GameObject levelselector;
    public GameObject mainmenu;
    public FPS fps;

    //// Update is called once per frame
    //void Update()
    //{
    //    if (menuButtonController.index == thisIndex)
    //    {
    //        animator.SetBool("selected", true);
    //        if (Input.GetAxis("Submit") == 1)
    //        {
    //            animator.SetBool("pressed", true);
    //        }
    //        else if (animator.GetBool("pressed"))
    //        {
    //            animator.SetBool("pressed", false);
    //            animatorFunctions.disableOnce = true;
    //            if (thisIndex == 0) LevelSelector();
    //            if (thisIndex == 1) Options();
    //            if (thisIndex == 2) QuitGame();
    //        }
    //    }
    //    else
    //    {
    //        animator.SetBool("selected", false);
    //    }

    //}

    public void LevelSelector()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        Cursor.visible = true;
        levelselector.SetActive(true);
        optionsMenu.SetActive(false);
        mainmenu.SetActive(false);
        fps.LoadPlayer();
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
