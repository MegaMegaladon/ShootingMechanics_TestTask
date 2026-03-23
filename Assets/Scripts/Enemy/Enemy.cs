using System;
using UnityEngine;

[SelectionBase]
public class Enemy : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamage;

    [SerializeField] private Animator _animator;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;

    private EnemyVisuals _visuals;
    private void Awake()
    {
        _currentHealth = _maxHealth;
        _visuals = new EnemyVisuals(_animator);
    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _visuals.PlayGetHitAnimation();
        OnTakeDamage?.Invoke();
    }

}
