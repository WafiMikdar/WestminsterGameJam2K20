using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensorPlacer : MonoBehaviour
{
    [SerializeField] private GameObject sensorPrefab;

    private uint remainingSensors = 3;

    public void TryPlaceSensor()
    {
        if (remainingSensors > 0)
        {
            PlaceSensor();
        }
    }

    private void PlaceSensor()
    {
        MotionSensor sensor = Instantiate(sensorPrefab, transform.position, Quaternion.identity).GetComponent<MotionSensor>();
        sensor.Setup(transform, GetComponent<RadialBarIndicator>());
        remainingSensors--;
    }
}