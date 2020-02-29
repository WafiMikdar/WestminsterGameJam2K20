using System;
using System.Collections;
using UnityEngine;

public class DoctorAdrenalineBoost : UnlockableCooldownAbility
{
    [SerializeField] private DoctorController dc;
    [SerializeField] private float speedAmp, duration, normalSpeed;
    [SerializeField] private DoctorSFX doctorSfx;

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