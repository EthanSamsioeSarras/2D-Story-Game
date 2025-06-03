using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float masterVolume;

    //These are the default values
    public GameData()
    {
        this.masterVolume = 0f;
    }
}
