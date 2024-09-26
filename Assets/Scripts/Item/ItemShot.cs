using UnityEngine;

public class ItemShot : Item
{
    [SerializeField] private Bullet _bulletPrefab;
    public override void ProcessPickupItem(Collector collector)
    {
        Bullet bulletInstance = Instantiate(_bulletPrefab, collector.transform.position, Quaternion.identity);
        bulletInstance.Launch(collector.transform.forward);        
    }
}
