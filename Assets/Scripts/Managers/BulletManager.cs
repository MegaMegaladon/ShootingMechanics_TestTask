using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private Gun _gun;
    private List<BulletDataSO> _bulletDatas;

    public IReadOnlyList<BulletDataSO> BulletDatas => _bulletDatas;

    private void Start()
    {
        _bulletDatas = Resources.LoadAll<BulletDataSO>("").ToList();
    }

    public void SetBullet(BulletDataSO data)
    {
        _gun.SetCurrentBulletPrefab(data.Prefab);
    }
}
