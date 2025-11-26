using NaughtyAttributes;
using System;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public static Stick StickCurrentlyRotating;

    public bool isComplete;
    [SerializeField] Transform _anchorPos;
    BoxCollider _boxCollider;
    public Stick _stickParent;

    [Header("SETUP NEW STICK")]
    [SerializeField] Stick[] _stickPrefabs;
    [SerializeField] float _angle;
    [SerializeField] Stick childStick;

    private bool _isRotating = false;        // Chặn spam click
    private float _previousAngle;            // Lưu góc trước khi quay
    private bool _shouldRollback = false;    // Đánh dấu rollback

    public event Action OnStickCompleteEvent;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        Init();
    }

    void Init()
    {
        if (isComplete || _stickParent == null)
        {
            Complete();
        }
    }

    void OnMouseDown()
    {
        if (_isRotating) return; // đang xoay → không cho click tiếp

        StickCurrentlyRotating = this;
        StartCoroutine(RotateStep());
    }

    private System.Collections.IEnumerator RotateStep()
    {
        _isRotating = true;
        _shouldRollback = false;

        // Lưu góc hiện tại để rollback nếu cần
        _previousAngle = transform.localEulerAngles.z;

        float targetAngle = _previousAngle - 90f;
        float duration = 0.3f;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float z = Mathf.Lerp(_previousAngle, targetAngle, elapsed / duration);

            transform.localEulerAngles = new Vector3(0, 0, z);

            if (_shouldRollback)
            {
                // Quay ngược lại nếu bị va chạm
                transform.localEulerAngles = new Vector3(0, 0, _previousAngle);
                _isRotating = false;
                yield break;
            }

            yield return null;
        }

        transform.localEulerAngles = new Vector3(0, 0, targetAngle);

        // Check complete nếu quay tới -180 hoặc 180
        if (Mathf.Approximately(targetAngle, 180f))
        {
            Complete();
            //Debug.Log($"{name} COMPLETE (-180°)");
            if (GetRoot().IsAllComplete())
            {
                OnStickCompleteEvent?.Invoke();
            }
        }

        _isRotating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stick"))
        {
            if (StickCurrentlyRotating != null)
            {
                StickCurrentlyRotating._shouldRollback = true; // 🔥 rollback đúng stick đang xoay
            }
        }
    }

    void Complete()
    {
        isComplete = true;
        _boxCollider.enabled = false;
    }

    public bool IsAllComplete()
    {
        // Nếu stick hiện tại chưa complete → fail ngay
        if (!isComplete)
            return false;

        // Nếu có child → kiểm tra tiếp
        if (childStick != null)
            return childStick.IsAllComplete();

        // Nếu không có child → coi như complete
        return true;
    }
    public Stick GetRoot()
    {
        Stick current = this;
        while (current._stickParent != null)
        {
            current = current._stickParent;
        }
        return current;
    }


    [Button("New Stick")]
    public void CreateNewStick()
    {
        if (childStick != null)
        {
            childStick.Destroy();
            childStick = null;
        }

        childStick = Instantiate(_stickPrefabs[UnityEngine.Random.Range(0, _stickPrefabs.Length - 1)], _anchorPos.position, Quaternion.identity);
        childStick._stickParent = this;
        childStick.SetParent(transform);
        childStick.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, _angle));
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);    
    }

    public void Destroy()
    {
        DestroyImmediate(gameObject);
    }
}
