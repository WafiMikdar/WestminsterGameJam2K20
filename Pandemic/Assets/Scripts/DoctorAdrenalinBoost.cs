using System.Collections;
using UnityEngine;

public class DoctorAdrenalinBoost : MonoBehaviour
{
    [SerializeField] private DoctorController dc;
    [SerializeField] private float speedAmp, seconds;
    [SerializeField] private DoctorSFX doctorSfx;
    //[SerializeField] private DoctorSFX doctorSfx;

    public void AdrenalinBoost()
    {
        if (dc.Speed == 5.0f)
        {
            dc.Speed = dc.Speed * speedAmp;
            doctorSfx.PlaySFX(doctorSfx.DoctorAdrenalinBoost);
            StartCoroutine(BoostDuration(seconds));
        }

        //doctorSfx.PlaySFX(doctorSfx.DoctorAdrenalinBoost);
        StartCoroutine(BoostDuration(seconds));
    }

    private IEnumerator BoostDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dc.Speed = dc.Speed / speedAmp;
    }
}