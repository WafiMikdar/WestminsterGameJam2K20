using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DoctorAdrenalinBoost : MonoBehaviour
{
    private DoctorControls dc;
    private float secondsLeft = 0, speedAmp = 2;
    private int count = 0;


    public void adrenalinBoost()
    {
        dc.Speed = dc.Speed * speedAmp;
        StartCoroutine(boostDuration(5));           
    }

    IEnumerator boostDuration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        revertSpeed();
    }

    void revertSpeed()
    {
        dc.Speed = dc.Speed / speedAmp;
    }
}
