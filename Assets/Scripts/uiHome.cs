using System;
using UnityEngine;
using UnityEngine.UI;

public class uiHome : baseUI
{
    public override UI Type => UI.Home;

    [SerializeField] Button _btnPlay;
    [SerializeField] Button _btnHTP;

    public static Action PlayClickEvent;
    public static Action HTPClickEvent;

    private void Awake()
    {
        _btnPlay.onClick.AddListener(PlayClicked);
        _btnHTP.onClick.AddListener(HTPClicked);
    }

    void PlayClicked()
    {
        PlayClickEvent?.Invoke();
    }

    void HTPClicked()
    {
        HTPClickEvent?.Invoke();
    }
}
