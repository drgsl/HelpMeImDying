using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Music : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip orchestra;
    public AudioClip chase;
    public AudioClip sneaky;

    public static bool chaseMusic;

    private void Awake()
    {
        Time.timeScale = 1f;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = orchestra;

        audioSource.Play();
    }

    private void Update()
    {
        if (chaseMusic)
        {
            if (audioSource.clip != chase)
            {
                audioSource.clip = chase;

                audioSource.Play();
            }

        }
        else if (SceneManager.GetActiveScene().name == "House01")
        {
            if (audioSource.clip != sneaky)
            {
                audioSource.clip = sneaky;

                audioSource.Play();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Credits")
        {
            audioSource.Pause();
        }
        else
        {
            if (audioSource.clip != orchestra)
            {
                audioSource.clip = orchestra;

                audioSource.Play();
            }

        }
    }
}
