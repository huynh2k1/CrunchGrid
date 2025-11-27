using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class uiWin : basePanel
{
    public override UI Type => UI.Win;

    [SerializeField] Button _btnReplay;
    [SerializeField] Button _btnHome;
    [SerializeField] Button _btnNext;

    public static Action ClickReplayAction;
    public static Action ClickHomeAction;
    public static Action ClickNextAction;

    [SerializeField] DOTweenAnimation[] _tweens;

    protected override void Awake()
    {
        _btnReplay.onClick.AddListener(ReplayClicked);
        _btnHome.onClick.AddListener(HomeClicked);
        _btnNext.onClick.AddListener(NextClicked);
    }

    public override void Enable()
    {
        base.Enable();
        foreach(var t in _tweens)
        {
            t.DORestart();
        }
    }

    public override void Disable()
    {
        base.Disable();
    }

    void ReplayClicked()
    {
        if(DataPref.CurLevel > 0)
        {
            DataPref.CurLevel--;
        }
        Disable(() =>
        {
            ClickReplayAction?.Invoke();
        });
    }

    void HomeClicked()
    {
        Disable(() =>
        {
            ClickHomeAction?.Invoke();  
        });
    }

    void NextClicked()
    {
        Disable(() =>
        {
            ClickNextAction?.Invoke();
        });
    }
}
