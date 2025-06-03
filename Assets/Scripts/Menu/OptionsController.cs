using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;

    public AudioMixer audioMixer;

    private float masterVolume;

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void ApplySettings()
    {

    }

    public void LoadData(GameData data)
    {
        this.masterVolume = data.masterVolume;
    }
    public void SaveData(ref GameData data)
    {
        data.masterVolume = this.masterVolume;
    }

}
