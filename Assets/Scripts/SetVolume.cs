using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MasterVol", 0.75f);
        slider.value = PlayerPrefs.GetFloat("MusicVol", 0.75f);
        slider.value = PlayerPrefs.GetFloat("SoundVol", 0.75f);
    }

    public void SetMasterLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVol", sliderValue);
    }
    public void SetMusicLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }
    public void SetSoundLevel()
    {
        float sliderValue = slider.value;
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SoundVol", sliderValue);
    }
}
