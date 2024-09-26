using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private ParticleSystem _pickupParticlePrefab;
    private float _timeDestroyEffect = 2.5f;
    public void DestroyItemWithParticles()
    {
        if (_pickupParticlePrefab != null)
        {
            ParticleSystem particleInstance = Instantiate(_pickupParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particleInstance, _timeDestroyEffect);
        }

        Destroy(gameObject);
    }
    public abstract void ProcessPickupItem(Collector collector);
}