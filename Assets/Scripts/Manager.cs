using UnityEngine;

public class Manager : baseManager
{
    public static Manager I;
    [SerializeField] uiManager uiManager;

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        Application.targetFrameRate = 120;
        Home();
    }

    private void OnEnable()
    {
        uiHome.PlayClickEvent += PlayGame;

        uiGame.SettingClickEvent += PauseGame;
        uiGame.HomeClickEvent += Home;
        uiGame.ReplayClickEvent += ReplayGame;  
    }

    private void OnDestroy()
    {
        uiHome.PlayClickEvent -= PlayGame;

        uiGame.SettingClickEvent -= PauseGame;
        uiGame.HomeClickEvent -= Home;  
        uiGame.ReplayClickEvent -= ReplayGame;  
    }

    public override void Home()
    {
        base.Home();
        uiManager.EnableHome();
    }

    public override void PlayGame()
    {
        base.PlayGame();
        uiManager.EnableGame();
    }

    public void PauseGame()
    {
        state = State.None;
        uiManager.EnableUI(UI.Setting);
    }

    public override void ReplayGame()
    {
        base.ReplayGame();
        uiManager.EnableGame();
    }

    public override void WinGame()
    {
        base.WinGame();
    }

    public override void LoseGame()
    {
        base.LoseGame();
    }
}
