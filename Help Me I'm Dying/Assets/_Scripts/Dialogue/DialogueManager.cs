using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Image NpcPicture;

    //public DialogueTrigger dialogtrigger;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<Sprite> sprites;

    public LuckyManager luckymanager;

    private int spriteindex;
    public FPS fps;
    public PlayerHealth playerHealth;
    public GameObject weapon;
    public GameObject enemyspawner;
    public EnemyMovement enemymovements;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        sprites = new Queue<Sprite>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        luckymanager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<LuckyManager>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();
        names.Clear();
        sprites.Clear();


        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (Sprite sprite in dialogue.sprites)
        {
            sprites.Enqueue(sprite);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        string name = names.Dequeue();

        Sprite sprite = sprites.Dequeue();


        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence));
        nameText.text = name;
        NpcPicture.sprite = sprite;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach  (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        sentences.Clear();

        animator.SetBool("IsOpen", false);

        if (SceneManager.GetActiveScene().name == "Intro")
        {
            fps.SavePlayer();
            Changeable.level = 0;
            Cursor.visible = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (SceneManager.GetActiveScene().name == "House01")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (playerHealth.isLucky)
            {
                luckymanager.TimerStart = true;
                weapon.SetActive(true);
                enemyspawner.SetActive(true);
            }
            else
            {
                EnemyMovement.DialogueIsFinished = true;
            }
        }
    }
}
