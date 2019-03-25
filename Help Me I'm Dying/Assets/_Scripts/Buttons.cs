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
    public Animator quitanim;



    private void Awake()
    {
        if (SceneManager.GetActiveScene().name != "Menu" )  
        {

            fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FPS>();
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

    public void nextLevel()
    {
        fps.SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
