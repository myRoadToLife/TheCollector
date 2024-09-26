using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected Collector _collector;

    private bool _isCollectorInTrigger = false;

    private Vector3 _offsetPositionToSetParent = new Vector3(0f, 0f, 1f);


    private void OnTriggerEnter(Collider other)
    {
        Collector collector = other.GetComponent<Collector>();

        if (collector != null)
        {
            _collector = collector;
            _isCollectorInTrigger = true;

            bool hasItem = false;

            foreach (Transform child in _collector.transform)
            {
                if (child.gameObject.GetComponent<Item>())
                {
                    hasItem = true;
                    //Debug.Log("Сборщик уже держит предмет: " + child.name);
                    break;
                }
            }

            if (hasItem == false)
            {
                transform.SetParent(_collector.transform);
                transform.localPosition = Vector3.forward + _offsetPositionToSetParent;

                //Debug.Log("Сборщик подобрал предмет: " + transform.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_collector != null && other.GetComponent<Collector>() == _collector)
        {
            _isCollectorInTrigger = false;
            _collector = null;
        }
    }

    private void Update()
    {
        if (_isCollectorInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (_collector != null)
            {
                ProcessPickupItem(_collector);
                Destroy(gameObject);
                _isCollectorInTrigger = false;
            }
        }
        else if(_isCollectorInTrigger == false && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("У сборщика ничего нет!");
        }
    }

    protected abstract void ProcessPickupItem(Collector collector);

}






