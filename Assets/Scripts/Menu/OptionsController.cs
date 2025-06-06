using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour, IDataPersistence
{
    [SerializeField] private Slider masterSlider, musicSlider, sfxSlider;
    [SerializeField] private TMP_Dropdown qualityDropdown, resolutionDropdown, windowModeIndexropdown;

    public AudioMixer audioMixer;

    Resolution[] resolutions;

    private float currentMasterVolume;
    private float currentMusicVolume;
    private float currentSFXVolume;

    private int currentQualityIndex;
    private int currentWindowModeIndex;
    private int currentResolutionIndex;

    public bool hasSaved = false;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int resolutionIndex = 0;    
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                resolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = resolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void LoadData(GameData data)
    {
        //Audio Settings
        masterSlider.value = data.masterVolume;
        currentMasterVolume = data.masterVolume;

        musicSlider.value = data.musicVolume;
        currentMusicVolume = data.musicVolume;

        sfxSlider.value = data.sfxVolume;
        currentSFXVolume = data.sfxVolume;

        //Graphics Settings
        qualityDropdown.value = data.qualityIndex;
        currentQualityIndex = data.qualityIndex;

        windowModeIndexropdown.value = data.windowModeIndex;
        currentWindowModeIndex = data.windowModeIndex;

        resolutionDropdown.value = data.resolutionIndex;
        currentResolutionIndex = data.resolutionIndex;
    }
    public void SaveData(GameData data)
    {
        if (hasSaved)
        {
            data.masterVolume = masterSlider.value;
            data.musicVolume = musicSlider.value;
            data.sfxVolume = sfxSlider.value;
            
            data.qualityIndex = qualityDropdown.value;
            data.windowModeIndex = windowModeIndexropdown.value;
            data.resolutionIndex = resolutionDropdown.value;
        }
        else
        {
            masterSlider.value = data.masterVolume;
            musicSlider.value = data.musicVolume;
            sfxSlider .value = data.sfxVolume;

            qualityDropdown.value = data.qualityIndex;
            windowModeIndexropdown.value = data.windowModeIndex;
            resolutionDropdown.value = data.resolutionIndex;
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

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetScreen(int windowModeIndex)
    {
        if(windowModeIndex == 0)
        {
            Screen.fullScreen = true;
            Debug.Log(windowModeIndex + " " + Screen.fullScreen);
        }
        if (windowModeIndex == 1)
        {
            Screen.fullScreen = false;
            Debug.Log(windowModeIndex + " " + Screen.fullScreen);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }

    public void ApplySettings()
    {
        hasSaved = true;
        Debug.Log(resolutionDropdown.value);
    }

    public void DiscardSettings()
    {
        //Audio Settings
        masterSlider.value = currentMasterVolume;
        musicSlider.value = currentMusicVolume;
        sfxSlider.value = currentSFXVolume;

        //Graphics Settings
        qualityDropdown.value = currentQualityIndex;
        windowModeIndexropdown.value = currentWindowModeIndex;
        resolutionDropdown.value = currentResolutionIndex;
    }

}
