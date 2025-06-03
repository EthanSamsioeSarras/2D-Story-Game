using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;

    public AudioMixer audioMixer;

    private float currentMasterVolume;

    public bool hasSaved = false;

    public void LoadData(GameData data)
    {
        masterSlider.value = data.masterVolume;
        currentMasterVolume = data.masterVolume;
    }
    public void SaveData(GameData data)
    {
        if (hasSaved)
        {
            data.masterVolume = masterSlider.value;
        }
        else
        {
            masterSlider.value = data.masterVolume;
            Debug.Log("Nope");
        }
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void ApplySettings()
    {
        hasSaved = true;
    }

    public void DiscardSettings()
    {
        masterSlider.value = currentMasterVolume;
    }

}
