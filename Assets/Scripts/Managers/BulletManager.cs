using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    [SerializeField] private List<BulletBase> bulletPrefabs;

    private Dictionary<BulletType, BulletBase> _map;

    private void Awake()
    {
        _map = new Dictionary<BulletType, BulletBase>();

        foreach (var bullet in bulletPrefabs)
        {
            _map[bullet.BulletType] = bullet;
        }
    }

    public void SetBullet(BulletType type)
    {
        _gun.SetCurrentBulletPrefab(_map[type]);
    }
}
