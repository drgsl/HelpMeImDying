using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthslider;
    public Image damageImage;
    public AudioClip deathclip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public GameObject NormalEndMenu;

    Animator anim;
    AudioSource playerAudio;
    bool isDead;
    bool damaged;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {

        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false; 


	}


    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthslider.value = currentHealth;
        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Cursor.visible = true;
            NormalEndMenu.SetActive(true);
        }
    }


    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        playerAudio.clip = deathclip;
        playerAudio.Play();
    }
}
