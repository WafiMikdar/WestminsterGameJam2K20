using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class DoctorNewsBroadcast : SupplyDropAbility
{
    [SerializeField] private GameObject cameraGameObject;

    [SerializeField] private float duration = 5;

    [SerializeField] private uint usesLeft = 1;

    public override void TryActivate()
    {
        if (usesLeft > 0)
        {
            Activate();
            usesLeft--;
        }
    }

    public override void Activate()
    {
        cameraGameObject.SetActive(true);
        StartCoroutine(Duration(duration));
    }

    private IEnumerator Duration(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        cameraGameObject.SetActive(false);
    }
}