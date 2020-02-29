using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensorPlacer : SupplyDropAbility
{
    [SerializeField] private GameObject sensorPrefab;

    [SerializeField] private RadialBarIndicator directionalIndicator;

    [SerializeField] private uint totalUses = 3;

    public override void TryActivate()
    {
        if (totalUses > 0)
        {
            PlaceSensor();
        }
    }

    private void PlaceSensor()
    {
        MotionSensor sensor = Instantiate(sensorPrefab, transform.position, Quaternion.identity).GetComponent<MotionSensor>();
        sensor.Setup(transform, directionalIndicator);
        totalUses--;
    }

    public override void Activate()
    {
        PlaceSensor();
    }
}