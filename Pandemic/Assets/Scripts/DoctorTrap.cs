using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorTrap : MonoBehaviour
{
    [SerializeField] private float activationDistance, duration;
    private float sqrActivationDistance, monsterSpeedBackup;

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
        PlayerController monsterMovement = monsterTransform.GetComponent<PlayerController>();
        monsterSpeedBackup = monsterMovement.Speed;
        monsterMovement.Speed = 0;
    }

    private IEnumerator ResettingMonsterSpeed(PlayerController monsterMovement)
    {
        yield return new WaitForSeconds(duration);

        if (monsterMovement.Speed == 0)
        {
            monsterMovement.Speed = monsterSpeedBackup;
        }
    }
}