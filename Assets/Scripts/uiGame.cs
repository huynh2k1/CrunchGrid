using System;
using UnityEngine;
using UnityEngine.UI;

public class uiGame : baseUI
{
    public override UI Type => UI.Game;

    [SerializeField] Button _btnSetting;
    [SerializeField] Button _btnHome;
    [SerializeField] Button _btnReplay;

    [SerializeField] Text _txtLevel;

    public static Action SettingClickEvent;
    public static Action HomeClickEvent;
    public static Action ReplayClickEvent;

    private void Awake()
    {
        _btnSetting.onClick.AddListener(SettingClicked);
        _btnHome.onClick.AddListener(HomeClicked);
        _btnReplay.onClick.AddListener(ReplayClicked);  
    }

    public override void Enable()
    {
        base.Enable();
        UpdateTextLevel();
    }

    void UpdateTextLevel()
    {
        _txtLevel.text = $"Level {DataPref.CurLevel + 1}";
    }

    void SettingClicked()
    {
        SettingClickEvent?.Invoke();
    }

    void HomeClicked()
    {
        HomeClickEvent?.Invoke();
    }

    void ReplayClicked()
    {
        ReplayClickEvent?.Invoke(); 
    }
}
