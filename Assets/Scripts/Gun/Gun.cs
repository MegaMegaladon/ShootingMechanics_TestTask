using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class Gun : MonoBehaviour
{
    public event Action OnShoot;
    [SerializeField] private InputActionReference _fire;

    [SerializeField] private BulletBase _currentBulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _cooldown = 1f;

    private float _nextShootTime;
    private void OnEnable()
    {
        _fire.action.started += Shoot;
    }
    private void OnDisable()
    {
        _fire.action.started -= Shoot;
    }
    public void Shoot(InputAction.CallbackContext obj)
    {
        if (!CanShoot())
            return;

        _nextShootTime = Time.time + _cooldown;

        OnShoot?.Invoke();
        BulletBase bullet = Instantiate(_currentBulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.Init(_firePoint.forward);
    }
    public void SetCurrentBulletPrefab(BulletBase bullet)
    {
        _currentBulletPrefab = bullet;
    }
    private bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }
}
