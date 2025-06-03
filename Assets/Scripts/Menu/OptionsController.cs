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
    private float currentMusicVolume;
    private float currentSFXVolume;

    public bool hasSaved = false;

    public void LoadData(GameData data)
    {
        //Audio Settings
        masterSlider.value = data.masterVolume;
        currentMasterVolume = data.masterVolume;

        musicSlider.value = data.musicVolume;
        currentMusicVolume = data.musicVolume;

        sfxSlider.value = data.sfxVolume;
        currentSFXVolume = data.sfxVolume;
    }
    public void SaveData(GameData data)
    {
        if (hasSaved)
        {
            data.masterVolume = masterSlider.value;
            data.musicVolume = musicSlider.value;
            data.sfxVolume = sfxSlider.value;
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

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void ApplySettings()
    {
        hasSaved = true;
    }

    public void DiscardSettings()
    {
        //Audio Settings
        masterSlider.value = currentMasterVolume;
        musicSlider.value = currentMusicVolume;
        sfxSlider.value = currentSFXVolume;
    }

}
