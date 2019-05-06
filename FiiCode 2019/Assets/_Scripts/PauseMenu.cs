using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenu;

    public PlayerHealth playerHealth;



	// Use this for initialization
	void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update () {
        if (playerHealth.currentHealth > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && EnemyMovement.DialogueIsFinished)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
	}

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        GameIsPaused = true;
    }
}
