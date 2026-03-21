using UnityEngine;

public class ExplosiveBullet : BulletBase
{
    [Header("Explosion Settings")]
    [SerializeField] private float _radius = 3f;
    [SerializeField] private LayerMask _damageMask;
    [SerializeField] private ParticleSystem _explosionVFX;

    private static readonly Collider[] _hitsBuffer = new Collider[16];
    protected override void OnHit(Collider other)
    {
        Vector3 explosionPoint = transform.position;

        int hitCount = Physics.OverlapSphereNonAlloc(explosionPoint, _radius, _hitsBuffer, _damageMask);

        for (int i = 0; i < hitCount; i++)
        {
            Collider hit = _hitsBuffer[i];

            if (hit != null && hit.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }

        Instantiate(_explosionVFX, explosionPoint, Quaternion.identity);

        Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
#endif
}
