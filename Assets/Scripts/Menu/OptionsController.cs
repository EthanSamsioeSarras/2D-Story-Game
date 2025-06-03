using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;

    public AudioMixer audioMixer;

    public void LoadData(GameData data)
    {
        masterSlider.value = data.masterVolume;
    }
    public void SaveData(GameData data)
    {
        data.masterVolume = masterSlider.value;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void ApplySettings()
    {
        Debug.Log(masterSlider.value);
    }

}
