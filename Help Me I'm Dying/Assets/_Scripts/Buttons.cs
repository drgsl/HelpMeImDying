using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Buttons : MonoBehaviour {



    Resolution[] resolutions;

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;




    public GameObject optionsMenu;

    public WinMenu winmenu;

    FPS fps;

    //public GameObject SaveButtons
    GameObject player;
    public GameObject EndMenu;
    PlayerHealth playerHealth;
    DialogueTrigger luckydialogtrigger;

    public GameObject enemyspawner;

    public GameObject maze;
    public GameObject house;

    public Animator quitanim;



    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            fps = player.GetComponent<FPS>();
            luckydialogtrigger = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DialogueTrigger>();
        }

    }

    public void LoadMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        if (winmenu.Finished)
        {
            fps.SavePlayer();
        }
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        if (winmenu != null)
        {
            if (winmenu.Finished)
            {
                fps.SavePlayer();
            }
        }
        Application.Quit();
        Debug.Log("Quitting game....");
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        fps.LoadPlayer();
        Changeable.level = 0;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void TryYourLuck()
    {
        if (enemyspawner!= null)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            Cursor.visible = true;

            house.SetActive(false);
            maze.SetActive(true);

            player.gameObject.transform.position = new Vector3(0, -1000, 0);
            EndMenu.SetActive(false);
            playerHealth.currentHealth = playerHealth.startingHealth;
            playerHealth.healthslider.value = playerHealth.currentHealth;
            playerHealth.isLucky = true;

            luckydialogtrigger.TriggerDialogue();
        }
        else
        {
            //play NO audio
        }

    }

    //Lucky Functions
    public void RestartGame()
    {
        fps.ResetProgress();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
    }




    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    public void OpenQuitMenu()
    {
        quitanim.SetBool("isOpen", true);
    }
    public void CloseQuitMenu()
    {
        quitanim.SetBool("isOpen", false);
    }
}
