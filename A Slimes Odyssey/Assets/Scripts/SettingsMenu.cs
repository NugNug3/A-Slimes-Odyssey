using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; //allows the use of the audio functions provided by Unity
public class SettingsMenu : MonoBehaviour
{

    public AudioMixer mixer;
    public void VolumeSlider(float volumeVal)
    {
        mixer.SetFloat("volume", volumeVal);
    }
}
