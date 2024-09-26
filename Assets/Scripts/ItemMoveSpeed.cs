using UnityEngine;

public class ItemMoveSpeed : Item
{
    [SerializeField] protected float _addSpeed;

    public override void ProcessPickupItem(Collector collector) => collector.AddSpeedToMove(_addSpeed);

}
