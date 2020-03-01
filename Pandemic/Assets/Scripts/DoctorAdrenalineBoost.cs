using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoctorAdrenalineBoost : UnlockableCooldownAbility
{
    [SerializeField] private DoctorController dc;
    [SerializeField] private DoctorSFX doctorSfx;

    private Animator anim;

    [SerializeField] private float speedAmp, duration;
    private float normalSpeed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        normalSpeed = dc.Speed;
    }

    public void AdrenalineBoost()
    {
        if (IsReady && Math.Abs(dc.Speed - normalSpeed) < 0.01f)
        {
            dc.Speed = dc.Speed * speedAmp;
            doctorSfx.PlaySFX(doctorSfx.DoctorAdrenalinBoost);
            StartCoroutine(BoostDuration(duration));
            ResetCooldown();
            anim.Play("Inject");
        }
    }

    private IEnumerator BoostDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dc.Speed = dc.Speed / speedAmp;
    }
}