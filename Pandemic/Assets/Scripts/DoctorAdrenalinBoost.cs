using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoctorAdrenalinBoost : MonoBehaviour
{
    [SerializeField] private DoctorControls dc;
    [SerializeField] private float speedAmp = 2;

    public void AdrenalinBoost()
    {
        dc.Speed = dc.Speed * speedAmp;
        StartCoroutine(BoostDuration(5));
    }

    IEnumerator BoostDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        dc.Speed = dc.Speed / speedAmp;
    }
}
