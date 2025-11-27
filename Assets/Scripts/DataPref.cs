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

    public static float Sound
    {
        get => PlayerPrefs.GetFloat("Sound", 1);
        set => PlayerPrefs.SetFloat("Sound", value);  
    }

    public static float Music
    {
        get => PlayerPrefs.GetFloat("Music", 1);
        set => PlayerPrefs.SetFloat("Music", value);  
    }
}
