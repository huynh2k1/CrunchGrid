using UnityEngine;

public class uiManager : baseUIManager
{

    private void OnEnable()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    void EnableHowToPlay()
    {
        EnableUI(UI.HowToPlay);
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
