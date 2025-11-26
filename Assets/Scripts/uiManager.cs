using UnityEngine;

public class uiManager : baseUIManager
{

    private void OnEnable()
    {
        uiHome.HTPClickEvent += EnableHowToPlay;
        uiHome.PlayClickEvent += EnableSelectLevel;
    }

    private void OnDestroy()
    {
        uiHome.HTPClickEvent -= EnableHowToPlay;   
        uiHome.PlayClickEvent -= EnableSelectLevel; 
    }

    void EnableHowToPlay()
    {
        EnableUI(UI.HowToPlay);
    }

    void EnableSelectLevel()
    {
        EnableUI(UI.SelectLevel);
    }

    public void EnableHome()
    {
        EnableUI(UI.Home);
        DisableUI(UI.Game);
    }

    public void EnableGame()
    {
        EnableUI(UI.Game);
        DisableUI(UI.Home);
    }
}
