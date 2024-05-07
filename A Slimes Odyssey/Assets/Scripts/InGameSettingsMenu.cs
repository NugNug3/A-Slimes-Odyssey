using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;
public class InGameSettingsMenu : MonoBehaviour
{
    [SerializeField] Canvas settingsMenu;
    
    [Header ("Audio")]
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider sfxSlider;

    [Header ("Resolution")]

    [SerializeField] TMP_Dropdown resDropdown;
    [SerializeField] Toggle fullscreenToggle;
    Resolution[] resolutions;
    int fullscreenStatus;

    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("InGameMasterVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        GetResolutionOptions();
        fullscreenStatus = PlayerPrefs.GetInt("fullscreen");
        CheckFullscreen(fullscreenStatus);
        resDropdown.value = PlayerPrefs.GetInt("resolution");
        SetResolution();
    }
    public void SetMasterVolume()
    {
        mixer.SetFloat("InGameMasterVolume", ConvertToDec(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("InGameMasterVolume", masterVolumeSlider.value);
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("SFX", ConvertToDec(sfxSlider.value));
        PlayerPrefs.SetFloat("SFX", sfxSlider.value);
    }

    public void GetResolutionOptions()
    {
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height}).Distinct().ToArray();
        for(int i = 0; i < resolutions.Length; i++)
        {
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }

    public void SetResolution()
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn);
        PlayerPrefs.SetInt("fullscreen", ConverToInt(fullscreenToggle.isOn));
        PlayerPrefs.SetInt("resolution", resDropdown.value);
    }

    public void CheckFullscreen(int fullscreenStatus)
    {
        if(fullscreenStatus == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }
    }

    float ConvertToDec(float sliderValue)
    {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.01f)) * 20;
    }

    int ConverToInt(bool toggle)
    {
        if(toggle == false)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    public void OpenSettings()
    {
        settingsMenu.enabled = true;
    }

    public void CloseSettings()
    {
        settingsMenu.enabled = false;
    }
}
