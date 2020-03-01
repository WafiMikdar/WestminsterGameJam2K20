using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSupplyDropAbilitySlotter : SupplyDropAbilitySlotter
{
    [SerializeField] private float supplyDropWaitTime;
    private float supplyDropPickUpReadyTime;

    protected override void PickUpSupplyDrop(SupplyDrop drop)
    {
        if (Time.time >= drop.SpawnTime + supplyDropWaitTime && Time.time >= supplyDropPickUpReadyTime)
        {
            base.PickUpSupplyDrop(drop);
        }
    }

    public override void TryActivate()
    {
        supplyDropPickUpReadyTime = Time.time + supplyDropWaitTime;
        base.TryActivate();
    }
}