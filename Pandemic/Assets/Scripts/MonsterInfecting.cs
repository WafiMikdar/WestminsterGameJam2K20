using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Experience))]
public class MonsterInfecting : UnlockableCooldownAbility
{
    [SerializeField] private float infectionRange;
    [SerializeField] private MonsterSfx monsterSfx;

    [SerializeField] protected ParticleSystem infectionParticles;

    protected Experience experience;

    private void Awake()
    {
        experience = GetComponent<Experience>();
    }

    public void TryInfect()
    {
        if (IsReady)
        {
            monsterSfx.PlaySFX(monsterSfx.MonsterInject);
            Infect();
            ResetCooldown();
        }
    }

    protected virtual void Infect()
    {
        infectionParticles.Play(true);
        ForEachNearbyInfectable(infectable => infectable.Infect(experience));
    }

    protected void ForEachNearbyInfectable(Action<IInfectable> func)
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