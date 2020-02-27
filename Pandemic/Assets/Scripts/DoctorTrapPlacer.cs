using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorTrapPlacer : MonoBehaviour
{
    [SerializeField] private float cooldown;
    private float availableTime;

    [SerializeField] private GameObject trap;

    private void Update()
    {
        if (CanPlaceTrap())
        {
            PlaceTrap();
        }
    }

    private bool CanPlaceTrap()
    {
        return Input.GetKeyDown(KeyCode.T) &&
               Time.time >= availableTime;
    }

    private void PlaceTrap()
    {
        Instantiate(trap, transform.position, Quaternion.identity);
        availableTime = Time.time + cooldown;
    }
}