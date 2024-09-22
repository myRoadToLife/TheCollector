using UnityEngine;

public class ItemShellShot : Item
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;

    protected override void ProcessPickupItem(Collector collector)
    {
        Bullet bulletInstance = Instantiate(_bulletPrefab, collector.transform.position, Quaternion.identity);
        bulletInstance.Launch(Vector3.forward);
    }
}
