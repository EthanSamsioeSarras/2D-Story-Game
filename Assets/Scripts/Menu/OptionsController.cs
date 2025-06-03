using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider, sfxSlider;

    public void SetMsuicVolume(float volume)
    {
        Debug.Log(volume);
    }

    public void ApplySettings()
    {

    }
}
