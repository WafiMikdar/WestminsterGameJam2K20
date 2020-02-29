using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensorPlacer : UnlockableCooldownAbility
{
    [SerializeField] private GameObject sensorPrefab;

    [SerializeField] private RadialBarIndicator directionalIndicator;

    [SerializeField] private DoctorSFX doctorSfx;

    public void TryActivate()
    {
        if (IsReady)
        {
            PlaceSensor();
            ResetCooldown();
        }
    }

    private void PlaceSensor()
    {
        MotionSensor sensor = Instantiate(sensorPrefab, transform.position, Quaternion.identity).GetComponent<MotionSensor>();
        sensor.Setup(transform, directionalIndicator);
        doctorSfx.PlaySFX(doctorSfx.DoctorMotionSensorSetup);
    }
}