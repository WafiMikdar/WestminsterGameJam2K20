using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorTrap : MonoBehaviour
{
    [SerializeField] private float activationDistance, debuffDuration, indicatorVariation;
    private float sqrActivationDistance, monsterSpeedBackup;

    private Transform monsterTransform, doctorTransform;

    private RadialBarIndicator indicator;

    private bool activated;

    private void Awake()
    {
        monsterTransform = GameObject.FindWithTag("Monster").transform;
        sqrActivationDistance = activationDistance * activationDistance;
    }

    public void Setup(Transform docTrans, RadialBarIndicator indicator)
    {
        doctorTransform = docTrans;
        this.indicator = indicator;
    }

    private void Update()
    {
        if ((monsterTransform.position - transform.position).sqrMagnitude <= sqrActivationDistance && !activated)
        {
            Activate();
        }
    }

    private void Activate()
    {
        activated = true;
        MonsterController monsterMovement = monsterTransform.GetComponent<MonsterController>();
        monsterSpeedBackup = monsterMovement.Speed;
        monsterMovement.Speed = 0;
        StartCoroutine(ResettingMonsterSpeed(monsterMovement));
        indicator.SetIndicator(Mathf.Atan2(doctorTransform.position.y - monsterTransform.position.y, doctorTransform.position.x - monsterTransform.position.x) * Mathf.Rad2Deg - 90, indicatorVariation);
        Explode();
    }

    private void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private IEnumerator ResettingMonsterSpeed(MonsterController monsterMovement)
    {
        yield return new WaitForSeconds(debuffDuration);

        if (Math.Abs(monsterMovement.Speed) < 0.01f)
        {
            monsterMovement.Speed = monsterSpeedBackup;
        }

        Destroy(gameObject);
    }
}