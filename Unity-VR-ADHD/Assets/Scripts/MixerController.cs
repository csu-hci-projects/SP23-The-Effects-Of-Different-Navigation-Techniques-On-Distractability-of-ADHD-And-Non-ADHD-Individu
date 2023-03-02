using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class MixerController : MonoBehaviour
{
    [SerializeField] private Slider slider = null;

    [SerializeField] private TMP_Text sliderText = null;

    public AudioMixer mixer;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
    public void VolumeSlider(float volume){
        sliderText.text = volume.ToString("0.0");
    }
    public void SetLevel (float sliderValue)
    {
	    mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}