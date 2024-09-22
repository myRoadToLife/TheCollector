using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private List<PointSpawn> _spawnPoints;
    [SerializeField] private List<Item> _itemPrefabs;
    [SerializeField] private float _cooldown;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            List<PointSpawn> emptyPoints = GetEmptyPoints();


            if (emptyPoints.Count == 0)
            {
                _time = 0;
                return;
            }

            PointSpawn spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

            Item itemInstance = Instantiate(_itemPrefabs[Random.Range(0, _itemPrefabs.Count)], spawnPoint.Position, Quaternion.identity);

            spawnPoint.Occupy(itemInstance);

            _time = 0;
        }
    }

    private List<PointSpawn> GetEmptyPoints()
    {
        List<PointSpawn> emptyPoints = new List<PointSpawn>();

        foreach (PointSpawn spawnPoint in _spawnPoints)
        {
            if (spawnPoint.IsEmpty)
                emptyPoints.Add(spawnPoint);
        }

        return emptyPoints;
    }
}
