using UnityEngine;

public class ItemHealth : Item
{
    [SerializeField] protected int _addHealthPoints;

    public override void ProcessPickupItem(Collector collector) => collector.AddHealth(_addHealthPoints);

}
