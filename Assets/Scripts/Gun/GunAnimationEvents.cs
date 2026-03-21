using UnityEngine;

public class GunAnimationEvents : MonoBehaviour
{
    [SerializeField] private ParticleSystem _muzzleFlashVFX;
    public void PlayShootEfect()
    {
        _muzzleFlashVFX.Play();
    }
}
