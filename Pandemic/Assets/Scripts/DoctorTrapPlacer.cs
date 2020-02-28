﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RadialBarIndicator))]
public class DoctorTrapPlacer : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float availableTime;

    [SerializeField] private GameObject trap;

    public void TryPlaceTrap()
    {
        if (CanPlaceTrap())
        {
            PlaceTrap();
        }
    }

    private bool CanPlaceTrap()
    {
        return Time.time >= availableTime;
    }

    private void PlaceTrap()
    {
        DoctorTrap newTrap = Instantiate(trap, transform.position, Quaternion.identity).GetComponent<DoctorTrap>();
        newTrap.Setup(transform, GetComponent<RadialBarIndicator>());

        availableTime = Time.time + cooldown;
    }
}