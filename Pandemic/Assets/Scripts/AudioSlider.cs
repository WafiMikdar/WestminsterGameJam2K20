using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;

    [SerializeField] private Slider slider;

    [SerializeField] private string channel;

    public void SetVolumeLevel(float sliderValue)
    {
        if (sliderValue == 0)
        {
            sliderValue = float.Epsilon;
        }

        Mixer.SetFloat(channel, Mathf.Log10(sliderValue) * 20);
    }

    private void OnEnable()
    {
        float channelVolume = PlayerPrefs.GetFloat(channel, 0);
        //Debug.Log($"Saved volume for {channel}: {channelVolume}");
        SetVolumeLevel(channelVolume);
        slider.value = channelVolume;
    }

    private void OnDisable()
    {
        Mixer.GetFloat(channel, out var channelVolume);
        PlayerPrefs.SetFloat(channel, Mathf.Pow(10, channelVolume / 20));
        PlayerPrefs.Save();
    }
}