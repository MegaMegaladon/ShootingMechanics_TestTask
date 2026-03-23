using UnityEngine;

public class GunVisuals
{
    private readonly Animator _animator;
    private readonly ParticleSystem _muzzleFlash;

    private const string FIRE_TRIGGER = "Fire";
    public GunVisuals(Animator animator, ParticleSystem muzzleFlash)
    {
        _animator = animator;
        _muzzleFlash = muzzleFlash;
    }
    public void PlayShootAnimation()
    {
        _animator.SetTrigger(FIRE_TRIGGER);
        _muzzleFlash.Play();
    }
}
