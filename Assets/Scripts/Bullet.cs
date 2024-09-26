using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private ParticleSystem _shootEffect;



    private float _timeDestroy = 2f;

    private void Awake()
    {
        _shootEffect = GetComponentInChildren<ParticleSystem>();
    }

    public void ShootEffect( Collector collector)
    {
        if (_shootEffect != null)
        {
            _shootEffect.transform.position = collector.transform.position;
            _shootEffect.Play();
        }
    }

    public void Launch(Vector3 diraction)
    {
        _rigidbody.AddForce(diraction * _force, ForceMode.Impulse);
    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if (obstacle != null)
        {
            Destroy(obstacle.gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, _timeDestroy);
    }

    
}
