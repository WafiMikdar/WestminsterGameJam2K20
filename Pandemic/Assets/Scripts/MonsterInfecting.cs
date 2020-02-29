using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterInfecting : MonoBehaviour
{
    [SerializeField] private float infectionRange, lethalInfectionCooldown;
    [SerializeField] private MonsterSfx monsterSfx;
    private float lethalInfectionReadyTime;

    private Experience experience;

    private void Awake()
    {
        experience = GetComponent<Experience>();
    }

    public void TryInfect()
    {
        monsterSfx.PlaySFX(monsterSfx.MonsterInject);
        Infect();
    }

    public void TryLethalInfect()
    {
        if (Time.time >= lethalInfectionReadyTime)
        {
            monsterSfx.PlaySFX(monsterSfx.MonsterLethalInjection);
            LethalInfect();
        }
    }

    private void LethalInfect()
    {
        ForEachNearbyInfectable(infectable => infectable.Infect(experience, 0));
    }

    private void Infect()
    {
        //Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, infectionRange);

        //foreach (Collider2D hit in hits)
        //{
        //    hit.GetComponent<IInfectable>()?.Infect(experience);
        //}

        ForEachNearbyInfectable(infectable => infectable.Infect(experience));
    }

    private void ForEachNearbyInfectable(Action<IInfectable> func)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, infectionRange);

        foreach (Collider2D hit in hits)
        {
            IInfectable infectable = hit.GetComponent<IInfectable>();
            if (infectable != null)
            {
                func(infectable);
            }
        }
    }
}