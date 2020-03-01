using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RadialBarIndicator))]
public class DoctorTrapPlacer : UnlockableCooldownAbility
{
    [SerializeField] private DoctorSFX doctorSfx;

    [SerializeField] private GameObject trap;

    private void Awake()
    {
        Unlock();
    }

    public void TryPlaceTrap()
    {
        if (IsReady)
        {
            doctorSfx.PlaySFX(doctorSfx.DoctorTrapSetUp);
            PlaceTrap();
            ResetCooldown();
        }
    }

    private void PlaceTrap()
    {
        DoctorTrap newTrap = Instantiate(trap, transform.position, Quaternion.identity).GetComponent<DoctorTrap>();
        newTrap.Setup(transform, GetComponent<RadialBarIndicator>());
    }
}