using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BulletButton : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private BulletDataSO _bulletData;

    [Header("References")]
    [SerializeField] private BulletManager _bulletManager;
    [SerializeField] private Image _iconImage;
    private void Awake()
    {
        UpdateIcon();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_bulletManager == null)
            _bulletManager = FindAnyObjectByType<BulletManager>();

        UpdateIcon();
    }
#endif
    private void UpdateIcon()
    {
        if (_iconImage != null && _bulletData != null)
        {
            _iconImage.sprite = _bulletData.Icon;
        }
    }
    public void OnClick()
    {
        _bulletManager.SetBullet(_bulletData);
    }
}
