using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyManager : MonoBehaviour
{
    [HideInInspector] public float timeLeft = 300f;
    [HideInInspector] public bool TimerStart;
    public Text text;
    PlayerHealth playerHealth;
    FPS fps;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FPS>();
    }

    void Update()
    {
        if (TimerStart)
        {
            timeLeft -= Time.deltaTime;
            text.text = "Time left: " + timeLeft;

            if (timeLeft <= 0f)
            {
                fps.ResetProgress();
                playerHealth.TakeDamage(playerHealth.startingHealth);
            }
        }
    }
}
