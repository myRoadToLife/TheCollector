using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private float _xInput;
    private float _yInput;

    private Item _item;
    private CharacterController _characterController;

    private bool _isCollectorInTrigger = false;

    private Vector3 _offsetPositionToSetParent = new Vector3(0f, 0f, 1.5f);

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Item itemInTrigger = other.GetComponent<Item>();

        if (itemInTrigger != null && _item == null)
        {
            _item = itemInTrigger;
            _isCollectorInTrigger = true;

            bool hasItem = false;

            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<Item>())
                {
                    hasItem = true;
                    Debug.Log("Сборщик уже держит предмет: " + child.name);
                    break;
                }
            }

            if (hasItem == false)
            {
                _item.transform.SetParent(transform);
                _item.transform.localPosition = _offsetPositionToSetParent;
                Debug.Log("Сборщик подобрал предмет: " + _item.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_item != null && other.GetComponent<Item>() == _item)
        {
            _isCollectorInTrigger = false;
            _item = null;
        }
    }

    private void Update()
    {
        Vector3 direction = UserInput();
        MovementAndRotation(direction);

        InspectionUsePickup();
    }

    private Vector3 UserInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");

        return new Vector3(_xInput, 0f, _yInput).normalized;
    }

    private void InspectionUsePickup()
    {
        if (_isCollectorInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (_item != null)
            {
                _item.ProcessPickupItem(this);
                _item.DestroyItemWithParticles();
                _item = null;
                _isCollectorInTrigger = false;
            }
        }
        else if (_isCollectorInTrigger == false && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("У сборщика ничего нет!");
        }
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
