using UnityEngine;

public class EnemyVisuals
{
    private readonly Animator _enemyAnimator;

    private const string GETHIT_STATE_NAME = "Getting Hit";
    private float _crossFadeDuration = 0.1f;
    public EnemyVisuals(Animator enemyAnimator)
    {
        _enemyAnimator = enemyAnimator;
    }

    public void PlayGetHitAnimation()
    {
        _enemyAnimator.CrossFade(GETHIT_STATE_NAME, _crossFadeDuration, 0, 0f);
    }
}
