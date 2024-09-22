using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField]private float _frecuency;
    [SerializeField]private float _phase; // должно быть рандомное число

    private Vector3 _defaultPosition;
    private float _time;

    private void Awake()
    {
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        _time += Time.deltaTime * 5;
        transform.position = _defaultPosition + Vector3.up * _amplitude * Mathf.Sin(_time * _frecuency + _phase);
    }
}
