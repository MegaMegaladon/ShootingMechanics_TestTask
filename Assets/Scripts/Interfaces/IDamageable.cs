
using System;

public interface IDamageable
{
    event Action OnTakeDamage;
    void TakeDamage(float damage);
}
