using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEcholocation : SupplyDropAbility
{
    [SerializeField] private RadialBarIndicator indicator;

    [SerializeField] private float indicatorVariance, indicatorDuration;

    [SerializeField] private Color indicatorColor;

    [SerializeField] private Transform doctorTransform;

    [SerializeField] private uint totalUses = 3;

    public override void TryActivate()
    {
        if (totalUses > 0)
        {
            Activate();
            totalUses--;
        }
    }

    public override void Activate()
    {
        indicator.SetIndicator(Mathf.Atan2(transform.position.y - doctorTransform.position.y, transform.position.x - doctorTransform.position.x) * Mathf.Rad2Deg - 90,
                               indicatorVariance, indicatorDuration, indicatorColor);
    }
}