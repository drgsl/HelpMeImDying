using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorButton : MonoBehaviour
{
    private Button button;
    public GameObject buttonText;
    
    public float NeededLevel;

    public GameObject LoadingScreen;
    public Slider slider;
    public Text progresstext;

    public bool intro;

    FPS player;

    Text loadingText;

    string[] Tips = new string[] {  "The area of forests we lose every minute is equivalent to 48 football fields.",
                                    "Approximately 600,000 deaths occurred worldwide as a result of weather-related natural disasters",
                                    "2014 was the world’s hottest year on record, surpassing the previous record set in 2010, tied with 2005.",
                                    "There is more carbon dioxide in the atmosphere today than at any point in the past 800,000 years",
                                    "Since the beginning of the Industrial Revolution, the acidity of surface ocean waters has increased by about 30 percent."};
    int tipIndex;

    private void Awake()
    {
        button = GetComponent<Button>();
        loadingText = LoadingScreen.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Changeable.level >= NeededLevel)
        {
            button.interactable = true;
            buttonText.SetActive(true);
        }
        else
        {
            button.interactable = false;
            buttonText.SetActive(false);
        }
    }

    public void PlayGame(int index)
    {

        if (intro)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        Time.timeScale = 1f;
        StartCoroutine(LoadAsynchronously(index));
    }

    IEnumerator LoadAsynchronously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);//SceneManager.GetActiveScene().buildIndex + 1);

        LoadingScreen.SetActive(true);

        tipIndex = Random.Range(0, Tips.Length);
        loadingText.text = Tips[tipIndex];

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progresstext.text = progress * 100 + "%";


            yield return null;
        }
    }
}
