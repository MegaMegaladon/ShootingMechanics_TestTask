using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _enemyAnimator;

    private const string GETHIT_TRIGGER = "GetHit";
    private void OnEnable()
    {
        _enemy.OnTakeDamage += PlayGetHitAnimation;
    }
    private void OnDisable()
    {
        _enemy.OnTakeDamage -= PlayGetHitAnimation;
    }
    private void PlayGetHitAnimation()
    {
        _enemyAnimator.SetTrigger(GETHIT_TRIGGER);
    }
}
