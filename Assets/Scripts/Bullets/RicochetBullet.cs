using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : BulletBase
{
    [Header("Ricochet Settings")]
    [SerializeField] private int ricochetCount = 3;
    [SerializeField] private float ricochetRadius = 10f;
    [SerializeField] private LayerMask _damageMask;
    private int _ricochetsRemaining;

    private static readonly Collider[] _hitsBuffer = new Collider[16];

    private void Awake()
    {
        _ricochetsRemaining = ricochetCount;
    }
    protected override void OnHit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }

        _ricochetsRemaining--;

        if (_ricochetsRemaining <= 0)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 targetPoint;
        IDamageable nextTarget = FindNextTarget(other.transform.position, damageable, out targetPoint);

        if (nextTarget != null)
        {
            Vector3 dir = targetPoint - transform.position;
            dir.Normalize();
            Init(dir);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IDamageable FindNextTarget(Vector3 origin, IDamageable exclude, out Vector3 targetPoint)
    {
        targetPoint = default;

        int hitCount = Physics.OverlapSphereNonAlloc(origin, ricochetRadius, _hitsBuffer, _damageMask);
        List<(Collider collider, IDamageable damageable)> validTargets = new();

        for (int i = 0; i < hitCount; i++)
        {
            Collider hit = _hitsBuffer[i];

            if (hit != null && hit.TryGetComponent<IDamageable>(out IDamageable damageable) && damageable != exclude)
            {
                validTargets.Add((hit, damageable));
            }
        }

        if (validTargets.Count == 0)
            return null;

        var chosen = validTargets[Random.Range(0, validTargets.Count)];
        targetPoint = chosen.collider.bounds.center;
        return chosen.damageable;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ricochetRadius);
    }
#endif
}
