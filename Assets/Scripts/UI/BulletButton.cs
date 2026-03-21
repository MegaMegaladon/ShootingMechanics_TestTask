using UnityEngine;

public class BulletButton : MonoBehaviour
{
    [SerializeField] private BulletType _bulletType;
    [SerializeField] private BulletManager _bulletManager;
    private void Reset()
    {
        _bulletManager = FindAnyObjectByType<BulletManager>();
    }
    public void OnClick()
    {
        _bulletManager.SetBullet(_bulletType);
    }
}
