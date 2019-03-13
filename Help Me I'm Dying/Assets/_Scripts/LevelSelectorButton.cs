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

    private void Awake()
    {
        button = GetComponent<Button>();
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

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progresstext.text = progress * 100 + "%";

            yield return null;
        }
    }
}
