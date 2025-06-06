using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public int qualityIndex;
    public int windowModeIndex;
    public int resolutionIndex;

    //These are the default values
    public GameData()
    {
        this.masterVolume = 0f;
        this.musicVolume = 0f;
        this.sfxVolume = 0f;
        this.qualityIndex = 3;
        this.windowModeIndex = 1;
        this.resolutionIndex = 17;
    }
}
