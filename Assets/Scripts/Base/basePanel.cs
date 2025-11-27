using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class basePanel : baseUI
{
    public override UI Type => throw new NotImplementedException();

    [Header("References")]
    [SerializeField] protected Button btnClose;
    [SerializeField] protected Image mask;
    [SerializeField] protected CanvasGroup mainGroup;
    [SerializeField] protected GameObject main;

    [Header("Tween Settings")]
    [SerializeField] private float tweenDuration = 0.4f;
    [SerializeField] private Ease showEase = Ease.OutBack;
    [SerializeField] private Ease hideEase = Ease.InBack;

    #region Unity Methods
    protected virtual void Awake()
    {
        Init();
        btnClose?.onClick.AddListener(Disable);
    }
    #endregion

    #region Initialization
    [Button("Load Components")]
    public void LoadAllComponents()
    {
        //Load Mask
        Transform maskTf = transform.GetComponentsInChildren<Transform>(true)
                            .FirstOrDefault(t => t.name == "Mask");
        if (maskTf != null)
            mask = maskTf.GetComponent<Image>();

        //Load mainGroup
        mainGroup = transform.GetComponentInChildren<CanvasGroup>(true);

        //Load main
        Transform mainTf = transform.GetComponentsInChildren<Transform>(true)
                            .FirstOrDefault(t => t.name == "Main");

        if (mainTf != null)
            main = mainTf.gameObject;
    }

    protected virtual void Init()
    {
        if (mask != null)
        {
            mask.gameObject.SetActive(false);
            mask.raycastTarget = true;
        }

        if (main != null)
            main.SetActive(false);

        if (mainGroup != null)
            mainGroup.blocksRaycasts = false;
    }
    #endregion

    #region Public Methods
    public override void Enable()
    {
        ShowMask(true);
        TweenMain(true);
    }

    public virtual void Disable(Action actionDone)
    {
        TweenMain(false, () =>
        {
            actionDone?.Invoke();   
            ShowMask(false);
        });
    }

    public override void Disable()
    {
        TweenMain(false, () =>
        {
            ShowMask(false);
        });
    }
    #endregion

    #region Animation
    protected virtual void TweenMain(bool isShowing, Action onComplete = null)
    {
        if (main == null || mainGroup == null) return;

        main.transform.DOKill();
        mainGroup.blocksRaycasts = false;

        if (isShowing)
        {
            main.SetActive(true);
            main.transform
                .DOScale(Vector3.one, tweenDuration)
                .From(0.6f)
                .SetUpdate(true)
                .SetEase(showEase)
                .OnComplete(() =>
                {
                    mainGroup.blocksRaycasts = true;
                    onComplete?.Invoke();
                });
        }
        else
        {
            main.transform
                .DOScale(0.6f, tweenDuration)
                .From(1f)
                .SetUpdate(true)
                .SetEase(hideEase)
                .OnComplete(() =>
                {
                    main.SetActive(false);
                    onComplete?.Invoke();
                    Time.timeScale = 1f;
                });
        }
    }

    protected virtual void ShowMask(bool isShowing)
    {
        if (mask == null) return;
        mask.gameObject.SetActive(isShowing);
    }
    #endregion
}
