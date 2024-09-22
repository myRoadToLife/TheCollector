using UnityEngine;

public class ItemHealth : Item
{
    [SerializeField] protected int _addHealthPoints;

    protected override void ProcessPickupItem(Collector collector) => collector.AddHealth(_addHealthPoints);
  
}
