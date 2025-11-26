using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class baseUI : MonoBehaviour
{
    public abstract UI Type { get; }

    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);    
    }
}

public enum UI
{
    Home,
    Game,
    Win,
    SelectLevel,
    HowToPlay,
    Setting,
    Lose
}
