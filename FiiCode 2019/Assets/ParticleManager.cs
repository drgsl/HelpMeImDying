using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public GameObject[] particles;

    GameObject player;

    bool[] activated = new bool[10];

    public GameObject[] plantSets;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < particles.Length; i++)
        {
                activated[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkParticle(20, 0);
        checkParticle(40, 1);
        checkParticle(60, 2);
        checkParticle(80, 3);
        checkParticle(100, 4);
        checkParticle(110, 5);
    }

    void checkParticle(int level, int number)
    {
        if (Changeable.level >= level && activated[number] == false)
        {
            Instantiate(particles[number], player.transform.position, player.transform.rotation);
            activated[number] = true;
            plantSets[number].SetActive(true);
        }
    }
}
