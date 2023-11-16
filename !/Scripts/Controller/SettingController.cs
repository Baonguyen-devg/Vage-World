using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingController : AutoMonobehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sliderBackgroundAudio;
    [SerializeField] private Slider sliderSFXAudio;
    [SerializeField] private Slider sliderAllAudio;

    protected override void LoadComponent()
    {
        sliderBackgroundAudio = transform.Find("Volume").Find("Background_Audio_Volume").GetComponentInChildren<Slider>();
        sliderSFXAudio = transform.Find("Volume").Find("SFX_Audio_Volume").GetComponentInChildren<Slider>();
        sliderAllAudio = transform.Find("Volume").Find("All_Audio_Volume").GetComponentInChildren<Slider>();
    }

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        if (PlayerPrefs.HasKey("backgroundAudioVolume")) LoadBackgroundAudioVolume();
        else SetBackgroundAudioVolume();

        if (PlayerPrefs.HasKey("SFXAudioVolume")) LoadSFXAudioVolume();
        else SetSFXAudioVolume();

        if (PlayerPrefs.HasKey("AllAudioVolume")) LoadAllAudioVolume();
        else SetAllAudioVolume();
    }

    private void LoadBackgroundAudioVolume()
    {
        sliderBackgroundAudio.value = PlayerPrefs.GetFloat("backgroundAudioVolume");
        SetBackgroundAudioVolume();
    }

    public virtual void SetBackgroundAudioVolume()
    {
        float volume = sliderBackgroundAudio.value;
        audioMixer.SetFloat("Background", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("backgroundAudioVolume", volume);
    }

    private void LoadSFXAudioVolume()
    {
        sliderSFXAudio.value = PlayerPrefs.GetFloat("SFXAudioVolume");
        SetSFXAudioVolume();
    }

    public virtual void SetSFXAudioVolume()
    {
        float volume = sliderSFXAudio.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXAudioVolume", volume);
    }

    private void LoadAllAudioVolume()
    {
        sliderAllAudio.value = PlayerPrefs.GetFloat("AllAudioVolume");
        SetAllAudioVolume();
    }

    public virtual void SetAllAudioVolume()
    {
        float volume = sliderAllAudio.value;
        audioMixer.SetFloat("AllAudio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("AllAudioVolume", volume);
    }
}
