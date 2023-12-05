using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingController : AutoMonobehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _sliderBackgroundAudio;
    [SerializeField] private Slider _sliderSFXAudio;
    [SerializeField] private Slider _sliderAllAudio;

    #region Load Component Methods
    [ContextMenu("Load Component")]
    protected override void LoadComponent()
    {
        Transform volume = transform.Find("Volume");
        _sliderBackgroundAudio = volume.Find("Background_Audio_Volume").GetComponentInChildren<Slider>();
        _sliderSFXAudio = volume.Find("SFX_Audio_Volume").GetComponentInChildren<Slider>();
        _sliderAllAudio = volume.Find("All_Audio_Volume").GetComponentInChildren<Slider>();
    }
    #endregion

    protected override void LoadComponentInAwakeAfter()
    {
        base.LoadComponentInAwakeAfter();
        if (DataManager.HasData(DataManager.FLOAT_BACKGROUND_VOLUME)) LoadBackgroundAudioVolume();
        else SetBackgroundAudioVolume();

        if (DataManager.HasData(DataManager.FLOAT_SFX_VOLUME)) LoadSFXAudioVolume();
        else SetSFXAudioVolume();

        if (DataManager.HasData(DataManager.FLOAT_ALL_VOLUME)) LoadAllAudioVolume();
        else SetAllAudioVolume();
    }

    private void LoadBackgroundAudioVolume()
    {
        _sliderBackgroundAudio.value = DataManager.GetFloatData(DataManager.FLOAT_BACKGROUND_VOLUME);
        SetBackgroundAudioVolume();
    }

    public virtual void SetBackgroundAudioVolume()
    {
        float volume = _sliderBackgroundAudio.value;
        _audioMixer.SetFloat("Background", Mathf.Log10(volume) * 20);
        DataManager.SetFloatData(DataManager.FLOAT_BACKGROUND_VOLUME, volume);
    }

    private void LoadSFXAudioVolume()
    {
        _sliderSFXAudio.value = DataManager.GetFloatData(DataManager.FLOAT_SFX_VOLUME);
        SetSFXAudioVolume();
    }

    public virtual void SetSFXAudioVolume()
    {
        float volume = _sliderSFXAudio.value;
        _audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        DataManager.SetFloatData(DataManager.FLOAT_SFX_VOLUME, volume);
    }

    private void LoadAllAudioVolume()
    {
        _sliderAllAudio.value = DataManager.GetFloatData(DataManager.FLOAT_ALL_VOLUME);
        SetAllAudioVolume();
    }

    public virtual void SetAllAudioVolume()
    {
        float volume = _sliderAllAudio.value;
        _audioMixer.SetFloat("AllAudio", Mathf.Log10(volume) * 20);
        DataManager.SetFloatData(DataManager.FLOAT_ALL_VOLUME, volume);
    }
}
