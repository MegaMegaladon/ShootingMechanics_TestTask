using UnityEngine;

public class NormalBullet : BulletBase
{
    protected override void OnHit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
