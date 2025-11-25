using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
public class buttonEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Button button;

    [Header("Settings")]
    public float timeTween = 0.2f;

    [Header("Delay Click")]
    public float clickDelay = 0.2f;
    bool canClick = true;

    Vector3 initScale;
    Tween tween;
    Tween delayTween;   // <-- tween thay cho coroutine

    void Awake()
    {
        button = GetComponent<Button>();
        initScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!canClick) return;

        tween?.Kill();

        transform.DOScale(initScale * 0.8f, timeTween)
            .SetEase(Ease.OutQuad);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!canClick) return;

        tween?.Kill();

        tween = transform.DOScale(initScale, timeTween)
            .SetEase(Ease.OutElastic, 1.2f, 0.5f);

        if (button && button.interactable)
            button.onClick.Invoke();

        StartDelay();
    }

    void StartDelay()
    {
        canClick = false;
        if (button) button.interactable = false;

        delayTween?.Kill();
        // ❗ Thay coroutine bằng DOTween delay
        delayTween = DOVirtual.DelayedCall(clickDelay, () =>
        {
            canClick = true;
            if (button) button.interactable = true;
        }).SetAutoKill(true);
    }
}
