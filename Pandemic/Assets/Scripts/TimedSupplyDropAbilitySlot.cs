using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSupplyDropAbilitySlot : SupplyDropAbilitySlot
{
    [SerializeField] private float supplyDropWaitTime;

    protected override void PickUpSupplyDrop(SupplyDrop drop)
    {
        if (Time.time >= drop.SpawnTime + supplyDropWaitTime)
        {
            base.PickUpSupplyDrop(drop);
        }
    }
}