using UnityEngine;
using UnityEngine.InputSystem;

[SelectionBase]
public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private Transform _firePoint;

    [Header("Shooting")]
    [SerializeField] private Bullet _currentBulletPrefab;
    [SerializeField] private float _cooldown = 1f;

    [Header("Input")]
    [SerializeField] private InputActionReference _fire;

    private float _nextShootTime;
    private GunVisuals _visuals;
    private void Awake()
    {
        _visuals = new GunVisuals(_animator, _muzzleFlash);
    }
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

        _visuals.PlayShootAnimation();

        Bullet bullet = Instantiate(_currentBulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.Init(_firePoint.forward);
    }
    public void SetCurrentBulletPrefab(Bullet bullet)
    {
        _currentBulletPrefab = bullet;
    }
    private bool CanShoot()
    {
        return Time.time >= _nextShootTime;
    }
}
