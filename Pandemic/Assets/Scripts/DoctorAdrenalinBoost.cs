using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoctorAdrenalinBoost : MonoBehaviour
{
    [SerializeField] private DoctorController dc;
    [SerializeField] private float speedAmp, seconds;

    public void AdrenalinBoost()
    {
        dc.Speed = dc.Speed * speedAmp;
        StartCoroutine(BoostDuration(seconds));
    }

    IEnumerator BoostDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dc.Speed = dc.Speed / speedAmp;
    }
}
