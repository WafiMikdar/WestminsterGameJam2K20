using System;
using System.Collections;
using UnityEngine;

public class DoctorAdrenalineBoost : UnlockableCooldownAbility
{
    [SerializeField] private DoctorController dc;
    [SerializeField] private DoctorSFX doctorSfx;

    [SerializeField] private float speedAmp, duration;
    private float normalSpeed;

    private void Awake()
    {
        normalSpeed = dc.Speed;
    }

    public void AdrenalinBoost()
    {
        if (IsReady && Math.Abs(dc.Speed - normalSpeed) < 0.01f)
        {
            dc.Speed = dc.Speed * speedAmp;
            doctorSfx.PlaySFX(doctorSfx.DoctorAdrenalinBoost);
            StartCoroutine(BoostDuration(duration));
            ResetCooldown();
        }
    }

    private IEnumerator BoostDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dc.Speed = dc.Speed / speedAmp;
    }
}