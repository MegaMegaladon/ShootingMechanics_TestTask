using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Bullets/BulletData")]
public class BulletDataSO : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string _bulletName = "New Bullet";
    [SerializeField] private Sprite _icon;

    [Header("Prefab")]
    [SerializeField] private Bullet _prefab;

    public string BulletName => _bulletName;
    public Sprite Icon => _icon;
    public Bullet Prefab => _prefab;
}
