using UnityEngine;

public class LevelCtrl : MonoBehaviour
{
    [SerializeField] Level[] listLevel;
    public Level _curLevel;
    public void InitLevel()
    {
        DestroyCurLevel();
        _curLevel = Instantiate(listLevel[DataPref.CurLevel], transform);
    }
    public void CheckIncreaseLevel()
    {
        if(DataPref.CurLevel < listLevel.Length - 1)
        {
            DataPref.CurLevel++;
            if(DataPref.CurLevel > DataPref.LevelUnlock)
            {
                DataPref.LevelUnlock = DataPref.CurLevel;
            }
        }
        else
        {
            DataPref.CurLevel = 0;  
        }
    }

    public void DestroyCurLevel()
    {
        if(_curLevel != null)
        {
            _curLevel.Destroy();
            _curLevel = null;
        }
    }
    
}
