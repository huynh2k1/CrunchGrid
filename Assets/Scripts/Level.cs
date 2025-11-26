using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour
{
    [SerializeField] List<Stick> sticks;

    [Button("Load All Sticks")]
    public void LoadAllStick()
    {
        if (sticks != null || sticks.Count != 0)
        {
            sticks.Clear();
        }
        sticks = GetComponentsInChildren<Stick>().ToList();
    }

    private void Awake()
    {
        LoadAllStick();
    }

    private void OnEnable()
    {
        foreach(var s in sticks)
        {
            s.OnStickCompleteEvent += HandleStickCompleteEvent;
        }
    }

    private void OnDestroy()
    {
        foreach (var s in sticks)
        {
            s.OnStickCompleteEvent -= HandleStickCompleteEvent;
        }
        
    }

    public void HandleStickCompleteEvent()
    {
        CheckUnlockSticks();

        if (IsAllStickComplete())
        {
            Manager.I.WinGame();
        }
    }

    bool IsAllStickComplete()
    {
        foreach(Stick s in sticks)
        {
            if (!s.isComplete)
                return false;
        }
        return true;
    }

    public void CheckUnlockSticks()
    {
        foreach(var stick in sticks)
        {
            if(stick.isLocked == true)
            {
                stick.Unlock();
            }
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);    
    }
}
