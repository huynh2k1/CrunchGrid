using System;
using UnityEngine;

public class uiSelectLevel : basePanel
{
    public override UI Type => UI.SelectLevel;   
    [SerializeField] LevelBtn[] levelBtns;

    public event Action<int> OnClickSelectLevel;

    protected override void Awake()
    {
        InitLevelBtn(); 
    }

    void InitLevelBtn()
    {
        for(int i = 0; i < levelBtns.Length; i++)
        {
            levelBtns[i].Initialize(i);
            levelBtns[i].OnClickThisEvent += HandleClickSelectLevel;
        }
    }

    void HandleClickSelectLevel(int index)
    {
        DataPref.CurLevel = index;
        Disable(() =>
        {
            Manager.I.PlayGame();
        });
    }
}
