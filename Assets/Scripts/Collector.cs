using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private CharacterController _characterController;

    private float _xInput;
    private float _yInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 direction = UserInput();

        MovementAndRotation(direction);

    }

    private void MovementAndRotation(Vector3 direction)
    {
        if (direction.magnitude >= 0.01f)
        {
            _characterController.Move(direction * (_moveSpeed * Time.deltaTime));

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private Vector3 UserInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(_xInput, 0f, _yInput).normalized;

        return direction;
    }

    public void AddHealth(int health)
    {
        if (health < 0)
        {
            Debug.LogError("Health < 0");
            return;
        }

        _health += health;

        Debug.Log($"Твоё здоровье: {_health}");
    }

    public void AddSpeedToMove(float speed)
    {
        if (speed < 0)
        {
            Debug.LogError("Speed < 0");
            return;
        }

        _moveSpeed += speed;

        Debug.Log($"Твоя скорость: {_moveSpeed}");
    }

}
