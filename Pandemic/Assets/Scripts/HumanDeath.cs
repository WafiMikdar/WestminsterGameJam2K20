using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour, ICallOnDestroy
{
    private Action onDeath;

    public void SetupCallOnDestroy(Action toCall)
    {
        onDeath += toCall;
    }

    private void OnDestroy()
    {
        onDeath?.Invoke();
    }
}