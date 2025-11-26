using UnityEngine;

public static class DataPref
{
    public static int CurLevel
    {
        get { 
            return PlayerPrefs.GetInt("CurLevel", 0); 
        } 
        set { 
            PlayerPrefs.SetInt("CurLevel", value); 
        }
    }

    public static int LevelUnlock
    {
        get => PlayerPrefs.GetInt("LevelUnlock", 0);
        set => PlayerPrefs.SetInt("LevelUnlock", value);
    }

    public static bool Sound
    {
        get => PlayerPrefs.GetInt("Sound", 0) == 0;
        set => PlayerPrefs.SetInt("Sound", value ? 0 : 1);  
    }

    public static bool Music
    {
        get => PlayerPrefs.GetInt("Music", 0) == 0;
        set => PlayerPrefs.SetInt("Music", value ? 0 : 1);  
    }
}
