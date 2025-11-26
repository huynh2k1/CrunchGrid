using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public int ID;
    [SerializeField] Button _btn;
    [SerializeField] GameObject _lock;
    [SerializeField] Text _txtLevel;
    public event Action<int> OnClickThisEvent;

    private void Awake()
    {
        _btn.onClick.AddListener(OnClickThis);
    }

    private void OnEnable()
    {
        CheckUnlock();
    }

    public void Initialize(int id)
    {
        ID = id;
        CheckUnlock();
        UpdateTextLevel();
    }

    void OnClickThis()
    {
        OnClickThisEvent?.Invoke(ID);
    }

    void CheckUnlock()
    {
        if (DataPref.LevelUnlock >= ID)
        {
            Unlock();
        }
        else
        {
            Lock();
        }
    }

    void Unlock()
    {
        _btn.interactable = true;
        _btn.GetComponent<Image>().raycastTarget = true;
        _lock.SetActive(false);
    }

    void Lock()
    {
        _btn.interactable = false;
        _btn.GetComponent<Image>().raycastTarget = false;
        _lock.SetActive(true);
    }

    void UpdateTextLevel()
    {
        _txtLevel.text = (ID + 1).ToString();
    }
}
