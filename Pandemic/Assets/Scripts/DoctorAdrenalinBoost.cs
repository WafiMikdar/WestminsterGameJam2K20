using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoctorAdrenalinBoost : MonoBehaviour
{
    private void adrenalinBoost()
    {

    }

    private float secondsLeft = 0, speedAmp = 2;

    void Start() { StartCoroutine(boostDuration(5)); }

    IEnumerator boostDuration(float seconds)
    {
        secondsLeft = seconds;
        do { yield return new WaitForSeconds(1); }
        while (--secondsLeft > 1);
        DoctorControls.Speed.g * speedAmp;
        while (--secondsLeft < 1) ;
        // speed / speedAmp;
    }
}
