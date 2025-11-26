using DG.Tweening;
using UnityEngine;

public class Manager : baseManager
{
    public static Manager I;
    [SerializeField] uiManager uiManager;
    [SerializeField] LevelCtrl levelCtrl;
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
        uiGame.SettingClickEvent += PauseGame;
        uiGame.HomeClickEvent += Home;
        uiGame.ReplayClickEvent += ReplayGame;  

        uiWin.ClickHomeAction += Home;
        uiWin.ClickReplayAction += ReplayGame;
        uiWin.ClickNextAction += NextLevel;
    }

    private void OnDestroy()
    {
        uiGame.SettingClickEvent -= PauseGame;
        uiGame.HomeClickEvent -= Home;  
        uiGame.ReplayClickEvent -= ReplayGame;
        
        uiWin.ClickHomeAction -= Home;  
        uiWin.ClickReplayAction -= ReplayGame;
        uiWin.ClickNextAction -= NextLevel;
    }

    public override void Home()
    {
        base.Home();
        uiManager.EnableHome();
        levelCtrl.DestroyCurLevel();
    }

    public override void PlayGame()
    {
        base.PlayGame();
        uiManager.EnableGame();
        levelCtrl.InitLevel();
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
        levelCtrl.InitLevel();
    }

    public void NextLevel()
    {
        uiManager.EnableGame();
        levelCtrl.InitLevel();
    }

    public override void WinGame()
    {
        base.WinGame();
        uiManager.DisableUI(UI.Game);
        levelCtrl.CheckIncreaseLevel();
        DOVirtual.DelayedCall(1f, () =>
        {
            uiManager.EnableUI(UI.Win);
        });
    }

    public override void LoseGame()
    {
        base.LoseGame();
        uiManager.EnableUI(UI.Lose);
    }
}
