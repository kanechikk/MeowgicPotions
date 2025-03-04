using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer m_audioMixer;
    [SerializeField] private Slider m_musicSlider;
    [SerializeField] private Slider m_audioSlider;
    private float musicVolume, SFXVolume;

    private void OnEnable()
    {
        m_audioMixer.GetFloat("MusicVolume", out musicVolume);
        m_musicSlider.value = Mathf.Pow(10, musicVolume / 20);
        m_audioMixer.GetFloat("SFXVolume", out SFXVolume);
        m_audioSlider.value = Mathf.Pow(10, SFXVolume / 20);
    }

    public void SetMusicVolume()
    {
        float volume = m_musicSlider.value;
        m_audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume()
    {
        float volume = m_audioSlider.value;
        m_audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
