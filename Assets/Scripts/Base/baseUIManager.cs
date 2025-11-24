using System.Collections.Generic;
using UnityEngine;

public class baseUIManager : MonoBehaviour
{
    public baseUI[] _uis;
    protected Dictionary<UI, baseUI> _dictUIs = new Dictionary<UI, baseUI>();


    protected virtual void Awake()
    {
        foreach(baseUI ui in _uis)
        {
            if(_dictUIs.ContainsKey(ui.Type) == false)
            {
                _dictUIs.Add(ui.Type, ui);
            }
        }
    }

    public void EnableUI(UI type)
    {
        if (_dictUIs.ContainsKey(type) == false)
        {
            return;
        }

        _dictUIs[type].Enable();
    }

    public void DisableUI(UI type)
    {
        if (_dictUIs.ContainsKey(type) == false)
        {
            return;
        }

        _dictUIs[type].Disable();
    }
}
