using System;
using UnityEngine;

[SelectionBase]
public class Enemy : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamage;

    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _currentHealth;


    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        OnTakeDamage?.Invoke();
    }

}
