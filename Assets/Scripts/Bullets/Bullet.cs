using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[SelectionBase]
public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private TrailRenderer _trail;

    [Header("Bullet Stats")]
    [SerializeField] protected float damage = 10f;
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
    protected virtual void OnHit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
