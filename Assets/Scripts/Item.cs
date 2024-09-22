using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Collector _collector;
    private bool _isCollectorInTrigger = false;


    private void OnTriggerStay(Collider other)
    {
        _collector = other.GetComponent<Collector>();

        if (_collector != null)
        {
            bool hasItem = false;

            foreach (Transform child in _collector.transform)
            {
                if (child.gameObject.GetComponent<Item>())
                {
                    hasItem = true;
                    Debug.Log("Сборщик уже держит предмет: " + child.name); 
                }
            }
            _isCollectorInTrigger = true;

            if (!hasItem && _isCollectorInTrigger)
            {
                transform.SetParent(_collector.transform);
                transform.localPosition = Vector3.forward;
                Debug.Log("Предмет подобран: " + transform.name);
            }
            
        }
    }


    private void Update()
    {
        if (_isCollectorInTrigger == true && Input.GetKeyDown(KeyCode.F))
        {
            ProcessPickupItem(_collector);
            Destroy(gameObject);
            _isCollectorInTrigger = false;
        }

    }


    protected abstract void ProcessPickupItem(Collector collector);
}






