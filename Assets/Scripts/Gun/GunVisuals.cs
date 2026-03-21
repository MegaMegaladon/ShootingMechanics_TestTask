using UnityEngine;

public class GunVisuals : MonoBehaviour
{
    [SerializeField] Animator _gunAnimator;
    [SerializeField] private Gun _gun;

    private const string FIRE_TRIGGER = "Fire";
    private void OnEnable()
    {
        _gun.OnShoot += PlayShootAnimation;
    }
    private void OnDisable()
    {
        _gun.OnShoot -= PlayShootAnimation;
    }
    private void PlayShootAnimation()
    {
        _gunAnimator.SetTrigger(FIRE_TRIGGER);
    }
}
