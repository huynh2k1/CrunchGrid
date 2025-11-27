using System;
using UnityEngine;
using UnityEngine.UI;

public class uiSetting : basePanel
{
    public override UI Type => UI.Setting;
    [SerializeField] Slider _sliderSound;
    [SerializeField] Slider _sliderMusic;

    protected override void Awake()
    {
        base.Awake();
        _sliderMusic.onValueChanged.AddListener((v) =>
        {
            OnVolumeMusicChange(v);
        });
        _sliderSound.onValueChanged.AddListener((v) =>
        {
            OnVolumeSoundChange(v);
        });
    }

    public override void Enable()
    {
        base.Enable();
        LoadData();
    }

    void LoadData()
    {
        _sliderSound.value = DataPref.Sound;
        _sliderMusic.value = DataPref.Music;
    }

    public override void Disable()
    {
        TweenMain(false, () =>
        {
            ShowMask(false);
            Manager.I.state = baseManager.State.Playing;
        });
    }

    void OnVolumeSoundChange(float value)
    {
        DataPref.Sound = value;
        soundManager.I.LoadVolumeSounds();
    }

    void OnVolumeMusicChange(float value)
    {
        DataPref.Music = value;
        soundManager.I.LoadVolumeMusic();
    }
}
