using UnityEngine;

public class ItemShellShot : Item
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    //[SerializeField] private ParticleSystem _shotEffect;


    public override void ProcessPickupItem(Collector collector)
    {
        Bullet bulletInstance = Instantiate(_bulletPrefab, collector.transform.position, Quaternion.identity);
        bulletInstance.Launch(collector.transform.forward);

        //bulletInstance.ShootEffect(collector);
    }
}
