using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartUpDialogue : MonoBehaviour
{

    GameObject player;

    public DialogueTrigger dialoguetrigger;
    public DialogueManager dialoguemanager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {

            dialoguetrigger.TriggerDialogue();
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            Cursor.visible = true;
            Destroy(this);
        }
    }
}
