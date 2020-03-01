using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RadialBarIndicator), typeof(Animator))]
public class DoctorTrapPlacer : UnlockableCooldownAbility
{
    [SerializeField] private DoctorSFX doctorSfx;

    [SerializeField] private GameObject trap;

    private Animator anim;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        Unlock();
    }

    public void TryPlaceTrap()
    {
        if (IsReady)
        {
            doctorSfx.PlaySFX(doctorSfx.DoctorTrapSetUp);
            PlaceTrap();
            ResetCooldown();
            
            anim.Play("Cure");
        }
    }

    private void PlaceTrap()
    {
        DoctorTrap newTrap = Instantiate(trap, transform.position, Quaternion.identity).GetComponent<DoctorTrap>();
        newTrap.Setup(transform, GetComponent<RadialBarIndicator>());
    }
}