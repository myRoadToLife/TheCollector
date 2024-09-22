using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    private float _timeDestroy = 2f;

    public void Launch(Vector3 diraction)
    {
        _rigidbody.AddForce(diraction * _force, ForceMode.Impulse);
        Debug.Log("Выстрел");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();

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
