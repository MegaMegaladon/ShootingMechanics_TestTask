using UnityEngine;

public enum BulletType
{
    Normal,
    Explosive,
    Ricochet
}

[RequireComponent(typeof(Rigidbody))]
[SelectionBase]
public abstract class BulletBase : MonoBehaviour
{
    public BulletType BulletType => _bulletType;

    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private TrailRenderer _trail;

    [Header("Bullet Stats")]
    [SerializeField] protected float damage = 10f;
    [SerializeField] private BulletType _bulletType = BulletType.Normal;
    [SerializeField] private float _speed = 120f;

    private void Reset()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public virtual void Init(Vector3 direction)
    {
        _rb.velocity = direction * _speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        OnHit(other);
    }
    private void OnDestroy()
    {
        _trail.transform.parent = null;
        Destroy(_trail.gameObject, _trail.time);
    }
    protected abstract void OnHit(Collider other);

}
