using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData{

    public int level;
    public float[] position;


    public PlayerData (FPS player)
    {
        level = player.level;
    }

    //public Emptydata(FPS player)
    //{
    //    level = 0;

    //    position = new float[3];
    //    position[0] = 0;
    //    position[1] = 0;
    //    position[2] = 0;
    //}
}
