using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorTrap : MonoBehaviour
{
    [SerializeField] private float activationDistance;
    private float sqrActivationDistance;

    private Transform monsterTransform;

    private void Awake()
    {
        monsterTransform = GameObject.FindWithTag("Monster").transform;
        sqrActivationDistance = activationDistance * activationDistance;
    }

    private void Update()
    {
        if ((monsterTransform.position - transform.position).sqrMagnitude <= sqrActivationDistance)
        {
            Activate();
        }
    }

    private void Activate()
    {
        //monsterTransform
    }
}